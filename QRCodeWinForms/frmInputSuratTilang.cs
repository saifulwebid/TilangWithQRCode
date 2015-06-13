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

namespace QRCodeWinForms
{
    public partial class frmInputSuratTilang : Form
    {
        private Pelanggaran datpel = new Pelanggaran();
       
        public frmInputSuratTilang()
        {
            InitializeComponent();
        }

        private void InputSuratTilang_Load(object sender, EventArgs e)
        {
            cbxPasal.DataSource = Pasal.GetAll();
            cbxPasal.DisplayMember = "Nomor";

            SetToDefault();
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
            CultureInfo provider = CultureInfo.InvariantCulture;
            provider = new CultureInfo("id-ID");

            frmScanSIM f2 = new frmScanSIM();
            f2.ShowDialog();

            try
            {
                datpel.Pelanggar = new SIM(f2.GetData);

                txtTanggalLahir.Text = datpel.Pelanggar.Pemilik.TanggalLahir.ToString("dd MMMM yyyy", provider);
                txtNamaPelanggar.Text = datpel.Pelanggar.Pemilik.Nama;
                txtAlamatPelanggar.Text = datpel.Pelanggar.Pemilik.Alamat;
                txtNoKTPPelanggar.Text = datpel.Pelanggar.Pemilik.Nomor;
                txtPekerjaan.Text = datpel.Pelanggar.Pemilik.Pekerjaan.ToString();
                txtPendidikan.Text = datpel.Pelanggar.Pemilik.Pendidikan.ToString();
                txtNoSIM.Text = datpel.Pelanggar.Nomor;
                txtTempatPelanggar.Text = datpel.Pelanggar.Pemilik.TempatLahir;
                txtGolSIM.Text = datpel.Pelanggar.Golongan;
                txtUmurPelanggar.Text = Convert.ToString(ConvertUmur(datpel.Pelanggar.Pemilik.TanggalLahir));

                rbtLK.Checked = (datpel.Pelanggar.Pemilik.JenisKelamin == EnumJenisKelamin.Pria);
                rbtPR.Checked = (datpel.Pelanggar.Pemilik.JenisKelamin == EnumJenisKelamin.Wanita);
            }
            catch
            {
                MessageBox.Show("QR Code tidak bisa dibaca");
            }
        }

        private void btnSimpanData_Click(object sender, EventArgs e)
        {
            try
            {
                datpel.WaktuPelanggaran = dtpWaktuLanggar.Value;
                datpel.NomorRegister = txtNoRegPenyidikan.Text;
                datpel.Kesatuan = txtKesatuan.Text;
                datpel.NomorTilang = txtNoRegTilang.Text;
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
                datpel.DisitaSK = CekCheckBoxSK();
                datpel.DisitaSKDiterbitkanOleh = txtTerbitSK.Text;
                datpel.DisitaSKMasaBerlaku = dtpBerlakuSK.Value;
                datpel.DisitaBukuUji = CekCheckBoxBK();
                datpel.DisitaBukuUjiDiterbitkanOleh = txtTerbitPemda.Text;
                datpel.DisitaBukuUjiMasaBerlaku = dtpBerlakuPemda.Value;
                datpel.LokasiSidang = txtPengadilan.Text;
                datpel.WaktuSidang = dtpWaktuSidang.Value;
                datpel.NamaPenyidik = txtNamaPenyidik.Text;
                datpel.PangkatPenyidik = txtPangkatPenyidik.Text;
                datpel.TempatPengambilanBarangSita = txtTempatAmbil.Text;
                datpel.PasalPelanggaran = (Pasal)cbxPasal.SelectedItem;
                datpel.BankSetoranDendaMaksimal = txtBankSetor.Text;
                datpel.AngkaPinaltiPelanggaran = Convert.ToInt16(txtAngkaPinalti.Text);
                datpel.PernyataanHadirSendiri = rbtHadirSendiri.Checked;
                datpel.NamaWakil = txtNamaWali.Text;
                datpel.UmurWakil = txtUmurWali.Text;
                datpel.AlamatWakil = txtAlamatWali.Text;
                datpel.BankSisaDenda = txtBankSisaDenda.Text;
                datpel.Save();

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
            int status=0;

            if (ckbRANMOR.Checked) { status = status + 1; }
            if (ckbSIM.Checked) { status = status + 2; }
            if (ckbSTCK.Checked) { status = status + 4; }
            if (ckbSTNK.Checked) { status = status + 8; }

            return status;
        }

        private int CekCheckBoxBK()
        {
            int status = 0;

            if (ckbLainnya.Checked) {status = status + 1;}
            if (cbkBukuUji.Checked) {status = status + 2;}

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
            txtNamaPelanggar.Text = "Silahkan Scan QR Code";
        }
    }
}