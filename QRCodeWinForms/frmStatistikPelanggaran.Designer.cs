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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStatistikPelanggaran = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbbTahun = new System.Windows.Forms.ComboBox();
            this.lblTahun = new System.Windows.Forms.Label();
            this.chartStatistikPasal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPelanggaran = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPelanggaran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPasal)).BeginInit();
            this.tabPelanggaran.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartStatistikPelanggaran
            // 
            chartArea3.Name = "ChartArea1";
            this.chartStatistikPelanggaran.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartStatistikPelanggaran.Legends.Add(legend3);
            this.chartStatistikPelanggaran.Location = new System.Drawing.Point(0, 0);
            this.chartStatistikPelanggaran.Name = "chartStatistikPelanggaran";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Banyak Pelanggaran";
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartStatistikPelanggaran.Series.Add(series3);
            this.chartStatistikPelanggaran.Size = new System.Drawing.Size(596, 386);
            this.chartStatistikPelanggaran.TabIndex = 0;
            this.chartStatistikPelanggaran.Text = "chart1";
            this.chartStatistikPelanggaran.Click += new System.EventHandler(this.chartStatistikPelanggaran_Click);
            // 
            // cbbTahun
            // 
            this.cbbTahun.FormattingEnabled = true;
            this.cbbTahun.Location = new System.Drawing.Point(618, 52);
            this.cbbTahun.Name = "cbbTahun";
            this.cbbTahun.Size = new System.Drawing.Size(83, 21);
            this.cbbTahun.TabIndex = 2;
            this.cbbTahun.SelectedIndexChanged += new System.EventHandler(this.cbbTahun_SelectedIndexChanged);
            // 
            // lblTahun
            // 
            this.lblTahun.AutoSize = true;
            this.lblTahun.BackColor = System.Drawing.Color.Transparent;
            this.lblTahun.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTahun.Location = new System.Drawing.Point(636, 34);
            this.lblTahun.Name = "lblTahun";
            this.lblTahun.Size = new System.Drawing.Size(65, 15);
            this.lblTahun.TabIndex = 3;
            this.lblTahun.Text = "Pilih Tahun";
            // 
            // chartStatistikPasal
            // 
            chartArea4.Name = "ChartArea1";
            this.chartStatistikPasal.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartStatistikPasal.Legends.Add(legend4);
            this.chartStatistikPasal.Location = new System.Drawing.Point(3, 0);
            this.chartStatistikPasal.Name = "chartStatistikPasal";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Banyak Pasal Dilanggar";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartStatistikPasal.Series.Add(series4);
            this.chartStatistikPasal.Size = new System.Drawing.Size(590, 383);
            this.chartStatistikPasal.TabIndex = 4;
            this.chartStatistikPasal.Text = "chart1";
            // 
            // tabPelanggaran
            // 
            this.tabPelanggaran.Controls.Add(this.tabPage1);
            this.tabPelanggaran.Controls.Add(this.tabPage2);
            this.tabPelanggaran.Location = new System.Drawing.Point(12, 12);
            this.tabPelanggaran.Name = "tabPelanggaran";
            this.tabPelanggaran.SelectedIndex = 0;
            this.tabPelanggaran.Size = new System.Drawing.Size(604, 412);
            this.tabPelanggaran.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartStatistikPelanggaran);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pelanggaran Per Bulan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartStatistikPasal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 386);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pelanggaran Per-Pasal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmStatistikPelanggaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 443);
            this.Controls.Add(this.tabPelanggaran);
            this.Controls.Add(this.lblTahun);
            this.Controls.Add(this.cbbTahun);
            this.Name = "frmStatistikPelanggaran";
            this.Text = "Statistik Pelanggaran";
            this.Load += new System.EventHandler(this.frmStatistikPelanggaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPelanggaran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistikPasal)).EndInit();
            this.tabPelanggaran.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistikPelanggaran;
        private System.Windows.Forms.ComboBox cbbTahun;
        private System.Windows.Forms.Label lblTahun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistikPasal;
        private System.Windows.Forms.TabControl tabPelanggaran;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}