
namespace BookStoreApp
{
    partial class AvailabilityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBookId = new System.Windows.Forms.Label();
            this.lblAvailableQuantity = new System.Windows.Forms.Label();
            this.btnReserve = new System.Windows.Forms.Button();
            this.lnkBookDetail = new System.Windows.Forms.LinkLabel();
            this.lnkReservationPage = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Location = new System.Drawing.Point(70, 114);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(54, 13);
            this.lblBookId.TabIndex = 0;
            this.lblBookId.Text = "BOOK ID:";
            // 
            // lblAvailableQuantity
            // 
            this.lblAvailableQuantity.AutoSize = true;
            this.lblAvailableQuantity.Location = new System.Drawing.Point(73, 145);
            this.lblAvailableQuantity.Name = "lblAvailableQuantity";
            this.lblAvailableQuantity.Size = new System.Drawing.Size(62, 13);
            this.lblAvailableQuantity.TabIndex = 1;
            this.lblAvailableQuantity.Text = "QUANTITY";
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(204, 198);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(75, 34);
            this.btnReserve.TabIndex = 2;
            this.btnReserve.Text = "RESERVE BOOK";
            this.btnReserve.UseVisualStyleBackColor = true;
            // 
            // lnkBookDetail
            // 
            this.lnkBookDetail.AutoSize = true;
            this.lnkBookDetail.Location = new System.Drawing.Point(73, 32);
            this.lnkBookDetail.Name = "lnkBookDetail";
            this.lnkBookDetail.Size = new System.Drawing.Size(107, 13);
            this.lnkBookDetail.TabIndex = 3;
            this.lnkBookDetail.TabStop = true;
            this.lnkBookDetail.Text = "Back to Book Details";
            // 
            // lnkReservationPage
            // 
            this.lnkReservationPage.AutoSize = true;
            this.lnkReservationPage.Location = new System.Drawing.Point(674, 32);
            this.lnkReservationPage.Name = "lnkReservationPage";
            this.lnkReservationPage.Size = new System.Drawing.Size(103, 13);
            this.lnkReservationPage.TabIndex = 4;
            this.lnkReservationPage.TabStop = true;
            this.lnkReservationPage.Text = "Make a Reservation";
            // 
            // AvailabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lnkReservationPage);
            this.Controls.Add(this.lnkBookDetail);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.lblAvailableQuantity);
            this.Controls.Add(this.lblBookId);
            this.Name = "AvailabilityForm";
            this.Text = "AvailabilityForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.Label lblAvailableQuantity;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.LinkLabel lnkBookDetail;
        private System.Windows.Forms.LinkLabel lnkReservationPage;
    }
}