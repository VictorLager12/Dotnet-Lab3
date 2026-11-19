using System;
using System.Data;
using MySqlConnector;

namespace IkiminaManager.Models
{
    // SQL for the fund summary and the member statement
    public class ReportRepository
    {
        // The three totals the fund summary is built from. The Available Fund is worked out by the controller.
        public FundSummary GetFundTotals()
        {
            string sql = @"SELECT (SELECT IFNULL(SUM(Amount), 0) FROM Contributions) AS TotalContributions,
                                  (SELECT IFNULL(SUM(Principal), 0) FROM Loans) AS TotalLoans,
                                  (SELECT IFNULL(SUM(Amount), 0) FROM Repayments) AS TotalRepayments";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);

                    FundSummary summary = new FundSummary();
                    summary.TotalContributions = Convert.ToInt64(table.Rows[0]["TotalContributions"]);
                    summary.TotalLoansDisbursed = Convert.ToInt64(table.Rows[0]["TotalLoans"]);
                    summary.TotalRepayments = Convert.ToInt64(table.Rows[0]["TotalRepayments"]);
                    return summary;
                }
            }
        }

        // Builds one member's statement from three small queries on the same connection
        public MemberStatement GetMemberStatement(int memberID)
        {
            MemberStatement statement = new MemberStatement();

            using (MySqlConnection con = Database.GetConnection())
            {
                con.Open();

                // 1. The member's name (stays empty if the member does not exist)
                using (MySqlCommand cmd = new MySqlCommand("SELECT FullName FROM Members WHERE MemberID = @id", con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberID;
                    object name = cmd.ExecuteScalar();

                    if (name != null && name != DBNull.Value)
                    {
                        statement.FullName = Convert.ToString(name);
                    }
                }

                // 2. How many contributions the member made and their total
                string contributionSql = @"SELECT COUNT(*) AS HowMany, IFNULL(SUM(Amount), 0) AS Total
                                           FROM Contributions WHERE MemberID = @id";

                using (MySqlCommand cmd = new MySqlCommand(contributionSql, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberID;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        statement.ContributionCount = Convert.ToInt32(table.Rows[0]["HowMany"]);
                        statement.ContributionTotal = Convert.ToInt64(table.Rows[0]["Total"]);
                    }
                }

                // 3. The most recent loan with what is still owed on it. No row means the member never borrowed.
                string loanSql = @"SELECT l.Principal,
                                          l.DueDate,
                                          l.Status,
                                          l.TotalRepayable - IFNULL(SUM(r.Amount), 0) AS Outstanding
                                   FROM Loans l
                                   LEFT JOIN Repayments r ON r.LoanID = l.LoanID
                                   WHERE l.MemberID = @id
                                   GROUP BY l.LoanID, l.Principal, l.DueDate, l.Status, l.TotalRepayable
                                   ORDER BY l.LoanID DESC
                                   LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(loanSql, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberID;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);

                        if (table.Rows.Count > 0)
                        {
                            statement.HasLoan = true;
                            statement.LoanPrincipal = Convert.ToInt32(table.Rows[0]["Principal"]);
                            statement.LoanDueDate = Convert.ToDateTime(table.Rows[0]["DueDate"]);
                            statement.LoanStatus = Convert.ToString(table.Rows[0]["Status"]);
                            statement.LoanOutstanding = Convert.ToInt64(table.Rows[0]["Outstanding"]);
                        }
                    }
                }
            }

            return statement;
        }
    }
}