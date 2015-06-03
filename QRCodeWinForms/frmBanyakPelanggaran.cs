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
        List<SIM> dataSIM = new List<SIM>();
        List<DataPelanggaran> dataPelanggar = new List<DataPelanggaran>();
        List<DataPelanggaran> pelanggaranPerSIM = new List<DataPelanggaran>();
        List<string> pasalDilanggar = new List<string>();
        List<string> pasalPerSIM = new List<string>();
        List<SIM> simPelanggar = new List<SIM>();

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
            /*Menyimpan semua sim berdasrkan ktp pelanggar */
            foreach (SIM x in dataSIM)
            {
                if (x.Pemilik.NomorKTP == txtNoKTP.Text)
                {
                    simPelanggar.Add(x);
                }
            }
            
            /*Menyimpan history pelanggaran berdasrkan semua sim yang dimiliki oleh pelanggar */
            for (int j = 0; j < simPelanggar.Count; j++)
            {
                foreach (DataPelanggaran x in data)
                {
                    if (x.Pelanggar.NomorSIM == simPelanggar[j].NomorSIM)
                    {
                        dataPelanggar.Add(x);
                    }
                }
            }

            /* Memindahkan Pasal - Pasal yang dilanggar oleh Pelanggar */
            foreach (DataPelanggaran x in dataPelanggar)
            {
                pasalDilanggar.Add(x.PasalPelanggaran.NomorPasal);
                if (x.Pelanggar.NomorSIM == txtNoSIM.Text)
                {
                    pasalPerSIM.Add(x.PasalPelanggaran.NomorPasal);
                    pelanggaranPerSIM.Add(x);
                }

            }

            LookPelanggaran(pelanggaranPerSIM);
        }

        void SetTablePasal()
        {
            dgvDataPelanggaranPelanggar.ColumnCount = 2;
            dgvDataPelanggaranPelanggar.Columns[0].Name = "Pasal yang Dilanggar";
            dgvDataPelanggaranPelanggar.Columns[1].Name = "Jumlah Melanggar";
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
        }

        void LookPasal(List<string> pasal)
        {
            SetTablePasal();
            /*Menampilkan Banyak nya pasal yang dilanggar */
            dgvDataPelanggaranPelanggar.Rows.Clear();
            int i = 0, count = 0;
            foreach (var x in pasal.GroupBy(k => k))
            {
                dgvDataPelanggaranPelanggar.Rows.Add();
                dgvDataPelanggaranPelanggar.Rows[i].Cells[0].Value = x.Key;
                dgvDataPelanggaranPelanggar.Rows[i].Cells[1].Value = x.Count();
                i++;
                count = count + x.Count();
            }

            txtJumlahPelanggaran.Text = count.ToString();
        }

        void LookPelanggaran(List<DataPelanggaran> Pelanggaran)
        {
            SetTablePelanggaran();
            dgvDataPelanggaranPelanggar.Rows.Clear();
            int i = 0, count = 0;
            foreach(DataPelanggaran x in Pelanggaran)
            {
                dgvDataPelanggaranPelanggar.Rows.Add();
                dgvDataPelanggaranPelanggar.Rows[i].Cells[0].Value = x.WaktuPelanggaran.ToLongDateString();
                dgvDataPelanggaranPelanggar.Rows[i].Cells[1].Value = x.LokasiPelanggaran;
                dgvDataPelanggaranPelanggar.Rows[i].Cells[2].Value = x.NomorKendaraan;
                dgvDataPelanggaranPelanggar.Rows[i].Cells[3].Value = x.PasalPelanggaran.NomorPasal;
                i++;
            }

            txtJumlahPelanggaran.Text = i.ToString();
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
            {
                if (cbPasal.Checked)
                {
                    LookPasal(pasalDilanggar);
                }
                else
                {
                    LookPelanggaran(dataPelanggar);
                }
            }
            else
            {
                if (cbPasal.Checked)
                {
                    LookPasal(pasalPerSIM);
                }
                else
                {
                    LookPelanggaran(pelanggaranPerSIM);
                }
            }
        }

        private void cbPasal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPasal.Checked)
            {
                if (cbAll.Checked)
                {
                    LookPasal(pasalDilanggar);
                }
                else
                {
                    LookPasal(pasalPerSIM);
                }
            }
            else
            {
                if (cbAll.Checked)
                {
                    LookPelanggaran(dataPelanggar);
                }
                else
                {
                    LookPelanggaran(pelanggaranPerSIM);
                }
            }
        }

    }
}
