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

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            hareket();      
            ajanda();
            fihrist();
            dovizIslemleri();
        }

       
        public void rowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0) // Sadece veri satırları için
            {
                e.Appearance.BackColor = Color.FromArgb(255, 213, 194);   // Başlangıç rengi
                e.Appearance.BackColor2 = Color.FromArgb(130, 205, 224);  // Bitiş rengi
                e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
                // Horizontal → Yatay geçiş
                // Vertical → Dikey geçiş
            }
        }

        public void ajanda()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_Notlar.Select(note => new
                    {
                       Tarih= note.NotTarih,
                       Saat= note.NotSaat,
                       Baslık= note.NotBaslik,
                       Detay= note.NotDetay,
                    }).ToList();
                    gridControl1.DataSource = spendingList;
                    gridView1.RowStyle += rowStyle;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void azalanStok()
        {
            using (var context = new DboTicariOtomasyonEntities1())
            {
                var veriler = context.Tbl_Urunler.GroupBy(u => u.UrunAdi)
                    .Select(g => new
                    {
                        UrunAdi = g.Key,
                        ToplamAdet = g.Sum(x => x.UrunAdet)                       
                    })
                    .OrderBy(x => x.ToplamAdet) //En düşükten en yükseğe sıralama
                    .Where(x => x.ToplamAdet < 10) // 10'dan az stok filtreleme
                    .ToList();
      
            }
        }

        public void hareket()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var firmMovementList = values.Tbl_FirmaHareketler
                        .OrderByDescending(fh => fh.Tarih) // Tarihe göre azalan sırala
                        .Take(10)                         // Sadece son 10 kayıt
                        .Select(fh => new
                        {
                            UrunAdı = fh.Tbl_Urunler.UrunAdi,
                            fh.Adet,
                            Firma = fh.Tbl_Sirketler.SirketAd,
                            fh.Fiyat,
                            fh.Toplam,
                            fh.Tarih,
                        }).ToList();

                    gridControl3.DataSource = firmMovementList;
            
                    gridView3.RowStyle += rowStyle;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void fihrist()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_Musteriler.Select(m => new
                    {
                       Ad_Soyad=m.MusteriAd + " " + m.MusteriSoyad,
                       Telefon= m.MusteriTelefon,
                    }).ToList();
                    gridControl4.DataSource = spendingList;
                    gridView4.RowStyle += rowStyle;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA");
            }
        }


        public void dovizIslemleri()
        {
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }

    }
}
