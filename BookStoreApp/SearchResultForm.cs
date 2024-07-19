using System;
using System.Data;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class SearchResultForm : Form
    {
        public SearchResultForm(DataTable searchResults)
        {
            InitializeComponent();

            // Set the DataGridView's DataSource to the search results
            dataGridView1.DataSource = searchResults;

            // Optionally, set a label to display summary information
            if (searchResults != null && searchResults.Rows.Count > 0)
            {
                labelSummary.Text = $"Found {searchResults.Rows.Count} result(s).";
            }
            else
            {
                labelSummary.Text = "No results found.";
            }
        }

        private void linkLabelSearchRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); // Close the Search Result form
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is selected
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Get the Book ID from the selected row
                string bookId = row.Cells["B_ID"].Value.ToString();
                BookDetailForm bookDetailForm = new BookDetailForm(bookId);
                bookDetailForm.ShowDialog();
            }
        }
    }
}
