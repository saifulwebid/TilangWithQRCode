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
        public static string FileName = "";
        private const int startRow = 1;

        /** Methods **/
        public static void SaveAccount(User acc)
        {
            FileInfo existingFile = new FileInfo(FileName);
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
                        object col3Header = currentWorksheet.Cells[startRow, 3].Value;

                        if ((col1Header != null) && (col2Header != null) && (col3Header != null))
                        {
                            int rowNumber = currentWorksheet.Dimension.End.Row + 1;
                            currentWorksheet.Cells[rowNumber, 1].Value = acc.Username;
                            currentWorksheet.Cells[rowNumber, 2].Value = acc.Password;
                            switch (acc.Jenis)
                            {
                                case EnumJenisUser.Jaksa: currentWorksheet.Cells[rowNumber, 3].Value = "Jaksa"; break;
                                case EnumJenisUser.Polantas: currentWorksheet.Cells[rowNumber, 3].Value = "Polantas"; break;
                                case EnumJenisUser.Samsat: currentWorksheet.Cells[rowNumber, 3].Value = "Samsat"; break;
                            }
                        }
                    }
                }
                package.Save();
            }
        }

        public static User CheckUser(string username, string password)
        {
            User acc = new User();

            FileInfo existingFile = new FileInfo(FileName);
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
                                        switch (col3Value.ToString())
                                        {
                                            case "Jaksa": acc.Jenis = EnumJenisUser.Jaksa; break;
                                            case "Polantas": acc.Jenis = EnumJenisUser.Polantas; break;
                                            case "Samsat": acc.Jenis = EnumJenisUser.Samsat; break;
                                        };
                                        return acc;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static Penduduk CheckPenduduk(string ktp)
        {
            Penduduk pdd = new Penduduk();

            FileInfo existingFile = new FileInfo(FileName);
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
                                    if (col1Value.Equals(ktp))
                                    {
                                        pdd.Nomor = col1Value.ToString();
                                        pdd.Nama = col2Value.ToString();
                                        pdd.TempatLahir = col3Value.ToString();
                                        pdd.TanggalLahir = Convert.ToDateTime(col4Value);
                                        pdd.Alamat = col5Value.ToString();

                                        switch (col6Value.ToString())
                                        {
                                            case "Lainnya":
                                                pdd.Pekerjaan = EnumPekerjaan.Lainnya;
                                                break;
                                            case "Mahasiswa":
                                                pdd.Pekerjaan = EnumPekerjaan.Mahasiswa;
                                                break;
                                            case "Pelajar":
                                                pdd.Pekerjaan = EnumPekerjaan.Pelajar;
                                                break;
                                            case "PNS":
                                                pdd.Pekerjaan = EnumPekerjaan.PNS;
                                                break;
                                            case "POLRI":
                                                pdd.Pekerjaan = EnumPekerjaan.POLRI;
                                                break;
                                            case "Swasta":
                                                pdd.Pekerjaan = EnumPekerjaan.Swasta;
                                                break;
                                            case "TNI":
                                                pdd.Pekerjaan = EnumPekerjaan.TNI;
                                                break;
                                        }

                                        switch (col7Value.ToString())
                                        {
                                            case "PT":
                                                pdd.Pendidikan = EnumPendidikan.PT;
                                                break;
                                            case "SD":
                                                pdd.Pendidikan = EnumPendidikan.SD;
                                                break;
                                            case "SMA":
                                                pdd.Pendidikan = EnumPendidikan.SMA;
                                                break;
                                            case "SMP":
                                                pdd.Pendidikan = EnumPendidikan.SMP;
                                                break;
                                        }

                                        if (col8Value.ToString() == "Pria")
                                            pdd.JenisKelamin = EnumJenisKelamin.Pria;
                                        else if (col8Value.ToString() == "Wanita")
                                            pdd.JenisKelamin = EnumJenisKelamin.Wanita;

                                        return pdd;
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
            List<Penduduk> listDataPenduduk = new List<Penduduk>();

            FileInfo existingFile = new FileInfo(FileName);
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
                                    Penduduk pdk = new Penduduk();
                                    pdk.Nomor = col1Value.ToString();
                                    pdk.Nama = col2Value.ToString();
                                    pdk.TempatLahir = col3Value.ToString();
                                    pdk.TanggalLahir = Convert.ToDateTime(col4Value);
                                    pdk.Alamat = col5Value.ToString();

                                    switch (col6Value.ToString())
                                    {
                                        case "Lainnya":
                                            pdk.Pekerjaan = EnumPekerjaan.Lainnya;
                                            break;
                                        case "Mahasiswa":
                                            pdk.Pekerjaan = EnumPekerjaan.Mahasiswa;
                                            break;
                                        case "Pelajar":
                                            pdk.Pekerjaan = EnumPekerjaan.Pelajar;
                                            break;
                                        case "PNS":
                                            pdk.Pekerjaan = EnumPekerjaan.PNS;
                                            break;
                                        case "POLRI":
                                            pdk.Pekerjaan = EnumPekerjaan.POLRI;
                                            break;
                                        case "Swasta":
                                            pdk.Pekerjaan = EnumPekerjaan.Swasta;
                                            break;
                                        case "TNI":
                                            pdk.Pekerjaan = EnumPekerjaan.TNI;
                                            break;
                                    }

                                    switch (col7Value.ToString())
                                    {
                                        case "PT":
                                            pdk.Pendidikan = EnumPendidikan.PT;
                                            break;
                                        case "SD":
                                            pdk.Pendidikan = EnumPendidikan.SD;
                                            break;
                                        case "SMA":
                                            pdk.Pendidikan = EnumPendidikan.SMA;
                                            break;
                                        case "SMP":
                                            pdk.Pendidikan = EnumPendidikan.SMP;
                                            break;
                                    }

                                    if (col8Value.ToString() == "Pria")
                                        pdk.JenisKelamin = EnumJenisKelamin.Pria;
                                    else if (col8Value.ToString() == "Wanita")
                                        pdk.JenisKelamin = EnumJenisKelamin.Wanita;

                                    listDataPenduduk.Add(pdk);
                                }
                            }
                        }
                    }
                }
                return listDataPenduduk;
            }
            return null;
        }

        public static void SavePenduduk(Penduduk pdd)
        {
            FileInfo existingFile = new FileInfo(FileName);
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
                            int rowNumber = currentWorksheet.Dimension.End.Row + 1;
                            currentWorksheet.Cells[rowNumber, 1].Value = pdd.Nomor;
                            currentWorksheet.Cells[rowNumber, 2].Value = pdd.Nama;
                            currentWorksheet.Cells[rowNumber, 3].Value = pdd.TempatLahir;
                            currentWorksheet.Cells[rowNumber, 4].Value = pdd.TanggalLahir;
                            currentWorksheet.Cells[rowNumber, 5].Value = pdd.Alamat;
                            currentWorksheet.Cells[rowNumber, 6].Value = pdd.Pekerjaan;
                            currentWorksheet.Cells[rowNumber, 7].Value = pdd.Pendidikan;
                            currentWorksheet.Cells[rowNumber, 8].Value = pdd.JenisKelamin;
                        }
                    }
                }
                package.Save();
            }
        }

        public static List<SIM> GetAllSIM()
        {
            List<SIM> listDataSIM = new List<SIM>();
            List<Penduduk> ListPenduduk = GetAllPenduduk();

            FileInfo existingFile = new FileInfo(FileName);
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
                                    sim.Nomor = col2Value.ToString();
                                    sim.Golongan = col3Value.ToString();
                                    sim.TanggalBuat = Convert.ToDateTime(col4Value);
                                    sim.TanggalHabis = Convert.ToDateTime(col5Value);

                                    foreach (Penduduk pdd in ListPenduduk)
                                    {
                                        if (pdd.Nomor.Equals(col1Value))
                                        {
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
            return null;
        }

        public static void SaveSIM(SIM dataSIM)
        {
            FileInfo existingFile = new FileInfo(FileName);
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
                            int rowNumber = currentWorksheet.Dimension.End.Row + 1;
                            currentWorksheet.Cells[rowNumber, 1].Value = dataSIM.Pemilik.Nomor;
                            currentWorksheet.Cells[rowNumber, 2].Value = dataSIM.Nomor;
                            currentWorksheet.Cells[rowNumber, 3].Value = dataSIM.Golongan;
                            currentWorksheet.Cells[rowNumber, 4].Value = dataSIM.TanggalBuat;
                            currentWorksheet.Cells[rowNumber, 5].Value = dataSIM.TanggalHabis;
                        }
                    }
                }
                package.Save();
            }
        }

        public static List<Pasal> GetAllPasal()
        {
            List<Pasal> listDataPasal = new List<Pasal>();

            FileInfo existingFile = new FileInfo(FileName);
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
                                    Pasal psl = new Pasal();

                                    psl.Nomor = col1Value.ToString();
                                    psl.Keterangan = col2Value.ToString();
                                    psl.Pidana = Convert.ToDouble(col3Value);
                                    psl.DendaMaksimal = Convert.ToDouble(col4Value);

                                    listDataPasal.Add(psl);
                                }
                            }
                        }
                    }
                }
                return listDataPasal;
            }
            return null;
        }

        public static void SavePelanggaran(Pelanggaran dapel)
        {
            FileInfo existingFile = new FileInfo(FileName);
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

                        if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                            (col5Header != null) && (col6Header != null) && (col7Header != null) && (col8Header != null)
                            && (col9Header != null) && (col10Header != null) && (col11Header != null) && (col12Header != null)
                            && (col13Header != null) && (col14Header != null) && (col15Header != null) && (col16Header != null)
                            && (col17Header != null) && (col18Header != null) && (col19Header != null) && (col20Header != null)
                            && (col21Header != null) && (col22Header != null) && (col23Header != null) && (col24Header != null)
                            && (col25Header != null) && (col26Header != null) && (col27Header != null) && (col28Header != null)
                            && (col29Header != null) && (col30Header != null) && (col31Header != null) && (col32Header != null)
                            && (col33Header != null) && (col34Header != null) && (col35Header != null) && (col36Header != null)
                            && (col37Header != null))
                        {
                            int rowNumber = currentWorksheet.Dimension.End.Row + 1;
                            currentWorksheet.Cells[rowNumber, 1].Value = dapel.WaktuPelanggaran;
                            currentWorksheet.Cells[rowNumber, 2].Value = dapel.NomorRegister;
                            currentWorksheet.Cells[rowNumber, 3].Value = dapel.Kesatuan;
                            currentWorksheet.Cells[rowNumber, 4].Value = dapel.NomorTilang;
                            currentWorksheet.Cells[rowNumber, 5].Value = dapel.Pelanggar.Nomor;
                            currentWorksheet.Cells[rowNumber, 6].Value = dapel.Satpas;
                            currentWorksheet.Cells[rowNumber, 7].Value = dapel.NomorKendaraan;
                            currentWorksheet.Cells[rowNumber, 8].Value = dapel.SamsatKendaraan;
                            currentWorksheet.Cells[rowNumber, 9].Value = dapel.JenisKendaraan;
                            currentWorksheet.Cells[rowNumber, 10].Value = dapel.MerekKendaraan;
                            currentWorksheet.Cells[rowNumber, 11].Value = dapel.NomorRangkaKendaraan;
                            currentWorksheet.Cells[rowNumber, 12].Value = dapel.NomorMesinKendaraan;
                            currentWorksheet.Cells[rowNumber, 13].Value = dapel.LokasiPelanggaran;
                            currentWorksheet.Cells[rowNumber, 14].Value = dapel.PatokanLokasi;
                            currentWorksheet.Cells[rowNumber, 15].Value = dapel.WilayahHukum;
                            currentWorksheet.Cells[rowNumber, 16].Value = dapel.DisitaSK;
                            currentWorksheet.Cells[rowNumber, 17].Value = dapel.DisitaSKDiterbitkanOleh;
                            currentWorksheet.Cells[rowNumber, 18].Value = dapel.DisitaSKMasaBerlaku;
                            currentWorksheet.Cells[rowNumber, 19].Value = dapel.DisitaBukuUji;
                            currentWorksheet.Cells[rowNumber, 20].Value = dapel.DisitaBukuUjiDiterbitkanOleh;
                            currentWorksheet.Cells[rowNumber, 21].Value = dapel.DisitaBukuUjiMasaBerlaku;
                            currentWorksheet.Cells[rowNumber, 22].Value = dapel.LokasiSidang;
                            currentWorksheet.Cells[rowNumber, 23].Value = dapel.WaktuSidang.Day;
                            currentWorksheet.Cells[rowNumber, 24].Value = dapel.WaktuSidang.Date;
                            currentWorksheet.Cells[rowNumber, 25].Value = dapel.WaktuSidang.Hour;
                            currentWorksheet.Cells[rowNumber, 26].Value = dapel.NamaPenyidik;
                            currentWorksheet.Cells[rowNumber, 27].Value = dapel.PangkatPenyidik;
                            currentWorksheet.Cells[rowNumber, 28].Value = dapel.TempatPengambilanBarangSita;
                            currentWorksheet.Cells[rowNumber, 29].Value = dapel.PasalPelanggaran.Nomor;
                            currentWorksheet.Cells[rowNumber, 30].Value = dapel.PasalPelanggaran.DendaMaksimal;
                            currentWorksheet.Cells[rowNumber, 31].Value = dapel.BankSetoranDendaMaksimal;
                            currentWorksheet.Cells[rowNumber, 32].Value = dapel.AngkaPinaltiPelanggaran;
                            currentWorksheet.Cells[rowNumber, 33].Value = dapel.PernyataanHadirSendiri;
                            currentWorksheet.Cells[rowNumber, 34].Value = dapel.NamaWakil;
                            currentWorksheet.Cells[rowNumber, 35].Value = dapel.UmurWakil;
                            currentWorksheet.Cells[rowNumber, 36].Value = dapel.AlamatWakil;
                            currentWorksheet.Cells[rowNumber, 37].Value = dapel.BankSisaDenda;
                        }
                    }
                }
                package.Save();
            }
        }

        public static List<Pelanggaran> GetAllPelanggaran()
        {
            List<Pelanggaran> listDataPelanggaran = new List<Pelanggaran>();

            FileInfo existingFile = new FileInfo(FileName);
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

                        if ((col1Header != null) && (col2Header != null) && (col3Header != null) && (col4Header != null) &&
                            (col5Header != null) && (col6Header != null) && (col7Header != null) && (col8Header != null)
                            && (col9Header != null) && (col10Header != null) && (col11Header != null) && (col12Header != null)
                            && (col13Header != null) && (col14Header != null) && (col15Header != null) && (col16Header != null)
                            && (col17Header != null) && (col18Header != null) && (col19Header != null) && (col20Header != null)
                            && (col21Header != null) && (col22Header != null) && (col23Header != null) && (col24Header != null)
                            && (col25Header != null) && (col26Header != null) && (col27Header != null) && (col28Header != null)
                            && (col29Header != null) && (col30Header != null) && (col31Header != null) && (col32Header != null)
                            && (col33Header != null) && (col34Header != null) && (col35Header != null) && (col36Header != null)
                            && (col37Header != null))
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

                                Pelanggaran pelanggaran = new Pelanggaran();
                                pelanggaran.WaktuPelanggaran = DateTime.FromOADate((double)col1Value);
                                pelanggaran.NomorRegister = col2Value.ToString();
                                pelanggaran.Kesatuan = col3Value.ToString();
                                pelanggaran.NomorTilang = col4Value.ToString();
                                pelanggaran.Satpas = col6Value.ToString();
                                pelanggaran.NomorKendaraan = col7Value.ToString();
                                pelanggaran.SamsatKendaraan = col8Value.ToString();
                                pelanggaran.JenisKendaraan = col9Value.ToString();
                                pelanggaran.MerekKendaraan = col10Value.ToString();
                                pelanggaran.NomorRangkaKendaraan = col11Value.ToString();
                                pelanggaran.NomorMesinKendaraan = col12Value.ToString();
                                pelanggaran.LokasiPelanggaran = col13Value.ToString();
                                pelanggaran.PatokanLokasi = col14Value.ToString();
                                pelanggaran.WilayahHukum = col15Value.ToString();
                                pelanggaran.DisitaSK = Convert.ToInt16(col16Value);
                                pelanggaran.DisitaSKDiterbitkanOleh = col17Value.ToString();
                                pelanggaran.DisitaSKMasaBerlaku = DateTime.FromOADate((double)col18Value);
                                pelanggaran.DisitaBukuUji = Convert.ToInt16(col19Value);
                                pelanggaran.DisitaBukuUjiDiterbitkanOleh = col20Value.ToString();
                                pelanggaran.DisitaBukuUjiMasaBerlaku = DateTime.FromOADate((double)col21Value);
                                pelanggaran.TempatSidang = col22Value.ToString();
                                //WaktuSidang 23
                                //24
                                //25
                                pelanggaran.NamaPenyidik = col26Value.ToString();
                                pelanggaran.PangkatPenyidik = col27Value.ToString();
                                pelanggaran.TempatPengambilanBarangSita = col28Value.ToString();
                                //PernyataanHadirSendiri = Convert.ToBoolean(col31Value),
                                //32
                                //33
                                pelanggaran.NamaWakil = col34Value.ToString();
                                pelanggaran.UmurWakil = col35Value.ToString();
                                pelanggaran.AlamatWakil = col36Value.ToString();
                                pelanggaran.BankSisaDenda = col37Value.ToString();

                                SIM pelanggar = new SIM();
                                pelanggar.Nomor = col5Value.ToString();
                                pelanggaran.Pelanggar = pelanggar;

                                Pasal pasal = new Pasal();
                                pasal.Nomor = col29Value.ToString();
                                //pasal.DendaMaksimal = Convert.ToDouble(col30Value);
                                // pasal.IsNew = false; -- tidak ada properti isNew di Pasal
                                pelanggaran.PasalPelanggaran = pasal;

                                listDataPelanggaran.Add(pelanggaran);
                            }
                        }
                    }
                }
                return listDataPelanggaran;
            }
            return null;
        }
    }
}
