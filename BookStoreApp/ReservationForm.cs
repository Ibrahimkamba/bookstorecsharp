using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public partial class ReservationForm : Form
    {
        private string bookId;
        private string userId; // Assuming you have a way to get the user ID

        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string Uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";
        private static readonly string connectionString = $"server={server};database={database};Uid={Uid};password={password};";

        public ReservationForm(string bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            this.userId = SessionManager.Instance.CurrentCustomerId;
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            int quantity = (int)numericUpDownQuantity.Value;

            // Update the reservation record and stock
            UpdateReservationRecord(userId, bookId, quantity);
            UpdateBookStock(bookId, quantity);

            // Display reservation summary
            ShowReservationSummary();
        }

        private void UpdateReservationRecord(string userId, string bookId, int quantity)
        {
            // Create or update the reservation record
            string query = @"
                INSERT INTO Reservation (R_C_ID, R_C_NAME, R_B_ID, R_B_TITLE, R_B_QUANTITY)
                VALUES ((SELECT C_ID FROM Customers WHERE C_ID = @UserId), (SELECT C_NAME FROM Customers WHERE C_ID = @UserId), @BookId, 
                (SELECT B_TITLE FROM Books WHERE B_ID = @BookId), @Quantity)
                ON DUPLICATE KEY UPDATE R_B_QUANTITY = R_B_QUANTITY + @Quantity";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateBookStock(string bookId, int quantity)
        {
            // Update the book stock
            string query = "UPDATE Books SET B_STOCK = B_STOCK - @Quantity WHERE B_ID = @BookId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the book stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowReservationSummary()
        {
            // Create and show a summary form
            ReservationSummaryForm summaryForm = new ReservationSummaryForm();
            summaryForm.ShowDialog();
        }
    }
}
