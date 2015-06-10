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
    public partial class frmInputSuratTilang : Form
    {
        string ResultString;
        DataPelanggaran datpel = new DataPelanggaran();
       
        public frmInputSuratTilang()
        {
            InitializeComponent();
        }

        private void txtNoRegPenyidikan_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputSuratTilang_Load(object sender, EventArgs e)
        {
            dtpJamSidang.ShowUpDown = true;
            dtpJamSidang.CustomFormat = "HH:mm";
            dtpJamSidang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            dtpJamLanggar.ShowUpDown = true;
            dtpJamLanggar.CustomFormat = "HH:mm";
            dtpJamLanggar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            //combobox
            cbxPasal.DataSource = Pasal.GetAllPasal();
            cbxPasal.DisplayMember = "NomorPasal";

            txtKesatuanPenyidik.Text = txtKesatuan.Text;
            SetToDefault();
        }

        private void TampilData()
        {
            
            try
            {
                string[] Split = ResultString.Split('#');
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime parseddate;
                provider = new CultureInfo("id-ID");

                txtNamaPelanggar.Text = Split[3];
                txtAlamatPelanggar.Text = Split[6];
                txtNoKTPPelanggar.Text = Split[0];
                txtPekerjaan.Text = ConvertPekerjaan(Convert.ToInt32(Split[7])); ;
                txtPendidikan.Text = ConvertPendidikan(Convert.ToInt32(Split[8]));
                txtNoSIM.Text = Split[1];
                txtTempatPelanggar.Text = Split[4];
                txtGolSIM.Text = Split[2];
                //merubah supaya tanggalnya jadi bukan angka lagi
                if (DateTime.TryParseExact(Split[5], "ddMMyy", null, DateTimeStyles.None, out parseddate))
                {
                    txtTanggalLahir.Text = parseddate.ToString("dd MMMM yyyy", provider);
                }
                txtUmurPelanggar.Text = Convert.ToString(ConvertUmur(parseddate));
                //kolom jenis kelamin
                if (Split[9] == "L")
                {
                    rbtLK.Checked = true;
                    datpel.Pelanggar.Pemilik.JenisKelamin = EnumJenisKelamin.Pria;
                }
                else
                {
                    rbtPR.Checked = true;
                    datpel.Pelanggar.Pemilik.JenisKelamin = EnumJenisKelamin.Wanita;
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

        private void btnScanQRCode_Click(object sender, EventArgs e)
        {
            frmScanSIM f2 = new frmScanSIM();
            f2.ShowDialog();
            ResultString = f2.GetData;
            TampilData();
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
                //datpel.Pelanggar.Pemilik.Pekerjaan = txtPekerjaan.Text;
                //datpel.Pelanggar.Pemilik.Pendidikan = txtPendidikan.Text;
                datpel.Pelanggar.Pemilik.TempatLahir = txtTempatPelanggar.Text;
                datpel.Pelanggar.Pemilik.TanggalLahir = Convert.ToDateTime(txtTanggalLahir.Text);
                datpel.Pelanggar.Golongan = txtGolSIM.Text;
                datpel.Pelanggar.Pemilik.Nomor = txtNoKTPPelanggar.Text;
                datpel.Pelanggar.Nomor = txtNoSIM.Text;
                datpel.Satpas = txtSATPAS.Text;
                datpel.NomorKendaraan = txtNoKendaraan.Text;
                datpel.SamsatKendaraan = txtSamsat.Text;
                datpel.JenisKendaraan = txtJenisKendaraan.Text;
                datpel.MerekKendaraan = txtMerekKendaraan.Text;
                datpel.NomorRangkaKendaraan = txtNoRangka.Text;
                datpel.NomorMesinKendaraan = txtNoMeSIN.Text;
                datpel.LokasiPelanggaran = txtJalan.Text;
                datpel.PatokanLokasi = txtPatokan.Text;
                datpel.WilayahHukum = txtWilayahHukum.Text;
                datpel.DisitaSK = CekCheckBoxSK().ToString();
                datpel.DisitaSKDiterbitkanOleh = txtTerbitSK.Text;
                datpel.DisitaSKMasaBerlaku = Convert.ToDateTime(dtpBerlakuSK.Text);
                datpel.DisitaBukuUji = CekCheckBoxBK().ToString();
                datpel.DisitaBukuUjiDiterbitkanOleh = txtTerbitPemda.Text;
                datpel.DisitaBukuUjiMasaBerlaku = Convert.ToDateTime(dtpBerlakuPemda.Text);
                datpel.LokasiSidang = txtPengadilan.Text;
                datpel.WaktuSidang = Convert.ToDateTime(txtWaktuSidang.Text);
                datpel.NamaPenyidik = txtNamaPenyidik.Text;
                datpel.PangkatPenyidik = txtPangkatPenyidik.Text;
                datpel.TempatPengambilanBarangSita = txtTempatAmbil.Text;
                datpel.PasalPelanggaran.Nomor = cbxPasal.Text;
                datpel.PasalPelanggaran.DendaMaksimal = Convert.ToDouble(txtDendaMaksimal.Text);
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

                btnTampil.Enabled = true;
                btnNewST.Enabled = true;
                btnSimpanData.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan Data Pelanggaran Gagal! " + "\n" + ex.Message);
            } 
        }
        private int CekCheckBoxSK()
        {
            int coba=0;
            if (ckbRANMOR.Checked)
            {
                coba = coba+ 1;
            }
            if (ckbSIM.Checked)
            {
                coba = coba + 2;
            }
            if (ckbSTCK.Checked)
            {
                coba = coba + 4;
            }
            if (ckbSTNK.Checked)
            {
                coba = coba + 8;
            }
            return coba;
        }

        private int CekCheckBoxBK()
        {
            int status = 0;
            if (ckbLainnya.Checked)
            {
                status = status + 1;
            }
            if (cbkBukuUji.Checked)
            {
                status = status + 2;
            }
            return status;
        }

        private void ClearData(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                TextBox tb = ctrl as TextBox;
                CheckBox cb = ctrl as CheckBox;
                RadioButton rb = ctrl as RadioButton;
                if (tb != null)
                    tb.Text = "";
                if (cb != null)
                    cb.Checked = false;
                if (rb != null)
                    rb.Checked = false;
                else
                    ClearData(ctrl.Controls);
            }
        }

        private void SetToDefault()
        {
            btnTampil.Enabled = false;
            btnSimpanData.Enabled = true;
            btnNewST.Enabled = false;
        }

        private void cbxPasal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pasal item = (Pasal)cbxPasal.SelectedItem;
            txtDendaMaksimal.Text = Convert.ToString(item.DendaMaksimal);
        }

        private void TampilSuratTilang()
        {
            frmSuratTilangViewer frmsurat = new frmSuratTilangViewer(datpel);

            //kondisi supaya checkbox form viewer mengikuti checkbox form input
            frmsurat.ckbSTNK.Checked = ckbSTNK.Checked;
            frmsurat.ckbSTCK.Checked = ckbSTCK.Checked;
            frmsurat.ckbSIM.Checked = ckbSIM.Checked;
            frmsurat.ckbRANMOR.Checked = ckbRANMOR.Checked;
            frmsurat.ckbLainnya.Checked = ckbLainnya.Checked;
            frmsurat.ckbBukuUji.Checked = cbkBukuUji.Checked;

            frmsurat.ShowDialog(); 
        }
        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }
        private void txtDendaMaksimal_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnTampilST_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            TampilSuratTilang();
            btnNewST.Enabled = true;
        }

        private void btnNewST_Click(object sender, EventArgs e)
        {
            btnSimpanData.Enabled = true;
            btnNewST.Enabled = false;
            btnTampil.Enabled = false;
            ClearData(this.Controls);
        }
    }
}
