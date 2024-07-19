using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public partial class ReservationSummaryForm : Form
    {
        private string userId;
        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string Uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";

        public ReservationSummaryForm()
        {
            InitializeComponent();
            this.userId = SessionManager.Instance.CurrentCustomerId;
            LoadReservationSummary();
        }

        private void LoadReservationSummary()
        {
            string connectionString = $"server={server};database={database};Uid={Uid};password={password};";
            string query = @"
                SELECT Books.B_TITLE AS Title, Reservation.R_B_QUANTITY AS Quantity, Books.B_UNIT_PRIZE AS Unitprice, 
                       Reservation.R_B_QUANTITY * Books.B_UNIT_PRIZE AS TotalPrice
                FROM Reservation
                JOIN Books ON Reservation.R_B_ID = Books.B_ID
                WHERE Reservation.R_C_ID = @UserId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Title"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["UnitPrice"].ToString());
                        item.SubItems.Add(reader["TotalPrice"].ToString());
                        listViewReservations.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Search Request form
            SearchRequestForm searchRequestForm = new SearchRequestForm();
            searchRequestForm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Records page for each item (assuming you have a way to navigate to records)
            foreach (ListViewItem item in listViewReservations.Items)
            {
                string bookTitle = item.Text;
                // Open the record page for the book
                BookRecordForm bookRecordForm = new BookRecordForm(bookTitle);
                bookRecordForm.ShowDialog();
            }
        }
    }
}
