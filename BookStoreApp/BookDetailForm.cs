using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public partial class BookDetailForm : Form
    {
        private string bookId;
        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";

        public BookDetailForm(string bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            DisplayBookDetails();
        }

        private void DisplayBookDetails()
        {
            string connectionString = $"server={server};database={database};uid={uid};password={password};";
            string query = @"SELECT B.B_TITLE, CONCAT(A.A_FNAME, ' ',A.A_LNAME) AS A_NAME, B.B_SUBJECT, B.B_PUB_DATE 
                             FROM Books B 
                             JOIN Author A ON B.B_A_ID = A.A_ID 
                             WHERE B.B_ID = @BookId";

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
                            string title = reader["B_TITLE"].ToString();
                            string author = reader["A_NAME"].ToString();
                            string subject = reader["B_SUBJECT"].ToString();
                            string published = reader["B_PUB_DATE"].ToString();

                            string bookDetails = $"Book ID: {bookId}\nTitle: {title}\nAuthor: {author}\nSubject: {subject}\nPublished: {published}";
                            richTextBox1.Text = bookDetails;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Search Request form
            SearchRequestForm searchRequestForm = new SearchRequestForm();
            searchRequestForm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Check Availability form
            CheckAvailabilityForm checkAvailabilityForm = new CheckAvailabilityForm(bookId);
            checkAvailabilityForm.ShowDialog();
        }
    }
}
