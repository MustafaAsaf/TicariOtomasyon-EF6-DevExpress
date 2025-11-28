using System;
using System.Collections.Generic;
using System.Linq;
using Ticari_Otomasyon.Models;

public class SalesAnalyticsService
{
    private readonly DboTicariOtomasyonEntities1 _db;

    public SalesAnalyticsService()
    {
        _db = new DboTicariOtomasyonEntities1();
    }

    // ------------------------------
    // 1) ÜRÜN SATIŞ ÖZETLERİ
    // ------------------------------
    public List<vw_UrunSatisOzet> GetProductSummaries(
        int? urunId = null,
        int? kategoriId = null,
        DateTime? baslangic = null,
        DateTime? bitis = null)
    {
        var query = _db.vw_UrunSatisOzet.AsQueryable();

        // Ürün filtresi
        if (urunId.HasValue)
            query = query.Where(x => x.UrunID == urunId.Value);

        // Kategori filtresi
        if (kategoriId.HasValue)
            query = query.Where(x => x.KategoriAdi != null &&
                                     x.KategoriAdi.Contains(GetKategoriAdiById(kategoriId.Value)));

        // Tarih filtresi
        if (baslangic.HasValue)
            query = query.Where(x => x.SonSatisTarihi >= baslangic.Value);

        if (bitis.HasValue)
            query = query.Where(x => x.SonSatisTarihi <= bitis.Value);

        return query
            .OrderByDescending(x => x.ToplamCiro)
            .ToList();
    }

    // ------------------------------
    // 2) KATEGORİ SATIŞ ÖZETLERİ
    // ------------------------------
    public List<vw_KategoriSatisOzet> GetCategorySummaries(
        int? kategoriId = null,
        DateTime? baslangic = null,
        DateTime? bitis = null)
    {
        var query = _db.vw_KategoriSatisOzet.AsQueryable();

        if (kategoriId.HasValue)
            query = query.Where(x => x.KategoriID == kategoriId.Value);

        return query
            .OrderByDescending(x => x.ToplamCiro)
            .ToList();
    }

    // ------------------------------
    // 3) PERSONEL SATIŞ ÖZETLERİ
    // ------------------------------
    public List<vw_PersonelSatisOzet> GetEmployeeSummaries(
        int? personelId = null,
        DateTime? baslangic = null,
        DateTime? bitis = null)
    {
        var query = _db.vw_PersonelSatisOzet.AsQueryable();

        // Personel filtresi
        if (personelId.HasValue)
            query = query.Where(x => x.PersonelID == personelId.Value);

        return query
            .OrderByDescending(x => x.ToplamCiro)
            .ToList();
    }

    // ------------------------------
    // 4) GEMINI'YE ÖZET ÜRETİMİ İÇİN DERLENMİŞ METİN
    // ------------------------------
    public string BuildSummaryText(
        List<vw_UrunSatisOzet> urunler,
        List<vw_KategoriSatisOzet> kategoriler,
        List<vw_PersonelSatisOzet> personeller)
    {
        var text = "### Satış Analitik Özeti\n\n";

        // Ürün Özeti
        if (urunler.Any())
        {
            text += "#### Ürün Satış Özeti:\n";
            foreach (var u in urunler)
            {
                text += $"- **{u.UrunAdi}** → {u.ToplamAdet} adet, {u.ToplamCiro:C} ciro\n";
            }
            text += "\n";
        }

        // Kategori Özeti
        if (kategoriler.Any())
        {
            text += "#### Kategori Satış Özeti:\n";
            foreach (var k in kategoriler)
            {
                text += $"- **{k.KategoriAdi}** → {k.ToplamAdet} adet, {k.ToplamCiro:C} ciro\n";
            }
            text += "\n";
        }

        // Personel Özeti
        if (personeller.Any())
        {
            text += "#### Personel Satış Özeti:\n";
            foreach (var p in personeller)
            {
                text += $"- **{p.PersonelAd} {p.PersonelSoyad}** → {p.SatisSayisi} satış, {p.ToplamCiro:C} ciro\n";
            }
            text += "\n";
        }

        return text;
    }

    // ------------------------------
    // Yardımcı Metot: Kategori Adı Bul
    // ------------------------------
    private string GetKategoriAdiById(int kategoriId)
    {
        return _db.Tbl_Kategoriler
                .Where(x => x.KategoriID == kategoriId)
                .Select(x => x.KategoriAdi)
                .FirstOrDefault();
    }
}
