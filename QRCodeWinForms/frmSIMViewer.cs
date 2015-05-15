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
            lblNama.Text = tampilSIM.Nama;
            lblAlamat.Text = tampilSIM.Alamat;
            lblTempatLahir.Text = tampilSIM.TempatLahir;
            lblTanggalLahir.Text = tampilSIM.TanggalLahir.ToLongDateString();
            lblPendidikan.Text = tampilSIM.Pendidikan;
            lblPekerjaan.Text = tampilSIM.Pekerjaan;
            lblNoSIM.Text = tampilSIM.NomorSIM;
            lblMasaBerlaku.Text = "10 Maret 2018 (edit)";
        }
    }
}
