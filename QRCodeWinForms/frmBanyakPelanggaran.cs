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
            int i = 0;
            data = ExcelHelper.GetAllPelanggaran();
            foreach (DataPelanggaran tampil in data)
            {
                if (tampil.Pelanggar.Pemilik.NomorKTP == txtNoKTP.Text)
                {
                    dgvDataPelanggaranPelanggar.Rows.Add();
                    dgvDataPelanggaranPelanggar.Rows[i].Cells[0].Value = tampil.WaktuPelanggaran.Date;
                    dgvDataPelanggaranPelanggar.Rows[i].Cells[1].Value = tampil.NomorRegister;
                    dgvDataPelanggaranPelanggar.Rows[i].Cells[2].Value = tampil.NomorKendaraan;
                    dgvDataPelanggaranPelanggar.Rows[i].Cells[3].Value = tampil.JenisKendaraan;
                    dgvDataPelanggaranPelanggar.Rows[i].Cells[4].Value = tampil.MerekKendaraan;
                    dgvDataPelanggaranPelanggar.Rows[i].Cells[5].Value = tampil.PasalPelanggaran;
                    i++;
                }
            }

            txtJumlahPelanggaran.Text = (i + 1).ToString();
        }

        void SetTable()
        {
            dgvDataPelanggaranPelanggar.ColumnCount = 6;
            dgvDataPelanggaranPelanggar.Columns[0].Name = "Tanggal";
            dgvDataPelanggaranPelanggar.Columns[1].Name = "No Reg Penyidikan";
            dgvDataPelanggaranPelanggar.Columns[2].Name = "No Reg Kendaraan";
            dgvDataPelanggaranPelanggar.Columns[3].Name = "Jenis Kendaraan";
            dgvDataPelanggaranPelanggar.Columns[4].Name = "Merk Kendaraan";
            dgvDataPelanggaranPelanggar.Columns[5].Name = "Pasal";
        }

        private void frmBanyakPelanggaran_Load(object sender, EventArgs e)
        {
            SetTable();
        }
    }
}
