using System;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class BookDetailForm : Form
    {
        private string bookId;

        public BookDetailForm(string bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            DisplayBookDetails();
        }

        private void DisplayBookDetails()
        {
            // Mock book details
            string bookDetails = $"Book ID: {bookId}\nTitle: Example Book\nAuthor: John Doe\nSubject: Programming\nPublished: 2023";
            richTextBox1.Text = bookDetails;
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
