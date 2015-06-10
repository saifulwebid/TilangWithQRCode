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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (User.Check(txtUsername.Text, txtPassword.Text) == null)
            {
                MessageBox.Show("Data tidak ditemukan !");
            }
            else
            {
                this.Hide();
                frmMain f2 = new frmMain();
                f2.ShowDialog();
                this.Show();
                ClearText();
                
            }
        }

        public void ClearText()
        {
            txtPassword.Text = "Password";
            txtUsername.Text = "Username";
        }
    }
}
