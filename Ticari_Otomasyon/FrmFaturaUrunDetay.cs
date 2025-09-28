using DevExpress.CodeParser;
using DevExpress.Office.Design.Internal;
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
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }


        private FrmFaturaDetay _faturaDetay = new FrmFaturaDetay();
        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();


        public int _faturaDetayID;
        public string _urunAd;
        public int _miktar;
        public decimal _fiyat;
        public decimal _tutar;
        public int _faturaID;
        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            try
            {
                txtFaturaIDForeign.Text = _faturaID.ToString();
                txtUrunID.Text = _faturaDetayID.ToString();
                txtUrunAd.Text = _urunAd;
                txtMiktar.Text = _miktar.ToString();
                txtFiyat.Text = _fiyat.ToString("0.00");
                txtTutar.Text = _tutar.ToString("0.00");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {

            dataBase.SaveChanges();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int faturaDetayId = Convert.ToInt32(txtUrunID.Text);

                using (var db = new DboTicariOtomasyonEntities1())
                using (var tr = db.Database.BeginTransaction())
                {
                    var detay = db.Tbl_FaturaDetay.Find(faturaDetayId);
                    if (detay == null)
                    {
                        MessageBox.Show("Seçili ürün bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int iadeMiktari = detay.FaturaDetayMiktar ?? 0;
                    int urunID = detay.UrunID ?? 0;
                    int faturaID = detay.FaturaID ?? 0;

                    // ---------- (A) Trigger var mı kontrolü (varsa stok güncellemesini SKIP et)
                    int triggerCount = db.Database.SqlQuery<int>(
                        "SELECT COUNT(*) FROM sys.triggers WHERE name = @p0",
                        "trg_FaturaDetay_Delete_StokGeriEkle").FirstOrDefault();
                    bool triggerExists = triggerCount > 0;

                    // ---------- (B) Eğer trigger yoksa: uygulama üzerinden stok geri ekle
                    if (!triggerExists)
                    {
                        var urun = db.Tbl_Urunler.Find(urunID);
                        if (urun == null)
                        {
                            MessageBox.Show("Ürün kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int urunStok = urun.UrunAdet ?? 0;
                        int yeniStok = urunStok + iadeMiktari;

                        if (yeniStok < short.MinValue || yeniStok > short.MaxValue)
                        {
                            MessageBox.Show("Stok değeri sınırları aşıyor. İşlem iptal edildi.",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        urun.UrunAdet = (short?)yeniStok;
                    }
                    // if triggerExists -> trigger DELETE işlemi stok eklemesini yapacaktır, uygulama burada ekleme yapmaz

                    // ---------- (C) Fatura bilgilerini getir
                    var faturaBilgi = db.Tbl_FaturaBilgi.FirstOrDefault(f => f.FaturaID == faturaID);
                    if (faturaBilgi == null)
                    {
                        MessageBox.Show("Fatura bilgisi bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string faturaTipi = faturaBilgi.FaturaTipi?.ToUpper() ?? "ŞAHIS";

                    // ---------- (D) İade zaten yapılmış mı kontrolü (basit kontrol: aynı fatura/ürün için Notlar içinde "İADE" varsa atla)
                    bool alreadyReturned = false;
                    if (faturaTipi == "ŞAHIS")
                    {
                        alreadyReturned = db.Tbl_MusteriHareketler
                            .Any(h => h.FaturaID == faturaID && h.UrunID == urunID && h.Notlar.Contains("İADE"));
                    }
                    else if (faturaTipi == "KURUMSAL")
                    {
                        alreadyReturned = db.Tbl_FirmaHareketler
                            .Any(h => h.FaturaID == faturaID && h.UrunID == urunID && h.Notlar.Contains("İADE"));
                    }

                    if (alreadyReturned)
                    {
                        MessageBox.Show("Bu fatura satırı için daha önce iade kaydı oluşturulmuş. İşlem tekrarlanamaz.",
                            "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ---------- (E) Personel / müşteri / firma ID'lerini doğru şekilde DB'den bul
                    // NOT: Fatura tablosunda satıcı/alici isimleri varsa onlara göre ID sorgulanır.
                    int personelId = 0;
                    int musteriId = 0;
                    int firmaId = 0;

                    // Satıcıdan personel id al (faturaBilgi.FaturaSatıcı isim-tutuyorsa)
                    if (!string.IsNullOrEmpty(faturaBilgi.FaturaSatıcı))
                    {
                        personelId = db.Tbl_Personeller
                            .Where(p => (p.PersonelAd + " " + p.PersonelSoyad) == faturaBilgi.FaturaSatıcı)
                            .Select(p => p.PersonellD)
                            .FirstOrDefault();
                    }

                    // Alıcı şahıs mı firma mı ona göre ID al
                    if (faturaTipi == "ŞAHIS")
                    {
                        if (!string.IsNullOrEmpty(faturaBilgi.FaturaAlıcı))
                        {
                            musteriId = db.Tbl_Musteriler
                                .Where(m => (m.MusteriAd + " " + m.MusteriSoyad) == faturaBilgi.FaturaAlıcı)
                                .Select(m => m.MusteriID)
                                .FirstOrDefault();
                        }
                    }
                    else // KURUMSAL
                    {
                        if (!string.IsNullOrEmpty(faturaBilgi.FaturaAlıcı))
                        {
                            firmaId = db.Tbl_Sirketler
                                .Where(s => s.SirketAd == faturaBilgi.FaturaAlıcı)
                                .Select(s => s.SirketID)
                                .FirstOrDefault();
                        }
                    }

                    // ---------- (F) Yeni hareket kaydı ekle (iade)
                    string tarihStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    decimal fiyat = detay.FaturaDetayFiyat ?? 0m;
                    decimal toplam = (detay.FaturaDetayTutar ?? (fiyat * iadeMiktari));

                    if (faturaTipi == "ŞAHIS")
                    {
                        Tbl_MusteriHareketler mh = new Tbl_MusteriHareketler
                        {
                            UrunID = detay.UrunID,
                            Adet = iadeMiktari,
                            PersonelID = personelId,
                            MusteriID = musteriId,
                            Fiyat = fiyat,
                            Toplam = toplam,
                            FaturaID = detay.FaturaID,
                            Tarih = tarihStr,
                            Notlar = $"ÜRÜN İADESİ YAPILDI: FaturaDetayID={faturaDetayId}"
                        };
                        db.Tbl_MusteriHareketler.Add(mh);
                    }
                    else // KURUMSAL
                    {
                        Tbl_FirmaHareketler fh = new Tbl_FirmaHareketler
                        {
                            UrunID = detay.UrunID,
                            Adet = iadeMiktari,
                            PersonelID = personelId,
                            SirketID = firmaId,
                            Fiyat = fiyat,
                            Toplam = toplam,
                            FaturaID = detay.FaturaID,
                            Tarih = tarihStr,
                            Notlar = $"ÜRÜN İADESİ YAPILDI: FaturaDetayID={faturaDetayId}"
                        };
                        db.Tbl_FirmaHareketler.Add(fh);
                    }

                    // ---------- (G) Fatura detay kaydını sil
                    db.Tbl_FaturaDetay.Remove(detay);

                    // Kaydet & commit
                    db.SaveChanges();
                    tr.Commit();

                    MessageBox.Show("Ürün başarıyla iade edildi ve iade hareketi oluşturuldu.",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _faturaDetay.GetAll2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında bir hata oluştu! " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
