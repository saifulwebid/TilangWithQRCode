using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class User
    {
        public EnumJenisUser Jenis { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public User Check(string username, string password)
        {
            return ExcelHelper.AccountCheck(username, password);
        }

    }
}
