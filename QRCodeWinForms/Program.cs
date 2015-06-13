using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace QRCodeWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string fileName = "data\\DataGabungan.xlsx";
            string folder = Assembly.GetEntryAssembly().Location;
            if (folder != null)
            {
                folder = Path.GetDirectoryName(folder);
                string filePath = Path.Combine(folder, fileName);

                ExcelHelper.FileName = filePath;
            }

            Application.Run(new frmMain());
            
        }
    }
}
