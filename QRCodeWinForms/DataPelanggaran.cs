using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class DataPelanggaran : SIM
    {
        private string _alamatWakil;
        private double _angkaPinaltiPelanggaran;
        private string _bankSisaDenda;
        private string _disitaDiterbitkanOleh;
        private int _disitaMasaBerlaku;
        private bool _disitaRanmor;
        private bool _disitaSIM;
        private bool _disitaSTCK;
        private bool _disitaSTNK;
        private string _jenisKendaraan;
        private double _jumlahUangTitipan;
        private string _kesatuan;
        private string _lokasiSidang;
        private string _merekKendaraan;
        private string _namaWakil;
        private string _noka;
        private string _nosin;
        private string _nomorKendaraan;
        private string _nomorMesinKendaraan;
        private string _nomorRangkaKendaraan;
        private string _nomorRegister;
        private string _nomorTilang;
        private Pasal _pasalPelanggaran;
        private SIM _pelanggar;
        private bool _pernyataanHadirSendiri;
        private string _samsatKendaraan;
        private string _umurWakil;
        private DateTime _waktuPelanggaran;
        private DateTime _waktuSidang;
        private string _wilayahHukum;

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
        public string DisitaDiterbitkanOleh
        {
            get { return _disitaDiterbitkanOleh; }
            set { _disitaDiterbitkanOleh = value; }
        }
        public int DisitaMasaBerlaku
        {
            get { return _disitaMasaBerlaku; }
            set { _disitaMasaBerlaku = value; }
        }
        public bool DisitaRanmor
        {
            get { return _disitaRanmor; }
            set { _disitaRanmor = value; }
        }
        public bool DisitaSIM
        {
            get { return _disitaSIM; }
            set { _disitaSIM = value; }
        }
        public bool DisitaSTCK
        {
            get { return _disitaSTCK; }
            set { _disitaSTCK = value; }
        }
        public bool DisitaSTNK
        {
            get { return _disitaSTNK; }
            set { _disitaSTNK = value; }
        }
        public string JenisKendaraan
        {
            get { return _jenisKendaraan; }
            set { _jenisKendaraan = value; }
        }
        public double JumlahUangTitipan
        {
            get { return _jumlahUangTitipan; }
            set { _jumlahUangTitipan = value; }
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
        public string NOKA
        {
            get { return _noka; }
            set { _noka = value; }
        }
        public string NOSIN
        {
            get { return _nosin; }
            set { _nosin = value; }
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
        public Pasal PasalPelanggaran
        {
            get { return _pasalPelanggaran; }
            set { _pasalPelanggaran = value; }
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
    }
}
