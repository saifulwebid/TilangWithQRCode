using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;

namespace QRCodeWinForms
{
    class ExcelHelper
    {
        public class ExcelHelper
        {
            static List<SIM> GetAllSIM()
            {
                const string fileName = "data\\DataGabungan.xlsm";
                const int startRow = 1;

                string folder = Assembly.GetEntryAssembly().Location;
                if (folder != null)
                {
                    folder = Path.GetDirectoryName(folder);
                    string filePath = Path.Combine(folder, fileName);
                    List<SIM> listDataSIM = new List<SIM>();

                    var existingFile = new FileInfo(filePath);
                    using (var package = new ExcelPackage(existingFile))
                    {
                        ExcelWorkbook workBook = package.Workbook;

                        if (workBook != null)
                        {
                            if (workBook.Worksheets.Count > 0)
                            {
                                ExcelWorksheet currentWorksheet = workBook.Worksheets[1];

                                object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                                object col2Header = currentWorksheet.Cells[startRow, 2].Value;
                                object col3Header = currentWorksheet.Cells[startRow, 3].Value;
                                object col4Header = currentWorksheet.Cells[startRow, 4].Value;
                                object col5Header = currentWorksheet.Cells[startRow, 5].Value;
                                object col6Header = currentWorksheet.Cells[startRow, 6].Value;
                                object col7Header = currentWorksheet.Cells[startRow, 7].Value;
                                object col8Header = currentWorksheet.Cells[startRow, 8].Value;

                                if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                                    (col5Header != null) && (col6Header != null) && (col7Header != null) && (col8Header != null))
                                {
                                    for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                                    {
                                        object col1Value = currentWorksheet.Cells[rowNumber, 1].Value;
                                        object col2Value = currentWorksheet.Cells[rowNumber, 2].Value;
                                        object col3Value = currentWorksheet.Cells[rowNumber, 3].Value;
                                        object col4Value = currentWorksheet.Cells[rowNumber, 4].Value;
                                        object col5Value = currentWorksheet.Cells[rowNumber, 5].Value;
                                        object col6Value = currentWorksheet.Cells[rowNumber, 6].Value;
                                        object col7Value = currentWorksheet.Cells[rowNumber, 7].Value;
                                        object col8Value = currentWorksheet.Cells[rowNumber, 8].Value;

                                        if ((col1Value != null) && (col2Value != null) && (col3Value != null) && (col4Value != null)
                                             && (col5Value != null) && (col6Value != null) && (col7Value != null) && (col8Value != null))
                                        {
                                            listDataSIM.Add(new SIM
                                            {
                                                Golongan = col1Value.ToString(),
                                                Nama = col2Value.ToString(),
                                                TempatLahir = col3Value.ToString(),
                                                TanggalLahir = Convert.ToDateTime(col4Value),
                                                Alamat = col5Value.ToString(),
                                                Pekerjaan = col6Value.ToString(),
                                                Pendidikan = col7Value.ToString(),
                                                JenisKelamin = col8Value.ToString()
                                            });
                                        }
                                    }
                                }
                            }
                        }
                        return listDataSIM;
                    }
                }
                return null;
            }
            static void SaveDataSIM(SIM dataSIM)
            {
                const string fileName = "data\\DataGabungan.xlsm";
                const int startRow = 1;

                string folder = Assembly.GetEntryAssembly().Location;
                if (folder != null)
                {
                    folder = Path.GetDirectoryName(folder);
                    string filePath = Path.Combine(folder, fileName);

                    var existingFile = new FileInfo(filePath);
                    using (var package = new ExcelPackage(existingFile))
                    {
                        ExcelWorkbook workBook = package.Workbook;

                        if (workBook != null)
                        {
                            if (workBook.Worksheets.Count > 0)
                            {
                                ExcelWorksheet currentWorksheet = workBook.Worksheets[1];

                                object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                                object col2Header = currentWorksheet.Cells[startRow, 2].Value;
                                object col3Header = currentWorksheet.Cells[startRow, 3].Value;
                                object col4Header = currentWorksheet.Cells[startRow, 4].Value;
                                object col5Header = currentWorksheet.Cells[startRow, 5].Value;
                                object col6Header = currentWorksheet.Cells[startRow, 6].Value;
                                object col7Header = currentWorksheet.Cells[startRow, 7].Value;
                                object col8Header = currentWorksheet.Cells[startRow, 8].Value;

                                if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                                    (col5Header != null) && (col6Header != null) && (col7Header != null) && (col8Header != null))
                                {
                                    int rowNumber = currentWorksheet.Dimension.End.Row;
                                    currentWorksheet.Cells[rowNumber, 1].Value = dataSIM.Golongan;
                                    currentWorksheet.Cells[rowNumber, 2].Value = dataSIM.Nama;
                                    currentWorksheet.Cells[rowNumber, 3].Value = dataSIM.TempatLahir;
                                    currentWorksheet.Cells[rowNumber, 4].Value = dataSIM.TanggalLahir;
                                    currentWorksheet.Cells[rowNumber, 5].Value = dataSIM.Alamat;
                                    currentWorksheet.Cells[rowNumber, 6].Value = dataSIM.Pekerjaan;
                                    currentWorksheet.Cells[rowNumber, 7].Value = dataSIM.Pendidikan;
                                    currentWorksheet.Cells[rowNumber, 8].Value = dataSIM.JenisKelamin;
                                }
                            }
                        }
                        package.Save();
                    }
                }
            }
            static void SaveDataPelanggaran(DataPelanggaran dapel)
            {

            }

        }
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
        }
        public class SIM : Penduduk
        {
            private string _golongan;
            private string _nomor;
            private Penduduk _pemilik;
            private DateTime _tanggalBuat;
            private DateTime _tanggalHabis;
            private bool _isNew;

            public string Golongan
            {
                get { return _golongan; }
                set { _golongan = value; }
            }
            public string Nomor
            {
                get { return _nomor; }
                set { _nomor = value; }
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
        public class DataPelanggaran : SIM
        {
            private string _alamatWakil;
            private double _angkaPinaltiPelanggaran;
            private string _bankSetoranDendaMaksimal;
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
            private string _nomorKendaraan;
            private string _nomorMesinKendaraan;
            private string _nomorRangkaKendaraan;
            private string _nomorRegister;
            private string _nomorTilang;
            private Pasal _pasalPelanggaran;
            private SIM _pelanggar;
            private bool _pernyataanHadirSendiri;
            private string _samsatKendaraan;
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
            public string BankSetoranDendaMaksimal
            {
                get { return _bankSetoranDendaMaksimal; }
                set { _bankSetoranDendaMaksimal = value; }
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
        public class Pasal
        {
            private double _dendaMaksimal;
            private string _keterangan;
            private string _nomorPasal;
            private bool _isNew;

            public double DendaMaksimal
            {
                get { return _dendaMaksimal; }
                set { _dendaMaksimal = value; }
            }
            public string Keterangan
            {
                get { return _keterangan; }
                set { _keterangan = value; }
            }
            public string NomorPasal
            {
                get { return _nomorPasal; }
                set { _nomorPasal = value; }
            }
            public bool IsNew
            {
                get { return _isNew; }
                set { _isNew = value; }
            }
        }
    }
}
