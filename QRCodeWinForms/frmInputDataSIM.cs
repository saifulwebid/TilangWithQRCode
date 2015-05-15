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

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            additem.NomorSIM = txtNoSIM.Text;
            additem.Golongan = txtGolongan.Text;
            additem.TanggalBuat = Convert.ToDateTime(dtpTanggalPembuatan);
            additem.Pemilik.Nama = txtNama.Text;
            additem.Pemilik.Pekerjaan = txtPekerjaan.Text;
            additem.Pemilik.Pendidikan = txtPendidikan.Text;
            additem.Pemilik.TempatLahir = txtTempatLahir.Text;
            additem.Pemilik.Alamat = txtAlamat.Text;
            additem.Pemilik.TanggalLahir = Convert.ToDateTime(dtpTanggalLahir);
            additem.Pemilik.JenisKelamin = txtJenisKelamin.Text;
            additem.Pemilik.NomorKTP = txtNoKTP.Text;
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            
            frmSIMViewer f2 = new frmSIMViewer(additem);
            f2.ShowDialog();
        }
    }
}
