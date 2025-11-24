using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticari_Otomasyon
{
    public static class CurrentUser //Geçerli Kullanıcı
    {
        public static int AdminID { get; set; }
        public static string KullaniciAdi { get; set; }
        public static List<string> Roller { get; set; }
        public static List<string> Izinler { get; set; }
        public static bool IsSuperAdmin { get; set; }
        public static byte[] ProfilResim { get; set; }

        public static bool HasPermission(string key)
        {
            if (IsSuperAdmin) return true;
            return Izinler != null && Izinler.Contains(key);
        }
    }
}
