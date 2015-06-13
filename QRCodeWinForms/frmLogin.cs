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

        public void ClearText()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = User.Check(txtUsername.Text, txtPassword.Text);

            if (user == null) // User tidak ditemukan
            {
                MessageBox.Show("Username atau password salah!", "Login gagal", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                // TODO : Set agar frmMain dalam status "Logged In".
                // frmMain harus dikirimi instance "user" untuk status.
                throw new NotImplementedException();

                ClearText();
                this.Close();
            }
        }
    }
}
