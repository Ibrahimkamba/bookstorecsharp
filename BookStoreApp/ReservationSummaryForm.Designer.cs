namespace BookStoreApp
{
    partial class ReservationSummaryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listViewReservations = new System.Windows.Forms.ListView();
            this.columnHeaderBook = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderQuantity = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTotalPrice = new System.Windows.Forms.ColumnHeader();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservation Summary";
            // 
            // listViewReservations
            // 
            this.listViewReservations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderBook,
            this.columnHeaderQuantity,
            this.columnHeaderUnitPrice,
            this.columnHeaderTotalPrice});
            this.listViewReservations.Location = new System.Drawing.Point(16, 40);
            this.listViewReservations.Name = "listViewReservations";
            this.listViewReservations.Size = new System.Drawing.Size(400, 150);
            this.listViewReservations.TabIndex = 1;
            this.listViewReservations.UseCompatibleStateImageBehavior = false;
            this.listViewReservations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderBook
            // 
            this.columnHeaderBook.Text = "Book";
            this.columnHeaderBook.Width = 150;
            // 
            // columnHeaderQuantity
            // 
            this.columnHeaderQuantity.Text = "Quantity";
            // 
            // columnHeaderUnitPrice
            // 
            this.columnHeaderUnitPrice.Text = "Unit Price";
            // 
            // columnHeaderTotalPrice
            // 
            this.columnHeaderTotalPrice.Text = "Total Price";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(16, 210);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 17);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Search Request";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(114, 210);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(46, 17);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Records";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // ReservationSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 240);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listViewReservations);
            this.Controls.Add(this.label1);
            this.Name = "ReservationSummaryForm";
            this.Text = "Reservation Summary";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewReservations;
        private System.Windows.Forms.ColumnHeader columnHeaderBook;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantity;
        private System.Windows.Forms.ColumnHeader columnHeaderUnitPrice;
        private System.Windows.Forms.ColumnHeader columnHeaderTotalPrice;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}
