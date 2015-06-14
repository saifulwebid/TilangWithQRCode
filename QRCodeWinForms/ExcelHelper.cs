using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;

namespace QRCodeWinForms
{
    static class ExcelHelper
    {
        public static string FileName = "";
        private const int startRow = 1;

        /** Methods **/
        /*public static void SaveAccount(User acc)
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

                        bool valid = true;
                        for (int i = 1; i <= 3; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
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
        }*/

        public static User CheckUser(string username, string password)
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

                        bool valid = true;
                        for (int i = 1; i <= 2; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
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
                                        User acc = new User();
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
            List<Penduduk> list = GetAllPenduduk();

            foreach (Penduduk x in list)
            {
                if (x.Nomor.Equals(ktp))
                {
                    return x;
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

                        bool valid = true;
                        for (int i = 1; i <= 8; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
                        {
                            for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                            {
                                object[] colValue = new object[9];
                                for (int i = 1; i <= 8; i++)
                                {
                                    colValue[i] = currentWorksheet.Cells[rowNumber, i].Value;
                                    valid = valid && (colValue[i] != null);
                                }

                                if (valid)
                                {
                                    Penduduk pdk = new Penduduk(true);
                                    pdk.Nomor = colValue[1].ToString();
                                    pdk.Nama = colValue[2].ToString();
                                    pdk.TempatLahir = colValue[3].ToString();
                                    pdk.TanggalLahir = Convert.ToDateTime(colValue[4]);
                                    pdk.Alamat = colValue[5].ToString();

                                    switch (colValue[6].ToString())
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

                                    switch (colValue[7].ToString())
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

                                    if (colValue[8].ToString() == "Pria")
                                        pdk.JenisKelamin = EnumJenisKelamin.Pria;
                                    else if (colValue[8].ToString() == "Wanita")
                                        pdk.JenisKelamin = EnumJenisKelamin.Wanita;

                                    listDataPenduduk.Add(pdk);
                                }
                            }
                        }
                    }
                }
                return listDataPenduduk;
            }
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

                        bool valid = true;
                        for (int i = 1; i <= 8; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
                        {
                            int rowNumber = currentWorksheet.Dimension.End.Row + 1;
                            currentWorksheet.Cells[rowNumber, 1].Value = pdd.Nomor;
                            currentWorksheet.Cells[rowNumber, 2].Value = pdd.Nama;
                            currentWorksheet.Cells[rowNumber, 3].Value = pdd.TempatLahir;
                            currentWorksheet.Cells[rowNumber, 4].Value = pdd.TanggalLahir;
                            currentWorksheet.Cells[rowNumber, 5].Value = pdd.Alamat;
                            currentWorksheet.Cells[rowNumber, 6].Value = pdd.Pekerjaan.ToString();
                            currentWorksheet.Cells[rowNumber, 7].Value = pdd.Pendidikan.ToString();
                            currentWorksheet.Cells[rowNumber, 8].Value = pdd.JenisKelamin.ToString();
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

                        bool valid = true;
                        for (int i = 1; i <= 5; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
                        {
                            for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                            {
                                object[] colValue = new object[6];
                                for (int i = 1; i <= 5; i++)
                                {
                                    colValue[i] = currentWorksheet.Cells[rowNumber, i].Value;
                                    valid = valid && (colValue[i] != null);
                                }

                                if (valid)
                                {
                                    SIM sim = new SIM(true);
                                    sim.Nomor = colValue[2].ToString();
                                    sim.Golongan = colValue[3].ToString();
                                    sim.TanggalBuat = Convert.ToDateTime(colValue[4]);
                                    sim.TanggalHabis = Convert.ToDateTime(colValue[5]);

                                    foreach (Penduduk pdd in ListPenduduk)
                                    {
                                        if (pdd.Nomor.Equals(colValue[1]))
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

                        bool valid = true;
                        for (int i = 1; i <= 5; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
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

                        bool valid = true;
                        for (int i = 1; i <= 4; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
                        {
                            for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                            {
                                object[] colValue = new object[5];
                                for (int i = 1; i <= 4; i++)
                                {
                                    colValue[i] = currentWorksheet.Cells[rowNumber, i].Value;
                                    valid = valid && (colValue[i] != null);
                                }

                                if (valid)
                                {
                                    Pasal psl = new Pasal();

                                    psl.Nomor = colValue[1].ToString();
                                    psl.Keterangan = colValue[2].ToString();
                                    psl.Pidana = Convert.ToDouble(colValue[3]);
                                    psl.DendaMaksimal = Convert.ToDouble(colValue[4]);

                                    listDataPasal.Add(psl);
                                }
                            }
                        }
                    }
                }
                return listDataPasal;
            }
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

                        bool valid = true;
                        for (int i = 1; i <= 37; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
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
                            currentWorksheet.Cells[rowNumber, 23].Value = dapel.WaktuSidang;
                            currentWorksheet.Cells[rowNumber, 24].Value = dapel.NamaPenyidik;
                            currentWorksheet.Cells[rowNumber, 25].Value = dapel.PangkatPenyidik;
                            currentWorksheet.Cells[rowNumber, 26].Value = dapel.TempatPengambilanBarangSita;
                            currentWorksheet.Cells[rowNumber, 27].Value = dapel.PasalPelanggaran.Nomor;
                            currentWorksheet.Cells[rowNumber, 28].Value = dapel.BankSetoranDendaMaksimal;
                            currentWorksheet.Cells[rowNumber, 29].Value = dapel.AngkaPinaltiPelanggaran;
                            currentWorksheet.Cells[rowNumber, 30].Value = dapel.PernyataanHadirSendiri;
                            currentWorksheet.Cells[rowNumber, 31].Value = dapel.NamaWakil;
                            currentWorksheet.Cells[rowNumber, 32].Value = dapel.UmurWakil;
                            currentWorksheet.Cells[rowNumber, 33].Value = dapel.AlamatWakil;
                            currentWorksheet.Cells[rowNumber, 34].Value = dapel.BankSisaDenda;
                        }
                    }
                }
                package.Save();
            }
        }

        public static List<Pelanggaran> GetAllPelanggaran()
        {
            List<Pelanggaran> listDataPelanggaran = new List<Pelanggaran>();
            List<SIM> listSIM = GetAllSIM();
            List<Pasal> listPasal = GetAllPasal();

            FileInfo existingFile = new FileInfo(FileName);
            using (var package = new ExcelPackage(existingFile))
            {
                ExcelWorkbook workBook = package.Workbook;

                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet currentWorksheet = workBook.Worksheets[3];

                        bool valid = true;
                        for (int i = 1; i <= 37; i++)
                        {
                            valid = valid && (currentWorksheet.Cells[startRow, i].Value != null);
                        }

                        if (valid)
                        {
                            for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                            {
                                object[] colValue = new object[38];
                                for (int i = 1; i <= 37; i++)
                                {
                                    colValue[i] = currentWorksheet.Cells[rowNumber, i].Value;
                                    valid = valid && (colValue[i] != null);
                                }

                                if (valid)
                                {
                                    Pelanggaran pelanggaran = new Pelanggaran(true);
                                    pelanggaran.WaktuPelanggaran = DateTime.FromOADate((double)colValue[1]);
                                    pelanggaran.NomorRegister = colValue[2].ToString();
                                    pelanggaran.Kesatuan = colValue[3].ToString();
                                    pelanggaran.NomorTilang = colValue[4].ToString();

                                    foreach (SIM x in listSIM)
                                    {
                                        if (x.Nomor.Equals(colValue[5].ToString()))
                                        {
                                            pelanggaran.Pelanggar = x;
                                            break;
                                        }
                                    }

                                    pelanggaran.Satpas = colValue[6].ToString();
                                    pelanggaran.NomorKendaraan = colValue[7].ToString();
                                    pelanggaran.SamsatKendaraan = colValue[8].ToString();
                                    pelanggaran.JenisKendaraan = colValue[9].ToString();
                                    pelanggaran.MerekKendaraan = colValue[10].ToString();
                                    pelanggaran.NomorRangkaKendaraan = colValue[11].ToString();
                                    pelanggaran.NomorMesinKendaraan = colValue[12].ToString();
                                    pelanggaran.LokasiPelanggaran = colValue[13].ToString();
                                    pelanggaran.PatokanLokasi = colValue[14].ToString();
                                    pelanggaran.WilayahHukum = colValue[15].ToString();
                                    pelanggaran.DisitaSK = Convert.ToInt16(colValue[16]);
                                    pelanggaran.DisitaSKDiterbitkanOleh = colValue[17].ToString();
                                    pelanggaran.DisitaSKMasaBerlaku = DateTime.FromOADate((double)colValue[18]);
                                    pelanggaran.DisitaBukuUji = Convert.ToInt16(colValue[19]);
                                    pelanggaran.DisitaBukuUjiDiterbitkanOleh = colValue[20].ToString();
                                    pelanggaran.DisitaBukuUjiMasaBerlaku = DateTime.FromOADate((double)colValue[21]);
                                    pelanggaran.LokasiSidang = colValue[22].ToString();
                                    pelanggaran.WaktuSidang = DateTime.FromOADate((double)colValue[23]);
                                    pelanggaran.NamaPenyidik = colValue[24].ToString();
                                    pelanggaran.PangkatPenyidik = colValue[25].ToString();
                                    pelanggaran.TempatPengambilanBarangSita = colValue[26].ToString();

                                    foreach (Pasal x in listPasal)
                                    {
                                        if (x.Nomor.Equals(colValue[27].ToString()))
                                        {
                                            pelanggaran.PasalPelanggaran = x;
                                            break;
                                        }
                                    }

                                    pelanggaran.BankSetoranDendaMaksimal = colValue[28].ToString();
                                    pelanggaran.AngkaPinaltiPelanggaran = Convert.ToInt16(colValue[29]);
                                    pelanggaran.PernyataanHadirSendiri = Convert.ToBoolean(colValue[30]);
                                    pelanggaran.NamaWakil = colValue[31].ToString();
                                    pelanggaran.UmurWakil = colValue[32].ToString();
                                    pelanggaran.AlamatWakil = colValue[33].ToString();
                                    pelanggaran.BankSisaDenda = colValue[34].ToString();

                                    listDataPelanggaran.Add(pelanggaran);
                                }
                            }
                        }
                    }
                }
                return listDataPelanggaran;
            }
        }
    }
}
