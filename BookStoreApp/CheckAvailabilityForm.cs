using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public partial class CheckAvailabilityForm : Form
    {
        private string bookId;
        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string Uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";

        public CheckAvailabilityForm(string bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            CheckStock();
        }

        private void CheckStock()
        {
            // Assume you have a method to get the available stock from a database
            int availableStock = GetAvailableStock(bookId);

            // Display the available stock
            availableStockLabel.Text = availableStock.ToString();
        }

        private int GetAvailableStock(string bookId)
        {
            int stock = 0;
            string connectionString = $"server={server};database={database};Uid={Uid};password={password};";
            string query = "SELECT B_STOCK FROM Books WHERE B_ID = @BookId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookId);

                try
                {
                    connection.Open();
                    stock = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return stock;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Reservation form
            ReservationForm reservationForm = new ReservationForm(bookId);
            reservationForm.ShowDialog();
        }
    }
}
