using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class SIM
    {
        private string _golongan;
        private string _nomorSIM;
        private Penduduk _pemilik = new Penduduk();
        private DateTime _tanggalBuat;
        private DateTime _tanggalHabis;
        private bool _isNew;

        public SIM()
        {  }

        public SIM(string gol, string noSIM, Penduduk pemilik, DateTime tanggalbuat, bool status)
        {
            _golongan = gol;
            _nomorSIM = noSIM;
            _pemilik = pemilik;
            _tanggalBuat = tanggalbuat;
            _isNew = status;
            //_tanggalHabis = _tanggalBuat;
        }
        public string Golongan
        {
            get { return _golongan; }
            set { _golongan = value; }
        }
        public string NomorSIM
        {
            get { return _nomorSIM; }
            set { _nomorSIM = value; }
        }
        public Penduduk Pemilik
        {
            get { return _pemilik; }
            set { _pemilik = value; }
        }
        public DateTime TanggalBuat
        {
            get { return _tanggalBuat; }
            set { _tanggalBuat = value; }
        }
        public DateTime TanggalHabis
        {
            get { return _tanggalHabis; }
            set { _tanggalHabis = value; }
        }
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        public void Save(SIM dataSIM)
        {
            ExcelHelper.SaveDataSIM(dataSIM);
        }
        public List<DataPelanggaran> GetAllPelanggaran()
        {
            return ExcelHelper.GetAllPelanggaran();
        }
        public bool isValidate()
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
