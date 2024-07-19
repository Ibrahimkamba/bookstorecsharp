using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public partial class SearchRequestForm : Form
    {
        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string Uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";
        private static readonly string connectionString = $"server={server};database={database};Uid={Uid};password={password};";

        public SearchRequestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchCriterion = comboBox1.SelectedItem.ToString();
            string searchValue = textBox1.Text;

            if (!string.IsNullOrEmpty(searchValue) && searchValue != textBox1.PlaceholderText)
            {
                // Perform the search based on the selected criterion and value
                PerformSearch(searchCriterion, searchValue);
            }
            else
            {
                MessageBox.Show("Please enter a value to search.");
            }
        }

        private void PerformSearch(string criterion, string value)
        {
            string query = "";
            switch (criterion)
            {
                case "Title":
                    query = "SELECT B_ID, B_TITLE, B_PUBLISHER, B_PUB_DATE, B_SUBJECT, B_UNIT_PRIZE, B_STOCK FROM Books WHERE B_TITLE LIKE @Value";
                    break;
                case "Author":
                    query = "SELECT B_ID, B_TITLE, B_PUBLISHER, B_PUB_DATE, B_SUBJECT, B_UNIT_PRIZE, B_STOCK FROM Books JOIN Author ON Books.B_A_ID = Author.A_ID WHERE CONCAT(Author.A_FNAME, ' ', Author.A_LNAME) LIKE @Value";
                    break;
                case "Publisher":
                    query = "SELECT B_ID, B_TITLE, B_PUBLISHER, B_PUB_DATE, B_SUBJECT, B_UNIT_PRIZE, B_STOCK FROM Books WHERE B_PUBLISHER LIKE @Value";
                    break;
                case "Subject":
                    query = "SELECT B_ID, B_TITLE, B_PUBLISHER, B_PUB_DATE, B_SUBJECT, B_UNIT_PRIZE, B_STOCK FROM Books WHERE B_SUBJECT LIKE @Value";
                    break;
                default:
                    MessageBox.Show("Invalid search criterion.");
                    return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Value", $"%{value}%");

                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);

                    // Open the Search Result form and pass the search result
                    SearchResultForm searchResultForm = new SearchResultForm(resultTable);
                    searchResultForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while performing the search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
