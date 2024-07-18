using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookStoreApp.Data
{
    class Connection
    {
        private static MySqlConnection conn;

        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string Uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";

        public static MySqlConnection DataSource()
        {
            string connectionString = $"server={server};database={database};Uid={Uid};password={password};";
            conn = new MySqlConnection(connectionString);
            return conn;
        }

        public void ConnOpen()
        {
            try
            {
                conn = DataSource();
                conn.Open();
                Console.WriteLine("Connection opened successfully.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }
        }

        public void ConnClose()
        {
            try
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine("Connection closed successfully.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }
        }
    }
}
