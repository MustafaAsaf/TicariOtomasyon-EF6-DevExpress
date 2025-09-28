using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ticari_Otomasyon.Models;

namespace Ticari_Otomasyon
{
    public partial class FrmSirketler : Form
    {
        public FrmSirketler()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();
        public void ClearForm(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextEdit textEdit)
                {
                    textEdit.Text = string.Empty;
                }
                else if (control is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.Clear();
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.Value = numericUpDown.Minimum;
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.Clear();
                }
                else if (control is ComboBoxEdit comboBoxEdit)
                {
                    comboBoxEdit.EditValue = null; // ComboBox temizleme
                }

                // Eğer kontrol bir container ise (Panel, GroupBox, TableLayoutPanel vb.)
                if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }
        public void GetAll()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_Sirketler
                        .Select(x => new
                        {
                            x.SirketID,
                            x.SirketAd,
                            x.YetkiliStatu,
                            x.YetkiliAdSoyad,
                            x.YetkiliTC,
                            x.SirketSektor,
                            x.SirketTelefon1,
                            x.SirketTelefon2,
                            x.SirketTelefon3,
                            x.SirketMail,
                            x.SirketFax,
                            x.SirketSehir,
                            x.SirketIlce,
                            x.SirketVergiDaire,
                            x.SirketAdres,
                            x.OzelKod1,
                            x.OzelKod2,
                            x.OzelKod3
                        })
                        .ToList();

                    gridControl1.DataSource = spendingList;
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        public void GetSehirler()
        {
            comboBoxIl.Properties.Items.Clear(); // Önce temizle
            var sehirler = dataBase.Tbl_Sehirler.Select(s => s.SehirAdi).ToList();

            comboBoxIl.Properties.Items.AddRange(sehirler);
        }
        public void GetIlceler()
        {
            if (comboBoxIl.SelectedIndex == -1) return;

            string selectedCityName = comboBoxIl.SelectedItem.ToString();

            // Seçilen şehrin ID'sini bulalım
            var selectedCity = dataBase.Tbl_Sehirler.FirstOrDefault(s => s.SehirAdi == selectedCityName);
            if (selectedCity == null) return;

            comboBoxIlce.Properties.Items.Clear(); // Önce temizle
            var ilceler = dataBase.Tbl_Ilceler
                .Where(d => d.SehirId == selectedCity.SehirId)
                .Select(i => i.IlceAdi)
                .ToList();

            comboBoxIlce.Properties.Items.AddRange(ilceler);
        }
        private void FrmSirketler_Load(object sender, EventArgs e)
        {
           GetAll();
           GetSehirler();
           gridView1.BestFitColumns();

        }
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(
                        gridView1.GetFocusedRowCellValue("SirketID")); // Seçili satırdaki "SirketID" değerini al
                    var updateProduct = dataBase.Tbl_Sirketler.Find(id); // ID'ye göre veriyi bul

                    if (updateProduct != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                            "Güncelleme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {
                            updateProduct.SirketAd = txtSirketAd.Text;
                            updateProduct.YetkiliStatu = txtYGorev.Text;
                            updateProduct.YetkiliAdSoyad = txtYetkiliAdSoyad.Text;
                            updateProduct.YetkiliTC = txtTcNo.Text;
                            updateProduct.SirketSektor = txtSektor.Text;
                            updateProduct.SirketTelefon1 = txtMusteriTelefon1.Text;
                            updateProduct.SirketTelefon2 = txtMusteriTelefon2.Text;
                            updateProduct.SirketTelefon3 = txtMusteriTelefon3.Text;
                            updateProduct.SirketMail = txtMusteriMail.Text;
                            updateProduct.SirketFax = txtMusteriFaks.Text;
                            updateProduct.SirketSehir = comboBoxIl.EditValue.ToString();
                            updateProduct.SirketIlce = comboBoxIlce.EditValue.ToString();
                            updateProduct.SirketVergiDaire = txtVergiDairesi.Text;
                            updateProduct.SirketAdres = txtAdres.Text;
                            updateProduct.OzelKod1 = txtKod1.Text;
                            updateProduct.OzelKod2 = txtKod2.Text;
                            updateProduct.OzelKod3 = txtKod3.Text;

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Müşteriler", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            GetAll(); // Listeyi yenile
                            ClearForm(xtraTabControl1); // Formu temizle
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
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("SirketID")); // ID'yi al
                    var removeValues = dataBase.Tbl_Sirketler.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Sirketler.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "MÜŞTERİLER", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            GetAll(); // Listeyi yenile
                            ClearForm(xtraTabControl1); // Formu temizle
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm(xtraTabControl1);
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
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

                Tbl_Sirketler tblSirketler = new Tbl_Sirketler();

                tblSirketler.SirketAd = txtSirketAd.Text;
                tblSirketler.YetkiliStatu = txtYGorev.Text;
                tblSirketler.YetkiliAdSoyad = txtYetkiliAdSoyad.Text;
                tblSirketler.YetkiliTC = txtTcNo.Text;
                tblSirketler.SirketSektor = txtSektor.Text;
                tblSirketler.SirketTelefon1 = txtMusteriTelefon1.Text;
                tblSirketler.SirketTelefon2 = txtMusteriTelefon2.Text;
                tblSirketler.SirketTelefon3 = txtMusteriTelefon3.Text;
                tblSirketler.SirketMail = txtMusteriMail.Text;
                tblSirketler.SirketFax = txtMusteriFaks.Text;
                tblSirketler.SirketSehir = comboBoxIl.EditValue.ToString();
                tblSirketler.SirketIlce = comboBoxIlce.EditValue.ToString();
                tblSirketler.SirketVergiDaire = txtVergiDairesi.Text;
                tblSirketler.SirketAdres = txtAdres.Text;
                tblSirketler.OzelKod1 = txtKod1.Text;
                tblSirketler.OzelKod2 = txtKod2.Text;
                tblSirketler.OzelKod3 = txtKod3.Text;

                dataBase.Tbl_Sirketler.Add(tblSirketler);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Kayıt Eklendi!", "MÜŞTERİLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();
                ClearForm(xtraTabControl1);
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
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa
            {

                txtSirketAd.Text = gridView1.GetFocusedRowCellValue("SirketAd")?.ToString() ?? "";
                txtSektor.Text = gridView1.GetFocusedRowCellValue("SirketSektor")?.ToString() ?? "";
                txtYGorev.Text = gridView1.GetFocusedRowCellValue("YetkiliStatu")?.ToString() ?? "";
                txtYetkiliAdSoyad.Text = gridView1.GetFocusedRowCellValue("YetkiliAdSoyad")?.ToString() ?? "";
                txtTcNo.Text = gridView1.GetFocusedRowCellValue("YetkiliTC")?.ToString() ?? "";
                txtMusteriTelefon1.Text = gridView1.GetFocusedRowCellValue("SirketTelefon1")?.ToString() ?? "";
                txtMusteriTelefon2.Text = gridView1.GetFocusedRowCellValue("SirketTelefon2")?.ToString() ?? "";
                txtMusteriTelefon3.Text = gridView1.GetFocusedRowCellValue("SirketTelefon3")?.ToString() ?? "";
                txtMusteriMail.Text = gridView1.GetFocusedRowCellValue("SirketMail")?.ToString() ?? "";
                txtMusteriFaks.Text = gridView1.GetFocusedRowCellValue("SirketFax")?.ToString() ?? "";
                comboBoxIl.Text = gridView1.GetFocusedRowCellValue("SirketSehir")?.ToString() ?? "";
                comboBoxIlce.Text = gridView1.GetFocusedRowCellValue("SirketIlce")?.ToString() ?? "";
                txtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("SirketVergiDaire")?.ToString() ?? "";
                txtAdres.Text = gridView1.GetFocusedRowCellValue("SirketAdres")?.ToString() ?? "";
                txtKod1.Text = gridView1.GetFocusedRowCellValue("OzelKod1")?.ToString() ?? "";
                txtKod2.Text = gridView1.GetFocusedRowCellValue("OzelKod2")?.ToString() ?? "";
                txtKod3.Text = gridView1.GetFocusedRowCellValue("OzelKod3")?.ToString() ?? "";

            }
        }
        private void comboBoxIl_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetIlceler();
        }
    }
}
