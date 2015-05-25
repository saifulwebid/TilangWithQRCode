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

        private void btnGenerateSim_Click(object sender, EventArgs e)
        {
            frmInputDataSIM fInputDataSIM = new frmInputDataSIM();
            fInputDataSIM.ShowDialog();
        }

        private void btnSuratTilang_Click(object sender, EventArgs e)
        {
            frmInputSuratTilang fSuratTilang = new frmInputSuratTilang();
            fSuratTilang.ShowDialog();
        }

        private void btnBanyakPelanggaran_Click(object sender, EventArgs e)
        {
            frmBanyakPelanggaran fBanyakPelanggaran = new frmBanyakPelanggaran();
            fBanyakPelanggaran.ShowDialog();
        }

        private void btnStatistik_Click(object sender, EventArgs e)
        {
            frmStatistikPelanggaran fStatistik = new frmStatistikPelanggaran();
            fStatistik.ShowDialog();
        }
    }
}
