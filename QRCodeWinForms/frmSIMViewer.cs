using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

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
            lblMasaBerlaku.Text = tampilSIM.TanggalHabis.ToLongDateString();
            if (tampilSIM.Pemilik.JenisKelamin == "Laki-Laki")
            {
                lblJenisKelamin.Text = "PRIA";
            }
            else
            {
                lblJenisKelamin.Text = "WANITA";
            }

            GenerateQrCode();
        }

        void GenerateQrCode()
        {
            /*  Isi dari qrcode,Revisi lagi dibagian ini nanti */
            string input = tampilSIM.Pemilik.NomorKTP + '#' + tampilSIM.NomorSIM + '#' + tampilSIM.Golongan + '#' + tampilSIM.Pemilik.Nama + '#' + tampilSIM.Pemilik.TempatLahir + '#' + tampilSIM.Pemilik.TanggalLahir + '#' + tampilSIM.Pemilik.Alamat + '#' + tampilSIM.Pemilik.Pekerjaan + '#' + tampilSIM.Pemilik.Pendidikan + '#' + tampilSIM.Pemilik.JenisKelamin;
            
            /*Generate qr code dari input ke picturebox*/
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.M); //ECC Level merupakan error correction
            pictureBox2.BackgroundImage = qrCode.GetGraphic(10); //10 adalah besar pixel dari qr code
        }
    }
}
