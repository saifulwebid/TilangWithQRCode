using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.Versioning;

namespace QRCodeWinForms
{
    public partial class frmSuratTilang : Form
    {
        public frmSuratTilang()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void rbtDenda500K_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSuratTilang_Load(object sender, EventArgs e)
        {
            cbxPekerjaan.DropDownStyle = ComboBoxStyle.DropDown;
            cbxPekerjaan.Items.Add("PNS");
            cbxPekerjaan.Items.Add("SWASTA");
            cbxPekerjaan.Items.Add("TNI");
            cbxPekerjaan.Items.Add("POLRI");
            cbxPekerjaan.Items.Add("PELAJAR");
            cbxPekerjaan.Items.Add("MHS");

            cbxPendidikan.Items.Add("SD");
            cbxPendidikan.Items.Add("SLTP");
            cbxPendidikan.Items.Add("SLTA");
            cbxPendidikan.Items.Add("PT");
        }

        private void TampilData()
        {
            string ResultString = "3277032811798239#791151586708#A#UTOM#PANGKAL PINANG#281179#Komp.DPRD No.1/3 Ciwaruga Bandung#2#3#L";
            string[] Split = ResultString.Split('#');
            try
            {
                txtNamaPelanggar.Text = Split[3];
                txtAlamatPelanggar.Text = Split[6];
                txtNoKTPPelanggar.Text = Split[0];
                txtNoSIM.Text = Split[1];
                txtTempatPelanggar.Text = Split[4];
                txtGolSIM.Text = Split[2];
                txtTanggalLahir.Text = Convert.ToString(Convert.ToDateTime(DateTime.ParseExact(Split[5],"dd MMMM yyyy",CultureInfo.InvariantCulture)));
                if (Split[9] == "L")
                {
                    rbtLK.Checked = true;
                }
                else
                { rbtPR.Checked = true; }
              //  switch (Split[6])
               // {
                 //   case "1" :   cbxPekerjaan.Text 
                //}
              //  DateTime ttl = DateTime.ParseExact(Split[5], "ddmmyyyy", CultureInfo.InvariantCulture);
               // txtUmurPelanggar.Text = Convert.ToString(ConvertUmur(ttl));

                
            }
            catch
            {
                MessageBox.Show("QR Code tidak bisa dibaca!");
            }
        }

        private void btnScanQRCode_Click(object sender, EventArgs e)
        {
            TampilData();
        }

        private static int ConvertUmur(DateTime ttl)
       {
            DateTime currentdate = new DateTime();
            currentdate = DateTime.Today;
            int age =   currentdate.Year - ttl.Year;
            if (ttl > currentdate.AddYears(-age)) age--;
            return age;

        }

    }
}
