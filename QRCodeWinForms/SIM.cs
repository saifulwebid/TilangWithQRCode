using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class SIM
    {
        public string Golongan { get; set; }
        public string Nomor { get; set; }
        public Penduduk Pemilik { get; set; }
        public DateTime TanggalBuat { get; set; }
        public DateTime TanggalHabis { get; set; }
        private bool isNew = true;

        /** Constructor **/
        public SIM() { }

        public SIM(bool FromExcel)
        {
            if (FromExcel == true)
            {
                isNew = false;
            }
            else
            {
                isNew = true;
            }
        }

        public SIM(string QRData)
        {
            string[] field = QRData.Split('#'); 
            // Isi field pada class SIM
            Nomor = field[1];
            Golongan = field[2];
            
            //Isi field-field pada class Penduduk
            Penduduk pdk = new Penduduk(true);
            pdk.Nomor = field[0];
            pdk.Nama = field[3];
            pdk.TempatLahir = field[4];
            pdk.TanggalLahir = Converter.DDMMYYToDateTime(field[5]);
            pdk.Alamat = field[6];
            pdk.Pekerjaan = Converter.IntToEnum<EnumPekerjaan>(Convert.ToInt16(field[7]));
            pdk.Pendidikan = Converter.IntToEnum<EnumPendidikan>(Convert.ToInt16(field[8]));
            pdk.JenisKelamin = Converter.CharToEnumJenisKelamin(field[9][0]);
            Pemilik = pdk;
            isNew = false;
        }
        
        /** Method **/
        public string GenerateQRData()
        {
            string[] result = 
            {
                Pemilik.Nomor,
                Nomor,
                Golongan,
                Pemilik.Nama,
                Pemilik.TempatLahir,
                Converter.DateTimeToDDMMYY(Pemilik.TanggalLahir),
                Pemilik.Alamat,
                Converter.EnumToInt<EnumPekerjaan>(Pemilik.Pekerjaan).ToString(), 
                Converter.EnumToInt<EnumPendidikan>(Pemilik.Pendidikan).ToString(),
                Converter.EnumJenisKelaminToChar(Pemilik.JenisKelamin).ToString(),
                Converter.DateTimeToDDMMYY(TanggalBuat)
            };
            return String.Join("#", result);
        }

        public List<Pelanggaran> GetAllPelanggaran()
        {
            List<Pelanggaran> all = ExcelHelper.GetAllPelanggaran();
            List<Pelanggaran> filtered = new List<Pelanggaran>();

            foreach (Pelanggaran x in all)
            {
                if (x.Pelanggar.Nomor.Equals(this.Nomor))
                {
                    filtered.Add(x);
                }
            }

            return filtered;
        }

        public static List<SIM> GetAll()
        {
            return ExcelHelper.GetAllSIM();
        }

        public void Save()
        {
            if (isNew == true)
            {
                this.Pemilik.Save();

                ExcelHelper.SaveSIM(this);
                isNew = false;
            }
        }
        
        public bool isValid()
        {
            if ((TanggalBuat.Year - Pemilik.TanggalLahir.Year) == 17)
            {
                if (TanggalBuat.Month == Pemilik.TanggalLahir.Month)
                    return (TanggalBuat.Day >= Pemilik.TanggalLahir.Day);
                else
                    return (TanggalBuat.Month > Pemilik.TanggalLahir.Month);
            }
            else
                return (TanggalBuat.Year - Pemilik.TanggalLahir.Year) > 17;
        }
    }
}
