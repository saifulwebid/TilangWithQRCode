using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class Penduduk
    {
        public string Alamat { get; set; }
        public EnumJenisKelamin JenisKelamin { get; set; }
        public string Nama { get; set; }
        public string Nomor { get; set; }
        public EnumPekerjaan Pekerjaan { get; set; }
        public EnumPendidikan Pendidikan { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string TempatLahir { get; set; }
        private bool isNew = true;

        /** Constructor **/
        public Penduduk() { }
        public Penduduk(bool FromExcel)
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
        public static List<SIM> GetAllSIM()
        {
            return ExcelHelper.GetAllSIM();
        }
        public static Penduduk IsPresent(string noKTP)
        {
            return ExcelHelper.CheckPenduduk(noKTP);
        }
        public void Save()
        {
            if (isNew == true)
            {
                ExcelHelper.SavePenduduk(this);
                isNew = false;
            }
        }

        public string ConvertTanggalLahir()
        {
            return TanggalLahir.Day.ToString() + TanggalLahir.Month.ToString() + (TanggalLahir.Year - 1900).ToString();
        }

        public static int ConvertPekerjaan(EnumPekerjaan jenis)
        {
            List<EnumPekerjaan> Pekerjaan = Enum.GetValues(typeof(EnumPekerjaan)).Cast<EnumPekerjaan>().ToList(); //convert enum ke list
            return Pekerjaan.IndexOf(jenis) + 1;
        }

        public static int ConvertPendidikan(EnumPendidikan jenis)
        {
            List<EnumPendidikan> Pendidikan = Enum.GetValues(typeof(EnumPekerjaan)).Cast<EnumPendidikan>().ToList();
            return Pendidikan.IndexOf(jenis) + 1;
        }
        public static char ConvertJenisKelamin(EnumJenisKelamin jenis)
        {
            if (jenis == EnumJenisKelamin.Pria) return 'L';
            else return 'P';
        }
    }
}
