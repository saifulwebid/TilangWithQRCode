namespace QRCodeWinForms
{
    partial class frmBanyakPelanggaran
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
            this.grbIdentitasPelanggar = new System.Windows.Forms.GroupBox();
            this.txtNamaPelanggar = new System.Windows.Forms.TextBox();
            this.txtNoKTP = new System.Windows.Forms.TextBox();
            this.txtTempatLahir = new System.Windows.Forms.TextBox();
            this.txtTanggalLahir = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtPendidikan = new System.Windows.Forms.TextBox();
            this.txtPekerjaan = new System.Windows.Forms.TextBox();
            this.txtJenisKelamin = new System.Windows.Forms.TextBox();
            this.lblNamaPelanggar = new System.Windows.Forms.Label();
            this.lblNoKTP = new System.Windows.Forms.Label();
            this.lblTmptLhr = new System.Windows.Forms.Label();
            this.lblTglLhr = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblPekerjaan = new System.Windows.Forms.Label();
            this.lblPendidikan = new System.Windows.Forms.Label();
            this.lblJnsKelamin = new System.Windows.Forms.Label();
            this.txtScanQR = new System.Windows.Forms.TextBox();
            this.cmdScanSIM = new System.Windows.Forms.Button();
            this.dgvDataPelanggaranPelanggar = new System.Windows.Forms.DataGridView();
            this.gbDataPelanggaranPelanggar = new System.Windows.Forms.GroupBox();
            this.txtJumlahPelanggaran = new System.Windows.Forms.TextBox();
            this.lblJumlahPelanggaran = new System.Windows.Forms.Label();
            this.grbIdentitasPelanggar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPelanggaranPelanggar)).BeginInit();
            this.gbDataPelanggaranPelanggar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbIdentitasPelanggar
            // 
            this.grbIdentitasPelanggar.Controls.Add(this.lblJnsKelamin);
            this.grbIdentitasPelanggar.Controls.Add(this.lblPendidikan);
            this.grbIdentitasPelanggar.Controls.Add(this.lblPekerjaan);
            this.grbIdentitasPelanggar.Controls.Add(this.lblAlamat);
            this.grbIdentitasPelanggar.Controls.Add(this.lblTglLhr);
            this.grbIdentitasPelanggar.Controls.Add(this.lblTmptLhr);
            this.grbIdentitasPelanggar.Controls.Add(this.lblNoKTP);
            this.grbIdentitasPelanggar.Controls.Add(this.lblNamaPelanggar);
            this.grbIdentitasPelanggar.Controls.Add(this.txtJenisKelamin);
            this.grbIdentitasPelanggar.Controls.Add(this.txtNamaPelanggar);
            this.grbIdentitasPelanggar.Controls.Add(this.txtPekerjaan);
            this.grbIdentitasPelanggar.Controls.Add(this.txtNoKTP);
            this.grbIdentitasPelanggar.Controls.Add(this.txtPendidikan);
            this.grbIdentitasPelanggar.Controls.Add(this.txtTempatLahir);
            this.grbIdentitasPelanggar.Controls.Add(this.txtAlamat);
            this.grbIdentitasPelanggar.Controls.Add(this.txtTanggalLahir);
            this.grbIdentitasPelanggar.Location = new System.Drawing.Point(12, 12);
            this.grbIdentitasPelanggar.Name = "grbIdentitasPelanggar";
            this.grbIdentitasPelanggar.Size = new System.Drawing.Size(492, 266);
            this.grbIdentitasPelanggar.TabIndex = 0;
            this.grbIdentitasPelanggar.TabStop = false;
            this.grbIdentitasPelanggar.Text = "Identitas Pelanggar";
            // 
            // txtNamaPelanggar
            // 
            this.txtNamaPelanggar.Location = new System.Drawing.Point(128, 37);
            this.txtNamaPelanggar.Name = "txtNamaPelanggar";
            this.txtNamaPelanggar.ReadOnly = true;
            this.txtNamaPelanggar.Size = new System.Drawing.Size(353, 20);
            this.txtNamaPelanggar.TabIndex = 1;
            this.txtNamaPelanggar.Text = "Silahkan Scan SIM";
            this.txtNamaPelanggar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNoKTP
            // 
            this.txtNoKTP.Location = new System.Drawing.Point(128, 63);
            this.txtNoKTP.Name = "txtNoKTP";
            this.txtNoKTP.ReadOnly = true;
            this.txtNoKTP.Size = new System.Drawing.Size(254, 20);
            this.txtNoKTP.TabIndex = 2;
            // 
            // txtTempatLahir
            // 
            this.txtTempatLahir.Location = new System.Drawing.Point(128, 89);
            this.txtTempatLahir.Name = "txtTempatLahir";
            this.txtTempatLahir.ReadOnly = true;
            this.txtTempatLahir.Size = new System.Drawing.Size(147, 20);
            this.txtTempatLahir.TabIndex = 3;
            // 
            // txtTanggalLahir
            // 
            this.txtTanggalLahir.Location = new System.Drawing.Point(128, 115);
            this.txtTanggalLahir.Name = "txtTanggalLahir";
            this.txtTanggalLahir.ReadOnly = true;
            this.txtTanggalLahir.Size = new System.Drawing.Size(147, 20);
            this.txtTanggalLahir.TabIndex = 4;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(128, 141);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(353, 20);
            this.txtAlamat.TabIndex = 5;
            // 
            // txtPendidikan
            // 
            this.txtPendidikan.Location = new System.Drawing.Point(128, 167);
            this.txtPendidikan.Name = "txtPendidikan";
            this.txtPendidikan.ReadOnly = true;
            this.txtPendidikan.Size = new System.Drawing.Size(147, 20);
            this.txtPendidikan.TabIndex = 6;
            // 
            // txtPekerjaan
            // 
            this.txtPekerjaan.Location = new System.Drawing.Point(128, 193);
            this.txtPekerjaan.Name = "txtPekerjaan";
            this.txtPekerjaan.ReadOnly = true;
            this.txtPekerjaan.Size = new System.Drawing.Size(147, 20);
            this.txtPekerjaan.TabIndex = 7;
            // 
            // txtJenisKelamin
            // 
            this.txtJenisKelamin.Location = new System.Drawing.Point(128, 219);
            this.txtJenisKelamin.Name = "txtJenisKelamin";
            this.txtJenisKelamin.ReadOnly = true;
            this.txtJenisKelamin.Size = new System.Drawing.Size(123, 20);
            this.txtJenisKelamin.TabIndex = 8;
            // 
            // lblNamaPelanggar
            // 
            this.lblNamaPelanggar.AutoSize = true;
            this.lblNamaPelanggar.Location = new System.Drawing.Point(84, 40);
            this.lblNamaPelanggar.Name = "lblNamaPelanggar";
            this.lblNamaPelanggar.Size = new System.Drawing.Size(38, 13);
            this.lblNamaPelanggar.TabIndex = 1;
            this.lblNamaPelanggar.Text = "NAMA";
            // 
            // lblNoKTP
            // 
            this.lblNoKTP.AutoSize = true;
            this.lblNoKTP.Location = new System.Drawing.Point(75, 66);
            this.lblNoKTP.Name = "lblNoKTP";
            this.lblNoKTP.Size = new System.Drawing.Size(47, 13);
            this.lblNoKTP.TabIndex = 9;
            this.lblNoKTP.Text = "NO KTP";
            // 
            // lblTmptLhr
            // 
            this.lblTmptLhr.AutoSize = true;
            this.lblTmptLhr.Location = new System.Drawing.Point(36, 92);
            this.lblTmptLhr.Name = "lblTmptLhr";
            this.lblTmptLhr.Size = new System.Drawing.Size(86, 13);
            this.lblTmptLhr.TabIndex = 2;
            this.lblTmptLhr.Text = "TEMPAT LAHIR";
            // 
            // lblTglLhr
            // 
            this.lblTglLhr.AutoSize = true;
            this.lblTglLhr.Location = new System.Drawing.Point(29, 118);
            this.lblTglLhr.Name = "lblTglLhr";
            this.lblTglLhr.Size = new System.Drawing.Size(93, 13);
            this.lblTglLhr.TabIndex = 2;
            this.lblTglLhr.Text = "TANGGAL LAHIR";
            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Location = new System.Drawing.Point(72, 144);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(50, 13);
            this.lblAlamat.TabIndex = 2;
            this.lblAlamat.Text = "ALAMAT";
            // 
            // lblPekerjaan
            // 
            this.lblPekerjaan.AutoSize = true;
            this.lblPekerjaan.Location = new System.Drawing.Point(52, 170);
            this.lblPekerjaan.Name = "lblPekerjaan";
            this.lblPekerjaan.Size = new System.Drawing.Size(70, 13);
            this.lblPekerjaan.TabIndex = 2;
            this.lblPekerjaan.Text = "PEKERJAAN";
            // 
            // lblPendidikan
            // 
            this.lblPendidikan.AutoSize = true;
            this.lblPendidikan.Location = new System.Drawing.Point(49, 196);
            this.lblPendidikan.Name = "lblPendidikan";
            this.lblPendidikan.Size = new System.Drawing.Size(73, 13);
            this.lblPendidikan.TabIndex = 2;
            this.lblPendidikan.Text = "PENDIDIKAN";
            // 
            // lblJnsKelamin
            // 
            this.lblJnsKelamin.AutoSize = true;
            this.lblJnsKelamin.Location = new System.Drawing.Point(35, 222);
            this.lblJnsKelamin.Name = "lblJnsKelamin";
            this.lblJnsKelamin.Size = new System.Drawing.Size(87, 13);
            this.lblJnsKelamin.TabIndex = 10;
            this.lblJnsKelamin.Text = "JENIS KELAMIN";
            // 
            // txtScanQR
            // 
            this.txtScanQR.Location = new System.Drawing.Point(12, 284);
            this.txtScanQR.Name = "txtScanQR";
            this.txtScanQR.ReadOnly = true;
            this.txtScanQR.Size = new System.Drawing.Size(374, 20);
            this.txtScanQR.TabIndex = 11;
            this.txtScanQR.Text = "ID QR-Code";
            this.txtScanQR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdScanSIM
            // 
            this.cmdScanSIM.Location = new System.Drawing.Point(392, 284);
            this.cmdScanSIM.Name = "cmdScanSIM";
            this.cmdScanSIM.Size = new System.Drawing.Size(112, 23);
            this.cmdScanSIM.TabIndex = 12;
            this.cmdScanSIM.Text = "Scan SIM";
            this.cmdScanSIM.UseVisualStyleBackColor = true;
            // 
            // dgvDataPelanggaranPelanggar
            // 
            this.dgvDataPelanggaranPelanggar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataPelanggaranPelanggar.Location = new System.Drawing.Point(6, 19);
            this.dgvDataPelanggaranPelanggar.Name = "dgvDataPelanggaranPelanggar";
            this.dgvDataPelanggaranPelanggar.Size = new System.Drawing.Size(480, 126);
            this.dgvDataPelanggaranPelanggar.TabIndex = 13;
            // 
            // gbDataPelanggaranPelanggar
            // 
            this.gbDataPelanggaranPelanggar.Controls.Add(this.lblJumlahPelanggaran);
            this.gbDataPelanggaranPelanggar.Controls.Add(this.txtJumlahPelanggaran);
            this.gbDataPelanggaranPelanggar.Controls.Add(this.dgvDataPelanggaranPelanggar);
            this.gbDataPelanggaranPelanggar.Location = new System.Drawing.Point(12, 310);
            this.gbDataPelanggaranPelanggar.Name = "gbDataPelanggaranPelanggar";
            this.gbDataPelanggaranPelanggar.Size = new System.Drawing.Size(492, 186);
            this.gbDataPelanggaranPelanggar.TabIndex = 14;
            this.gbDataPelanggaranPelanggar.TabStop = false;
            this.gbDataPelanggaranPelanggar.Text = "Data Pelanggaran Pelanggar";
            // 
            // txtJumlahPelanggaran
            // 
            this.txtJumlahPelanggaran.Location = new System.Drawing.Point(363, 160);
            this.txtJumlahPelanggaran.Name = "txtJumlahPelanggaran";
            this.txtJumlahPelanggaran.ReadOnly = true;
            this.txtJumlahPelanggaran.Size = new System.Drawing.Size(123, 20);
            this.txtJumlahPelanggaran.TabIndex = 11;
            this.txtJumlahPelanggaran.Text = "0";
            // 
            // lblJumlahPelanggaran
            // 
            this.lblJumlahPelanggaran.AutoSize = true;
            this.lblJumlahPelanggaran.Location = new System.Drawing.Point(223, 163);
            this.lblJumlahPelanggaran.Name = "lblJumlahPelanggaran";
            this.lblJumlahPelanggaran.Size = new System.Drawing.Size(134, 13);
            this.lblJumlahPelanggaran.TabIndex = 11;
            this.lblJumlahPelanggaran.Text = "JUMLAH PELANGGARAN";
            // 
            // frmBanyakPelanggaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 508);
            this.Controls.Add(this.gbDataPelanggaranPelanggar);
            this.Controls.Add(this.cmdScanSIM);
            this.Controls.Add(this.txtScanQR);
            this.Controls.Add(this.grbIdentitasPelanggar);
            this.Name = "frmBanyakPelanggaran";
            this.Text = "Banyak Pelanggaran";
            this.grbIdentitasPelanggar.ResumeLayout(false);
            this.grbIdentitasPelanggar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPelanggaranPelanggar)).EndInit();
            this.gbDataPelanggaranPelanggar.ResumeLayout(false);
            this.gbDataPelanggaranPelanggar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbIdentitasPelanggar;
        private System.Windows.Forms.TextBox txtNamaPelanggar;
        private System.Windows.Forms.TextBox txtNoKTP;
        private System.Windows.Forms.TextBox txtTempatLahir;
        private System.Windows.Forms.TextBox txtTanggalLahir;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtPendidikan;
        private System.Windows.Forms.TextBox txtPekerjaan;
        private System.Windows.Forms.TextBox txtJenisKelamin;
        private System.Windows.Forms.Label lblPendidikan;
        private System.Windows.Forms.Label lblPekerjaan;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblTglLhr;
        private System.Windows.Forms.Label lblTmptLhr;
        private System.Windows.Forms.Label lblNoKTP;
        private System.Windows.Forms.Label lblNamaPelanggar;
        private System.Windows.Forms.Label lblJnsKelamin;
        private System.Windows.Forms.TextBox txtScanQR;
        private System.Windows.Forms.Button cmdScanSIM;
        private System.Windows.Forms.DataGridView dgvDataPelanggaranPelanggar;
        private System.Windows.Forms.GroupBox gbDataPelanggaranPelanggar;
        private System.Windows.Forms.Label lblJumlahPelanggaran;
        private System.Windows.Forms.TextBox txtJumlahPelanggaran;
    }
}