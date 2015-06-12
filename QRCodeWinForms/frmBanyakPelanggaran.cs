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
            
        List<Pelanggaran> data = new List<Pelanggaran>();
        List<SIM> dataSIM = new List<SIM>();
        List<Pelanggaran> dataPelanggar = new List<Pelanggaran>();
        List<Pelanggaran> pelanggaranPerSIM = new List<Pelanggaran>();
        List<string> pasalDilanggar = new List<string>();
        List<string> pasalPerSIM = new List<string>();
        List<SIM> simPelanggar = new List<SIM>();

        public frmBanyakPelanggaran()
        {
            InitializeComponent();
        }

        void FillField()
        {
            SIM sim = new SIM(qrData);
            txtNoKTP.Text = sim.Pemilik.Nomor;
            txtNoSIM.Text = sim.Nomor;
            txtGol.Text = sim.Golongan;
            txtNamaPelanggar.Text = sim.Pemilik.Nama;
            txtTempatLahir.Text = sim.Pemilik.TempatLahir;
            txtTanggalLahir.Text = sim.Pemilik.TanggalLahir.ToLongDateString();
            txtAlamat.Text = sim.Pemilik.Alamat;
            txtPekerjaan.Text = sim.Pemilik.Pekerjaan.ToString();
            txtPendidikan.Text = sim.Pemilik.Pendidikan.ToString();
            txtJenisKelamin.Text = sim.Pemilik.JenisKelamin.ToString();
        }

        private void cmdScanSIM_Click(object sender, EventArgs e)
        {
            frmScanSIM f2 = new frmScanSIM();
            f2.ShowDialog();
            if ((qrData = f2.GetData) != null)
            {
                FillField();
                GetDataPelanggar();
            }
           
        }

        void GetDataPelanggar()
        {            
            /*Menyimpan semua sim Pelanggar berdasrkan ktp pelanggar */
            foreach (SIM x in dataSIM)
            {
                if (x.Pemilik.Nomor == txtNoKTP.Text)
                {
                    simPelanggar.Add(x);
                }
            }
            
            /*Menyimpan history pelanggaran berdasrkan SEMUA SIM yang dimiliki oleh pelanggar */
            for (int j = 0; j < simPelanggar.Count; j++)
            {
                foreach (Pelanggaran x in data)
                {
                    if (x.Pelanggar.Nomor == simPelanggar[j].Nomor)
                    {
                        dataPelanggar.Add(x);
                    }
                }
            }

            /* Memindahkan Pasal - Pasal yang dilanggar oleh Pelanggar */
            foreach (Pelanggaran x in dataPelanggar)
            {
                pasalDilanggar.Add(x.PasalPelanggaran.Nomor);
                if (x.Pelanggar.Nomor == txtNoSIM.Text)
                {
                    pasalPerSIM.Add(x.PasalPelanggaran.Nomor);
                    pelanggaranPerSIM.Add(x);
                }
            }
        }

        void SetTablePasal()
        {
            dgvPasal.ColumnCount = 2;
            dgvPasal.Columns[0].Name = "Pasal yang Dilanggar";
            dgvPasal.Columns[1].Name = "Jumlah Melanggar";
        }

        void SetTablePelanggaran()
        {
            dgvDataPelanggaranPelanggar.ColumnCount = 5;
            dgvDataPelanggaranPelanggar.Columns[0].Name = "Tanggal";
            dgvDataPelanggaranPelanggar.Columns[1].Name = "Lokasi Pelanggaran   ";
            dgvDataPelanggaranPelanggar.Columns[2].Name = "No Kendaraan";
            dgvDataPelanggaranPelanggar.Columns[3].Name = "Pasal yang Dilanggar";
            dgvDataPelanggaranPelanggar.Columns[4].Name = "No SIM";
        }

        private void frmBanyakPelanggaran_Load(object sender, EventArgs e)
        {
            data = ExcelHelper.GetAllPelanggaran();
            dataSIM = ExcelHelper.GetAllSIM();
            SetTablePasal();
            SetTablePelanggaran();
        }

        void LookPasal(List<string> pasal)
        {
            /*Menampilkan Banyak nya pasal yang dilanggar */
            dgvPasal.Rows.Clear();
            int i = 0, count = 0;
            foreach (var x in pasal.GroupBy(k => k))
            {
                dgvPasal.Rows.Add();
                dgvPasal.Rows[i].Cells[0].Value = x.Key;
                dgvPasal.Rows[i].Cells[1].Value = x.Count();
                i++;
                count = count + x.Count();
            }

            txtJumlahPelanggaran.Text = count.ToString();
        }

        void LookPelanggaran(List<Pelanggaran> Pelanggaran)
        {
            dgvDataPelanggaranPelanggar.Rows.Clear();
            int i = 0;
            foreach(Pelanggaran x in Pelanggaran)
            {
                dgvDataPelanggaranPelanggar.Rows.Add();
                dgvDataPelanggaranPelanggar.Rows[i].Cells[0].Value = x.WaktuPelanggaran.ToLongDateString();
                dgvDataPelanggaranPelanggar.Rows[i].Cells[1].Value = x.LokasiPelanggaran;
                dgvDataPelanggaranPelanggar.Rows[i].Cells[2].Value = x.NomorKendaraan;
                dgvDataPelanggaranPelanggar.Rows[i].Cells[3].Value = x.PasalPelanggaran.Nomor;
                dgvDataPelanggaranPelanggar.Rows[i].Cells[4].Value = x.Pelanggar.Nomor;
                i++;
            }

            txtJumlahPelanggaran.Text = i.ToString();
        }
       
        private static string ConvertPekerjaan(int i)
        {
            string[] Pekerjaan = new string[] { "PNS", "SWASTA", "TNI", "POLRI", "PELAJAR", "MHS", "LAINNYA" };
            return Pekerjaan[i - 1];
        }

        private static string ConvertPendidikan(int i)
        {
            string[] Pendidikan = new string[] { "SD", "SLTP", "SLTA", "PT" };
            return Pendidikan[i - 1];
        }

        private void btnRekap_Click(object sender, EventArgs e)
        {
            if (rbAllSim.Checked)
            {
                LookPelanggaran(dataPelanggar);
                LookPasal(pasalDilanggar);
            }
            else if (rbOneSIM.Checked)
            {
                LookPelanggaran(pelanggaranPerSIM);
                LookPasal(pasalPerSIM);
            }
        }

    }
}
