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
            additem.TanggalHabis = new DateTime(additem.TanggalBuat.Year + 5, additem.TanggalBuat.Date.Month, additem.TanggalBuat.Date.Day);
            if (additem.isValidate())
            {
                additem.Save(additem);
                MessageBox.Show("Data Berhasil Disimpan");
                txtNoKTP.Text = "";
                txtNama.Text = "";
                txtAlamat.Text = "";
                txtTempatLahir.Text = "";
                txtNoSIM.Text = "";
            }
            else
            {
                MessageBox.Show("Umur Pendaftar Belum Cukup");
            }
            
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            
            frmSIMViewer f2 = new frmSIMViewer(additem);
            f2.ShowDialog();
        }
    }
}
