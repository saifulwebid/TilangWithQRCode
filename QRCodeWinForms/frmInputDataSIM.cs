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
        
        private SIM additem = new SIM();
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
            else
            {
                MessageBox.Show("Penyimpanan Data SIM Gagal!\nData yang diisi belum lengkap");
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

        private void txtNoKTP_TextChanged(object sender, EventArgs e)
        {/*
            List<SIM> datapemilik = ExcelHelper.GetAllSIM();
            SIM item = new SIM();
            additem.IsNew = true;
            foreach(SIM data in datapemilik)
            {
                if (data.Pemilik.NomorKTP == txtNoKTP.Text)
                {
                    item = data;
                    additem.IsNew = false;
                    break;
                }
            }
            if (!additem.IsNew)
            {
                txtNama.Text = item.Pemilik.Nama;
                txtAlamat.Text = item.Pemilik.Alamat;
                txtTempatLahir.Text = item.Pemilik.TempatLahir;
                dtpTanggalLahir.Text = item.Pemilik.TanggalLahir.ToLongDateString();
                cmbPendidikan.SelectedItem = item.Pemilik.Pendidikan;
                cmbPekerjaan.SelectedItem = item.Pemilik.Pekerjaan;
                cmbJenisKelamin.SelectedItem = item.Pemilik.JenisKelamin;
            }*/
        }
    }
}
