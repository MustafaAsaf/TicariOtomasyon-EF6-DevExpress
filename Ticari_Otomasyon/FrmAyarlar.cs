using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        byte[] profilResimBytes = null;
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();

        public void ClearForm(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is DevExpress.XtraEditors.TextEdit textEdit) // DevExpress TextEdit
                {
                    textEdit.Text = string.Empty;
                }
                else if (control is MaskedTextBox maskedTextBox) // MaskedTextBox
                {
                    maskedTextBox.Clear();
                }
                else if (control is NumericUpDown numericUpDown) // NumericUpDown
                {
                    numericUpDown.Value = numericUpDown.Minimum;
                }
                else if (control is RichTextBox richTextBox) // RichTextBox
                {
                    richTextBox.Clear();
                }
                else if (control is PictureBox pictureBox) // PictureBox
                {
                    pictureBox.Image = null;
                }


                // Eğer kontrol bir panel, groupbox veya başka bir container ise içindekileri de temizle
                if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }

        public void GetAllAdminList()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var adminList = values.Tbl_AdminRules.Select(adm => new
                    {
                        ID=adm.AdminRoleId,
                        KullaniciAdi=adm.Tbl_Admin.AdminKullaniciAdi,
                        Sifre=adm.Tbl_Admin.AdminSifre,
                        Rol =adm.Tbl_Roller.RolAdi,
                        
                        SuperAdmin=adm.Tbl_Roller.IsSuperAdmin
                    }).ToList();
                    gridControl1.DataSource = adminList;
                    ListeleRoller();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetAllRole_Permisson()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var roleList = values.Tbl_Rol_Izinleri.Select(role => new
                    {
                        ID=role.Rol_IzinleriId,
                        Rol=role.Tbl_Roller.RolAdi,
                        Izin=role.Tbl_Izinler.IzinKey,
                    }).ToList();
                    gridControl2.DataSource = roleList;
                    ListeleIzinler();
                    ListeleRoller();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListeleRoller()
        {
            using (var db = new DboTicariOtomasyonEntities1())
            {
                var roller = dataBase.Tbl_Roller.Select(s => s.RolAdi).ToList();

                combobox_Roller.Properties.Items.Clear(); // Önce temizle
                combobox_Roller.Properties.Items.AddRange(roller);

                combobox_Roller2.Properties.Items.Clear(); // Önce temizle
                combobox_Roller2.Properties.Items.AddRange(roller);
            }
        }

        public void ListeleIzinler()
        {
            using (var db = new DboTicariOtomasyonEntities1())
            {
                var izinler = dataBase.Tbl_Izinler.Select(s => s.IzinKey).ToList();
                comboBoxIzinler.Properties.Items.Clear(); // Önce temizle
                comboBoxIzinler.Properties.Items.AddRange(izinler);
            }
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            GetAllAdminList();
            GetAllRole_Permisson();
        }
   
        // Byte dizisini Image'a dönüştüren yardımcı fonksiyon
        private Image ByteToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        // Byte[] dönüştürme fonksiyonu
        private byte[] ImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

       
       
        //CRUD KODLARI
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
                    AdminSifre = txtSifre.Text,
                    AdminProfilResim = pictureBox1.Image != null ? ImageToByte(pictureBox1.Image) : null
                };

                Tbl_AdminRules adminRules = new Tbl_AdminRules
                {
                    AdminID = tblAdmin.AdminID,
                    RolId = dataBase.Tbl_Roller.FirstOrDefault(r => r.RolAdi == combobox_Roller.Text)?.RolId ?? 0
                };

                dataBase.Tbl_AdminRules.Add(adminRules);
                dataBase.Tbl_Admin.Add(tblAdmin);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Admin Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAllAdminList();
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                pictureBox1.Image = null; // Fotoğraf kutusunu temizle
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi !");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    // GridView'deki ID aslında AdminRoleId
                    int adminRoleId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));

                    // Tbl_AdminRules kaydını al
                    var adminRule = dataBase.Tbl_AdminRules.FirstOrDefault(ar => ar.AdminRoleId == adminRoleId);

                    if (adminRule != null)
                    {
                        // AdminID'yi al
                        int adminId = adminRule.AdminID;

                        DialogResult result = MessageBox.Show(
                            "Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            // AdminRules kaydını sil
                            dataBase.Tbl_AdminRules.Remove(adminRule);

                            // Admin tablosundaki kaydı sil
                            var admin = dataBase.Tbl_Admin.Find(adminId);
                            if (admin != null)
                            {
                                dataBase.Tbl_Admin.Remove(admin);
                            }

                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "ADMİNLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetAllAdminList(); // Grid'i yenile
                            txtKullaniciAdi.Text = "";
                            txtSifre.Text = "";
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silinecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                int focusedRowHandle = gridView1.FocusedRowHandle;
                if (focusedRowHandle < 0)
                {
                    MessageBox.Show("Lütfen önce bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Grid'den AdminRoleId alıyoruz
                int adminRoleId = Convert.ToInt32(gridView1.GetRowCellValue(focusedRowHandle, "ID"));

                // Tbl_AdminRules kaydını al
                var adminRule = dataBase.Tbl_AdminRules.FirstOrDefault(ar => ar.AdminRoleId == adminRoleId);
                if (adminRule == null)
                {
                    MessageBox.Show("Güncellenecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int adminId = adminRule.AdminID;

                // Tbl_Admin kaydını al
                var updateAdmin = dataBase.Tbl_Admin.Find(adminId);
                if (updateAdmin == null)
                {
                    MessageBox.Show("Admin kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kullanıcıdan onay al
                DialogResult result = MessageBox.Show(
                    "Bu kaydı güncellemek istiyor musunuz?",
                    "Güncelleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Admin bilgilerini güncelle
                    updateAdmin.AdminKullaniciAdi = txtKullaniciAdi.Text;
                    updateAdmin.AdminSifre = txtSifre.Text;
                    updateAdmin.AdminProfilResim = pictureBox1.Image != null ? ImageToByte(pictureBox1.Image) : null;

                    // Roller güncellemesi
                    var currentRoles = dataBase.Tbl_AdminRules.Where(r => r.AdminID == adminId).ToList();
                    if (currentRoles.Any())
                    {
                        dataBase.Tbl_AdminRules.RemoveRange(currentRoles);
                    }

                    if (!string.IsNullOrEmpty(combobox_Roller.Text))
                    {
                        var rolAdiList = combobox_Roller.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var rolAdi in rolAdiList)
                        {
                            var rol = dataBase.Tbl_Roller.FirstOrDefault(r => r.RolAdi == rolAdi.Trim());
                            if (rol != null)
                            {
                                dataBase.Tbl_AdminRules.Add(new Tbl_AdminRules
                                {
                                    AdminID = adminId,
                                    RolId = rol.RolId
                                });
                            }
                        }
                    }

                    dataBase.SaveChanges();

                    MessageBox.Show("Kayıt başarıyla güncellendi!", "ADMİNLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetAllAdminList(); // Grid'i yenile
                    txtKullaniciAdi.Text = "";
                    txtSifre.Text = "";
                    pictureBox1.Image = null;
                    combobox_Roller.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu! " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm(this);
        }

        private void btn_image_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim |*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                profilResimBytes = File.ReadAllBytes(ofd.FileName);
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int focusedRowHandle = gridView1.FocusedRowHandle;
            if (focusedRowHandle < 0) return;

            // Grid’deki AdminRoleId’yi alıyoruz
            var idDegeri = gridView1.GetRowCellValue(focusedRowHandle, "ID");
            if (idDegeri == null) return;

            int adminRoleId = Convert.ToInt32(idDegeri);

            using (var db = new DboTicariOtomasyonEntities1())
            {
                // Tbl_AdminRules üzerinden admin ve rol bilgilerini çek
                var adminRole = db.Tbl_AdminRules
                                  .Where(ar => ar.AdminRoleId == adminRoleId)
                                  .Select(ar => new
                                  {
                                      ar.AdminID,
                                      ar.RolId,
                                      KullaniciAdi = ar.Tbl_Admin.AdminKullaniciAdi,
                                      Sifre = ar.Tbl_Admin.AdminSifre,
                                      ProfilResim = ar.Tbl_Admin.AdminProfilResim,
                                      RolAdi = ar.Tbl_Roller.RolAdi,
                                      SuperAdmin = ar.Tbl_Roller.IsSuperAdmin
                                  })
                                  .FirstOrDefault();

                if (adminRole != null)
                {
                    txtKullaniciAdi.Text = adminRole.KullaniciAdi;
                    txtSifre.Text = adminRole.Sifre;
                    pictureBox1.Image = adminRole.ProfilResim != null ? ByteToImage(adminRole.ProfilResim) : null;

                    combobox_Roller.Text = adminRole.RolAdi;
                    //checkBoxSuperAdmin.Checked = adminRole.SuperAdmin; // Eğer SuperAdmin gösteriyorsan
                }
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0) // Seçili satır varsa
            {
               combobox_Roller2.Text = gridView2.GetFocusedRowCellValue("Rol").ToString();
               comboBoxIzinler.Text = gridView2.GetFocusedRowCellValue("Izin").ToString();

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }
    }
}