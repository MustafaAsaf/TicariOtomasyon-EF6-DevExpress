using System;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Veritabanı kontrolü yapılıyor
            // Eğer veritabanı mevcut ve erişilebilir ise, true döner.
            if (DatabaseConfigurator.CheckDatabaseExists())
            {
                // 2. Veritabanı mevcut ve erişilebilir, doğrudan giriş formunu aç
                Application.Run(new FrmAdmin());
            }
            else
            {
                // 3. Veritabanı mevcut değil veya erişim sağlanamadı, kurulum formunu aç
                // Kullanıcı burada sunucu bilgilerini girerek veritabanını kuracak.
                Application.Run(new FrmVeriTabani());
            }
        }
    }
}