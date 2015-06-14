using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    static class Converter
    {
        public static string DateTimeToDDMMYY(DateTime date)
        {
            return
                date.Day.ToString("00") +
                date.Month.ToString("00") +
                (date.Year % 100).ToString();
        }

        public static DateTime DDMMYYToDateTime(string date)
        {
            int tanggal = ((date[0] - '0') * 10) + (date[1] - '0');
            int bulan = ((date[2] - '0') * 10) + (date[3] - '0');
            int tahun = ((date[4] - '0') * 10) + (date[5] - '0');

            if (tahun <= (DateTime.Now.Year % 100))
            {
                tahun = tahun + (DateTime.Now.Year / 100) * 100;
            }
            else
            {
                tahun = tahun + ((DateTime.Now.Year / 100) - 1) * 100;
            }

            DateTime result = new DateTime(tahun, bulan, tanggal);
            return result;
        }

        public static int EnumToInt<T>(T jenis)
        {
            /* Konversi Enum ke List<Enum> */
            List<T> list = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            return list.IndexOf(jenis) + 1;
        }

        public static T IntToEnum<T>(int jenis)
        {
            List<T> list = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return list[jenis - 1];
        }

        public static char EnumJenisKelaminToChar(EnumJenisKelamin jenis)
        {
            if (jenis == EnumJenisKelamin.Pria) return 'L';
            else return 'P';   
        }

        public static EnumJenisKelamin CharToEnumJenisKelamin(char jenis)
        {
            if (jenis == 'L') return EnumJenisKelamin.Pria;
            else return EnumJenisKelamin.Wanita;
        }
    }
}
