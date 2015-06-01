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
        public static Account AccountCheck(string username, string password)
        {
            const string fileName = "data\\DataGabungan.xlsx";
            const int startRow = 1;

            string folder = Assembly.GetEntryAssembly().Location;
            if (folder != null)
            {
                folder = Path.GetDirectoryName(folder);
                string filePath = Path.Combine(folder, fileName);
                Account acc = new Account();

                var existingFile = new FileInfo(filePath);
                using (var package = new ExcelPackage(existingFile))
                {
                    ExcelWorkbook workBook = package.Workbook;

                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            ExcelWorksheet currentWorksheet = workBook.Worksheets[5];

                            object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                            object col2Header = currentWorksheet.Cells[startRow, 2].Value;

                            if ((col1Header != null) && (col2Header != null))
                            {
                                for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                                {
                                    object col1Value = currentWorksheet.Cells[rowNumber, 1].Value;
                                    object col2Value = currentWorksheet.Cells[rowNumber, 2].Value;
                                    object col3Value = currentWorksheet.Cells[rowNumber, 3].Value;

                                    if ((col1Value != null) && (col2Value != null) && (col3Value != null))
                                    {
                                        if ((username.Equals(col1Value) == true) && password.Equals(col2Value) == true)
                                        {
                                            acc.Username = col1Value.ToString();
                                            //acc.JenisAkun = col3Value.ToString();
                                            return acc;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        public static List<Penduduk> GetAllPenduduk()
        {
            const string fileName = "data\\DataGabungan.xlsx";
            const int startRow = 1;

            string folder = Assembly.GetEntryAssembly().Location;
            if (folder != null)
            {
                folder = Path.GetDirectoryName(folder);
                string filePath = Path.Combine(folder, fileName);
                List<Penduduk> listDataPenduduk = new List<Penduduk>();

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
                                        listDataPenduduk.Add(new Penduduk
                                        {
                                            NomorKTP = col1Value.ToString(),
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
                    return listDataPenduduk;
                }
            }
            return null;
        }
        public static List<SIM> GetAllSIM()
        {
            const string fileName = "data\\DataGabungan.xlsx";
            const int startRow = 1;

            string folder = Assembly.GetEntryAssembly().Location;
            if (folder != null)
            {
                folder = Path.GetDirectoryName(folder);
                string filePath = Path.Combine(folder, fileName);
                List<SIM> listDataSIM = new List<SIM>();
                List<Penduduk> ListPenduduk = GetAllPenduduk();

                var existingFile = new FileInfo(filePath);
                using (var package = new ExcelPackage(existingFile))
                {
                    ExcelWorkbook workBook = package.Workbook;

                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            ExcelWorksheet currentWorksheet = workBook.Worksheets[2];

                            object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                            object col2Header = currentWorksheet.Cells[startRow, 2].Value;
                            object col3Header = currentWorksheet.Cells[startRow, 3].Value;
                            object col4Header = currentWorksheet.Cells[startRow, 4].Value;
                            object col5Header = currentWorksheet.Cells[startRow, 5].Value;

                            if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                                (col5Header != null))
                            {
                                for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                                {
                                    object col1Value = currentWorksheet.Cells[rowNumber, 1].Value;
                                    object col2Value = currentWorksheet.Cells[rowNumber, 2].Value;
                                    object col3Value = currentWorksheet.Cells[rowNumber, 3].Value;
                                    object col4Value = currentWorksheet.Cells[rowNumber, 4].Value;
                                    object col5Value = currentWorksheet.Cells[rowNumber, 5].Value;

                                    if ((col1Value != null) && (col2Value != null) && (col3Value != null) && (col4Value != null)
                                         && (col5Value != null))
                                    {
                                        SIM sim = new SIM();
                                        sim.NomorSIM = col2Value.ToString();
                                        sim.Golongan = col3Value.ToString();
                                        sim.TanggalBuat = Convert.ToDateTime(col4Value);
                                        sim.TanggalHabis = Convert.ToDateTime(col5Value);

                                        foreach(Penduduk pdd in ListPenduduk) {
                                            if (pdd.NomorKTP.Equals(col1Value)) {
                                                sim.Pemilik = pdd;
                                                break;
                                            }
                                        }
                                        listDataSIM.Add(sim);
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
        public static void SaveDataSIM(SIM dataSIM)
        {
            const string fileName = "data\\DataGabungan.xlsx";
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
                            ExcelWorksheet currentWorksheet = workBook.Worksheets[2];

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
                                int rowNumber = currentWorksheet.Dimension.End.Row + 1;
                                currentWorksheet.Cells[rowNumber, 1].Value = dataSIM.Golongan;
                                currentWorksheet.Cells[rowNumber, 2].Value = dataSIM.Pemilik.Nama;
                                currentWorksheet.Cells[rowNumber, 3].Value = dataSIM.Pemilik.TempatLahir;
                                currentWorksheet.Cells[rowNumber, 4].Value = dataSIM.Pemilik.TanggalLahir;
                                currentWorksheet.Cells[rowNumber, 5].Value = dataSIM.Pemilik.Alamat;
                                currentWorksheet.Cells[rowNumber, 6].Value = dataSIM.Pemilik.Pekerjaan;
                                currentWorksheet.Cells[rowNumber, 7].Value = dataSIM.Pemilik.Pendidikan;
                                currentWorksheet.Cells[rowNumber, 8].Value = dataSIM.Pemilik.JenisKelamin;
                            }
                        }
                    }
                    package.Save();
                }
            }
        }
        public static List<Pasal> GetAllPasal()
        {
            const string fileName = "data\\DataGabungan.xlsx";
            const int startRow = 1;

            string folder = Assembly.GetEntryAssembly().Location;
            if (folder != null)
            {
                folder = Path.GetDirectoryName(folder);
                string filePath = Path.Combine(folder, fileName);
                List<Pasal> listDataPasal = new List<Pasal>();

                var existingFile = new FileInfo(filePath);
                using (var package = new ExcelPackage(existingFile))
                {
                    ExcelWorkbook workBook = package.Workbook;

                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            ExcelWorksheet currentWorksheet = workBook.Worksheets[4];

                            object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                            object col2Header = currentWorksheet.Cells[startRow, 2].Value;
                            object col3Header = currentWorksheet.Cells[startRow, 3].Value;
                            object col4Header = currentWorksheet.Cells[startRow, 4].Value;

                            if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null))
                            {
                                for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                                {
                                    object col1Value = currentWorksheet.Cells[rowNumber, 1].Value;
                                    object col2Value = currentWorksheet.Cells[rowNumber, 2].Value;
                                    object col3Value = currentWorksheet.Cells[rowNumber, 3].Value;
                                    object col4Value = currentWorksheet.Cells[rowNumber, 4].Value;

                                    if ((col1Value != null) && (col2Value != null) && (col3Value != null) && (col4Value != null))
                                    {
                                        listDataPasal.Add(new Pasal
                                        {
                                            NomorPasal = col1Value.ToString(),
                                            Keterangan = col2Value.ToString(),
                                            Pidana = Convert.ToDouble(col3Value),
                                            DendaMaksimal = Convert.ToDouble(col4Value)
                                        });
                                    }
                                }
                            }
                        }
                    }
                    return listDataPasal;
                }
            }
            return null;
        }
        public static void SaveDataPelanggaran(DataPelanggaran dapel)
        {
            const string fileName = "data\\DataGabungan.xlsx";
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
                            ExcelWorksheet currentWorksheet = workBook.Worksheets[3];

                            object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                            object col2Header = currentWorksheet.Cells[startRow, 2].Value;
                            object col3Header = currentWorksheet.Cells[startRow, 3].Value;
                            object col4Header = currentWorksheet.Cells[startRow, 4].Value;
                            object col5Header = currentWorksheet.Cells[startRow, 5].Value;
                            object col6Header = currentWorksheet.Cells[startRow, 6].Value;
                            object col7Header = currentWorksheet.Cells[startRow, 7].Value;
                            object col8Header = currentWorksheet.Cells[startRow, 8].Value;
                            object col9Header = currentWorksheet.Cells[startRow, 9].Value;
                            object col10Header = currentWorksheet.Cells[startRow, 10].Value;
                            object col11Header = currentWorksheet.Cells[startRow, 11].Value;
                            object col12Header = currentWorksheet.Cells[startRow, 12].Value;
                            object col13Header = currentWorksheet.Cells[startRow, 13].Value;
                            object col14Header = currentWorksheet.Cells[startRow, 14].Value;
                            object col15Header = currentWorksheet.Cells[startRow, 15].Value;
                            object col16Header = currentWorksheet.Cells[startRow, 16].Value;
                            object col17Header = currentWorksheet.Cells[startRow, 17].Value;
                            object col18Header = currentWorksheet.Cells[startRow, 18].Value;
                            object col19Header = currentWorksheet.Cells[startRow, 19].Value;
                            object col20Header = currentWorksheet.Cells[startRow, 20].Value;
                            object col21Header = currentWorksheet.Cells[startRow, 21].Value;
                            object col22Header = currentWorksheet.Cells[startRow, 22].Value;
                            object col23Header = currentWorksheet.Cells[startRow, 23].Value;
                            object col24Header = currentWorksheet.Cells[startRow, 24].Value;
                            object col25Header = currentWorksheet.Cells[startRow, 25].Value;
                            object col26Header = currentWorksheet.Cells[startRow, 26].Value;
                            object col27Header = currentWorksheet.Cells[startRow, 27].Value;
                            object col28Header = currentWorksheet.Cells[startRow, 28].Value;
                            object col29Header = currentWorksheet.Cells[startRow, 29].Value;
                            object col30Header = currentWorksheet.Cells[startRow, 30].Value;
                            object col31Header = currentWorksheet.Cells[startRow, 31].Value;
                            object col32Header = currentWorksheet.Cells[startRow, 32].Value;
                            object col33Header = currentWorksheet.Cells[startRow, 33].Value;
                            object col34Header = currentWorksheet.Cells[startRow, 34].Value;
                            object col35Header = currentWorksheet.Cells[startRow, 35].Value;
                            object col36Header = currentWorksheet.Cells[startRow, 36].Value;
                            object col37Header = currentWorksheet.Cells[startRow, 37].Value;
                            object col38Header = currentWorksheet.Cells[startRow, 38].Value;
                            object col39Header = currentWorksheet.Cells[startRow, 39].Value;

                            if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                                (col5Header != null) && (col6Header != null) && (col7Header != null) && (col8Header != null)
                                && (col9Header != null) && (col10Header != null) && (col11Header != null) && (col12Header != null)
                                && (col13Header != null) && (col14Header != null) && (col15Header != null) && (col16Header != null)
                                && (col17Header != null) && (col18Header != null) && (col19Header != null) && (col20Header != null)
                                && (col21Header != null) && (col22Header != null) && (col23Header != null) && (col24Header != null)
                                && (col25Header != null) && (col26Header != null) && (col27Header != null) && (col28Header != null)
                                && (col29Header != null) && (col30Header != null) && (col31Header != null) && (col32Header != null)
                                && (col33Header != null) && (col34Header != null) && (col35Header != null) && (col36Header != null)
                                && (col37Header != null) && (col38Header != null) && (col39Header != null))
                            {
                                int rowNumber = currentWorksheet.Dimension.End.Row + 1;
                                currentWorksheet.Cells[rowNumber, 1].Value = dapel.WaktuPelanggaran;
                                currentWorksheet.Cells[rowNumber, 2].Value = dapel.NomorRegister;
                                currentWorksheet.Cells[rowNumber, 3].Value = dapel.Kesatuan;
                                currentWorksheet.Cells[rowNumber, 4].Value = dapel.NomorTilang;
                                currentWorksheet.Cells[rowNumber, 5].Value = dapel.Pelanggar.Pemilik.NomorKTP;
                                currentWorksheet.Cells[rowNumber, 6].Value = dapel.Pelanggar.NomorSIM;
                                currentWorksheet.Cells[rowNumber, 7].Value = dapel.SATPAS;
                                currentWorksheet.Cells[rowNumber, 8].Value = dapel.NomorKendaraan;
                                currentWorksheet.Cells[rowNumber, 9].Value = dapel.SamsatKendaraan;
                                currentWorksheet.Cells[rowNumber, 10].Value = dapel.JenisKendaraan;
                                currentWorksheet.Cells[rowNumber, 11].Value = dapel.MerekKendaraan;
                                currentWorksheet.Cells[rowNumber, 12].Value = dapel.NomorRangkaKendaraan;
                                currentWorksheet.Cells[rowNumber, 13].Value = dapel.NomorMesinKendaraan;
                                currentWorksheet.Cells[rowNumber, 14].Value = dapel.LokasiPelanggaran;
                                currentWorksheet.Cells[rowNumber, 15].Value = dapel.PatokanLokasi;
                                currentWorksheet.Cells[rowNumber, 16].Value = dapel.WilayahHukum;
                                currentWorksheet.Cells[rowNumber, 17].Value = dapel.DisitaSKRanmor;
                                currentWorksheet.Cells[rowNumber, 18].Value = dapel.DisitaSKDiterbitkanOleh;
                                currentWorksheet.Cells[rowNumber, 19].Value = dapel.DisitaSKMasaBerlaku;
                                currentWorksheet.Cells[rowNumber, 20].Value = dapel.DisitaBukuUji;
                                currentWorksheet.Cells[rowNumber, 21].Value = dapel.DisitaBukuUjiDiterbitkanOleh;
                                currentWorksheet.Cells[rowNumber, 22].Value = dapel.DisitaBukuUjiMasaBerlaku;
                                currentWorksheet.Cells[rowNumber, 23].Value = dapel.LokasiSidang;
                                currentWorksheet.Cells[rowNumber, 24].Value = dapel.WaktuSidang.Day;
                                currentWorksheet.Cells[rowNumber, 25].Value = dapel.WaktuSidang.Date;
                                currentWorksheet.Cells[rowNumber, 26].Value = dapel.WaktuSidang.Hour;
                                currentWorksheet.Cells[rowNumber, 27].Value = dapel.NamaPenyidik;
                                currentWorksheet.Cells[rowNumber, 28].Value = dapel.PangkatPenyidik;
                                currentWorksheet.Cells[rowNumber, 29].Value = dapel.KesatuanPenyidik;
                                currentWorksheet.Cells[rowNumber, 30].Value = dapel.TempatPengambilanBarangSita;
                                currentWorksheet.Cells[rowNumber, 31].Value = dapel.PasalPelanggaran.NomorPasal;
                                currentWorksheet.Cells[rowNumber, 32].Value = dapel.PasalPelanggaran.DendaMaksimal;
                                currentWorksheet.Cells[rowNumber, 33].Value = dapel.BankSetorDendaMaksimal;
                                currentWorksheet.Cells[rowNumber, 34].Value = dapel.AngkaPinaltiPelanggaran;
                                currentWorksheet.Cells[rowNumber, 35].Value = dapel.PernyataanHadirSendiri;
                                currentWorksheet.Cells[rowNumber, 36].Value = dapel.NamaWakil;
                                currentWorksheet.Cells[rowNumber, 37].Value = dapel.UmurWakil;
                                currentWorksheet.Cells[rowNumber, 38].Value = dapel.AlamatWakil;
                                currentWorksheet.Cells[rowNumber, 39].Value = dapel.BankSisaDenda;
                            }
                        }
                    }
                    package.Save();
                }
            }
        }
        public static List<DataPelanggaran> GetAllPelanggaran()
        {
            const string fileName = "data\\DataGabungan.xlsx";
            const int startRow = 1;

            string folder = Assembly.GetEntryAssembly().Location;
            if (folder != null)
            {
                folder = Path.GetDirectoryName(folder);
                string filePath = Path.Combine(folder, fileName);
                List<DataPelanggaran> listDataPelanggaran = new List<DataPelanggaran>();

                var existingFile = new FileInfo(filePath);
                using (var package = new ExcelPackage(existingFile))
                {
                    ExcelWorkbook workBook = package.Workbook;

                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            ExcelWorksheet currentWorksheet = workBook.Worksheets[3];

                            object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                            object col2Header = currentWorksheet.Cells[startRow, 2].Value;
                            object col3Header = currentWorksheet.Cells[startRow, 3].Value;
                            object col4Header = currentWorksheet.Cells[startRow, 4].Value;
                            object col5Header = currentWorksheet.Cells[startRow, 5].Value;
                            object col6Header = currentWorksheet.Cells[startRow, 6].Value;
                            object col7Header = currentWorksheet.Cells[startRow, 7].Value;
                            object col8Header = currentWorksheet.Cells[startRow, 8].Value;
                            object col9Header = currentWorksheet.Cells[startRow, 9].Value;
                            object col10Header = currentWorksheet.Cells[startRow, 10].Value;
                            object col11Header = currentWorksheet.Cells[startRow, 11].Value;
                            object col12Header = currentWorksheet.Cells[startRow, 12].Value;
                            object col13Header = currentWorksheet.Cells[startRow, 13].Value;
                            object col14Header = currentWorksheet.Cells[startRow, 14].Value;
                            object col15Header = currentWorksheet.Cells[startRow, 15].Value;
                            object col16Header = currentWorksheet.Cells[startRow, 16].Value;
                            object col17Header = currentWorksheet.Cells[startRow, 17].Value;
                            object col18Header = currentWorksheet.Cells[startRow, 18].Value;
                            object col19Header = currentWorksheet.Cells[startRow, 19].Value;
                            object col20Header = currentWorksheet.Cells[startRow, 20].Value;
                            object col21Header = currentWorksheet.Cells[startRow, 21].Value;
                            object col22Header = currentWorksheet.Cells[startRow, 22].Value;
                            object col23Header = currentWorksheet.Cells[startRow, 23].Value;
                            object col24Header = currentWorksheet.Cells[startRow, 24].Value;
                            object col25Header = currentWorksheet.Cells[startRow, 25].Value;
                            object col26Header = currentWorksheet.Cells[startRow, 26].Value;
                            object col27Header = currentWorksheet.Cells[startRow, 27].Value;
                            object col28Header = currentWorksheet.Cells[startRow, 28].Value;
                            object col29Header = currentWorksheet.Cells[startRow, 29].Value;
                            object col30Header = currentWorksheet.Cells[startRow, 30].Value;
                            object col31Header = currentWorksheet.Cells[startRow, 31].Value;
                            object col32Header = currentWorksheet.Cells[startRow, 32].Value;
                            object col33Header = currentWorksheet.Cells[startRow, 33].Value;
                            object col34Header = currentWorksheet.Cells[startRow, 34].Value;
                            object col35Header = currentWorksheet.Cells[startRow, 35].Value;
                            object col36Header = currentWorksheet.Cells[startRow, 36].Value;
                            object col37Header = currentWorksheet.Cells[startRow, 37].Value;
                            object col38Header = currentWorksheet.Cells[startRow, 38].Value;
                            object col39Header = currentWorksheet.Cells[startRow, 39].Value;

                            if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                                (col5Header != null) && (col6Header != null) && (col7Header != null) && (col8Header != null)
                                && (col9Header != null) && (col10Header != null) && (col11Header != null) && (col12Header != null)
                                && (col13Header != null) && (col14Header != null) && (col15Header != null) && (col16Header != null)
                                && (col17Header != null) && (col18Header != null) && (col19Header != null) && (col20Header != null)
                                && (col21Header != null) && (col22Header != null) && (col23Header != null) && (col24Header != null)
                                && (col25Header != null) && (col26Header != null) && (col27Header != null) && (col28Header != null)
                                && (col29Header != null) && (col30Header != null) && (col31Header != null) && (col32Header != null)
                                && (col33Header != null) && (col34Header != null) && (col35Header != null) && (col36Header != null)
                                && (col37Header != null) && (col38Header != null) && (col39Header != null))
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
                                    object col9Value = currentWorksheet.Cells[rowNumber, 9].Value;
                                    object col10Value = currentWorksheet.Cells[rowNumber, 10].Value;
                                    object col11Value = currentWorksheet.Cells[rowNumber, 11].Value;
                                    object col12Value = currentWorksheet.Cells[rowNumber, 12].Value;
                                    object col13Value = currentWorksheet.Cells[rowNumber, 13].Value;
                                    object col14Value = currentWorksheet.Cells[rowNumber, 14].Value;
                                    object col15Value = currentWorksheet.Cells[rowNumber, 15].Value;
                                    object col16Value = currentWorksheet.Cells[rowNumber, 16].Value;
                                    object col17Value = currentWorksheet.Cells[rowNumber, 17].Value;
                                    object col18Value = currentWorksheet.Cells[rowNumber, 18].Value;
                                    object col19Value = currentWorksheet.Cells[rowNumber, 19].Value;
                                    object col20Value = currentWorksheet.Cells[rowNumber, 20].Value;
                                    object col21Value = currentWorksheet.Cells[rowNumber, 21].Value;
                                    object col22Value = currentWorksheet.Cells[rowNumber, 22].Value;
                                    object col23Value = currentWorksheet.Cells[rowNumber, 23].Value;
                                    object col24Value = currentWorksheet.Cells[rowNumber, 24].Value;
                                    object col25Value = currentWorksheet.Cells[rowNumber, 25].Value;
                                    object col26Value = currentWorksheet.Cells[rowNumber, 26].Value;
                                    object col27Value = currentWorksheet.Cells[rowNumber, 27].Value;
                                    object col28Value = currentWorksheet.Cells[rowNumber, 28].Value;
                                    object col29Value = currentWorksheet.Cells[rowNumber, 29].Value;
                                    object col30Value = currentWorksheet.Cells[rowNumber, 30].Value;
                                    object col31Value = currentWorksheet.Cells[rowNumber, 31].Value;
                                    object col32Value = currentWorksheet.Cells[rowNumber, 32].Value;
                                    object col33Value = currentWorksheet.Cells[rowNumber, 33].Value;
                                    object col34Value = currentWorksheet.Cells[rowNumber, 34].Value;
                                    object col35Value = currentWorksheet.Cells[rowNumber, 35].Value;
                                    object col36Value = currentWorksheet.Cells[rowNumber, 36].Value;
                                    object col37Value = currentWorksheet.Cells[rowNumber, 37].Value;
                                    object col38Value = currentWorksheet.Cells[rowNumber, 38].Value;
                                    object col39Value = currentWorksheet.Cells[rowNumber, 39].Value;

                                    listDataPelanggaran.Add(new DataPelanggaran
                                    {
                                        WaktuPelanggaran = DateTime.FromOADate((double) col1Value),
                                        NomorRegister = col2Value.ToString(),
                                        Kesatuan = col3Value.ToString(),
                                        NomorTilang = col4Value.ToString(),
                                        Pelanggar = new SIM
                                        {
                                            Pemilik = new Penduduk
                                            {
                                                NomorKTP = col5Value.ToString(),
                                            },
                                            NomorSIM = col6Value.ToString()
                                        },
                                        SATPAS = col7Value.ToString(),
                                        NomorKendaraan = col8Value.ToString(),
                                        SamsatKendaraan = col9Value.ToString(),
                                        JenisKendaraan = col10Value.ToString(),
                                        MerekKendaraan = col11Value.ToString(),
                                        NomorRangkaKendaraan = col12Value.ToString(),
                                        NomorMesinKendaraan = col13Value.ToString(),
                                        LokasiPelanggaran = col14Value.ToString(),
                                        PatokanLokasi = col15Value.ToString(),
                                        WilayahHukum = col16Value.ToString(),
                                        //17
                                        //18
                                        //19
                                        DisitaBukuUji = col20Value.ToString(),
                                        DisitaBukuUjiDiterbitkanOleh = col21Value.ToString(),
                                        DisitaBukuUjiMasaBerlaku = DateTime.FromOADate((double)col22Value),
                                        TempatSidang = col23Value.ToString(),
                                        //WaktuSidang 24
                                        //25
                                        //26
                                        NamaPenyidik = col27Value.ToString(),
                                        PangkatPenyidik = col28Value.ToString(),
                                        KesatuanPenyidik = col29Value.ToString(),
                                        TempatPengambilanBarangSita = col30Value.ToString(),
                                        PasalPelanggaran = new Pasal
                                        {
                                            NomorPasal = col31Value.ToString(),
                                            DendaMaksimal = Convert.ToDouble(col32Value),
                                            IsNew = false
                                        },
                                        //PernyataanHadirSendiri 33
                                        //34
                                        //35
                                        NamaWakil = col36Value.ToString(),
                                        UmurWakil = col37Value.ToString(),
                                        AlamatWakil = col38Value.ToString(),
                                        BankSisaDenda = col39Value.ToString(),
                                    });
                                    
                                }
                            }
                        }
                    }
                    return listDataPelanggaran;
                }
            }
            return null;
        }
    }
}
