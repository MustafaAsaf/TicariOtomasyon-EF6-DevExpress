using DevExpress.XtraCharts;
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
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing.Drawing2D;


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
            dovizIslemleri();
            azalanStok();
            userInformation();
            ModernizeArayuz();
        }
        // Bu metodları FrmAnaSayfa class'ının içine yapıştır
        private void ModernizeArayuz()
        {
            // 1. GENEL TEMA (DevExpress Skin)
            // Eğer Program.cs'de global bir skin belirlemediysen burayı açabilirsin.
            // DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Bezier"); 
            // veya "Office 2019 Colorful" deneyebilirsin.

            // 2. GRIDLERİN MODERNİZASYONU
            StyleGrid(gridView1); // Ajanda
            StyleGrid(gridView3); // Son 10 Hareket
            StyleGrid(gridView4); // Azalan Slotlar

            // 3. GROUP CONTROL BAŞLIKLARI
            StyleGroupControl(groupControl2);
            StyleGroupControl(groupControl3);
            StyleGroupControl(groupControl4);

            // 4. PROFİL RESMİNİ YUVARLAK YAPMA
            MakeCircular(pictureBox_Profil);

            // Panel rengini biraz daha yumuşatalım (Eğer skin kullanmıyorsan)
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.Appearance.BackColor = Color.White;
            panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Azalan Slotlar için Stok sütununa Progress Bar ekleme
            // NOT: "StokSayisi" yerine veritabanındaki gerçek kolon adını yazmalısın (FieldName)
            if (gridView4.Columns["StokSayisi"] != null)
            {
                DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ritem = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
                ritem.ShowTitle = true; // Sayıyı da göster
                ritem.PercentView = false; // Yüzde değil sayı göstersin
                ritem.Maximum = 100; // Maksimum stok sayısı (bunu dinamik de yapabilirsin)

                // Renk ayarı
                ritem.StartColor = Color.Red;
                ritem.EndColor = Color.Green;

                gridControl4.RepositoryItems.Add(ritem);
                gridView4.Columns["StokSayisi"].ColumnEdit = ritem;
            }
        }
        private void StyleGrid(GridView view)
        {
            // Temel Görünüm
            view.OptionsView.ShowGroupPanel = false; // Üstteki gri alanı kaldır
            view.OptionsView.ShowIndicator = false;  // Sol baştaki ok işaretini kaldır
            view.OptionsView.EnableAppearanceEvenRow = true; // Zebra satır (bir gri bir beyaz)
            view.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False; // Dikey çizgileri kaldır (daha temiz)
            view.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;

            // Satır Yükseklikleri (Nefes aldıralım)
            view.RowHeight = 35;
            view.ColumnPanelRowHeight = 45; // Başlık yüksekliği

            // Fontlar
            view.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; // Başlıklar ortalı
            view.Appearance.Row.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            view.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; // Veriler ortalı

            // Renkler (Skin kullanıyorsan burayı ezebilir, manuel renk için Appearance kullan)
            view.Appearance.HeaderPanel.ForeColor = Color.FromArgb(64, 64, 64);
            view.Appearance.FocusedRow.BackColor = Color.FromArgb(41, 128, 185); // Seçili satır rengi (Mavi tonu)
            view.Appearance.FocusedRow.ForeColor = Color.White;
        }
        private void StyleGroupControl(GroupControl group)
        {
            // GroupControl başlığını özelleştirme
            group.AppearanceCaption.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            group.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            group.CaptionImageOptions.SvgImageSize = new Size(24, 24); // Varsa ikon boyutu
        }
        private void MakeCircular(System.Windows.Forms.PictureBox box)
        {
            // Resmi yuvarlak kesmek için
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, box.Width - 1, box.Height - 1);
            Region rg = new Region(gp);
            box.Region = rg;
            box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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

                gridControl4.DataSource = veriler;

                gridView4.RowStyle += rowStyle;

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

        public void userInformation()
        {
            lbl_KullaniciAdi.Text = CurrentUser.KullaniciAdi;
            lblNameLastName.Text = CurrentUser.PersonelAdSoyad;

            // Birden fazla rol varsa ilkini gösterebiliriz
            if (CurrentUser.Roller != null && CurrentUser.Roller.Count > 0)
                lbl_Gorev.Text = CurrentUser.Roller[0];
            else
                lbl_Gorev.Text = "Rol bulunamadı";

            // Profil resmini göster
            if (CurrentUser.ProfilResim != null && CurrentUser.ProfilResim.Length > 0)
            {
                pictureBox_Profil.Image = ByteToImage(CurrentUser.ProfilResim);
            }
            else
            {
                pictureBox_Profil.Image = null; // Profil resmi yoksa boş bırak
            }
        }

        // Yardımcı fonksiyon: byte[] -> Image
        private Image ByteToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

    }
}
