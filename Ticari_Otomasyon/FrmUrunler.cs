using DevExpress.XtraEditors;
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
using Ticari_Otomasyon.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Ticari_Otomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
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

                // Eğer kontrol bir panel, groupbox veya başka bir container ise içindekileri de temizle
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
                    var spendingList = values.Tbl_Urunler.Select(urn => new
                    {
                       ID= urn.UrunID,
                       ÜrünAdı=  urn.UrunAdi,
                       Marka= urn.UrunMarka,
                       Model= urn.UrunModel,
                       Yıl= urn.UrunYil,
                       Adet= urn.UrunAdet,
                       AlışFiyatı= urn.UrunAlisFiyat,
                       SatışFiyatı= urn.UrunSatisFiyat,
                       Detay= urn.UrunDetay,
                       Kategori=urn.Tbl_AltKategoriler.Tbl_Kategoriler.KategoriAdi,
                       AltKategori = urn.Tbl_AltKategoriler.AltKategoriAdi
                    }).ToList();
                    gridControl1.DataSource = spendingList;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA");
                throw;
            }
        }
        public void getBaseCategory()
        {
            cbKategori.Properties.Items.Clear(); // Önce temizle
            var Anakategori = dataBase.Tbl_Kategoriler.Select(c => c.KategoriAdi).ToList();

            cbKategori.Properties.Items.AddRange(Anakategori);
        }
        public void getSubCategory()
        {
            
            if (cbKategori.SelectedIndex == -1) return;

            string selectedBaseCategory = cbKategori.SelectedItem.ToString();

            // Seçilen kategorinin ID'sini bulalım
            var selectedCategory = dataBase.Tbl_Kategoriler.FirstOrDefault(s => s.KategoriAdi == selectedBaseCategory);
            if (selectedCategory == null) return;

            cbAltKategori.Properties.Items.Clear(); // Önce temizle
            var altKategoriler = dataBase.Tbl_AltKategoriler
                .Where(d => d.KategoriID == selectedCategory.KategoriID)
                .Select(i => i.AltKategoriAdi)
                .ToList();

            cbAltKategori.Properties.Items.AddRange(altKategoriler);
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            GetAll();
            getBaseCategory();
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi !");
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcıdan onay al
                DialogResult result = MessageBox.Show(
                    "Bu ürünü eklemek istiyor musunuz?",
                    "Ürün Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Ürün ekleme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Alt kategori seçilmemişse uyarı ver
                if (cbAltKategori.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir alt kategori seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // AltKategoriID'yi al
                string selectedAltKategori = cbAltKategori.SelectedItem.ToString();
                var altKategoriEntity = dataBase.Tbl_AltKategoriler
                    .FirstOrDefault(a => a.AltKategoriAdi == selectedAltKategori);

                if (altKategoriEntity == null)
                {
                    MessageBox.Show("Seçilen alt kategori bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ürün bilgilerini al
                Tbl_Urunler tblUrunler = new Tbl_Urunler
                {
                    UrunAdi = txtUrunAd.Text,
                    UrunMarka = txtMarka.Text,
                    UrunModel = txtModel.Text,
                    UrunYil = txtYil.Text,
                    UrunAdet = (short)Convert.ToInt32(numericAdet.Text),
                    UrunAlisFiyat = Convert.ToDecimal(txtAlisFiyat.Text),
                    UrunSatisFiyat = Convert.ToDecimal(txtSatisFiyat.Text),
                    UrunDetay = txtDetay.Text,
                    AltKategoriID = altKategoriEntity.AltKategoriID // İlişki buradan kuruluyor
                };

                // Kaydet
                dataBase.Tbl_Urunler.Add(tblUrunler);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Ürün Eklendi!", "ÜRÜNLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();  // Listeyi yenile
                ClearForm(groupControl1); // Formu temizle
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır kontrolü
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")); // ID'yi al
                    var removeValues = dataBase.Tbl_Urunler.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Urunler.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "ÜRÜNLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetAll(); // Listeyi yenile
                            ClearForm(groupControl1); // Formu temizle
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")); // "ID" alanı kullanılmalı
                    var updateProduct = dataBase.Tbl_Urunler.Find(id);

                    if (updateProduct != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu ürünü güncellemek istiyor musunuz?",
                                                              "Güncelleme Onayı",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            updateProduct.UrunAdi = txtUrunAd.Text;
                            updateProduct.UrunMarka = txtMarka.Text;
                            updateProduct.UrunModel = txtModel.Text;
                            updateProduct.UrunYil = txtYil.Text;
                            updateProduct.UrunAdet = (short)numericAdet.Value;
                            updateProduct.UrunAlisFiyat = Convert.ToDecimal(txtAlisFiyat.Text);
                            updateProduct.UrunSatisFiyat = Convert.ToDecimal(txtSatisFiyat.Text);
                            updateProduct.UrunDetay = txtDetay.Text;

                            // Alt kategori seçimi
                            if (cbAltKategori.SelectedIndex != -1)
                            {
                                string selectedAltKategori = cbAltKategori.SelectedItem.ToString();
                                var altKategoriEntity = dataBase.Tbl_AltKategoriler
                                    .FirstOrDefault(a => a.AltKategoriAdi == selectedAltKategori);

                                if (altKategoriEntity != null)
                                {
                                    updateProduct.AltKategoriID = altKategoriEntity.AltKategoriID;
                                }
                            }

                            dataBase.SaveChanges();
                            MessageBox.Show("Ürün başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetAll();
                            ClearForm(groupControl1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek ürün bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir ürün seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu! " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm(groupControl1);
        }

        private void gridView1_RowCellStyle_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Adet") // stok kolonun adı
            {
                int value = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "Adet"));

                if (value == 0)
                {
                    e.Appearance.BackColor = Color.IndianRed;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (value > 0 && value < 5)
                {
                    e.Appearance.BackColor = Color.LightYellow;
                    e.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa
                {
                    txtUrunID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                    txtUrunAd.Text = gridView1.GetFocusedRowCellValue("ÜrünAdı").ToString();
                    txtMarka.Text = gridView1.GetFocusedRowCellValue("Marka").ToString();
                    txtModel.Text = gridView1.GetFocusedRowCellValue("Model").ToString();
                    txtYil.Text = gridView1.GetFocusedRowCellValue("Yıl").ToString();
                    numericAdet.Value = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Adet"));
                    txtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("AlışFiyatı").ToString();
                    txtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SatışFiyatı").ToString();
                    txtDetay.Text = gridView1.GetFocusedRowCellValue("Detay").ToString();

                    cbKategori.Text = gridView1.GetFocusedRowCellValue("Kategori")?.ToString();
                    cbAltKategori.Text = gridView1.GetFocusedRowCellValue("AltKategori")?.ToString();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void cbKategori_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getSubCategory();
        }
    }
}
