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
        private string txtA;
        
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
            int age;

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
            datpel.WaktuPelanggaran = Convert.ToDateTime(dtpTanggalLanggar.Text);
            datpel.NomorRegister = txtNoRegPenyidikan.Text;
            datpel.Kesatuan = txtKesatuan.Text;
            datpel.NomorTilang = txtNoRegTilang.Text;
            datpel.Pelanggar.Pemilik.Nama = txtNamaPelanggar.Text;
            //datpel.Pelanggar.Pemilik.JenisKelamin = rbtLK.Che;
            datpel.Pelanggar.Pemilik.Alamat = txtAlamatPelanggar.Text;
            datpel.Pelanggar.Pemilik.Pekerjaan = cbxPekerjaan.Text;
            datpel.Pelanggar.Pemilik.Pendidikan = cbxPendidikan.Text;
            datpel.Pelanggar.Pemilik.TempatLahir = txtTempatPelanggar.Text;
            datpel.Pelanggar.Pemilik.TanggalLahir = Convert.ToDateTime(txtTanggalLahir.Text);
            datpel.Pelanggar.Golongan = txtGolSIM.Text;
            datpel.Pelanggar.Pemilik.NomorKTP = txtNoKTPPelanggar.Text;
            datpel.Pelanggar.NomorSIM = txtNoSIM.Text;
            /*datpel.SATPAS = txt;
            datpel.NomorRegister =;
            datpel.SamsatKendaraan;
            datpel.JenisKendaraan;
            datpel.MerekKendaraan;
            datpel.NOKA;
            datpel.NOSIN;
            datpel.LokasiPelanggaran;
            datpel.PatokanLokasi;
            datpel.WilayahHukum;
            datpel.DisitaRanmor;
            datpel.DisitaDiterbitkanOleh;
            datpel.DisitaMasaBerlaku;
            datpel.BarangSita2;
            datpel.PenerbitPemda;
            datpel.BerlakuBarang2;
            datpel.TempatSidang;
            datpel.WaktuSidang.Day;
            datpel.WaktuSidang.Date;
            datpel.WaktuSidang.Hour;
            datpel.NamaPenyidik;
            datpel.PangkatPenyidik;
            datpel.KesatuanPenyidik;
            datpel.TempatPengambilan;
            datpel.PasalPelanggaran.NomorPasal;
            datpel.PasalPelanggaran.DendaMaksimal;
            datpel.JumlahUangTitipan;
            datpel.AngkaPinaltiPelanggaran;
            datpel.PernyataanHadirSendiri;
            datpel.NamaWakil;
            datpel.UmurWakil;
            datpel.AlamatWakil;
            datpel.BankSisaDenda;*/
            
            
        }
    }
}
