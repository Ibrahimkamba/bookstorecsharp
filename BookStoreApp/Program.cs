using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
            string database = "bkbxqvr3u99gdowtsu8c";
            string Uid = "u5dmf8qxsxlp6sca";
            string password = "iMsCpRUikhByXlmWSQnb";
            // Connection string to your MySQL database
            string connectionString = $"server={server};database={database};Uid={Uid};password={password};";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Define your table creation scripts
            string[] tableCreationScripts = new string[]
            {
                @"
                CREATE TABLE IF NOT EXISTS Books (
                    B_ID INT AUTO_INCREMENT PRIMARY KEY,
                    B_TITLE VARCHAR(255) NOT NULL,
                    B_A_ID INT NOT NULL,
                    B_PUBLISHER VARCHAR(255),
                    B_PUB_DATE DATE,
                    B_SUBJECT VARCHAR(255),
                    B_UNIT_PRIZE DECIMAL(10, 2),
                    B_STOCK INT,
                    FOREIGN KEY (B_A_ID) REFERENCES Author(A_ID)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Author (
                    A_ID INT AUTO_INCREMENT PRIMARY KEY,
                    A_FNAME VARCHAR(255) NOT NULL,
                    A_LNAME VARCHAR(255) NOT NULL
                );",
                @"
                CREATE TABLE IF NOT EXISTS Customers (
                    C_ID INT AUTO_INCREMENT PRIMARY KEY,
                    C_NAME VARCHAR(255) NOT NULL,
                    C_ADD VARCHAR(255)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Reservation (
                    R_ID INT AUTO_INCREMENT PRIMARY KEY,
                    R_C_ID INT NOT NULL,
                    R_C_NAME VARCHAR(255),
                    R_B_ID INT NOT NULL,
                    R_B_TITLE VARCHAR(255),
                    R_B_QUANTITY INT,
                    FOREIGN KEY (R_C_ID) REFERENCES Customers(C_ID),
                    FOREIGN KEY (R_B_ID) REFERENCES Books(B_ID)
                );"
            };

            // Define your data seeding scripts
            string[] dataSeedingScripts = new string[]
            {
                @"
                INSERT INTO Author (A_FNAME, A_LNAME) VALUES
                ('John', 'Doe'),
                ('Jane', 'Smith');",
                @"
                INSERT INTO Books (B_TITLE, B_A_ID, B_PUBLISHER, B_PUB_DATE, B_SUBJECT, B_UNIT_PRIZE, B_STOCK) VALUES
                ('C# Programming Basics', 1, 'TechBooks Publishing', '2024-01-15', 'Programming', 29.99, 100),
                ('Advanced SQL Techniques', 2, 'DataBooks Publishing', '2023-11-05', 'Database', 39.99, 50);",
                @"
                INSERT INTO Customers (C_NAME, C_ADD) VALUES
                ('Alice Johnson', '123 Maple St, Springfield'),
                ('Bob Brown', '456 Oak St, Springfield');",
                @"
                INSERT INTO Reservation (R_C_ID, R_C_NAME, R_B_ID, R_B_TITLE, R_B_QUANTITY) VALUES
                (1, 'Alice Johnson', 1, 'C# Programming Basics', 1),
                (2, 'Bob Brown', 2, 'Advanced SQL Techniques', 2);"
            };

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Database connection established successfully.");

                    foreach (var script in tableCreationScripts)
                    {
                        try
                        {
                            using (MySqlCommand command = new MySqlCommand(script, connection))
                            {
                                command.ExecuteNonQuery();
                                Console.WriteLine("Executed script successfully.");
                            }
                        }
                        catch (MySqlException sqlEx)
                        {
                            Console.WriteLine("MySQL Error: " + sqlEx.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("General Error: " + ex.Message);
                        }
                    }

                    // Execute data seeding scripts
                    foreach (var script in dataSeedingScripts)
                    {
                        try
                        {
                            using (MySqlCommand command = new MySqlCommand(script, connection))
                            {
                                command.ExecuteNonQuery();
                                Console.WriteLine("Executed data seeding script.");
                            }
                        }
                        catch (MySqlException sqlEx)
                        {
                            Console.WriteLine("MySQL Error during data seeding: " + sqlEx.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("General Error during data seeding: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
            }

            Application.Run(new HomeForm());
        }
    }
}
