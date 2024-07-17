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
        public static MySqlConnection conn = new MySqlConnection();

        static string server = "sql8.freesqldatabase.com;";
        static string database = "sql8720437;";
        static string Uid = "sql8720437;";
        static string password = "SWBRJQR7PI;";

        public static MySqlConnection dataSource()
        {
            conn = new MySqlConnection($"server={server} database={database} Uid={Uid} password={password}");
            return conn;
        }

        public void connOpen()
        {
            dataSource();
            conn.Open();
        }

        public void connClose()
        {
            dataSource();
            conn.Close();
        }
    }
}
