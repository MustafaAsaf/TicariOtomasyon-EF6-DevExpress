using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ticari_Otomasyon.Models;

namespace Ticari_Otomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 db = new DboTicariOtomasyonEntities1();

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Eğer checkEdit işaretlendiyse, şifreyi göster
                if (checkEdit1.Checked)
                {
                    txtSifre.Properties.UseSystemPasswordChar=false;
                }
                else // İşaret kaldırılırsa, şifreyi yine gizle
                {
                    txtSifre.Properties.UseSystemPasswordChar = true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = true;
        }

        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            // Kullanıcı kontrolü
            var admin = db.Tbl_Admin.FirstOrDefault(a => a.AdminKullaniciAdi == kullaniciAdi && a.AdminSifre == sifre);

            if (admin == null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Rolleri yükle
            var roller = db.Tbl_AdminRules
                .Where(ar => ar.AdminID == admin.AdminID)
                .Select(ar => ar.Tbl_Roller)
                .ToList();

           // Role ID listesini belleğe al
            var roleIdList = roller.Select(r => r.RolId).ToList();

            // Kullanıcının izinlerini çek
            var izinler = db.Tbl_Rol_Izinleri
                .Where(rp => roleIdList.Contains(rp.RolId))
                .Select(rp => rp.Tbl_Izinler.IzinKey)
                .Distinct()
                .ToList();

            //Kullanıcı personel ad soyad bilgisi
            /////////////////////

            // Şimdi bu bilgileri global olarak saklayalım
            CurrentUser.AdminID = admin.AdminID;
            CurrentUser.KullaniciAdi = admin.AdminKullaniciAdi;
            CurrentUser.Roller = roller.Select(r => r.RolAdi).ToList();
            CurrentUser.Izinler = izinler;
            CurrentUser.IsSuperAdmin = roller.Any(r => r.IsSuperAdmin);
            CurrentUser.ProfilResim = admin.AdminProfilResim;
            //CurrentUser.PersonelAdSoyad = 

            // Ana forma geçiş
            FrmAna ana = new FrmAna();
            ana.Show();
            this.Hide();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }


}
