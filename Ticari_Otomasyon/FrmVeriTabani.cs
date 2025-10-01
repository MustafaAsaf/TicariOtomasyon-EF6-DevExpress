using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmVeriTabani : Form
    {
        public FrmVeriTabani()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FrmAdmin formuna götüren kod.
        /// </summary>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // FrmAdmin aç ve bu formu kapat
                FrmAdmin admin = new FrmAdmin();
                admin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        /// <summary>
        /// Veritabanını oluşturacak, ilk admin kaydını ekleyecek ve bağlantı dizgesini kalıcı kaydedecek kod.
        /// </summary>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string serverName = txtServerName.Text.Trim();
            string authType = cbAuthentication.SelectedItem?.ToString() ?? "Windows Authentication"; // Default olarak Windows Auth
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(serverName))
            {
                MessageBox.Show("Lütfen SQL Server Adını girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Authentication tipi SQL Server ise, kullanıcı adı ve şifre zorunlu
            if (authType != "Windows Authentication" && (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre)))
            {
                MessageBox.Show("SQL Server Kimlik Doğrulaması seçtiyseniz, kullanıcı adı ve şifre girmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcının girdiği bilgileri Properties'e kaydet (İsteğe bağlı, formu açarken bilgileri geri getirmek için)
            Properties.Settings.Default.ServerName = serverName;
            Properties.Settings.Default.AuthType = authType;
            Properties.Settings.Default.Username = kullaniciAdi;
            Properties.Settings.Default.Password = sifre;
            Properties.Settings.Default.Save();

            // Veritabanı oluşturma ve seed işlemini yap
            if (DatabaseConfigurator.CreateDatabaseAndSeedAdmin(serverName, authType, kullaniciAdi, sifre))
            {
                MessageBox.Show("Veritabanı başarıyla oluşturuldu ve ilk yönetici hesabı (admin/1234) eklendi.", "Kurulum Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Başarılı kurulumdan sonra uygulamayı yeniden başlat
                Application.Restart();
            }
            // Hata durumunda, hata mesajı zaten DatabaseConfigurator içinden gösteriliyor.
        }
    }
}
