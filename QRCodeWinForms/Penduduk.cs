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
            return ExcelHelper.CekPenduduk(noKTP);
        }
        public void Save()
        {
            if (isNew == true)
            {
                ExcelHelper.SaveDataPenduduk(this);
                isNew = false;
            }
        }
    }
}
