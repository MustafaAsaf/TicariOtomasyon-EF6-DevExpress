using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq; // LINQ için
using System.Windows.Forms; // MessageBox.Show için eklendi

// Ticari Otomasyon projenizdeki Entity Framework Context'in adını buraya yazın.
// App.config dosyanızdaki "DboTicariOtomasyonEntities1" adlı bağlantı dizgesini kullanır.
using Ticari_Otomasyon.Models; // Context'inizin bulunduğu namespace'i buraya ekleyin

namespace Ticari_Otomasyon
{
    public static class DatabaseConfigurator
    {
        // Context adınız, App.config'den aldık.
        private const string ContextName = "DboTicariOtomasyonEntities1";
        // Veritabanı adınız, App.config'den aldık.
        private const string DatabaseName = "DboTicariOtomasyon";

        /// <summary>
        /// Mevcut bağlantı dizgesini kullanarak veritabanının varlığını ve erişilebilirliğini kontrol eder.
        /// </summary>
        public static bool CheckDatabaseExists()
        {
            try
            {
                // Mevcut bağlantı dizgesi (App.config'deki)
                string connectionString = ConfigurationManager.ConnectionStrings[ContextName].ConnectionString;

                // Connection String'de provider'dan sonra gelen kısmı almalıyız
                // EF'in karmaşık connection string'inden SQL connection string'i ayıklama.
                string sqlConnectionString = ExtractProviderConnectionString(connectionString);

                // Eğer bağlantı dizgesi boşsa veya yoksa, DB'nin kurulu olmadığını varsay
                if (string.IsNullOrEmpty(sqlConnectionString)) return false;

                // Entity Framework Context'ini kullanarak DB varlığını kontrol et
                // Context adınızın "DboTicariOtomasyonEntities1" olduğunu varsayıyoruz.
                using (var dbContext = new DboTicariOtomasyonEntities1(sqlConnectionString))
                {
                    // dbContext.Database.Exists() metodu hem varlığı kontrol eder hem de bağlantıyı dener.
                    return dbContext.Database.Exists();
                }
            }
            catch (Exception ex)
            {
                // Herhangi bir hata (SQL Server kapalı, bağlantı kurulamadı) durumunda DB'nin kullanılamadığını varsay.
                System.Diagnostics.Debug.WriteLine($"Veritabanı kontrol hatası: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// EF Metadata Connection String'inden sadece Provider Connection String'i ayıklar.
        /// </summary>
        private static string ExtractProviderConnectionString(string efConnectionString)
        {
            // Basit bir arama ile provider connection string kısmını bulmaya çalışırız.
            const string startMarker = "provider connection string=\"";
            const string endMarker = "\"";

            int startIndex = efConnectionString.IndexOf(startMarker);

            if (startIndex == -1) return null;

            startIndex += startMarker.Length;
            int endIndex = efConnectionString.IndexOf(endMarker, startIndex);

            if (endIndex == -1) return null;

            // Ayıklanan bağlantı dizgesindeki kaçış karakterlerini düzelt.
            return efConnectionString.Substring(startIndex, endIndex - startIndex).Replace("&quot;", "\"");
        }


        /// <summary>
        /// Yeni Server Adı ile veritabanını oluşturur, Admin kullanıcısını ekler ve yeni bağlantıyı kaydeder.
        /// </summary>
        public static bool CreateDatabaseAndSeedAdmin(string serverName, string authType, string username, string password)
        {
            try
            {
                // 1. Yeni SQL Connection String'i Oluştur
                string newSqlConnectionString = CreateSqlConnectionString(serverName, DatabaseName, authType, username, password);

                // 2. Yeni EF Connection String'i Oluştur
                string newEfConnectionString = CreateEfConnectionString(newSqlConnectionString);

                // 3. Veritabanını Oluştur ve Seed İşlemini Yap
                // HATA BURADA ÇÖZÜLÜR: Context sınıfınızda (DboTicariOtomasyonEntities1) string alan bir kurucu metot olmalıdır.
                using (var dbContext = new DboTicariOtomasyonEntities1(newEfConnectionString))
                {
                    // Database First modelinde: Veritabanı yoksa oluşturulur.
                    // Tabloların modelden otomatik oluşması için (DB First'te bazen sorun yaratabilir), 
                    // ya bu metodu kullanırız ya da harici SQL scripti çalıştırırız.
                    // Burada EF'e güveniyoruz.
                    dbContext.Database.CreateIfNotExists();

                    // Veritabanının gerçekten var olduğunu kontrol et
                    if (!dbContext.Database.Exists())
                    {
                        MessageBox.Show("Veritabanı oluşturuldu ancak bağlantı kurulamadı. SQL Server adını kontrol edin.", "Hata");
                        return false;
                    }

                    // 4. Admin Kaydını Ekle (Seeding)
                    // Tbl_Admin'de kayıt var mı diye kontrol et (Kayıt tekrarını önle)
                    if (!dbContext.Tbl_Admin.Any())
                    {
                        var newAdmin = new Tbl_Admin
                        {
                            AdminKullaniciAdi = "admin",
                            AdminSifre = "1234" // Lütfen gerçek uygulamada bunu hashleyin!
                        };

                        dbContext.Tbl_Admin.Add(newAdmin);
                        dbContext.SaveChanges();
                    }

                    // 5. Yeni Bağlantı Dizgesini Kalıcı Olarak Kaydet
                    SaveNewConnectionString(newEfConnectionString);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı kurulumu sırasında kritik bir hata oluştu: {ex.Message}", "Kurulum Hatası");
                return false;
            }
        }

        /// <summary>
        /// Kullanıcının girdiği bilgilere göre yeni bir SQL bağlantı dizgesi oluşturur.
        /// </summary>
        private static string CreateSqlConnectionString(string serverName, string dbName, string authType, string username, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = serverName,
                InitialCatalog = dbName,
                MultipleActiveResultSets = true,
                TrustServerCertificate = true,
                ApplicationName = "EntityFramework"
            };

            if (authType == "Windows Authentication")
            {
                builder.IntegratedSecurity = true;
            }
            else // SQL Server Authentication
            {
                builder.UserID = username;
                builder.Password = password;
                builder.IntegratedSecurity = false;
            }

            return builder.ConnectionString;
        }

        /// <summary>
        /// SQL bağlantı dizgesini Entity Framework (EF) metadata ile birleştirir.
        /// </summary>
        private static string CreateEfConnectionString(string sqlConnectionString)
        {
            // Bu metadata kısmı sizin App.config'inizden alınmıştır ve DEĞİŞMEZ.
            const string metadata = "metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;";
            const string provider = "provider=System.Data.SqlClient;";

            // SQL bağlantı dizgesini tırnak işaretleriyle kaçarak provider connection string içine yerleştiririz.
            string providerConnectionString = $"provider connection string=\"{sqlConnectionString}\"";

            return $"{metadata}{provider}{providerConnectionString}";
        }

        /// <summary>
        /// Çalışan Entity Framework bağlantı dizgesini App.config dosyasına kalıcı olarak kaydeder.
        /// </summary>
        public static void SaveNewConnectionString(string newConnectionString)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                // EF Context'ine ait bağlantı dizgesini bul ve güncelle
                if (connectionSection.ConnectionStrings[ContextName] != null)
                {
                    connectionSection.ConnectionStrings[ContextName].ConnectionString = newConnectionString;
                }
                else
                {
                    // Bulunamazsa yeni bir tane ekle
                    connectionSection.ConnectionStrings.Add(new ConnectionStringSettings(ContextName, newConnectionString, "System.Data.EntityClient"));
                }

                // İkinci (direkt SQL) bağlantı dizgesini de isteğe bağlı olarak güncelleyebilirsiniz.
                // update: "Ticari_Otomasyon.Properties.Settings.DboTicariOtomasyonConnectionString"

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı dizgesi kaydedilirken hata oluştu: {ex.Message}", "Hata");
            }
        }
    }
}
