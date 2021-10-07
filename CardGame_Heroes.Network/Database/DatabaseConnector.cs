using MySql.Data.MySqlClient;

namespace CardGame_Heroes.Network.Database
{
    public static class DatabaseConnector
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "192.168.1.38";
            int port = 3306;
            string database = "berserkserverdatabase";
            string username = "admin";
            string password = "S162E35030547";

            MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new()
            {
                Database = database,
                Server = host,
                Port = Convert.ToUInt32(port),
                UserID = username,
                Password = password
            };

            MySqlConnection MySqlConnectionBase = new(mySqlConnectionStringBuilder.ToString());

            return MySqlConnectionBase;
        }
    }
}
