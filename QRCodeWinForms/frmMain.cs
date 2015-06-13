﻿using System;
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
        private User loggedInUser = null;
        private string databasePath = null;

        public User LoggedInUser
        {
            get { return loggedInUser; }
            set
            {
                loggedInUser = value;

                /* Setiap ada perubahan pada User yang disimpan di properti ini,
                 * pastikan seluruh menu yang ada di frmMain diperiksa ulang sesuai
                 * dengan jenis User yang masuk ke dalam properti ini.
                 */
                InitializeMenuVisibility();
            }
        }
        public string DatabasePath
        {
            get { return databasePath; }
            set
            {
                databasePath = value;
                ExcelHelper.FileName = value;

                /* Jika database di-close, maka User otomatis logout. */
                if (value == null)
                    loggedInUser = null;

                InitializeMenuVisibility();
            }
        }
        
        public frmMain()
        {
            InitializeComponent();
            InitializeMenuVisibility();
        }

        private void InitializeMenuVisibility()
        {
            bool DatabaseLoaded = (databasePath != null);
            bool LoggedIn = (loggedInUser != null);
            bool SebagaiSamsat = LoggedIn && (loggedInUser.Jenis == EnumJenisUser.Samsat);
            bool SebagaiPolantas = LoggedIn && (loggedInUser.Jenis == EnumJenisUser.Polantas);
            bool SebagaiJaksa = LoggedIn && (loggedInUser.Jenis == EnumJenisUser.Jaksa);
            
            /** Menu Aplikasi **/
            bukaDatabaseToolStripMenuItem.Enabled = !DatabaseLoaded;
            tutupDatabaseToolStripMenuItem.Enabled = !bukaDatabaseToolStripMenuItem.Enabled;
            loginToolStripMenuItem.Enabled = DatabaseLoaded && !LoggedIn;
            logoutToolStripMenuItem.Enabled = DatabaseLoaded && !loginToolStripMenuItem.Enabled;
            // manajemen user

            /** Menu SIM **/
            buatSIMToolStripMenuItem.Enabled = SebagaiSamsat;

            /** Menu Surat Tilang **/
            buatSuratTilangToolStripMenuItem.Enabled = SebagaiPolantas;

            /** Menu Rekapitulasi **/
            statistikPerOrangToolStripMenuItem.Enabled = SebagaiJaksa;
            statistikUmumToolStripMenuItem.Enabled = SebagaiPolantas;

            /** Top-Level Menu **/
            sIMToolStripMenuItem.Enabled = buatSIMToolStripMenuItem.Enabled;
            suratTilangToolStripMenuItem.Enabled = buatSuratTilangToolStripMenuItem.Enabled;
            rekapitulasiToolStripMenuItem.Enabled = 
                statistikPerOrangToolStripMenuItem.Enabled ||
                statistikUmumToolStripMenuItem.Enabled;
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

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin fLogin = new frmLogin();
            fLogin.MdiParent = this;
            fLogin.Show();
        }
    }
}
