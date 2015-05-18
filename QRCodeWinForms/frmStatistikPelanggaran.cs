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
            List<DataPelanggaran>data = new  List<DataPelanggaran>();
            data = ExcelHelper.GetAllPelanggaran();
            List<int> dataBulan = new List<int>();

            foreach (DataPelanggaran x in data)
            {
                dataBulan.Add(x.WaktuPelanggaran.Month);
            }

            foreach (var grp in dataBulan.GroupBy(i => i))
            {
                chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.AddXY(ConvertToMonth(grp.Key), grp.Count());
            }
        }

        string ConvertToMonth(int i)
        {
            string[] Month = new string[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            return Month[i - 1];
        }
    }
}
