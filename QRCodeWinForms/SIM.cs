using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class SIM
    {
        public string Golongan { get; set; }
        public string Nomor { get; set; }
        public Penduduk Pemilik { get; set; }
        public DateTime TanggalBuat { get; set; }
        public DateTime TanggalHabis { get; set; }
        private bool isNew = true;

        /** Constructor **/
        public SIM() { }
        public SIM(bool FromExcel)
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
        public SIM(string QRData)
        {
            string[] field = QRData.Split('#'); 
            //Isi field pada class SIM
            Nomor = field[1];
            Golongan = field[2];
            
            //Isi field-field pada class Penduduk
            Penduduk pdk = new Penduduk(true);
            pdk.Nomor = field[0];
            pdk.Nama = field[3];
            pdk.TempatLahir = field[4];
            pdk.TanggalLahir = Penduduk.ToTanggalLahir(field[5]);
            pdk.Alamat = field[6];
            pdk.Pekerjaan = Penduduk.ToPekerjaan(Convert.ToInt16(field[7]));
            pdk.Pendidikan = Penduduk.ToPendidikan(Convert.ToInt16(field[8]));
            pdk.JenisKelamin = Penduduk.ToJenisKelamin(field[9]);
            Pemilik = pdk;
            isNew = false;
        }
        
        /** Method **/
        public string GenerateQRData()
        {
            string[] result = 
            {
                Pemilik.Nomor, Nomor, Golongan, Pemilik.Nama, Pemilik.TempatLahir,
                Pemilik.ConvertTanggalLahir(), Pemilik.Alamat, Penduduk.ConvertPekerjaan(Pemilik.Pekerjaan).ToString(), 
                Penduduk.ConvertPendidikan(Pemilik.Pendidikan).ToString(), Penduduk.ConvertJenisKelamin(Pemilik.JenisKelamin).ToString()
            };
            return string.Join("#", result);
        }
        public static List<Pelanggaran> GetAllPelanggaran()
        {
            return ExcelHelper.GetAllPelanggaran();
        }

        public static List<SIM> GetAll()
        {
            return ExcelHelper.GetAllSIM();
        }
        public void Save()
        {
            if (isNew == true)
            {
                this.Pemilik.Save();

                ExcelHelper.SaveSIM(this);
                isNew = false;
            }
        }
        
        public bool isValid()
        {
            if ((TanggalBuat.Year - Pemilik.TanggalLahir.Year) == 17)
            {
                if (TanggalBuat.Month == Pemilik.TanggalLahir.Month)
                    return (TanggalBuat.Day >= Pemilik.TanggalLahir.Day);
                else
                    return (TanggalBuat.Month > Pemilik.TanggalLahir.Month);
            }
            else
                return (TanggalBuat.Year - Pemilik.TanggalLahir.Year) > 17;
        }
    }
}
