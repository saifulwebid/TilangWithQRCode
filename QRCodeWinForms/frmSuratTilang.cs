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
        string ResultString;
        
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
            cbxPekerjaan.Items.Add("LAINNYA");

            cbxPendidikan.DropDownStyle = ComboBoxStyle.DropDown;
            cbxPendidikan.Items.Add("SD");
            cbxPendidikan.Items.Add("SLTP");
            cbxPendidikan.Items.Add("SLTA");
            cbxPendidikan.Items.Add("PT");
        }

        private void TampilData()
        {
            string[] Split = ResultString.Split('#');
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime parseddate;
            provider = new CultureInfo("id-ID");
            try
            {
                txtNamaPelanggar.Text = Split[3];
                txtAlamatPelanggar.Text = Split[6];
                txtNoKTPPelanggar.Text = Split[0];
                txtNoSIM.Text = Split[1];
                txtTempatPelanggar.Text = Split[4];
                txtGolSIM.Text = Split[2];
                //merubah supaya tanggalnya jadi bukan angka lagi
                if(DateTime.TryParseExact(Split[5],"ddMMyy",null,DateTimeStyles.None,out parseddate)){
                txtTanggalLahir.Text = parseddate.ToString("dd MMMM yyyy",provider);
                }
                txtUmurPelanggar.Text = Convert.ToString(ConvertUmur(parseddate));
                //kolom jenis kelamin
                if (Split[9] == "L")
                {
                    rbtLK.Checked = true;
                }
                else
                { rbtPR.Checked = true; }
                //kolom pekerjaan pelanggar
               switch(Split[7])
                {
                   case "1": cbxPekerjaan.Text = "PNS";
                        break;
                   case "2": cbxPekerjaan.Text = "SWASTA";
                        break;
                   case "3": cbxPekerjaan.Text = "TNI";
                        break;
                   case "4": cbxPekerjaan.Text = "POLRI";
                        break;
                   case "5": cbxPekerjaan.Text = "PELAJAR";
                        break;
                   case "6": cbxPekerjaan.Text = "MHS";
                        break;
                   case "7": cbxPekerjaan.Text = "LAINNYA";
                        break;
                }
                //kolom pendidikan pelanggar
               switch (Split[8])
               {
                   case "1": cbxPendidikan.Text = "SD";
                       break;
                   case "2": cbxPendidikan.Text = "SLTP";
                       break;
                   case "3": cbxPendidikan.Text = "SLTA";
                       break;
                   case "4": cbxPendidikan.Text = "PT";
                       break;
               }                
            }
            catch
            {
                MessageBox.Show("QR Code tidak bisa dibaca!");
            }
        }

        private void btnScanQRCode_Click(object sender, EventArgs e)
        {
            frmScanSIM f2 = new frmScanSIM();
            f2.ShowDialog();
            ResultString = f2.GetData;
            TampilData();
        }

        private static int ConvertUmur(DateTime ttl)
        {
            DateTime currentdate = new DateTime();
            currentdate = DateTime.Today;
            int age;

            if (currentdate.Month >= ttl.Month && currentdate.Date >= ttl.Date)
            {
                return currentdate.Year - ttl.Year + 1;
            }
            else 
            {
                return currentdate.Year - ttl.Year;
            }

        }
    }
}
