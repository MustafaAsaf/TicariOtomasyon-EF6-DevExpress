using DevExpress.Office.Design.Internal;
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

namespace Ticari_Otomasyon
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();
        public void GetAll()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_FaturaBilgi.Select(f => new
                    {
                        FaturaID = f.FaturaID,
                        f.FaturaTipi,
                        f.FaturaNo,
                        Tarih = f.FaturaTarih,
                        Saat = f.FaturaSaat,
                        VergiDairesi = f.FaturaVergiDaire,
                        Satıcı = f.FaturaSatıcı,
                        Alıcı = f.FaturaAlıcı,
                        Adres = f.FaturaAlıcıAdres,
                        Telefon = f.FaturaAlıcıTelefon,
                        E_Posta = f.FaturaAlıcıEPosta,
                        AlıcıVergiDairesi = f.FaturaAlıcıVergiDaire
                    }).ToList();
                    gridControl1.DataSource = spendingList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
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
                    // Radio butonlar seçili değilse combobox temiz kalsın
                    if (!radiobuttonKurumsal.Checked && !radioButtonSahis.Checked)
                    {
                        comboBoxEdit.Properties.Items.Clear();
                        comboBoxEdit.EditValue = null;
                    }
                }

                // Eğer kontrol bir panel, groupbox veya başka bir container ise içindekileri de temizle
                if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }
        public void GetPersonel()
        {
            comboBoxTeslimEden.Properties.Items.Clear(); // Önce temizle
            var personeller = dataBase.Tbl_Personeller
                .Select(p => p.PersonelAd + " " + p.PersonelSoyad)
                .ToList();

            comboBoxTeslimEden.Properties.Items.AddRange(personeller);
        }
        public void GetAlici()
        {
            try
            {
                comboBoxAlici.Properties.Items.Clear(); // Önce temizle

                if (radiobuttonKurumsal.Checked == true)
                {
                    var kurumsalAlici = dataBase.Tbl_Sirketler
                        .Select(s => s.SirketAd)
                        .ToList();

                    comboBoxAlici.Properties.Items.AddRange(kurumsalAlici.ToArray());
                }
                else if (radioButtonSahis.Checked == true)
                {
                    var sahisAlici = dataBase.Tbl_Musteriler
                        .Select(s => s.MusteriAd + " " + s.MusteriSoyad)
                        .ToList();

                    comboBoxAlici.Properties.Items.AddRange(sahisAlici.ToArray());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void getUrunler()
        {
            if (cbAltKategori.SelectedIndex == -1) return;

            string selectedSubCategory = cbAltKategori.SelectedItem.ToString();

            // Seçilen kategorinin ID'sini bulalım
            var selectedCategory = dataBase.Tbl_AltKategoriler.FirstOrDefault(s => s.AltKategoriAdi == selectedSubCategory);
            if (selectedCategory == null) return;

            cbUrunAdi.Properties.Items.Clear(); // Önce temizle
            var urunler = dataBase.Tbl_Urunler
                .Where(d => d.AltKategoriID == selectedCategory.AltKategoriID)
                .Select(i => i.UrunAdi)
                .ToList();

            cbUrunAdi.Properties.Items.AddRange(urunler);

        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            // Giriş yapan kullanıcıyı temsil eden global nesne
            // CurrentUser.RolePermissions bir List<string> tutuyor (örneğin ["ViewStock", "ViewInvoice"])

            GetPersonel();
            GetAlici();
            GetAll();
            getBaseCategory();
            txtFaturaID.Enabled = false;
            txtFaturaIDForeign.Enabled = false;

        }
       
        
        //Fatura CRUD İŞLEMLERİ
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi !");
        }
        private void btnClear_Click_1(object sender, EventArgs e)
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

                Tbl_FaturaBilgi faturaBilgi = new Tbl_FaturaBilgi();

                faturaBilgi.FaturaTipi = comboBoxFaturaTipi.SelectedItem.ToString();
                faturaBilgi.FaturaNo = txtFaturaNo.Text;
                faturaBilgi.FaturaTarih = txtTarih.Text;
                faturaBilgi.FaturaSaat = txtSaat.Text;
                faturaBilgi.FaturaVergiDaire = txtVergiDaire.Text;
                faturaBilgi.FaturaSatıcı = comboBoxTeslimEden.SelectedItem.ToString();
                faturaBilgi.FaturaAlıcı = comboBoxAlici.SelectedItem.ToString();
                faturaBilgi.FaturaAlıcıAdres = txtAliciAdres.Text;
                faturaBilgi.FaturaAlıcıTelefon = txtAliciTelefon.Text;
                faturaBilgi.FaturaAlıcıEPosta = txtAliciEMail.Text;
                faturaBilgi.FaturaAlıcıVergiDaire = txtAliciVergiDaire.Text;

                dataBase.Tbl_FaturaBilgi.Add(faturaBilgi);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Fatura Kaydı Eklendi!", "FATURA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();
                ClearForm(xtraTabControl1);
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
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("FaturaID")); // FaturaID'yi al
                    var removeValues = dataBase.Tbl_FaturaBilgi.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_FaturaBilgi.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "FATURA BİLGİLERİ", MessageBoxButtons.OK,
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
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(
                        gridView1.GetFocusedRowCellValue("FaturaID")); // Seçili satırdaki "FaturaID" değerini al
                    var updateFatura = dataBase.Tbl_FaturaBilgi.Find(id); // ID'ye göre veriyi bul

                    if (updateFatura != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                            "Güncelleme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {
                            updateFatura.FaturaNo = txtFaturaNo.Text;
                            updateFatura.FaturaTarih = txtTarih.Text;
                            updateFatura.FaturaSaat = txtSaat.Text;
                            updateFatura.FaturaVergiDaire = txtVergiDaire.Text;
                            updateFatura.FaturaSatıcı = comboBoxTeslimEden.SelectedItem.ToString();
                            updateFatura.FaturaAlıcı = comboBoxAlici.SelectedItem.ToString();
                            updateFatura.FaturaAlıcıAdres = txtAliciAdres.Text;
                            updateFatura.FaturaAlıcıTelefon = txtAliciTelefon.Text;
                            updateFatura.FaturaAlıcıEPosta = txtAliciEMail.Text;
                            updateFatura.FaturaAlıcıVergiDaire = txtAliciVergiDaire.Text;

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Fatura kaydı başarıyla güncellendi!", "Faturalar", MessageBoxButtons.OK,
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


        //FATURA(ÜRÜN) İŞLEMLERİ
        private void btnUrunEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                int urunID = Convert.ToInt32(txtUrunID.Text);

                // 1) Stok kontrolü
                var urun = dataBase.Tbl_Urunler.FirstOrDefault(u => u.UrunID == urunID);
                if (urun == null)
                {
                    MessageBox.Show("Seçili ürün bulunamadı!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (urun.UrunAdet <= 0)
                {
                    MessageBox.Show("Bu ürün stokta kalmamış! Faturaya eklenemez.",
                        "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2) Kullanıcı onayı
                DialogResult result = MessageBox.Show(
                    "Bu ürünü faturaya eklemek istiyor musunuz?",
                    "Ürün Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Ürün ekleme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // 3) Fatura detay ekleme
                int faturaID = Convert.ToInt32(txtFaturaID.Text); // asıl fatura ID
                short miktar = Convert.ToInt16(txtUrunMiktar.Text);
                decimal fiyat = Convert.ToDecimal(txtFiyat.Text);
                decimal tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString("0.00");

                Tbl_FaturaDetay faturaDetay = new Tbl_FaturaDetay
                {
                    FaturaID = faturaID,
                    UrunID = urunID,
                    FaturaDetayUrunAd = cbUrunAdi.SelectedItem?.ToString(),
                    FaturaDetayMiktar = miktar,
                    FaturaDetayFiyat = fiyat,
                    FaturaDetayTutar = tutar
                };
                dataBase.Tbl_FaturaDetay.Add(faturaDetay);

                // 4) Personel ID bulma
                string seciliPersonelAdSoyad = comboBoxTeslimEden.SelectedItem?.ToString();
                int personelID = dataBase.Tbl_Personeller
                    .Where(p => (p.PersonelAd + " " + p.PersonelSoyad) == seciliPersonelAdSoyad)
                    .Select(p => p.PersonellD)
                    .FirstOrDefault();

                // 5) Hareket ekleme
                string seciliAlici = comboBoxAlici.SelectedItem?.ToString();
                string faturaTipi = comboBoxFaturaTipi.Text; // ŞAHIS veya KURUMSAL
                string tarih = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string notlar = "FATURAYA ÜRÜN EKLENDİ";

                if (faturaTipi == "ŞAHIS")
                {
                    int musteriID = dataBase.Tbl_Musteriler
                        .Where(m => (m.MusteriAd + " " + m.MusteriSoyad) == seciliAlici)
                        .Select(m => m.MusteriID)
                        .FirstOrDefault();

                    Tbl_MusteriHareketler mh = new Tbl_MusteriHareketler
                    {
                        UrunID = urunID,
                        Adet = miktar,
                        PersonelID = personelID,
                        MusteriID = musteriID,
                        Fiyat = fiyat,
                        Toplam = tutar,
                        FaturaID = faturaID,
                        Tarih = tarih,
                        Notlar = notlar
                    };
                    dataBase.Tbl_MusteriHareketler.Add(mh);
                }
                else if (faturaTipi == "KURUMSAL")
                {
                    int sirketID = dataBase.Tbl_Sirketler
                        .Where(s => s.SirketAd == seciliAlici)
                        .Select(s => s.SirketID)
                        .FirstOrDefault();

                    Tbl_FirmaHareketler fh = new Tbl_FirmaHareketler
                    {
                        UrunID = urunID,
                        Adet = miktar,
                        PersonelID = personelID,
                        SirketID = sirketID,
                        Fiyat = fiyat,
                        Toplam = tutar,
                        FaturaID = faturaID,
                        Tarih = tarih,
                        Notlar = notlar
                    };
                    dataBase.Tbl_FirmaHareketler.Add(fh);
                }

                // 6) Tek seferde kaydet
                dataBase.SaveChanges();

                MessageBox.Show("Ürün başarıyla faturaya ve ilgili hareket tablosuna eklendi.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                string allMessages = ex.Message;
                while (inner != null)
                {
                    allMessages += "\n\n" + inner.Message;
                    inner = inner.InnerException;
                }

                MessageBox.Show("Hata ayrıntıları:\n" + allMessages,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBul_Click_1(object sender, EventArgs e)
        {
            try
            {
                int urunId = int.Parse(txtUrunID.Text); // TextBox'tan ID al
                var urun = dataBase.Tbl_Urunler.Find(urunId);

                if (urun != null)
                {
                    cbUrunAdi.Text = urun.UrunAdi;
                    txtFiyat.Text = urun.UrunSatisFiyat.ToString();
                    txtUrunMiktar.Text = urun.UrunAdet.ToString();
                    txtFiyat.Text = urun.UrunSatisFiyat.ToString();
                    cbKategori.Text = urun.Tbl_AltKategoriler.Tbl_Kategoriler.KategoriAdi.ToString();
                    cbAltKategori.Text = urun.Tbl_AltKategoriler.AltKategoriAdi.ToString();
                    comboBoxMarka.Text = urun.UrunMarka.ToString();
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa
                {
                    //FATURA BİLGİLERİ
                    txtFaturaID.Text = gridView1.GetFocusedRowCellValue("FaturaID").ToString();
                    comboBoxFaturaTipi.Text = gridView1.GetFocusedRowCellValue("FaturaTipi").ToString();
                    txtFaturaNo.Text = gridView1.GetFocusedRowCellValue("FaturaNo").ToString();
                    txtTarih.Text = gridView1.GetFocusedRowCellValue("Tarih").ToString();
                    txtSaat.Text = gridView1.GetFocusedRowCellValue("Saat").ToString();
                    txtVergiDaire.Text = gridView1.GetFocusedRowCellValue("VergiDairesi").ToString();
                    comboBoxTeslimEden.Text = gridView1.GetFocusedRowCellValue("Satıcı").ToString();
                    comboBoxAlici.Text = gridView1.GetFocusedRowCellValue("Alıcı").ToString();
                    txtAliciAdres.Text = gridView1.GetFocusedRowCellValue("Adres").ToString();
                    txtAliciTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
                    txtAliciEMail.Text = gridView1.GetFocusedRowCellValue("E_Posta").ToString();
                    txtAliciVergiDaire.Text = gridView1.GetFocusedRowCellValue("AlıcıVergiDairesi").ToString();


                    //FATURA DETAYLARI
                    txtFaturaIDForeign.Text = gridView1.GetFocusedRowCellValue("FaturaID").ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string faturaID = gridView1.GetFocusedRowCellValue("FaturaID")?.ToString();// Geçerli satırdaki "FaturaID" hücresinin değerini al
                // Eğer null değilse Form2'yi aç ve değeri gönder
                if (!string.IsNullOrEmpty(faturaID))
                {
                    FrmFaturaDetay faturaDetay = new FrmFaturaDetay();
                    faturaDetay._faturaID = Convert.ToInt32(faturaID);
                    faturaDetay.Show();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void radiobuttonKurumsal_CheckedChanged_1(object sender, EventArgs e)
        {
            GetAlici();
        }

        private void radioButtonSahis_CheckedChanged_1(object sender, EventArgs e)
        {
            GetAlici();
        }

        private void comboBoxAlici_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string selectedValue = comboBoxAlici.Text;

                if (radiobuttonKurumsal.Checked) // Kurumsal seçiliyse
                {
                    var firma = dataBase.Tbl_Sirketler
                        .Where(s => s.SirketAd == selectedValue)
                        .Select(s => new
                        {
                            s.SirketAd,
                            s.SirketTelefon1,
                            s.SirketMail,
                            s.SirketAdres,
                            s.SirketVergiDaire
                        })
                        .FirstOrDefault();

                    if (firma != null)
                    {
                        txtAliciAdres.Text = firma.SirketAdres;
                        txtAliciTelefon.Text = firma.SirketTelefon1;
                        txtAliciEMail.Text = firma.SirketMail;
                        txtAliciVergiDaire.Text = firma.SirketVergiDaire;
                    }
                }
                else if (radioButtonSahis.Checked) // Şahıs seçiliyse
                {
                    var musteri = dataBase.Tbl_Musteriler
                        .Where(m => (m.MusteriAd + " " + m.MusteriSoyad) == selectedValue)
                        .Select(m => new
                        {
                            AdSoyad = m.MusteriAd + " " + m.MusteriSoyad,
                            m.MusteriTelefon,
                            m.MusteriMail,
                            m.MusteriAdres
                        })
                        .FirstOrDefault();

                    if (musteri != null)
                    {
                        txtAliciAdres.Text = musteri.MusteriAdres;
                        txtAliciTelefon.Text = musteri.MusteriTelefon;
                        txtAliciEMail.Text = musteri.MusteriMail;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbKategori_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getSubCategory();
        }

        private void cbAltKategori_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getUrunler();
        }

        private void gridControl1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa
            {
                //FATURA BİLGİLERİ
                txtFaturaID.Text = gridView1.GetFocusedRowCellValue("FaturaID").ToString();
                comboBoxFaturaTipi.Text = gridView1.GetFocusedRowCellValue("FaturaTipi").ToString();
                txtFaturaNo.Text = gridView1.GetFocusedRowCellValue("FaturaNo").ToString();
                txtTarih.Text = gridView1.GetFocusedRowCellValue("Tarih").ToString();
                txtSaat.Text = gridView1.GetFocusedRowCellValue("Saat").ToString();
                txtVergiDaire.Text = gridView1.GetFocusedRowCellValue("VergiDairesi").ToString();
                comboBoxTeslimEden.Text = gridView1.GetFocusedRowCellValue("Satıcı").ToString();
                comboBoxAlici.Text = gridView1.GetFocusedRowCellValue("Alıcı").ToString();
                txtAliciAdres.Text = gridView1.GetFocusedRowCellValue("Adres").ToString();
                txtAliciTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
                txtAliciEMail.Text = gridView1.GetFocusedRowCellValue("E_Posta").ToString();
                txtAliciVergiDaire.Text = gridView1.GetFocusedRowCellValue("AlıcıVergiDairesi").ToString();

                //FATURA DETAYLARI
                txtFaturaIDForeign.Text = gridView1.GetFocusedRowCellValue("FaturaID").ToString();
            }
        }

        private void checkEditZaman_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // CheckEdit nesnesinin Checked (işaretli) olup olmadığını kontrol edin
                if (checkEditZaman.Checked)
                {
                    // CheckEdit işaretliyse, anlık tarih ve saati alın
                    DateTime simdi = DateTime.Now;

                    txtTarih.Text = simdi.ToString("dd.MM.yyyy");

                    // Veya kısa tarih formatını kullanabilirsiniz:
                    // txtTarih.EditValue = simdi.ToShortDateString();
                   
                    txtSaat.Text = simdi.ToString("HH:mm");

                    // Veya kısa saat formatını kullanabilirsiniz:
                    // txtSaat.EditValue = simdi.ToShortTimeString();
                }
                else
                {
                    // CheckEdit işaretli değilse, TextEdit nesnelerini temizleyin
                    txtTarih.Text = null; // veya txtTarih.Text = string.Empty;
                    txtSaat.Text = null;  // veya txtSaat.Text = string.Empty;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
