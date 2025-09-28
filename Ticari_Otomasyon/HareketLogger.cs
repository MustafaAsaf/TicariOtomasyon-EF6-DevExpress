using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticari_Otomasyon.Models;

namespace Ticari_Otomasyon
{
    // HareketLogger.cs
    // Tek noktadan hareket eklemeyi sağlar. Hem Musteri hem Firma tabloları için kullanılabilir.
    public static class HareketLogger
    {
        // Eğer her seferinde yeni context açmak istersen:
        public static void LogHareket(
            int urunId,
            int adet,
            int personelId,
            int musteriOrFirmaId,
            decimal fiyat,
            decimal toplam,
            int faturaId,
            string notlar,
            string faturaTipi)
        {
            using (var db = new DboTicariOtomasyonEntities1()) // ✅ doğru
            {
                string tarihStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (faturaTipi.Trim().ToUpper() == "ŞAHIS" || faturaTipi.Trim().ToUpper() == "SAHIS")
                {
                    var mh = new Tbl_MusteriHareketler
                    {
                        UrunID = urunId,
                        Adet = adet,
                        PersonelID = personelId,
                        MusteriID = musteriOrFirmaId,
                        Fiyat = fiyat,
                        Toplam = toplam,
                        FaturaID = faturaId,
                        Tarih = tarihStr,
                        Notlar = notlar
                    };

                    db.Tbl_MusteriHareketler.Add(mh);
                }
                else if (faturaTipi.Trim().ToUpper() == "KURUMSAL")
                {
                    var fh = new Tbl_FirmaHareketler
                    {
                        UrunID = urunId,
                        Adet = adet,
                        PersonelID = personelId,
                        SirketID = musteriOrFirmaId, // dokümandaki mapping
                        Fiyat = fiyat,
                        Toplam = toplam,
                        FaturaID = faturaId,
                        Tarih = tarihStr,
                        Notlar = notlar
                    };

                    db.Tbl_FirmaHareketler.Add(fh);
                }

                db.SaveChanges(); // Kaydet
            }
        }
    }

}
