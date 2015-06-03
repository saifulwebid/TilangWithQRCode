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
        List<List<int>> dataStatistik = new List<List<int>>();
        List<List<string>> dataStatistikPasal = new List<List<string>>();
        List<DataPelanggaran> data = new List<DataPelanggaran>();
        
        public frmStatistikPelanggaran()
        {
            InitializeComponent();
        }

        string ConvertToMonth(int i)
        {
            string[] Month = new string[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            return Month[i - 1];
        }

        private void cbbTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Hapus Recent Statistik */
            chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.Clear();
            chartStatistikPasal.Series["Banyak Pasal Dilanggar"].Points.Clear(); 

            /*Membuat Grafik*/
            foreach (var grp in dataStatistik[cbbTahun.SelectedIndex].GroupBy(i => i))
            {
                chartStatistikPelanggaran.Series["Banyak Pelanggaran"].Points.AddXY(ConvertToMonth(grp.Key), grp.Count());
            }

            foreach (var grp in dataStatistikPasal[cbbTahun.SelectedIndex].GroupBy(i => i))
            {
                chartStatistikPasal.Series["Banyak Pasal Dilanggar"].Points.AddXY(grp.Key, grp.Count());
            }
        }

        private void frmStatistikPelanggaran_Load(object sender, EventArgs e)
        {
            data = ExcelHelper.GetAllPelanggaran();
            List<int> tahun = new List<int>();
            /* Memasukkan data tahun dan tanggal ke dalam list tahun dan tanggal dari list data pelanggaran */
            foreach (DataPelanggaran x in data)
            {
                tahun.Add(x.WaktuPelanggaran.Year);
            }

            tahun = tahun.Distinct().ToList(); //membuat elemen list tahun menjadi unik       
           
            //Memasukkan Bulan ke dalam list dataStatistik dan Pasal ke dataStatistikPasal
            for (int i = 0; i < tahun.Count(); i++)
            {
                List<int> sublist = new List<int>();
                List<string> sublist1 = new List<string>();
              
                foreach (DataPelanggaran x in data)
                {
                    if (x.WaktuPelanggaran.Year == tahun[i])
                    {
                        sublist.Add(x.WaktuPelanggaran.Month);
                        sublist1.Add(x.PasalPelanggaran.NomorPasal);
                    }
                }
                dataStatistik.Add(sublist);
                dataStatistikPasal.Add(sublist1);
            }
            
            cbbTahun.DataSource = tahun; //sumber data combo box (pemilihan tahun statistik)
        }

        private void chartStatistikPelanggaran_Click(object sender, EventArgs e)
        {}

    }
}
