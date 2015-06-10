using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class Pasal
    {
        public double Pidana { get; set; }
        public double DendaMaksimal { get; set; }
        public string Keterangan { get; set; }
        public string Nomor { get; set; }

        /** Method **/
        public static List<Pasal> GetAllPasal()
        {
            return ExcelHelper.GetAllPasal();
        }

        /**
         * Mengembalikan seluruh pelanggaran yang terkait dengan pasal ini.
         * Sebagai contoh, jika this.Nomor = "182", maka this.GetAllPelanggaran()
         * akan mengembalikan seluruh DataPelanggaran yang terkait dengan Pasal 182.
         **/
        public List<DataPelanggaran> GetAllPelanggaran()
        {
            // TODO: Fix this.
            return ExcelHelper.GetAllPelanggaran();
        }
    }
}
