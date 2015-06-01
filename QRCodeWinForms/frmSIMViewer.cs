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
using System.Diagnostics;

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
            if (tampilSIM.Pemilik.JenisKelamin == EnumJenisKelamin.Pria)
            {
                lblJenisKelamin.Text = "PRIA";
            }
            else if (tampilSIM.Pemilik.JenisKelamin == EnumJenisKelamin.Wanita)
            {
                lblJenisKelamin.Text = "WANITA";
            }
            else
            {
                lblJenisKelamin.Text = "";
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
        /*
        Bitmap memoryImage;
        private void PrintScreenForm() // method untuk capture gambar form 2
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width-20, s.Height-81, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(Location.X+9, Location.Y+31, 0, 0, s);
        }

        private void pdSIM_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage,100,100); //gambar grpahic memoryImage (hasil Capture Form) ke pdSIM
        }
        */
        private void btnCetakSIM_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\View.jpg";
            PrintDialog Print = new PrintDialog();
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(panelSIM.Width, panelSIM.Height);
            panelSIM.DrawToBitmap(image, panelSIM.ClientRectangle);
            image.Save(path);

            var p = new Process();
            p.StartInfo.FileName = path;//pass in or whatever you need
            p.StartInfo.Verb = "Print";
            p.Start();
            /*Modul didapat dari kelompok 2 Project 1*/
        }
    }
}
