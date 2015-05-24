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

namespace QRCodeWinForms
{
    public partial class frmSuratTilang : Form
    {
        string ResultString;
        DataPelanggaran datpel = new DataPelanggaran();
        
        public frmSuratTilang()
        {
            InitializeComponent();
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

        private void frmSuratTilang_Load(object sender, EventArgs e)
        {
            dtpJam.ShowUpDown = true;
            dtpJam.CustomFormat = "HH:mm";
            dtpJam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            dtpJamLanggar.ShowUpDown = true;
            dtpJamLanggar.CustomFormat = "HH:mm";
            dtpJamLanggar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

        }

        private void TampilData()
        {
            string[] Split = ResultString.Split('#');
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime parseddate;
            provider = new CultureInfo("id-ID");
            try
            {
                txtNamaPelanggar.Text = Split[3];
                txtAlamatPelanggar.Text = Split[6];
                txtNoKTPPelanggar.Text = Split[0];
                txtPekerjaan.Text = ConvertPekerjaan(Convert.ToInt32(Split[7])); ;
                txtPendidikan.Text = ConvertPendidikan(Convert.ToInt32(Split[8])); 
                txtNoSIM.Text = Split[1];
                txtTempatPelanggar.Text = Split[4];
                txtGolSIM.Text = Split[2];
                //merubah supaya tanggalnya jadi bukan angka lagi
                if(DateTime.TryParseExact(Split[5],"ddMMyy",null,DateTimeStyles.None,out parseddate)){
                txtTanggalLahir.Text = parseddate.ToString("dd MMMM yyyy",provider);
                }
                txtUmurPelanggar.Text = Convert.ToString(ConvertUmur(parseddate));
                //kolom jenis kelamin
                if (Split[9] == "L")
                {
                    rbtLK.Checked = true;
                    datpel.Pelanggar.Pemilik.JenisKelamin = rbtLK.Text;
                }
                else
                { rbtPR.Checked = true;
                datpel.Pelanggar.Pemilik.JenisKelamin = rbtPR.Text;
                }
                             
            }
            catch
            {
                MessageBox.Show("QR Code tidak bisa dibaca!");
            }
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

        private void btnScanQRCode_Click(object sender, EventArgs e)
        {
            frmScanSIM f2 = new frmScanSIM();
            f2.ShowDialog();
            ResultString = f2.GetData;
            TampilData();
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

        private void btnSimpanData_Click(object sender, EventArgs e)
        {
            try
            {
                datpel.WaktuPelanggaran = Convert.ToDateTime(dtpWaktuLanggar.Text);
                datpel.NomorRegister = txtNoRegPenyidikan.Text;
                datpel.Kesatuan = txtKesatuan.Text;
                datpel.NomorTilang = txtNoRegTilang.Text;
                datpel.Pelanggar.Pemilik.Nama = txtNamaPelanggar.Text;
                datpel.Pelanggar.Pemilik.Alamat = txtAlamatPelanggar.Text;
                datpel.Pelanggar.Pemilik.Pekerjaan = txtPekerjaan.Text;
                datpel.Pelanggar.Pemilik.Pendidikan = txtPendidikan.Text;
                datpel.Pelanggar.Pemilik.TempatLahir = txtTempatPelanggar.Text;
                datpel.Pelanggar.Pemilik.TanggalLahir = Convert.ToDateTime(txtTanggalLahir.Text);
                datpel.Pelanggar.Golongan = txtGolSIM.Text;
                datpel.Pelanggar.Pemilik.NomorKTP = txtNoKTPPelanggar.Text;
                datpel.Pelanggar.NomorSIM = txtNoSIM.Text;
                datpel.SATPAS = txtSATPAS.Text;
                datpel.NomorKendaraan = txtNoKendaraan.Text;
                datpel.SamsatKendaraan = txtSamsat.Text;
                datpel.JenisKendaraan = txtJenisKendaraan.Text;
                datpel.MerekKendaraan = txtMerekKendaraan.Text;
                datpel.NomorRangkaKendaraan = txtNoRangka.Text;
                datpel.NomorMesinKendaraan = txtNoMeSIN.Text;
                datpel.LokasiPelanggaran = txtJalan.Text;
                datpel.PatokanLokasi = txtPatokan.Text;
                datpel.WilayahHukum = txtWilayahHukum.Text;
                datpel.DisitaSKRanmor = tbxSKSita.Text;
                datpel.DisitaSKDiterbitkanOleh = txtTerbitSK.Text;
                datpel.DisitaSKMasaBerlaku = Convert.ToDateTime(dtpBerlakuSK.Text);
                datpel.DisitaBukuUji = txtBukuUji.Text;
                datpel.DisitaBukuUjiDiterbitkanOleh = txtTerbitPemda.Text;
                datpel.DisitaBukuUjiMasaBerlaku = Convert.ToDateTime(dtpBerlakuPemda.Text);
                datpel.LokasiSidang = txtPengadilan.Text;
                datpel.WaktuSidang = Convert.ToDateTime(txtWaktuSidang.Text);
                datpel.NamaPenyidik = txtNamaPenyidik.Text;
                datpel.PangkatPenyidik = txtPangkatPenyidik.Text;
                datpel.KesatuanPenyidik = txtKesatuanPenyidik.Text;
                datpel.TempatPengambilanBarangSita = txtTempatAmbil.Text;
                datpel.PasalPelanggaran.NomorPasal = txtPasal.Text;
                datpel.PasalPelanggaran.DendaMaksimal = Convert.ToDouble(txtDenda.Text);
                datpel.BankSetorDendaMaksimal = txtBankSetor.Text;
                datpel.AngkaPinaltiPelanggaran = Convert.ToDouble(txtAngkaPinalti.Text);
                if (rbtHadirSendiri.Checked == true)
                {
                    datpel.PernyataanHadirSendiri = true;
                }
                else
                {
                    datpel.PernyataanHadirSendiri = false;
                }
                datpel.NamaWakil = txtNamaWali.Text;
                datpel.UmurWakil = txtUmurWali.Text;
                datpel.AlamatWakil = txtAlamatWali.Text;
                datpel.BankSisaDenda = txtBankSisaDenda.Text;

                datpel.Save(datpel);
                MessageBox.Show("Penyimpanan Data Pelanggaran Berhasil!");

            }
            catch (Exception ex)
            {
               MessageBox.Show("Penyimpanan Data Pelanggaran Gagal! " + "\n"+ ex.Message);
            } 
        }

        private void dtpJam_ValueChanged(object sender, EventArgs e)
        {
             
        }

        private void txtDenda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
