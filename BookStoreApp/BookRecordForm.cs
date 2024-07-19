using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public partial class BookRecordForm : Form
    {
        private string bookId;
        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";

        public BookRecordForm(string bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            LoadBookDetails();
        }

        private void LoadBookDetails()
        {
            string connectionString = $"server={server};database={database};uid={uid};password={password};";
            string query = "SELECT B_TITLE, B_AUTHOR, B_SUBJECT, B_UNIT_PRIZE, B_STOCK FROM Books WHERE B_ID = @BookId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookId);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelTitle.Text = "Title: " + reader["B_TITLE"].ToString();
                            labelAuthor.Text = "Author: " + reader["B_AUTHOR"].ToString();
                            labelSubject.Text = "Subject: " + reader["B_SUBJECT"].ToString();
                            labelPrice.Text = "Price: $" + reader["B_UNIT_PRIZE"].ToString();
                            labelStock.Text = "Stock: " + reader["B_STOCK"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"MySQL error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabelCheckAvailability_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Check Availability form
            CheckAvailabilityForm checkAvailabilityForm = new CheckAvailabilityForm(bookId);
            checkAvailabilityForm.ShowDialog();
        }

        private void linkLabelReserve_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Reservation form
            ReservationForm reservationForm = new ReservationForm(bookId);
            reservationForm.ShowDialog();
        }
    }
}
