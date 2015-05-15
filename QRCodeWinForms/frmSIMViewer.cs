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
    public partial class frmSIMViewer : Form
    {
        SIM tampilSIM;
        public frmSIMViewer()
        {
            InitializeComponent();
        }

        public frmSIMViewer(SIM additem)
        {
            InitializeComponent();
            tampilSIM = additem;
        }

        private void SIMViewer_Load(object sender, EventArgs e)
        {
            lblNama.Text = tampilSIM.Pemilik.Nama;
            lblAlamat.Text = tampilSIM.Pemilik.Alamat;
            lblTempatLahir.Text = tampilSIM.Pemilik.TempatLahir;
            lblTanggalLahir.Text = tampilSIM.Pemilik.TanggalLahir.ToLongDateString();
            lblPendidikan.Text = tampilSIM.Pemilik.Pendidikan;
            lblPekerjaan.Text = tampilSIM.Pemilik.Pekerjaan;
            lblNoSIM.Text = tampilSIM.NomorSIM;
            lblGolongan.Text = tampilSIM.Golongan;
            lblMasaBerlaku.Text = "10 Maret 2018 (edit)";
            if (tampilSIM.Pemilik.JenisKelamin == "Laki-Laki")
            {
                lblJenisKelamin.Text = "PRIA";
            }
            else
            {
                lblJenisKelamin.Text = "WANITA";
            }
        }
    }
}
