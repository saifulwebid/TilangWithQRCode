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
        public frmSIMViewer()
        {
            InitializeComponent();
        }

        private void SIMViewer_Load(object sender, EventArgs e)
        {
            lblNama.Text = "ANDRE FEBRIANTO";
            lblAlamat.Text = "Jalan Mahoni I no. D8 Lagadar Margaasih";
            lblTempatLahir.Text = "Bandung";
            lblTanggalLahir.Text = "10 Februari 1996";
            lblPendidikan.Text = "Mahasiswa";
            lblPekerjaan.Text = "Pelajar";
            lblNoSIM.Text = "960213310073";
            lblMasaBerlaku.Text = "10 Maret 2018";
            
        }
    }
}
