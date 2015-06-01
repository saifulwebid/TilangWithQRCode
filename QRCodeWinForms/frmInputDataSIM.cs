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
        private Penduduk datapenduduk = new Penduduk();

        public frmInputDataSIM()
        {
            InitializeComponent();
        }

        private void frmInputDataSIM_Load(object sender, EventArgs e)
        {
            List<string> jeniskelamin = new List<string> { "Laki-Laki", "Perempuan" };
            cmbJenisKelamin.DataSource = jeniskelamin;
            List<string> golSIM = new List<string> {"A", "B1", "B2", "C", "D", "A Umum", "B1 Umum", "B2 Umum" };
            cmbGolongan.DataSource = golSIM;
            List<string> pendidikan = new List<string> {"SD", "SMP", "SMA", "Perguruan Tinggi" };
            cmbPendidikan.DataSource = pendidikan;
            List<string> pekerjaan = new List<string> {"PNS", "SWASTA", "TNI", "POLRI", "PELAJAR", "MAHASISWA", "Lain-Lain" };
            cmbPekerjaan.DataSource = pekerjaan;
            SetFieldToDefault();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text != "" && txtNoKTP.Text != "" && txtAlamat.Text != "" && txtNoSIM.Text != "" && txtTempatLahir.Text != "")
            {
                dataSIM.NomorSIM = txtNoSIM.Text;
                dataSIM.Golongan = cmbGolongan.Text;
                dataSIM.TanggalBuat = Convert.ToDateTime(dtpTanggalPembuatan.Text);
                dataSIM.Pemilik.Nama = txtNama.Text;
                dataSIM.Pemilik.Pekerjaan = cmbPekerjaan.Text;
                dataSIM.Pemilik.Pendidikan = cmbPendidikan.Text;
                dataSIM.Pemilik.TempatLahir = txtTempatLahir.Text;
                dataSIM.Pemilik.Alamat = txtAlamat.Text;
                dataSIM.Pemilik.TanggalLahir = Convert.ToDateTime(dtpTanggalLahir.Text);
                dataSIM.Pemilik.JenisKelamin = cmbJenisKelamin.Text;
                dataSIM.Pemilik.NomorKTP = txtNoKTP.Text;
                dataSIM.TanggalHabis = new DateTime(dataSIM.TanggalBuat.Year + 5, dataSIM.TanggalBuat.Month, dataSIM.TanggalBuat.Day);
                if (dataSIM.isValidate())
                {
                    dataSIM.Save(dataSIM);
                    MessageBox.Show("Data Berhasil Disimpan");
                    SetFieldToDefault();
                }
                else
                {
                    MessageBox.Show("Umur Pendaftar Belum Cukup");
                    ClearObject();
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
        }

        private void ClearObject()
        {
            dataSIM.NomorSIM = "";
            dataSIM.Golongan = "";
            dataSIM.TanggalBuat = Convert.ToDateTime(dtpTanggalPembuatan.Text);
            dataSIM.Pemilik.Nama = "";
            dataSIM.Pemilik.Pekerjaan = "";
            dataSIM.Pemilik.Pendidikan = "";
            dataSIM.Pemilik.TempatLahir = "";
            dataSIM.Pemilik.Alamat = "";
            dataSIM.Pemilik.TanggalLahir = Convert.ToDateTime(dtpTanggalLahir.Text);
            dataSIM.Pemilik.JenisKelamin = "";
            dataSIM.Pemilik.NomorKTP = "";
            dataSIM.TanggalHabis = DateTime.Now;
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
        }

        private void txtNoKTP_Leave(object sender, EventArgs e)
        {
            datapenduduk = ExcelHelper.CheckPenduduk(txtNoKTP.Text);
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
        }
    }
}
