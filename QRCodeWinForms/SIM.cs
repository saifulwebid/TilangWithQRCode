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
        private Penduduk _pemilik;
        private DateTime _tanggalBuat;
        private DateTime _tanggalHabis;
        private bool _isNew;

        public SIM()
        { }

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
    }
}
