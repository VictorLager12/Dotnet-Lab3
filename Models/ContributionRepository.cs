using System;
using System.Data;
using MySqlConnector;

namespace IkiminaManager.Models
{
    // All SQL for the Contributions table lives here
    public class ContributionRepository
    {
        // Every contribution with the member's code and name, newest first
        public DataTable GetAll()
        {
            string sql = @"SELECT c.ContributionID,
                                  c.ContributionDate,
                                  CONCAT('M', LPAD(m.MemberID, 3, '0'), ' - ', m.FullName) AS Member,
                                  c.Amount
                           FROM Contributions c
                           JOIN Members m ON m.MemberID = c.MemberID
                           ORDER BY c.ContributionDate DESC, c.ContributionID DESC";

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

        public void Insert(Contribution contribution)
        {
            string sql = @"INSERT INTO Contributions (MemberID, Amount, ContributionDate)
                           VALUES (@member, @amount, @date)";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@member", MySqlDbType.Int32).Value = contribution.MemberID;
                cmd.Parameters.Add("@amount", MySqlDbType.Int32).Value = contribution.Amount;
                cmd.Parameters.Add("@date", MySqlDbType.Date).Value = contribution.ContributionDate.Date;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Total contributed by one member. IFNULL gives 0 when the member has no contributions yet.
        public long GetMemberTotal(int memberID)
        {
            string sql = "SELECT IFNULL(SUM(Amount), 0) FROM Contributions WHERE MemberID = @id";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberID;
                con.Open();
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }

        // Total contributed by the whole group
        public long GetGroupTotal()
        {
            string sql = "SELECT IFNULL(SUM(Amount), 0) FROM Contributions";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                con.Open();
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }
    }
}