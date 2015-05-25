using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class Penduduk
    {
        private string _nomorKTP;
        private string _nama;
        private string _tempatLahir;
        private DateTime _tanggalLahir;
        private string _alamat;
        private string _pekerjaan;
        private string _pendidikan;
        private string _jk;
        private bool _status;

        public Penduduk()
        { }

        public Penduduk(string noktp, string nama, string tmptlahir, DateTime tgllahir, string alamat, string pkrjn, string penddkn, string jnskelamin, bool status)
        {
            _nomorKTP = noktp;
            _nama = nama;
            _tempatLahir = tmptlahir;
            _tanggalLahir = tgllahir;
            _alamat = alamat;
            _pekerjaan = pkrjn;
            _pendidikan = penddkn;
            _jk = jnskelamin;
            _status = status;
        }

        public string NomorKTP
        {
            get { return _nomorKTP; }
            set { _nomorKTP = value; }
        }
        public string Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        public string TempatLahir
        {
            get { return _tempatLahir; }
            set { _tempatLahir = value; }
        }
        public DateTime TanggalLahir
        {
            get { return _tanggalLahir; }
            set { _tanggalLahir = value; }
        }
        public string Alamat
        {
            get { return _alamat; }
            set { _alamat = value; }
        }
        public string Pekerjaan
        {
            get { return _pekerjaan; }
            set { _pekerjaan = value; }
        }
        public string Pendidikan
        {
            get { return _pendidikan; }
            set { _pendidikan = value; }
        }
        public string JenisKelamin
        {
            get { return _jk; }
            set { _jk = value; }
        }
        public bool isNew
        {
            get { return _status; }
            set { _status = value; }
        }
        public List<Penduduk> GetAllPenduduk()
        {
            return ExcelHelper.GetAllPenduduk();
        }
        public List<SIM> GetAllSIM()
        {
            return ExcelHelper.GetAllSIM();
        }
    }
}
