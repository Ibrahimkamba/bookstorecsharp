using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BookStoreApp
{
    public class PlaceholderTextBox : TextBox
    {
        private string placeholderText;
        private bool isPlaceholderActive;

        public PlaceholderTextBox()
        {
            this.GotFocus += RemovePlaceholder;
            this.LostFocus += SetPlaceholder;
        }

        [Category("Placeholder")]
        [Description("Gets or sets the placeholder text.")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                SetPlaceholder(null, null);
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = placeholderText;
                this.ForeColor = Color.Gray;
                isPlaceholderActive = true;
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (isPlaceholderActive)
            {
                this.Text = string.Empty;
                this.ForeColor = SystemColors.WindowText;
                isPlaceholderActive = false;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (!this.Focused && string.IsNullOrEmpty(this.Text))
            {
                SetPlaceholder(this, e);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetPlaceholder(null, null);
        }
    }
}
