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
        
        /** Method **/
        public void Save()
        {
            if (isNew == true)
            {
                ExcelHelper.SaveSIM(this);
                isNew = false;
            }
        }
        public List<DataPelanggaran> GetAllPelanggaran()
        {
            return ExcelHelper.GetAllPelanggaran();
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
