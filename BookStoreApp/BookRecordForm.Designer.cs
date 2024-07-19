namespace BookStoreApp
{
    partial class BookRecordForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.linkLabelCheckAvailability = new System.Windows.Forms.LinkLabel();
            this.linkLabelReserve = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(13, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(35, 17);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(13, 40);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(51, 17);
            this.labelAuthor.TabIndex = 1;
            this.labelAuthor.Text = "Author:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(13, 67);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(57, 17);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Subject:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(13, 94);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(40, 17);
            this.labelPrice.TabIndex = 3;
            this.labelPrice.Text = "Price:";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(13, 121);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(47, 17);
            this.labelStock.TabIndex = 4;
            this.labelStock.Text = "Stock:";
            // 
            // linkLabelCheckAvailability
            // 
            this.linkLabelCheckAvailability.AutoSize = true;
            this.linkLabelCheckAvailability.Location = new System.Drawing.Point(16, 150);
            this.linkLabelCheckAvailability.Name = "linkLabelCheckAvailability";
            this.linkLabelCheckAvailability.Size = new System.Drawing.Size(127, 17);
            this.linkLabelCheckAvailability.TabIndex = 5;
            this.linkLabelCheckAvailability.TabStop = true;
            this.linkLabelCheckAvailability.Text = "Check Availability";
            this.linkLabelCheckAvailability.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheckAvailability_LinkClicked);
            // 
            // linkLabelReserve
            // 
            this.linkLabelReserve.AutoSize = true;
            this.linkLabelReserve.Location = new System.Drawing.Point(16, 180);
            this.linkLabelReserve.Name = "linkLabelReserve";
            this.linkLabelReserve.Size = new System.Drawing.Size(62, 17);
            this.linkLabelReserve.TabIndex = 6;
            this.linkLabelReserve.TabStop = true;
            this.linkLabelReserve.Text = "Reserve";
            this.linkLabelReserve.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReserve_LinkClicked);
            // 
            // BookRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.linkLabelReserve);
            this.Controls.Add(this.linkLabelCheckAvailability);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelTitle);
            this.Name = "BookRecordForm";
            this.Text = "Book Record";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.LinkLabel linkLabelCheckAvailability;
        private System.Windows.Forms.LinkLabel linkLabelReserve;
    }
}
