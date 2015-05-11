namespace QRCodeWinForms
{
    partial class frmScanSIM
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
            this.lblPetunjuk = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPetunjuk
            // 
            this.lblPetunjuk.AutoSize = true;
            this.lblPetunjuk.Location = new System.Drawing.Point(57, 318);
            this.lblPetunjuk.Name = "lblPetunjuk";
            this.lblPetunjuk.Size = new System.Drawing.Size(227, 13);
            this.lblPetunjuk.TabIndex = 3;
            this.lblPetunjuk.Text = "Arahkan QR-Code Pada SIM Anda Ke Kamera";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 303);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmScanSIM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 339);
            this.Controls.Add(this.lblPetunjuk);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmScanSIM";
            this.Text = "Scan SIM";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPetunjuk;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}