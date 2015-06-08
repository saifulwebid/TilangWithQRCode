using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    [Flags]
    public enum EnumJenisUser { Jaksa, Polantas, Samsat }

    [Flags]
    public enum EnumJenisKelamin { Pria, Wanita }

    [Flags]
    public enum EnumPendidikan { SD, SMP, SMA, PT }

    [Flags]
    public enum EnumPekerjaan { Mahasiswa, Pelajar, PNS, POLRI, Swasta, TNI, Lainnya }
}
