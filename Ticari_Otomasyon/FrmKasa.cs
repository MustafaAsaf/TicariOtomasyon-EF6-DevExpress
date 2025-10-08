using DevExpress.XtraCharts;
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
using DevExpress.XtraCharts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        private DboTicariOtomasyonEntities1 _context;
        public FrmKasa()
        {
            InitializeComponent();
            _context = new DboTicariOtomasyonEntities1();
        }

        private void geciciForm_Load(object sender, EventArgs e)
        {
            KasaBilgileriDoldur();
            Gelirler();
            Giderler();
            GrafikDoldurDevExpress();
            gridView1.BestFitColumns();
            gridView2.BestFitColumns();
        }

        public void KasaBilgileriDoldur()
        {

            try
            {
                using (var db = new DboTicariOtomasyonEntities1())
                {
                    // Bugünün tarihi
                    DateTime today = DateTime.Today;
                    DateTime monthStart = new DateTime(today.Year, today.Month, 1);
                    DateTime weekStart = today.AddDays(-7);


                    // 🔹 FaturaDetayları belleğe çekiyoruz
                    var faturaDetayList = db.Tbl_FaturaDetay
                        .Include("Tbl_FaturaBilgi") // ilişkili tabloyu da getir
                        .ToList();

                    // Günlük Gelir
                    var gunlukGelir = faturaDetayList
                        .Where(fd => DateTime.Parse(fd.Tbl_FaturaBilgi.FaturaTarih) == today)
                        .Sum(fd => (decimal?)fd.FaturaDetayTutar) ?? 0;
                    lblGunlukGelir.Text = gunlukGelir.ToString("N2") + " ₺";

                    // Haftalık Gelir
                    var haftalikGelir = faturaDetayList
                        .Where(fd => DateTime.Parse(fd.Tbl_FaturaBilgi.FaturaTarih) >= weekStart &&
                                     DateTime.Parse(fd.Tbl_FaturaBilgi.FaturaTarih) <= today)
                        .Sum(fd => (decimal?)fd.FaturaDetayTutar) ?? 0;
                    lblHaftalikGelir.Text = haftalikGelir.ToString("N2") + " ₺";

                    // Aylık Gelir
                    var aylikGelir = faturaDetayList
                        .Where(fd => DateTime.Parse(fd.Tbl_FaturaBilgi.FaturaTarih) >= monthStart &&
                                     DateTime.Parse(fd.Tbl_FaturaBilgi.FaturaTarih) <= today)
                        .Sum(fd => (decimal?)fd.FaturaDetayTutar) ?? 0;
                    lblAylikGelir.Text = aylikGelir.ToString("N2") + " ₺";

                    // Toplam Aylık Gider
                    var thisYear = today.Year.ToString();
                    // Ay adını Türkçe olarak alalım
                    var thisMonthName = today.ToString("MMMM", new System.Globalization.CultureInfo("tr-TR"));

                    // Örnek: "Ekim"
                    var aylikGider = db.Tbl_Giderler
                        .Where(g => g.GiderYıl == thisYear && g.GiderAy == thisMonthName)
                        .ToList()
                        .Sum(g => (decimal)(g.GiderElektrik + g.GiderSu + g.GiderDogalgaz +
                                            g.GiderInternet + g.GiderMaaslar + g.GiderEkstra));

                    lblAylikGider.Text = aylikGider.ToString("N2") + " ₺";

                    // Aylık Kasa Bakiyesi
                    var bakiye = aylikGelir - aylikGider;
                    lblKasaBakiyesi.Text = bakiye.ToString("N2") + " ₺";
                    if (bakiye < 0)
                    {
                        lblKasaBakiyesi.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblKasaBakiyesi.ForeColor = Color.Black;
                    }


                    // Personel Maaşları
                    var maaslar = db.Tbl_Giderler
                        .Where(g => g.GiderYıl == today.Year.ToString() && g.GiderAy == today.Month.ToString())
                        .ToList()
                        .Sum(g => (decimal)g.GiderMaaslar);
                    lblPersonelMaas.Text = maaslar.ToString("N2") + " ₺";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Gelirler()
        {
            try
            {
                var gelirler = _context.Tbl_FaturaDetay
                    .Select(f => new
                    {
                      f.FaturaID,
                      Tarih=f.Tbl_FaturaBilgi.FaturaTarih,
                      Müşteri=f.Tbl_FaturaBilgi.FaturaAlıcı,
                      Ürün=f.FaturaDetayUrunAd,
                      Miktar=f.FaturaDetayMiktar,
                      BirimFiyat=f.FaturaDetayFiyat,
                      ToplamTutar=f.FaturaDetayTutar
                    })
                    .ToList();

                gridControlGelir.DataSource = gelirler;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Giderler()
        {
            try
            {
                var giderler = _context.Tbl_Giderler
                    .Select(g => new
                    {
                       ID= g.GiderId,
                       Ay=g.GiderAy,
                       Yıl=g.GiderYıl,
                       Elektrik=g.GiderElektrik,
                       Su=g.GiderSu,
                       Doğalgaz=g.GiderDogalgaz,
                       İnternet=g.GiderInternet,
                       Maaşlar=g.GiderMaaslar,
                       Ekstra=g.GiderEkstra,
                       Notlar=g.GiderNotlar
                    })
                    .ToList();

                gridControlGiderler.DataSource = giderler;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrafikDoldurDevExpress()
        {
            try
            {
                // Son 4 ayı al
                var son4Ay = _context.Tbl_Giderler
                    .OrderByDescending(g => g.GiderId)
                    .Take(4)
                    .OrderBy(g => g.GiderId) // kronolojik sıraya sok
                    .ToList();

                chartKasa.Series.Clear();

                // Her gider kalemi için ayrı seri (StackedBar100)
                Series elektrik = new Series("Elektrik", ViewType.FullStackedBar);
                Series su = new Series("Su", ViewType.FullStackedBar);
                Series dogalgaz = new Series("Doğalgaz", ViewType.FullStackedBar);
                Series internet = new Series("İnternet", ViewType.FullStackedBar);
                Series maaslar = new Series("Maaşlar", ViewType.FullStackedBar);
                Series ekstra = new Series("Ekstra", ViewType.FullStackedBar);

                foreach (var gider in son4Ay)
                {
                    string ayAdi = $"{gider.GiderAy} {gider.GiderYıl}";

                    elektrik.Points.Add(new SeriesPoint(ayAdi, gider.GiderElektrik));
                    su.Points.Add(new SeriesPoint(ayAdi, gider.GiderSu));
                    dogalgaz.Points.Add(new SeriesPoint(ayAdi, gider.GiderDogalgaz));
                    internet.Points.Add(new SeriesPoint(ayAdi, gider.GiderInternet));
                    maaslar.Points.Add(new SeriesPoint(ayAdi, gider.GiderMaaslar));
                    ekstra.Points.Add(new SeriesPoint(ayAdi, gider.GiderEkstra));
                }

                // Serileri ekle
                chartKasa.Series.AddRange(new Series[] { elektrik, su, dogalgaz, internet, maaslar, ekstra });

                // Çubukları kalınlaştır
                foreach (Series s in chartKasa.Series)
                {
                    FullStackedBarSeriesView view = (FullStackedBarSeriesView)s.View;
                    view.BarWidth = 0.6; // 0.3 - 1.0 arası deneyebilirsin
                }

                // Başlık
                chartKasa.Titles.Clear();
                chartKasa.Titles.Add(new ChartTitle()
                {
                    Text = "Son 4 Ay Gider Dağılımı (%100)"
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            KasaBilgileriDoldur(); // 5 saniyede bir verileri tekrar yükle
        }
    }
}
