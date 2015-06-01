using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class Account
    {
        private string _namaLengkap;
        private string _username;
        private string _password;
        private EnumJenisUser _jenis;
        private Boolean isNew;

        public string NamaLengkap { get; set; }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public EnumJenisUser Jenis
        {
            get { return _jenis; }
            set { _jenis = value; }
        }

        public Boolean IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        /*Nanti dirubah , nilai return nya jadi account (objek account )*/
        public Account Check(string username, string password)
        {
            return ExcelHelper.AccountCheck(username, password);
        }

        /*Simpan account baru */
        public void Save() { }

    }
}
