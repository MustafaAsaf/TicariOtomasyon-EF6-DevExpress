using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Filtering;
using Ticari_Otomasyon.Models;
using DevExpress.XtraEditors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ticari_Otomasyon
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();
        public void ClearForm(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextEdit textEdit) // DevExpress TextEdit
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
                else if (control is ComboBoxEdit comboBoxEdit)
                {
                    //comboBoxEdit.EditValue = comboBoxEdit.SelectedItem.Clear();
                }

                // Eğer kontrol bir panel, groupbox veya başka bir container ise içindekileri de temizle
                if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }
        public void GetSehirler()
        {
            comboBoxSehir.Properties.Items.Clear(); // Önce temizle
            var sehirler = dataBase.Tbl_Sehirler.Select(s => s.SehirAdi).ToList();

            comboBoxSehir.Properties.Items.AddRange(sehirler);
        }
        public void GetIlceler()
        {
            if (comboBoxSehir.SelectedIndex == -1) return;

            string selectedCityName = comboBoxSehir.SelectedItem.ToString();

            // Seçilen şehrin ID'sini bulalım
            var selectedCity = dataBase.Tbl_Sehirler.FirstOrDefault(s => s.SehirAdi == selectedCityName);
            if (selectedCity == null) return;

            comboilce.Properties.Items.Clear(); // Önce temizle
            var ilceler = dataBase.Tbl_Ilceler
                .Where(d => d.SehirId == selectedCity.SehirId)
                .Select(i => i.IlceAdi)
                .ToList();

            comboilce.Properties.Items.AddRange(ilceler);
        }
        public void GetAll()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var personelList = values.Tbl_Personeller
                        .Select(p => new
                        {
                          ID=p.PersonellD,
                          Ad=p.PersonelAd,
                          Soyad=p.PersonelSoyad,
                          Telefon=p.PersonelTelefon,
                          E_Mail=p.PersonelMail,
                          TC=p.PersonelTC,
                          Şehir=p.PersonelSehir,
                          İlçe=p.Personellce,
                          Adres=p.PersonelAdres,
                          Görev=p.PersonelGorev
                        })
                        .ToList();

                    gridControl1.DataSource = personelList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            GetAll();
            GetSehirler();
            
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(
                        gridView1.GetFocusedRowCellValue("PersonellD")); // Seçili satırdaki "Personel ID" değerini al
                    var updateProduct = dataBase.Tbl_Personeller.Find(id); // ID'ye göre veriyi bul

                    if (updateProduct != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                            "Güncelleme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {

                            updateProduct.PersonelAd = txtAd.Text;
                            updateProduct.PersonelSoyad = txtSoyad.Text;
                            updateProduct.PersonelTelefon = txtTelefon.Text;
                            updateProduct.PersonelMail = txtMail.Text;
                            updateProduct.PersonelTC = txtTC.Text;
                            updateProduct.PersonelSehir = comboBoxSehir.EditValue.ToString();
                            updateProduct.Personellce = comboilce.EditValue.ToString();
                            updateProduct.PersonelAdres = txtAdres.Text;
                            updateProduct.PersonelGorev = txtGorev.Text;

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Müşteriler", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            GetAll(); // Listeyi yenile
                            ClearForm(this); // Formu temizle
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

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa 
            {
                txtAd.Text = gridView1.GetFocusedRowCellValue("Ad")?.ToString();
                txtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad")?.ToString();
                txtTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon")?.ToString();
                txtMail.Text = gridView1.GetFocusedRowCellValue("E_Mail")?.ToString();
                txtTC.Text = gridView1.GetFocusedRowCellValue("TC")?.ToString();
                txtAdres.Text = gridView1.GetFocusedRowCellValue("Adres")?.ToString();
                txtGorev.Text = gridView1.GetFocusedRowCellValue("Görev")?.ToString();
                comboBoxSehir.Text = gridView1.GetFocusedRowCellValue("Şehir")?.ToString();
                comboilce.Text = gridView1.GetFocusedRowCellValue("İlçe")?.ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır kontrolü
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("PersonellD")); // ID'yi al
                    var removeValues = dataBase.Tbl_Personeller.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Personeller.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "MÜŞTERİLER", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            GetAll(); // Listeyi yenile
                            ClearForm(this); // Formu temizle
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bu kaydı eklemek istiyor musunuz?",
                    "Kayıt Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Kayıt ekleme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                Tbl_Personeller tblPersoneller = new Tbl_Personeller();


                tblPersoneller.PersonelAd = txtAd.Text;
                tblPersoneller.PersonelSoyad = txtSoyad.Text;
                tblPersoneller.PersonelTelefon = txtTelefon.Text;
                tblPersoneller.PersonelMail = txtMail.Text;
                tblPersoneller.PersonelTC = txtTC.Text;
                tblPersoneller.PersonelSehir = comboBoxSehir.EditValue.ToString();
                tblPersoneller.Personellce = comboilce.EditValue.ToString();
                tblPersoneller.PersonelAdres = txtAdres.Text;
                tblPersoneller.PersonelGorev = txtGorev.Text;

                dataBase.Tbl_Personeller.Add(tblPersoneller);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Kayıt Eklendi!", "MÜŞTERİLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();
                ClearForm(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi !");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm(this);
        }

        private void comboBoxSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetIlceler();
        }

       
    }
}
