using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.Versioning;
using System.Diagnostics;

namespace QRCodeWinForms
{
    public partial class frmSuratTilangViewer : Form
    {
        private DataPelanggaran datpel = new DataPelanggaran();
        public frmSuratTilangViewer()
        {
            InitializeComponent();
        }

        private static int ConvertUmur(DateTime ttl)
        {
            DateTime currentdate = new DateTime();
            currentdate = DateTime.Today;

            if (currentdate.Month >= ttl.Month && currentdate.Date >= ttl.Date)
            {
                return currentdate.Year - ttl.Year + 1;
            }
            else
            {
                return currentdate.Year - ttl.Year;
            }

        }

        public frmSuratTilangViewer(DataPelanggaran pelanggaran)
        {
            InitializeComponent();
            //mengambil data dari class Pelanggaran
            datpel = pelanggaran;

        }

        private void frmSuratTilang_Load(object sender, EventArgs e)
        {
            
            try
            {
                lblNoRegPenyidikan.Text = datpel.NomorRegister;
                lblNoRegTilang.Text = datpel.NomorTilang;
                lblKesatuan.Text = datpel.Kesatuan;
                lblNamaPelanggar.Text = datpel.Pelanggar.Pemilik.Nama;
                lblAlamatPelanggar.Text = datpel.Pelanggar.Pemilik.Alamat;
                lblPendidikanPelanggar.Text = datpel.Pelanggar.Pemilik.Pendidikan.ToString();
                lblPekerjaanPelanggar.Text = datpel.Pelanggar.Pemilik.Pekerjaan.ToString();
                lblJK.Text = datpel.Pelanggar.Pemilik.JenisKelamin.ToString();
                lblTempatLahirPelanggar.Text = datpel.Pelanggar.Pemilik.TempatLahir;
                lblTanggalLahirPelanggar.Text = Convert.ToString(datpel.Pelanggar.Pemilik.TanggalLahir.Date.ToString("dd MMMM yyyy"));
                lblUmurPelanggar.Text = Convert.ToString(ConvertUmur(datpel.Pelanggar.Pemilik.TanggalLahir));
                lblGolSIM.Text = datpel.Pelanggar.Golongan;
                lblJenisKendaraan.Text = datpel.JenisKendaraan;
                lblMerekKendaraan.Text = datpel.MerekKendaraan;
                lblNoKTP.Text = datpel.Pelanggar.Pemilik.Nomor;
                lblNoSIM.Text = datpel.Pelanggar.NomorSIM;
                lblNoRegKendaraan.Text = datpel.NomorKendaraan;
                lblNoRangkaKendaraan.Text = datpel.NomorRangkaKendaraan;
                lblNoMesinKendaraan.Text = datpel.NomorMesinKendaraan;
                lblSamsat.Text = datpel.SamsatKendaraan;
                lblSATPAS.Text = datpel.SATPAS;
                lblTanggalPelanggaran.Text = Convert.ToString(datpel.WaktuPelanggaran.Date.ToLongDateString());
                lblTempatAmbilBarangSita.Text = datpel.TempatPengambilanBarangSita;
                lblWaktuLanggar.Text = Convert.ToString(datpel.WaktuPelanggaran.Date.ToLongDateString());
                lblJamLanggar.Text = Convert.ToString(datpel.WaktuPelanggaran.Date.ToShortTimeString());
                lblJalanLanggar.Text = datpel.LokasiPelanggaran;
                lblPatokanLanggar.Text = datpel.PatokanLokasi;
                lblWilayahHukum.Text = datpel.WilayahHukum;
                lblMasaBerlakuSK.Text = Convert.ToString(datpel.DisitaSKMasaBerlaku.Date.ToLongDateString());
                lblTerbitSKSita.Text = datpel.DisitaSKDiterbitkanOleh;
                lblBerlakuBukuUji.Text = Convert.ToString(datpel.DisitaBukuUjiMasaBerlaku.Date.ToLongDateString());
                lblTerbitBukuUji.Text = datpel.DisitaBukuUjiDiterbitkanOleh;
                lblPengadilanSidang.Text = datpel.LokasiSidang;
                lblWaktuSidang.Text = datpel.WaktuSidang.Date.ToLongDateString().ToString();
                lblJamSidang.Text = datpel.WaktuSidang.Date.ToShortTimeString().ToString();
                lblNamaPenyidik.Text = datpel.NamaPenyidik;
                lblPangkatPenyidik.Text = datpel.PangkatPenyidik;
                lblKesatuanPenyidik.Text = datpel.Kesatuan;
                lblPasal.Text = datpel.PasalPelanggaran.NomorPasal;
                lblDendaMaksimal.Text = datpel.PasalPelanggaran.DendaMaksimal.ToString();
                lblBankSetorDenda.Text = datpel.BankSetorDendaMaksimal;
                lblAngkaPinalti.Text = datpel.AngkaPinaltiPelanggaran.ToString();
                if (datpel.PernyataanHadirSendiri == true)
                    rbtprtHadirSendiri.Checked = true;
                else
                    rbtprtPerwakilan.Checked = true;
                lblNamaWakil.Text = datpel.NamaWakil;
                lblAlamatWakil.Text = datpel.AlamatWakil;
                lblUmurWakil.Text = datpel.UmurWakil;
                lblWaktuPernyataan.Text = datpel.WaktuPelanggaran.ToLongDateString();
                lblBankSisaDenda.Text = datpel.BankSisaDenda;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tampil Surat Tilang Gagal! \n" + "\n" + ex.Message);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void rbtDenda500K_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtpJam_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtDenda_TextChanged(object sender, EventArgs e)
        {
        }

        private void label29_Click(object sender, EventArgs e)
        {
        }

        private void label101_Click(object sender, EventArgs e)
        {

        }
        
        private void pdSuratTilang_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void btnPrintSurat_Click(object sender, EventArgs e)
        {
               string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SuratTilang.jpg";
               PrintDialog Print = new PrintDialog();
               System.Drawing.Bitmap image = new System.Drawing.Bitmap(pnlSuratTilang.Width, pnlSuratTilang.Height);
               pnlSuratTilang.DrawToBitmap(image, pnlSuratTilang.ClientRectangle);
               image.Save(path);

               var p = new Process();
               p.StartInfo.FileName = path;//pass in or whatever you need
               p.StartInfo.Verb = "Print";
               p.Start();
               /*Modul didapat dari kelompok 2 Project 1*/
        }

        private void ckbSIM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pnlSuratTilang_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
