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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statistikPerOrangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanyakPelanggaran fBanyakPelanggaran = new frmBanyakPelanggaran();
            fBanyakPelanggaran.MdiParent = this;
            fBanyakPelanggaran.Show();
        }

        private void buatSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInputDataSIM fInputDataSIM = new frmInputDataSIM();
            fInputDataSIM.MdiParent = this;
            fInputDataSIM.Show();
        }

        private void buatSuratTilangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInputSuratTilang fSuratTilang = new frmInputSuratTilang();
            fSuratTilang.MdiParent = this;
            fSuratTilang.Show();
        }

        private void statistikUmumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStatistikPelanggaran fStatistik = new frmStatistikPelanggaran();
            fStatistik.MdiParent = this;
            fStatistik.Show();
        }
    }
}
