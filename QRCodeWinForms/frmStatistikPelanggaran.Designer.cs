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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStatistikPelanggaran = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnTampil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPelanggaran)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStatistikPelanggaran
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStatistikPelanggaran.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStatistikPelanggaran.Legends.Add(legend1);
            this.chartStatistikPelanggaran.Location = new System.Drawing.Point(12, 12);
            this.chartStatistikPelanggaran.Name = "chartStatistikPelanggaran";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Banyak Pelanggaran";
            this.chartStatistikPelanggaran.Series.Add(series1);
            this.chartStatistikPelanggaran.Size = new System.Drawing.Size(728, 396);
            this.chartStatistikPelanggaran.TabIndex = 0;
            this.chartStatistikPelanggaran.Text = "chart1";
            // 
            // btnTampil
            // 
            this.btnTampil.Location = new System.Drawing.Point(577, 45);
            this.btnTampil.Name = "btnTampil";
            this.btnTampil.Size = new System.Drawing.Size(127, 28);
            this.btnTampil.TabIndex = 1;
            this.btnTampil.Text = "Lihat Statistik";
            this.btnTampil.UseVisualStyleBackColor = true;
            this.btnTampil.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // frmStatistikPelanggaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 420);
            this.Controls.Add(this.btnTampil);
            this.Controls.Add(this.chartStatistikPelanggaran);
            this.Name = "frmStatistikPelanggaran";
            this.Text = "Statistik Pelanggaran";
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPelanggaran)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistikPelanggaran;
        private System.Windows.Forms.Button btnTampil;
    }
}