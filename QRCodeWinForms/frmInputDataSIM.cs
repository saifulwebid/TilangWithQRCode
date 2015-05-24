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
        
        SIM additem = new SIM();
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
            additem.NomorSIM = txtNoSIM.Text;
            additem.Golongan = cmbGolongan.Text;
            additem.TanggalBuat = Convert.ToDateTime(dtpTanggalPembuatan.Text);
            additem.Pemilik.Nama = txtNama.Text;
            additem.Pemilik.Pekerjaan = cmbPekerjaan.Text;
            additem.Pemilik.Pendidikan = cmbPendidikan.Text;
            additem.Pemilik.TempatLahir = txtTempatLahir.Text;
            additem.Pemilik.Alamat = txtAlamat.Text;
            additem.Pemilik.TanggalLahir = Convert.ToDateTime(dtpTanggalLahir.Text);
            additem.Pemilik.JenisKelamin = cmbJenisKelamin.Text;
            additem.Pemilik.NomorKTP = txtNoKTP.Text;
            additem.TanggalHabis = new DateTime(additem.TanggalBuat.Year + 5, additem.TanggalBuat.Month, additem.TanggalBuat.Day);
            if (additem.isValidate())
            {
                additem.Save(additem);
                MessageBox.Show("Data Berhasil Disimpan");
                SetFieldToDefault();
            }
            else
            {
                MessageBox.Show("Umur Pendaftar Belum Cukup");
                ClearObject();
            }
            
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            
            frmSIMViewer f2 = new frmSIMViewer(additem);
            f2.ShowDialog();
        }

        private void ClearObject()
        {
            additem.NomorSIM = "";
            additem.Golongan = "";
            additem.TanggalBuat = Convert.ToDateTime(dtpTanggalPembuatan.Text);
            additem.Pemilik.Nama = "";
            additem.Pemilik.Pekerjaan = "";
            additem.Pemilik.Pendidikan = "";
            additem.Pemilik.TempatLahir = "";
            additem.Pemilik.Alamat = "";
            additem.Pemilik.TanggalLahir = Convert.ToDateTime(dtpTanggalLahir.Text);
            additem.Pemilik.JenisKelamin = "";
            additem.Pemilik.NomorKTP = "";
            additem.TanggalHabis = DateTime.Now;
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
    }
}
