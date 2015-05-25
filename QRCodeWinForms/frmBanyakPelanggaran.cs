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
    public partial class frmBanyakPelanggaran : Form
    {
        string qrData;
        string[] field = new string[10];
        List<DataPelanggaran> data = new List<DataPelanggaran>();
        public frmBanyakPelanggaran()
        {
            InitializeComponent();
        }

        void SetAllFieldToNull()
        {
            for (int i = 0; i < 10; i++)
                field[i] = null;
        }

        void PisahString()
        {
            int j = 0;
            for (int i = 0; i < qrData.Length; i++)
            {
                if (qrData[i] == '#')
                    j++;
                else
                    field[j] = field[j] + qrData[i];
            }
        }

        void FillField()
        {
            txtNoKTP.Text = field[0];
            txtNoSIM.Text = field[1];
            txtGol.Text = field[2];
            txtNamaPelanggar.Text = field[3];
            txtTempatLahir.Text = field[4];
            txtTanggalLahir.Text = field[5];
            txtAlamat.Text = field[6];
            txtPekerjaan.Text = field[7];
            txtPendidikan.Text = field[8];
            txtJenisKelamin.Text = field[9];
        }

        private void cmdScanSIM_Click(object sender, EventArgs e)
        {
            SetAllFieldToNull();
            frmScanSIM f2 = new frmScanSIM();
            f2.ShowDialog();
            if ((qrData = f2.GetData) != null)
            {
                PisahString();
                FillField();
                TampilDataPelanggaran();
            }
           
        }

        void TampilDataPelanggaran()
        {
            int count = 0;
            List<DataPelanggaran> dataPelanggar = new List<DataPelanggaran>();
            List<Pasal> pasalDilanggar = new List<Pasal>();
            
            /*Memindahkan Data Pelanggaran Ke list data Pelanggar berdasarkan KTP*/
            foreach (DataPelanggaran x in data)
            {
                if (x.Pelanggar.Pemilik.NomorKTP == txtNoKTP.Text)
                {
                    dataPelanggar.Add(x);
                }
            }

            /* Memindahkan Pasal - Pasal yang dilanggar oleh Pelanggar */
            foreach (DataPelanggaran x in dataPelanggar)
            {
                pasalDilanggar.Add(x.PasalPelanggaran);
            }

            /*Menampilkan Banyak nya pasal yang dilanggar */
            int i=0;
            foreach (var x in pasalDilanggar.GroupBy(k => k))
            {
                dgvDataPelanggaranPelanggar.Rows.Add();
                dgvDataPelanggaranPelanggar.Rows[i].Cells[0].Value = x.Key.NomorPasal;
                dgvDataPelanggaranPelanggar.Rows[i].Cells[1].Value = x.Count();
                i++;
                count = count + x.Count();
            }

            txtJumlahPelanggaran.Text = count.ToString();
        }

        void SetTable()
        {
            dgvDataPelanggaranPelanggar.ColumnCount = 2;
            dgvDataPelanggaranPelanggar.Columns[0].Name = "Pasal yang Dilanggar";
            dgvDataPelanggaranPelanggar.Columns[1].Name = "Jumlah Melanggar";
        }

        private void frmBanyakPelanggaran_Load(object sender, EventArgs e)
        {
            data = ExcelHelper.GetAllPelanggaran();
            SetTable();
        }
    }
}
