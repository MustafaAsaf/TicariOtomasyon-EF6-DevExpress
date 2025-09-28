using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Ticari_Otomasyon
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();

    
        public void TumAdminleriYukle()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var adminList = values.Tbl_Admin.Select(adm => new
                    {
                        adm.AdminID,
                        adm.AdminKullaniciAdi,
                        adm.AdminSifre
                    }).ToList();
                    gridControl1.DataSource = adminList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            TumAdminleriYukle();
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa 
            {
                txtKullaniciAdi.Text = gridView1.GetFocusedRowCellValue("AdminKullaniciAdi")?.ToString();
                txtSifre.Text = gridView1.GetFocusedRowCellValue("AdminSifre")?.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi !");
        }

     
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bu kaydı eklemek istiyor musunuz?",
                    "Kayıt Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                Tbl_Admin tblAdmin = new Tbl_Admin
                {
                    AdminKullaniciAdi = txtKullaniciAdi.Text,
                    AdminSifre = txtSifre.Text
                };

                dataBase.Tbl_Admin.Add(tblAdmin);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Admin Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TumAdminleriYukle();
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(
                        gridView1.GetFocusedRowCellValue("AdminID")); // Seçili satırdaki "AdminID" değerini al
                    var updateAdmin = dataBase.Tbl_Admin.Find(id); // ID'ye göre veriyi bul

                    if (updateAdmin != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                            "Güncelleme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {

                            updateAdmin.AdminKullaniciAdi = txtKullaniciAdi.Text;
                            updateAdmin.AdminSifre = txtSifre.Text;
                       

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Müşteriler", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            TumAdminleriYukle(); // Listeyi yenile
                            txtKullaniciAdi.Text = "";// Formu temizle
                            txtSifre.Text = ""; 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu! " + ex.Message, "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır kontrolü
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AdminID")); // ID'yi al
                    var removeValues = dataBase.Tbl_Admin.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Admin.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "ADMİNLER", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            TumAdminleriYukle(); //Listeyi yenile
                            txtKullaniciAdi.Text = "";
                            txtSifre.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silinecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                // Şifreyi göster
                txtSifre.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                // Şifreyi gizle
                txtSifre.Properties.UseSystemPasswordChar = true;
            }
        }
    }
}