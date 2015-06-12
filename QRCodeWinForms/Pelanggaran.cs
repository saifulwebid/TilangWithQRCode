using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class Pelanggaran
    {
        public string AlamatWakil { get; set; }
        public int AngkaPinaltiPelanggaran { get; set; } // double/integer?
        public string BankSetoranDendaMaksimal { get; set; } // BankSetoranDendaMaksimal ?
        public string BankSisaDenda { get; set; }
        public int DisitaBukuUji { get; set; } // Bitstring --> Integer ?
        public string DisitaBukuUjiDiterbitkanOleh { get; set; }
        public DateTime DisitaBukuUjiMasaBerlaku { get; set; }
        public int DisitaSK { get; set; } // Bitstring --> Integer ?
        public string DisitaSKDiterbitkanOleh { get; set; }
        public DateTime DisitaSKMasaBerlaku { get; set; }
        public string JenisKendaraan { get; set; }
        public string Kesatuan { get; set; }
        public string LokasiPelanggaran { get; set; }
        public string LokasiSidang { get; set; }
        public string MerekKendaraan { get; set; }
        public string NamaPenyidik { get; set; }
        public string NamaWakil { get; set; }
        public string NomorKendaraan { get; set; }
        public string NomorMesinKendaraan { get; set; }
        public string NomorRangkaKendaraan { get; set; }
        public string NomorRegister { get; set; }
        public string NomorTilang { get; set; }
        public string PangkatPenyidik { get; set; }
        public Pasal PasalPelanggaran { get; set; }
        public string PatokanLokasi { get; set; }
        public SIM Pelanggar { get; set; }
        public bool PernyataanHadirSendiri { get; set; }
        public string SamsatKendaraan { get; set; }
        public string Satpas { get; set; }
        public string TempatPengambilanBarangSita { get; set; }
        public string TempatSidang { get; set; }
        public string UmurWakil { get; set; }
        public DateTime WaktuPelanggaran { get; set; }
        public DateTime WaktuSidang { get; set; }
        public string WilayahHukum { get; set; }
        private bool isNew = true;

        /** Constructor **/
        public Pelanggaran() { }
        public Pelanggaran(bool FromExcel)
        {
            if (FromExcel == true)
            {
                isNew = false;
            }
            else
            {
                isNew = true;
            }
        }

        /** Methods **/
        public static List<Pelanggaran> GetAll()
        {
            return ExcelHelper.GetAllPelanggaran();
        }
        public void Save()
        {
            if (isNew == true)
            {
                ExcelHelper.SavePelanggaran(this);
                isNew = false;
            }
        }
    }
}
