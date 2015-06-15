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
    public partial class frmInputDataSIM : Form
    {
        
        private SIM dataSIM = new SIM();
        private Penduduk datapenduduk;

        public frmInputDataSIM()
        {
            InitializeComponent();
        }

        private void frmInputDataSIM_Load(object sender, EventArgs e)
        {
            cmbJenisKelamin.DataSource = Enum.GetValues(typeof(EnumJenisKelamin));
            List<string> golSIM = new List<string> {"A", "B1", "B2", "C", "D", "A Umum", "B1 Umum", "B2 Umum" };
            cmbGolongan.DataSource = golSIM;
            cmbPendidikan.DataSource = Enum.GetValues(typeof(EnumPendidikan));
            cmbPekerjaan.DataSource = Enum.GetValues(typeof(EnumPekerjaan));
            SetFieldToDefault();
        }
            
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text != "" && txtNoKTP.Text != "" && txtAlamat.Text != "" && txtNoSIM.Text != "" && txtTempatLahir.Text != "")
            {
                if (datapenduduk == null)
                {
                    datapenduduk = new Penduduk();
                    datapenduduk.Nomor = txtNoKTP.Text;
                    datapenduduk.Nama = txtNama.Text;
                    datapenduduk.Pekerjaan = (EnumPekerjaan)cmbPekerjaan.SelectedItem;
                    datapenduduk.Pendidikan = (EnumPendidikan)cmbPendidikan.SelectedItem;
                    datapenduduk.TempatLahir = txtTempatLahir.Text;
                    datapenduduk.Alamat = txtAlamat.Text;
                    datapenduduk.TanggalLahir = Convert.ToDateTime(dtpTanggalLahir.Text);
                    if (cmbJenisKelamin.Text == "Pria")
                        datapenduduk.JenisKelamin = EnumJenisKelamin.Pria;
                    else if (cmbJenisKelamin.Text == "Wanita")
                        datapenduduk.JenisKelamin = EnumJenisKelamin.Wanita;
                    datapenduduk.Save();
                }

                dataSIM.Nomor = txtNoSIM.Text;
                dataSIM.Golongan = cmbGolongan.Text;
                dataSIM.TanggalBuat = Convert.ToDateTime(dtpTanggalPembuatan.Text);
                dataSIM.Pemilik = datapenduduk;
                try
                {
                    dataSIM.TanggalHabis = new DateTime(
                        DateTime.Now.Year + 5, dataSIM.Pemilik.TanggalLahir.Month,
                        dataSIM.Pemilik.TanggalLahir.Day);
                }
                catch (ArgumentOutOfRangeException ex) // tahun kabisat
                {
                    dataSIM.TanggalHabis = new DateTime(
                        DateTime.Now.Year + 5, dataSIM.Pemilik.TanggalLahir.Month + 1, 1);
                }
                
                if (dataSIM.isValid())
                {
                    dataSIM.Save();
                    MessageBox.Show("Data Berhasil Disimpan");
                    SetFieldToDefault();
                    btnTampilkan.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Umur Pendaftar Belum Cukup");
                    dataSIM = new SIM();
                }
            }
            else
            {
                MessageBox.Show("Penyimpanan Data SIM Gagal!\nData yang diisi belum lengkap");
            }
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            frmSIMViewer f2 = new frmSIMViewer(dataSIM);
            f2.ShowDialog();
            btnTampilkan.Enabled = false;
        }

        private void SetFieldToDefault()
        {
            DateTime time = Convert.ToDateTime(dtpTanggalPembuatan.Text);
            txtNoKTP.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtTempatLahir.Text = "";
            txtNoSIM.Text = "";
            dtpTanggalLahir.Text = (new DateTime(time.Year - 17, time.Month, time.Day)).ToLongDateString();
            txtNama.Enabled = true;
            txtAlamat.Enabled = true;
            txtTempatLahir.Enabled = true;
            dtpTanggalLahir.Enabled = true;
            cmbPendidikan.Enabled = true;
            cmbPekerjaan.Enabled = true;
            cmbJenisKelamin.Enabled = true;
            btnTampilkan.Enabled = false;
        }

        private void txtNoKTP_Leave(object sender, EventArgs e)
        {
            datapenduduk = Penduduk.IsPresent(txtNoKTP.Text);
            if (datapenduduk != null)
            {
                txtNama.Text = datapenduduk.Nama;
                txtAlamat.Text = datapenduduk.Alamat;
                txtTempatLahir.Text = datapenduduk.TempatLahir;
                dtpTanggalLahir.Text = datapenduduk.TanggalLahir.ToLongDateString();
                cmbPendidikan.SelectedItem = datapenduduk.Pendidikan;
                cmbPekerjaan.SelectedItem = datapenduduk.Pekerjaan;
                cmbJenisKelamin.SelectedItem = datapenduduk.JenisKelamin;

                txtNama.Enabled = false;
                txtAlamat.Enabled = false;
                txtTempatLahir.Enabled = false;
                dtpTanggalLahir.Enabled = false;
                cmbPendidikan.Enabled = false;
                cmbPekerjaan.Enabled = false;
                cmbJenisKelamin.Enabled = false;
            }
            else
            {
                txtNama.Enabled = true;
                txtAlamat.Enabled = true;
                txtTempatLahir.Enabled = true;
                dtpTanggalLahir.Enabled = true;
                cmbPendidikan.Enabled = true;
                cmbPekerjaan.Enabled = true;
                cmbJenisKelamin.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataSIM = new SIM();
            SetFieldToDefault();
            btnTampilkan.Enabled = false;
        }
    }
}
