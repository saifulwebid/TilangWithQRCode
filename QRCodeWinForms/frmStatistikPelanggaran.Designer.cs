namespace QRCodeWinForms
{
    partial class frmStatistikPelanggaran
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStatistikPelanggaran = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbbTahun = new System.Windows.Forms.ComboBox();
            this.lblTahun = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPelanggaran)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStatistikPelanggaran
            // 
            chartArea2.Name = "ChartArea1";
            this.chartStatistikPelanggaran.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartStatistikPelanggaran.Legends.Add(legend2);
            this.chartStatistikPelanggaran.Location = new System.Drawing.Point(0, 0);
            this.chartStatistikPelanggaran.Name = "chartStatistikPelanggaran";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Banyak Pelanggaran";
            this.chartStatistikPelanggaran.Series.Add(series2);
            this.chartStatistikPelanggaran.Size = new System.Drawing.Size(737, 420);
            this.chartStatistikPelanggaran.TabIndex = 0;
            this.chartStatistikPelanggaran.Text = "chart1";
            this.chartStatistikPelanggaran.Click += new System.EventHandler(this.chartStatistikPelanggaran_Click);
            // 
            // cbbTahun
            // 
            this.cbbTahun.FormattingEnabled = true;
            this.cbbTahun.Location = new System.Drawing.Point(616, 60);
            this.cbbTahun.Name = "cbbTahun";
            this.cbbTahun.Size = new System.Drawing.Size(83, 21);
            this.cbbTahun.TabIndex = 2;
            this.cbbTahun.SelectedIndexChanged += new System.EventHandler(this.cbbTahun_SelectedIndexChanged);
            // 
            // lblTahun
            // 
            this.lblTahun.AutoSize = true;
            this.lblTahun.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTahun.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTahun.Location = new System.Drawing.Point(634, 42);
            this.lblTahun.Name = "lblTahun";
            this.lblTahun.Size = new System.Drawing.Size(65, 15);
            this.lblTahun.TabIndex = 3;
            this.lblTahun.Text = "Pilih Tahun";
            // 
            // frmStatistikPelanggaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 420);
            this.Controls.Add(this.lblTahun);
            this.Controls.Add(this.cbbTahun);
            this.Controls.Add(this.chartStatistikPelanggaran);
            this.Name = "frmStatistikPelanggaran";
            this.Text = "Statistik Pelanggaran";
            this.Load += new System.EventHandler(this.frmStatistikPelanggaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPelanggaran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistikPelanggaran;
        private System.Windows.Forms.ComboBox cbbTahun;
        private System.Windows.Forms.Label lblTahun;
    }
}