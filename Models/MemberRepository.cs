using System;
using System.Data;
using MySqlConnector;

namespace IkiminaManager.Models
{
    // All SQL for the Members table lives here. Nothing else in the project talks to the database about members.
    public class MemberRepository
    {
        // Returns members whose name or phone contains the keyword. An empty keyword returns everyone.
        public DataTable Search(string keyword)
        {
            string sql = @"SELECT MemberID,
                                  CONCAT('M', LPAD(MemberID, 3, '0')) AS MemberCode,
                                  FullName,
                                  Phone
                           FROM Members
                           WHERE FullName LIKE @key OR Phone LIKE @key
                           ORDER BY MemberID";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@key", MySqlDbType.VarChar, 150).Value = "%" + keyword + "%";
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public void Insert(Member member)
        {
            string sql = "INSERT INTO Members (FullName, Phone) VALUES (@name, @phone)";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = member.FullName;
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 10).Value = member.Phone;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Member member)
        {
            string sql = "UPDATE Members SET FullName = @name, Phone = @phone WHERE MemberID = @id";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = member.FullName;
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 10).Value = member.Phone;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = member.MemberID;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int memberID)
        {
            string sql = "DELETE FROM Members WHERE MemberID = @id";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberID;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // True if another member (not excludeMemberID) already uses this phone number
        public bool PhoneExists(string phone, int excludeMemberID)
        {
            string sql = "SELECT COUNT(*) FROM Members WHERE Phone = @phone AND MemberID <> @id";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 10).Value = phone;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = excludeMemberID;
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // True if the member has any contribution or loan, which means they must not be removed
        public bool HasRecords(int memberID)
        {
            string sql = @"SELECT (SELECT COUNT(*) FROM Contributions WHERE MemberID = @id)
                                + (SELECT COUNT(*) FROM Loans WHERE MemberID = @id)";

            using (MySqlConnection con = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberID;
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}