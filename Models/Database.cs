using MySqlConnector;

namespace IkiminaManager.Models
{
    public static class Database
    {
        // Address and login of the MariaDB server that XAMPP runs
        public const string ConnectionString =
            "Server=127.0.0.1;Port=3306;Database=IkiminaDB;User ID=root;Password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}