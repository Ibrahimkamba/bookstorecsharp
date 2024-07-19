using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public partial class HomeForm : Form
    {
        private static MySqlConnection conn;
        private static readonly string server = "bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com";
        private static readonly string database = "bkbxqvr3u99gdowtsu8c";
        private static readonly string Uid = "u5dmf8qxsxlp6sca";
        private static readonly string password = "iMsCpRUikhByXlmWSQnb";
        private static readonly string connectionString = $"server={server};database={database};Uid={Uid};password={password};";

        public HomeForm()
        {
            conn = new MySqlConnection(connectionString);
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = comboBox1.SelectedItem.ToString() == "Yes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Yes")
            {
                string customerId = textBox1.Text;
                if (!string.IsNullOrEmpty(customerId) && customerId != "Enter your Customer ID")
                {
                    // Fetch and display customer details
                    FetchCustomerDetails(customerId);
                }
                else
                {
                    MessageBox.Show("Please enter your Customer ID.");
                }
            }
            else
            {
                // Navigate to registration form
                RegisterNewCustomer();
            }
        }

        private void FetchCustomerDetails(string customerId)
        {
            try
            {
                conn.Open();

                // Define the query to get customer details
                string query = "SELECT C_NAME, C_ADD FROM Customers WHERE C_ID = @CustomerId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["C_NAME"].ToString();
                            string address = reader["C_ADD"].ToString();

                            // Store customer details in the session manager
                            SessionManager.Instance.CurrentCustomerId = customerId;
                            SessionManager.Instance.CurrentCustomerName = name;
                            SessionManager.Instance.CurrentCustomerAddress = address;

                            // Format customer details
                            string customerDetails = $"Customer ID: {customerId}\nName: {name}\nAddress: {address}";
                            MessageBox.Show(customerDetails, "Customer Details");

                            // Show the Search Request link
                            linkLabel1.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("No customer found with the given ID.", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching customer details: " + ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void RegisterNewCustomer()
        {
            // Navigate to registration form or handle registration process
            MessageBox.Show("Please register as a new customer.");
            // Show the Search Request link
            linkLabel2.Visible = true;
            // Hide the Search Request link
            linkLabel1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate to Search Request functionality
            SearchRequestForm searchForm = new SearchRequestForm();
            searchForm.ShowDialog();
        }
    }
}
