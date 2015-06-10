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
        public void Save(SIM dataSIM)
        {
            if (isNew == true)
            {
                ExcelHelper.SaveDataSIM(dataSIM);
                isNew = false;
            }
        }
        public List<DataPelanggaran> GetAllPelanggaran()
        {
            return ExcelHelper.GetAllPelanggaran();
        }
        public bool isValid()
        {
            if ((_tanggalBuat.Year - _pemilik.TanggalLahir.Year) == 17)
            {
                if (_tanggalBuat.Month == _pemilik.TanggalLahir.Month)
                    return (_tanggalBuat.Day >= _pemilik.TanggalLahir.Day);
                else
                    return (_tanggalBuat.Month > _pemilik.TanggalLahir.Month);
            }
            else
                return (_tanggalBuat.Year - _pemilik.TanggalLahir.Year) > 17;
        }
    }
}
