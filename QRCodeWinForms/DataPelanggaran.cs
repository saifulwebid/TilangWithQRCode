using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class DataPelanggaran
    {
        private string _alamatWakil;
        private double _angkaPinaltiPelanggaran;
        private string _bankSisaDenda;
        private string _disitaSKDiterbitkanOleh;
        private DateTime _disitaSKMasaBerlaku;
        private string  _disitaSK;
        private bool _isNew;
        private string _jenisKendaraan;
        private string _kesatuan;
        private string _lokasiSidang;
        private string _merekKendaraan;
        private string _namaWakil;
        private string _nomorKendaraan;
        private string _nomorMesinKendaraan;
        private string _nomorRangkaKendaraan;
        private string _nomorRegister;
        private string _nomorTilang;
        private Pasal _pasalPelanggaran = new Pasal();
        private SIM _pelanggar = new SIM();
        private bool _pernyataanHadirSendiri;
        private string _samsatKendaraan;
        private string _umurWakil;
        private DateTime _waktuPelanggaran;
        private DateTime _waktuSidang;
        private string _wilayahHukum;
        private string _satpas;
        private string _lokasiPelanggaran;
        private string _patokanLokasi;
        private string _namaPenyidik;
        private string _pangkatPenyidik;
        private string _tempatPengambilan;
        private DateTime _disitaBukuUjiMasaBerlaku;
        private string _bukuUjiRanmor;
        private string _disitaBukuUjiDiterbitkanOleh;
        private string _tempatSidang;
        private string _banksetorDendaMaksimal;

        public string AlamatWakil
        {
            get { return _alamatWakil; }
            set { _alamatWakil = value; }
        }
        public double AngkaPinaltiPelanggaran
        {
            get { return _angkaPinaltiPelanggaran; }
            set { _angkaPinaltiPelanggaran = value; }
        }
        public string BankSisaDenda
        {
            get { return _bankSisaDenda; }
            set { _bankSisaDenda = value; }
        }
        public string DisitaSK
        {
            get { return _disitaSK; }
            set { _disitaSK = value; }
        }
        public string DisitaSKDiterbitkanOleh
        {
            get { return _disitaSKDiterbitkanOleh; }
            set { _disitaSKDiterbitkanOleh = value; }
        }
        public DateTime DisitaSKMasaBerlaku
        {
            get { return _disitaSKMasaBerlaku; }
            set { _disitaSKMasaBerlaku = value; }
        }
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        public string JenisKendaraan
        {
            get { return _jenisKendaraan; }
            set { _jenisKendaraan = value; }
        }
        public string Kesatuan
        {
            get { return _kesatuan; }
            set { _kesatuan = value; }
        }

        public string LokasiSidang
        {
            get { return _lokasiSidang; }
            set { _lokasiSidang = value; }
        }
        public string LokasiPelanggaran
        {
            get { return _lokasiPelanggaran; }
            set { _lokasiPelanggaran = value; }
        }
        public string MerekKendaraan
        {
            get { return _merekKendaraan; }
            set { _merekKendaraan = value; }
        }
        public string NamaWakil
        {
            get { return _namaWakil; }
            set { _namaWakil = value; }
        }
        public string NamaPenyidik
        {
            get { return _namaPenyidik; }
            set { _namaPenyidik = value; }
        }
        public string NomorKendaraan
        {
            get { return _nomorKendaraan; }
            set { _nomorKendaraan = value; }
        }
        public string NomorMesinKendaraan
        {
            get { return _nomorMesinKendaraan; }
            set { _nomorMesinKendaraan = value; }
        }
        public string NomorRangkaKendaraan
        {
            get { return _nomorRangkaKendaraan; }
            set { _nomorRangkaKendaraan = value; }
        }
        public string NomorRegister
        {
            get { return _nomorRegister; }
            set { _nomorRegister = value; }
        }
        public string NomorTilang
        {
            get { return _nomorTilang; }
            set { _nomorTilang = value; }
        }
        public string PangkatPenyidik
        {
            get { return _pangkatPenyidik; }
            set { _pangkatPenyidik = value; }
        }
        public Pasal PasalPelanggaran
        {
            get { return _pasalPelanggaran; }
            set { _pasalPelanggaran = value; }
        }
        public string PatokanLokasi
        {
            get { return _patokanLokasi; }
            set { _patokanLokasi = value; }
        }
        public SIM Pelanggar
        {
            get { return _pelanggar; }
            set { _pelanggar = value; }
        }
        public bool PernyataanHadirSendiri
        {
            get { return _pernyataanHadirSendiri; }
            set { _pernyataanHadirSendiri = value; }
        }
        public string SamsatKendaraan
        {
            get { return _samsatKendaraan; }
            set { _samsatKendaraan = value; }
        }
        public string Satpas
        {
            get { return _satpas; }
            set { _satpas = value; }
        }
        public string TempatPengambilanBarangSita
        {
            get { return _tempatPengambilan; }
            set { _tempatPengambilan = value; }
        }
        public string TempatSidang
        {
            get { return _tempatSidang; }
            set { _tempatSidang = value; }
        }
        public string UmurWakil
        {
            get { return _umurWakil; }
            set { _umurWakil = value; }
        }
        public DateTime WaktuPelanggaran
        {
            get { return _waktuPelanggaran; }
            set { _waktuPelanggaran = value; }
        }
        public DateTime WaktuSidang
        {
            get { return _waktuSidang; }
            set { _waktuSidang = value; }
        }
        public string WilayahHukum
        {
            get { return _wilayahHukum; }
            set { _wilayahHukum = value; }
        }
        public string DisitaBukuUji
        {
            get { return _bukuUjiRanmor; }
            set { _bukuUjiRanmor = value; }
        }
        public string DisitaBukuUjiDiterbitkanOleh
        {
            get { return _disitaBukuUjiDiterbitkanOleh; }
            set { _disitaBukuUjiDiterbitkanOleh = value; }
        }
        public DateTime DisitaBukuUjiMasaBerlaku
        {
            get { return _disitaBukuUjiMasaBerlaku; }
            set { _disitaBukuUjiMasaBerlaku = value; }
        }
        public string BankSetorDendaMaksimal
        {
            get { return _banksetorDendaMaksimal; }
            set { _banksetorDendaMaksimal = value; }
        }

        public void Save(DataPelanggaran dapel)
        {
            ExcelHelper.SavePelanggaran(dapel);
        }
    }
}
