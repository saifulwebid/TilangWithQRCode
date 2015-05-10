using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodeWinForms
{
    public partial class frmStatistikPelanggaran : Form
    {
        public frmStatistikPelanggaran()
        {
            InitializeComponent();
        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.AddXY(2013, 50);
            chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.AddXY(2014, 90);
            chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.AddXY(2015, 40);
            chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.AddXY(2016, 25);
            chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.AddXY(2017, 5);
        }
    }
}
