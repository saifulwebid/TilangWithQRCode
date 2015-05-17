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
            cbxPekerjaan.DropDownStyle = ComboBoxStyle.DropDown;
            cbxPekerjaan.Items.Add("PNS");
            cbxPekerjaan.Items.Add("SWASTA");
            cbxPekerjaan.Items.Add("TNI");
            cbxPekerjaan.Items.Add("POLRI");
            cbxPekerjaan.Items.Add("PELAJAR");
            cbxPekerjaan.Items.Add("MHS");
            cbxPekerjaan.Items.Add("LAINNYA");

            cbxPendidikan.DropDownStyle = ComboBoxStyle.DropDown;
            cbxPendidikan.Items.Add("SD");
            cbxPendidikan.Items.Add("SLTP");
            cbxPendidikan.Items.Add("SLTA");
            cbxPendidikan.Items.Add("PT");

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
                //kolom pekerjaan pelanggar
               switch(Split[7])
                {
                   case "1": cbxPekerjaan.Text = "PNS";
                        break;
                   case "2": cbxPekerjaan.Text = "SWASTA";
                        break;
                   case "3": cbxPekerjaan.Text = "TNI";
                        break;
                   case "4": cbxPekerjaan.Text = "POLRI";
                        break;
                   case "5": cbxPekerjaan.Text = "PELAJAR";
                        break;
                   case "6": cbxPekerjaan.Text = "MHS";
                        break;
                   case "7": cbxPekerjaan.Text = "LAINNYA";
                        break;
                }
                //kolom pendidikan pelanggar
               switch (Split[8])
               {
                   case "1": cbxPendidikan.Text = "SD";
                       break;
                   case "2": cbxPendidikan.Text = "SLTP";
                       break;
                   case "3": cbxPendidikan.Text = "SLTA";
                       break;
                   case "4": cbxPendidikan.Text = "PT";
                       break;
               }                
            }
            catch
            {
                MessageBox.Show("QR Code tidak bisa dibaca!");
            }
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
                datpel.Pelanggar.Pemilik.Pekerjaan = cbxPekerjaan.Text;
                datpel.Pelanggar.Pemilik.Pendidikan = cbxPendidikan.Text;
                datpel.Pelanggar.Pemilik.TempatLahir = txtTempatPelanggar.Text;
                datpel.Pelanggar.Pemilik.TanggalLahir = Convert.ToDateTime(txtTanggalLahir.Text);
                datpel.Pelanggar.Golongan = txtGolSIM.Text;
                datpel.Pelanggar.Pemilik.NomorKTP = txtNoKTPPelanggar.Text;
                datpel.Pelanggar.NomorSIM = txtNoSIM.Text;
                datpel.SATPAS = textBox4.Text;
                datpel.NomorRegister = textBox12.Text;
                datpel.SamsatKendaraan = textBox13.Text;
                datpel.JenisKendaraan = textBox14.Text;
                datpel.MerekKendaraan = textBox15.Text;
                datpel.NOKA = textBox16.Text;
                datpel.NOSIN = textBox17.Text;
                datpel.LokasiPelanggaran = txtJalan.Text;
                datpel.PatokanLokasi = txtPatokan.Text;
                datpel.WilayahHukum = txtWilayahHukum.Text;
                datpel.DisitaRanmor = tbxSKSita.Text;
                datpel.DisitaDiterbitkanOleh = txtTerbitSK.Text;
                datpel.DisitaMasaBerlaku = Convert.ToDateTime(dtpBerlakuSK.Text);
                datpel.BarangSita2 = textBox1.Text;
                datpel.PenerbitPemda = txtTerbitPemda.Text;
                datpel.BerlakuBarang2 = Convert.ToDateTime(dtpBerlakuPemda.Text);
                datpel.LokasiSidang = txtPengadilan.Text;
                datpel.WaktuSidang = Convert.ToDateTime(dateTimePicker2.Text);
                datpel.NamaPenyidik = txtNamaPenyidik.Text;
                datpel.PangkatPenyidik = txtPangkatPenyidik.Text;
                datpel.KesatuanPenyidik = txtKesatuanPenyidik.Text;
                datpel.TempatPengambilan = txtTempatAmbil.Text;
                datpel.PasalPelanggaran.NomorPasal = txtPasal.Text;
                datpel.PasalPelanggaran.DendaMaksimal = Convert.ToDouble(txtDenda.Text);
                datpel.TempatSetorDenda = txtDenda.Text;
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
            catch
            {
               MessageBox.Show("Penyimpanan Data Pelanggaran Gagal!");
            } 
        }

        private void dtpJam_ValueChanged(object sender, EventArgs e)
        {
             
        }
    }
}
