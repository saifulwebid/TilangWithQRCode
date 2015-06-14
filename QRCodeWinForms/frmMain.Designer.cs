namespace QRCodeWinForms
{
    partial class frmMain
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
            this.mstMain = new System.Windows.Forms.MenuStrip();
            this.aplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bukaDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manajemenUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buatSIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suratTilangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buatSuratTilangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rekapitulasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikPerOrangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikUmumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.mstMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstMain
            // 
            this.mstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikasiToolStripMenuItem,
            this.sIMToolStripMenuItem,
            this.suratTilangToolStripMenuItem,
            this.rekapitulasiToolStripMenuItem});
            this.mstMain.Location = new System.Drawing.Point(0, 0);
            this.mstMain.Name = "mstMain";
            this.mstMain.Size = new System.Drawing.Size(636, 24);
            this.mstMain.TabIndex = 5;
            this.mstMain.Text = "menuStrip1";
            // 
            // aplikasiToolStripMenuItem
            // 
            this.aplikasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bukaDatabaseToolStripMenuItem,
            this.tutupDatabaseToolStripMenuItem,
            this.toolStripSeparator1,
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.manajemenUserToolStripMenuItem,
            this.toolStripSeparator2,
            this.keluarToolStripMenuItem});
            this.aplikasiToolStripMenuItem.Name = "aplikasiToolStripMenuItem";
            this.aplikasiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.aplikasiToolStripMenuItem.Text = "&Aplikasi";
            // 
            // bukaDatabaseToolStripMenuItem
            // 
            this.bukaDatabaseToolStripMenuItem.Name = "bukaDatabaseToolStripMenuItem";
            this.bukaDatabaseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.bukaDatabaseToolStripMenuItem.Text = "&Buka Database...";
            this.bukaDatabaseToolStripMenuItem.Click += new System.EventHandler(this.bukaDatabaseToolStripMenuItem_Click);
            // 
            // tutupDatabaseToolStripMenuItem
            // 
            this.tutupDatabaseToolStripMenuItem.Enabled = false;
            this.tutupDatabaseToolStripMenuItem.Name = "tutupDatabaseToolStripMenuItem";
            this.tutupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.tutupDatabaseToolStripMenuItem.Text = "&Tutup Database";
            this.tutupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.tutupDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.loginToolStripMenuItem.Text = "&Login...";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Enabled = false;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.logoutToolStripMenuItem.Text = "Logo&ut";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // manajemenUserToolStripMenuItem
            // 
            this.manajemenUserToolStripMenuItem.Enabled = false;
            this.manajemenUserToolStripMenuItem.Name = "manajemenUserToolStripMenuItem";
            this.manajemenUserToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.manajemenUserToolStripMenuItem.Text = "&Manajemen User...";
            this.manajemenUserToolStripMenuItem.Visible = false;
            this.manajemenUserToolStripMenuItem.Click += new System.EventHandler(this.manajemenUserToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.keluarToolStripMenuItem.Text = "&Keluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // sIMToolStripMenuItem
            // 
            this.sIMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buatSIMToolStripMenuItem});
            this.sIMToolStripMenuItem.Name = "sIMToolStripMenuItem";
            this.sIMToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.sIMToolStripMenuItem.Text = "&SIM";
            // 
            // buatSIMToolStripMenuItem
            // 
            this.buatSIMToolStripMenuItem.Name = "buatSIMToolStripMenuItem";
            this.buatSIMToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.buatSIMToolStripMenuItem.Text = "&Buat SIM...";
            this.buatSIMToolStripMenuItem.Click += new System.EventHandler(this.buatSIMToolStripMenuItem_Click);
            // 
            // suratTilangToolStripMenuItem
            // 
            this.suratTilangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buatSuratTilangToolStripMenuItem});
            this.suratTilangToolStripMenuItem.Name = "suratTilangToolStripMenuItem";
            this.suratTilangToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.suratTilangToolStripMenuItem.Text = "Surat &Tilang";
            // 
            // buatSuratTilangToolStripMenuItem
            // 
            this.buatSuratTilangToolStripMenuItem.Name = "buatSuratTilangToolStripMenuItem";
            this.buatSuratTilangToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.buatSuratTilangToolStripMenuItem.Text = "&Buat Surat Tilang...";
            this.buatSuratTilangToolStripMenuItem.Click += new System.EventHandler(this.buatSuratTilangToolStripMenuItem_Click);
            // 
            // rekapitulasiToolStripMenuItem
            // 
            this.rekapitulasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statistikPerOrangToolStripMenuItem,
            this.statistikUmumToolStripMenuItem});
            this.rekapitulasiToolStripMenuItem.Name = "rekapitulasiToolStripMenuItem";
            this.rekapitulasiToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.rekapitulasiToolStripMenuItem.Text = "&Rekapitulasi";
            // 
            // statistikPerOrangToolStripMenuItem
            // 
            this.statistikPerOrangToolStripMenuItem.Name = "statistikPerOrangToolStripMenuItem";
            this.statistikPerOrangToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.statistikPerOrangToolStripMenuItem.Text = "Statistik Per &Orang...";
            this.statistikPerOrangToolStripMenuItem.Click += new System.EventHandler(this.statistikPerOrangToolStripMenuItem_Click);
            // 
            // statistikUmumToolStripMenuItem
            // 
            this.statistikUmumToolStripMenuItem.Name = "statistikUmumToolStripMenuItem";
            this.statistikUmumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.statistikUmumToolStripMenuItem.Text = "Statistik &Umum...";
            this.statistikUmumToolStripMenuItem.Click += new System.EventHandler(this.statistikUmumToolStripMenuItem_Click);
            // 
            // ofdOpen
            // 
            this.ofdOpen.Filter = "File Microsoft Excel 2010 (*.xlsx)|*.xlsx";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 307);
            this.Controls.Add(this.mstMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mstMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Tilang Elektronik";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mstMain.ResumeLayout(false);
            this.mstMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstMain;
        private System.Windows.Forms.ToolStripMenuItem aplikasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bukaDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suratTilangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buatSIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buatSuratTilangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rekapitulasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistikPerOrangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistikUmumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manajemenUserToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
    }
}

