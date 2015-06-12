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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerateSim = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSuratTilang = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStatistik = new System.Windows.Forms.Button();
            this.btnBanyakPelanggaran = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenerateSim);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 283);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prasyarat SIM";
            // 
            // btnGenerateSim
            // 
            this.btnGenerateSim.Location = new System.Drawing.Point(52, 115);
            this.btnGenerateSim.Name = "btnGenerateSim";
            this.btnGenerateSim.Size = new System.Drawing.Size(83, 39);
            this.btnGenerateSim.TabIndex = 0;
            this.btnGenerateSim.Text = "Generate SIM";
            this.btnGenerateSim.UseVisualStyleBackColor = true;
            this.btnGenerateSim.Click += new System.EventHandler(this.btnGenerateSim_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSuratTilang);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 283);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tindak Langsung";
            // 
            // btnSuratTilang
            // 
            this.btnSuratTilang.Location = new System.Drawing.Point(58, 115);
            this.btnSuratTilang.Name = "btnSuratTilang";
            this.btnSuratTilang.Size = new System.Drawing.Size(83, 40);
            this.btnSuratTilang.TabIndex = 0;
            this.btnSuratTilang.Text = "Isi Form Surat Tilang";
            this.btnSuratTilang.UseVisualStyleBackColor = true;
            this.btnSuratTilang.Click += new System.EventHandler(this.btnSuratTilang_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStatistik);
            this.groupBox3.Controls.Add(this.btnBanyakPelanggaran);
            this.groupBox3.Location = new System.Drawing.Point(424, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 283);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rekapitulasi";
            // 
            // btnStatistik
            // 
            this.btnStatistik.Location = new System.Drawing.Point(53, 153);
            this.btnStatistik.Name = "btnStatistik";
            this.btnStatistik.Size = new System.Drawing.Size(83, 44);
            this.btnStatistik.TabIndex = 1;
            this.btnStatistik.Text = "Statistik Pelanggaran";
            this.btnStatistik.UseVisualStyleBackColor = true;
            this.btnStatistik.Click += new System.EventHandler(this.btnStatistik_Click);
            // 
            // btnBanyakPelanggaran
            // 
            this.btnBanyakPelanggaran.Location = new System.Drawing.Point(53, 78);
            this.btnBanyakPelanggaran.Name = "btnBanyakPelanggaran";
            this.btnBanyakPelanggaran.Size = new System.Drawing.Size(83, 46);
            this.btnBanyakPelanggaran.TabIndex = 0;
            this.btnBanyakPelanggaran.Text = "Banyak Pelanggaran";
            this.btnBanyakPelanggaran.UseVisualStyleBackColor = true;
            this.btnBanyakPelanggaran.Click += new System.EventHandler(this.btnBanyakPelanggaran_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 307);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Tilang Elektronik";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGenerateSim;
        private System.Windows.Forms.Button btnSuratTilang;
        private System.Windows.Forms.Button btnStatistik;
        private System.Windows.Forms.Button btnBanyakPelanggaran;
    }
}

