using System;
using System.Data;
using MySqlConnector;

namespace IkiminaManager.Models
{
    // All SQL for the Loans and Repayments tables lives here
    public class LoanRepository
    {
        // Cash in the fund: contributions + repayments - loans paid out
        public long GetAvailableFund()
        {
            string sql = @"SELECT (SELECT IFNULL(SUM(Amount), 0) FROM Contributions)
                                + (SELECT IFNULL(SUM(Amount), 0) FROM Repayments)
                                - (SELECT IFNULL(SUM(Principal), 0) FROM Loans)";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                con.Open();
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }

        // Active loans with what is still owed on each. LEFT JOIN keeps loans that have no repayment yet.
        public DataTable GetActiveLoans()
        {
            string sql = @"SELECT l.LoanID,
                                  CONCAT('M', LPAD(m.MemberID, 3, '0'), ' - ', m.FullName) AS Member,
                                  l.Principal,
                                  l.TotalRepayable,
                                  l.TotalRepayable - IFNULL(SUM(r.Amount), 0) AS Outstanding,
                                  l.DueDate
                           FROM Loans l
                           JOIN Members m ON m.MemberID = l.MemberID
                           LEFT JOIN Repayments r ON r.LoanID = l.LoanID
                           WHERE l.Status = 'Active'
                           GROUP BY l.LoanID, m.MemberID, m.FullName, l.Principal, l.TotalRepayable, l.DueDate
                           ORDER BY l.DueDate, l.LoanID";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        // Active loans whose due date is before today and that still owe money
        public DataTable GetOverdueLoans(DateTime today)
        {
            string sql = @"SELECT l.LoanID,
                                  CONCAT('M', LPAD(m.MemberID, 3, '0'), ' - ', m.FullName) AS Member,
                                  l.TotalRepayable - IFNULL(SUM(r.Amount), 0) AS Outstanding,
                                  l.DueDate,
                                  DATEDIFF(@today, l.DueDate) AS DaysOverdue
                           FROM Loans l
                           JOIN Members m ON m.MemberID = l.MemberID
                           LEFT JOIN Repayments r ON r.LoanID = l.LoanID
                           WHERE l.Status = 'Active' AND l.DueDate < @today
                           GROUP BY l.LoanID, m.MemberID, m.FullName, l.TotalRepayable, l.DueDate
                           HAVING Outstanding > 0
                           ORDER BY l.DueDate, l.LoanID";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@today", MySqlDbType.Date).Value = today.Date;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public bool HasActiveLoan(int memberID)
        {
            string sql = "SELECT COUNT(*) FROM Loans WHERE MemberID = @id AND Status = 'Active'";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberID;
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public void Insert(Loan loan)
        {
            string sql = @"INSERT INTO Loans (MemberID, Principal, TermMonths, Interest, TotalRepayable, IssueDate, DueDate, Status)
                           VALUES (@member, @principal, @term, @interest, @total, @issue, @due, @status)";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@member", MySqlDbType.Int32).Value = loan.MemberID;
                cmd.Parameters.Add("@principal", MySqlDbType.Int32).Value = loan.Principal;
                cmd.Parameters.Add("@term", MySqlDbType.Int32).Value = loan.TermMonths;
                cmd.Parameters.Add("@interest", MySqlDbType.Int32).Value = loan.Interest;
                cmd.Parameters.Add("@total", MySqlDbType.Int32).Value = loan.TotalRepayable;
                cmd.Parameters.Add("@issue", MySqlDbType.Date).Value = loan.IssueDate.Date;
                cmd.Parameters.Add("@due", MySqlDbType.Date).Value = loan.DueDate.Date;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar, 10).Value = loan.Status;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // What is still owed on one loan. Returns -1 when the loan does not exist.
        public long GetOutstanding(int loanID)
        {
            string sql = @"SELECT l.TotalRepayable - IFNULL((SELECT SUM(Amount) FROM Repayments WHERE LoanID = l.LoanID), 0)
                           FROM Loans l
                           WHERE l.LoanID = @id";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = loanID;
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    return -1;
                }

                return Convert.ToInt64(result);
            }
        }

        // Saves the repayment, then marks the loan Paid if the repayments now cover the total repayable
        public void AddRepayment(int loanID, int amount, DateTime date)
        {
            string insertSql = "INSERT INTO Repayments (LoanID, Amount, RepaymentDate) VALUES (@loan, @amount, @date)";
            string closeSql = @"UPDATE Loans SET Status = 'Paid'
                                WHERE LoanID = @loan
                                AND TotalRepayable <= (SELECT SUM(Amount) FROM Repayments WHERE LoanID = @loan)";

            using (MySqlConnection con = Database.GetConnection())
            {
                con.Open();

                using (MySqlCommand insert = new MySqlCommand(insertSql, con))
                {
                    insert.Parameters.Add("@loan", MySqlDbType.Int32).Value = loanID;
                    insert.Parameters.Add("@amount", MySqlDbType.Int32).Value = amount;
                    insert.Parameters.Add("@date", MySqlDbType.Date).Value = date.Date;
                    insert.ExecuteNonQuery();
                }

                using (MySqlCommand close = new MySqlCommand(closeSql, con))
                {
                    close.Parameters.Add("@loan", MySqlDbType.Int32).Value = loanID;
                    close.ExecuteNonQuery();
                }
            }
        }
    }
}