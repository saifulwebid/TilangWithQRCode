﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;

namespace QRCodeWinForms
{
    class ExcelHelper
    {
        public static List<SIM> GetAllSIM()
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
                                            Pemilik = new Penduduk
                                            {
                                                Nama = col2Value.ToString(),
                                                TempatLahir = col3Value.ToString(),
                                                TanggalLahir = Convert.ToDateTime(col4Value),
                                                Alamat = col5Value.ToString(),
                                                Pekerjaan = col6Value.ToString(),
                                                Pendidikan = col7Value.ToString(),
                                                JenisKelamin = col8Value.ToString()
                                            }
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
        public static void SaveDataSIM(SIM dataSIM)
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
        public static void SaveDataPelanggaran(DataPelanggaran dapel)
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
                            ExcelWorksheet currentWorksheet = workBook.Worksheets[2];

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
                            object col40Header = currentWorksheet.Cells[startRow, 40].Value;
                            object col41Header = currentWorksheet.Cells[startRow, 41].Value;
                            object col42Header = currentWorksheet.Cells[startRow, 42].Value;
                            object col43Header = currentWorksheet.Cells[startRow, 43].Value;

                            if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                                (col5Header != null) && (col6Header != null) && (col7Header != null) && (col8Header != null)
                                && (col9Header != null) && (col10Header != null) && (col11Header != null) && (col12Header != null)
                                && (col13Header != null) && (col14Header != null) && (col15Header != null) && (col16Header != null)
                                && (col17Header != null) && (col18Header != null) && (col19Header != null) && (col20Header != null)
                                && (col21Header != null) && (col22Header != null) && (col23Header != null) && (col24Header != null)
                                && (col25Header != null) && (col26Header != null) && (col27Header != null) && (col28Header != null)
                                && (col29Header != null) && (col30Header != null) && (col31Header != null) && (col32Header != null)
                                && (col33Header != null) && (col34Header != null) && (col35Header != null) && (col36Header != null)
                                && (col37Header != null) && (col38Header != null) && (col39Header != null) && (col40Header != null)
                                && (col41Header != null) && (col42Header != null) && (col43Header != null))
                            {
                                int rowNumber = currentWorksheet.Dimension.End.Row;
                                currentWorksheet.Cells[rowNumber, 1].Value = dapel.WaktuPelanggaran;
                                currentWorksheet.Cells[rowNumber, 2].Value = dapel.NomorRegister;
                                currentWorksheet.Cells[rowNumber, 3].Value = dapel.Kesatuan;
                                currentWorksheet.Cells[rowNumber, 4].Value = dapel.NomorTilang;
                                currentWorksheet.Cells[rowNumber, 5].Value = dapel.Pelanggar.Pemilik.Nama;
                                currentWorksheet.Cells[rowNumber, 6].Value = dapel.Pelanggar.Pemilik.JenisKelamin;
                                currentWorksheet.Cells[rowNumber, 7].Value = dapel.Pelanggar.Pemilik.Alamat;
                                currentWorksheet.Cells[rowNumber, 8].Value = dapel.Pelanggar.Pemilik.Pekerjaan;
                                currentWorksheet.Cells[rowNumber, 9].Value = dapel.Pelanggar.Pemilik.Pendidikan;
                                currentWorksheet.Cells[rowNumber, 10].Value = dapel.Pelanggar.Pemilik.TempatLahir;
                                currentWorksheet.Cells[rowNumber, 11].Value = dapel.Pelanggar.Pemilik.TanggalLahir;
                                currentWorksheet.Cells[rowNumber, 12].Value = dapel.Pelanggar.Golongan;
                                currentWorksheet.Cells[rowNumber, 13].Value = dapel.Pelanggar.Pemilik.NomorKTP;
                                currentWorksheet.Cells[rowNumber, 14].Value = dapel.Pelanggar.NomorSIM;
                                //currentWorksheet.Cells[rowNumber, 15].Value = dapel.SATPAS;
                                currentWorksheet.Cells[rowNumber, 16].Value = dapel.NomorRegister;
                                currentWorksheet.Cells[rowNumber, 17].Value = dapel.SamsatKendaraan;
                                currentWorksheet.Cells[rowNumber, 18].Value = dapel.JenisKendaraan;
                                currentWorksheet.Cells[rowNumber, 19].Value = dapel.MerekKendaraan;
                                currentWorksheet.Cells[rowNumber, 20].Value = dapel.NOKA;
                                currentWorksheet.Cells[rowNumber, 21].Value = dapel.NOSIN;
                                //currentWorksheet.Cells[rowNumber, 22].Value = dapel.LokasiPelanggaran;
                                //currentWorksheet.Cells[rowNumber, 23].Value = dapel.PatokanLokasi;
                                currentWorksheet.Cells[rowNumber, 24].Value = dapel.WilayahHukum;
                                currentWorksheet.Cells[rowNumber, 25].Value = dapel.DisitaRanmor;
                                currentWorksheet.Cells[rowNumber, 26].Value = dapel.DisitaDiterbitkanOleh;
                                currentWorksheet.Cells[rowNumber, 27].Value = dapel.DisitaMasaBerlaku;
                                currentWorksheet.Cells[rowNumber, 28].Value = dapel.WaktuSidang.Day;
                                currentWorksheet.Cells[rowNumber, 29].Value = dapel.WaktuSidang.Date;
                                currentWorksheet.Cells[rowNumber, 30].Value = dapel.WaktuSidang.Hour;
                                //currentWorksheet.Cells[rowNumber, 31].Value = dapel.NamaPenyidik;
                                //currentWorksheet.Cells[rowNumber, 32].Value = dapel.PangkatPenyidik;
                                //currentWorksheet.Cells[rowNumber, 33].Value = dapel.KesatuanPenyidik;
                                //currentWorksheet.Cells[rowNumber, 34].Value = dapel.TempatPengambilan;
                                currentWorksheet.Cells[rowNumber, 35].Value = dapel.PasalPelanggaran.NomorPasal;
                                currentWorksheet.Cells[rowNumber, 36].Value = dapel.PasalPelanggaran.DendaMaksimal;
                                currentWorksheet.Cells[rowNumber, 37].Value = dapel.JumlahUangTitipan;
                                currentWorksheet.Cells[rowNumber, 38].Value = dapel.AngkaPinaltiPelanggaran;
                                //currentWorksheet.Cells[rowNumber, 39].Value = dapel.PernyataanPelanggar;
                                currentWorksheet.Cells[rowNumber, 40].Value = dapel.NamaWakil;
                                currentWorksheet.Cells[rowNumber, 41].Value = dapel.UmurWakil;
                                currentWorksheet.Cells[rowNumber, 42].Value = dapel.AlamatWakil;
                                currentWorksheet.Cells[rowNumber, 43].Value = dapel.BankSisaDenda;
                            }
                        }
                    }
                    package.Save();
                }
            }
        }
    }
}