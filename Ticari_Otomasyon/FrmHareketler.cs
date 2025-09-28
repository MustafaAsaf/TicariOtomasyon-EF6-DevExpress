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
    public partial class FrmHareketler : Form
    {
        
        public FrmHareketler()  
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();
        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            GetFirmaMusteriHareketleri();
            GetSahisMusteriHareketleri();
            gridViewFirmaHareket.BestFitColumns(true);
            gridViewMusteriHareket.BestFitColumns(true);
        }
        public void GetFirmaMusteriHareketleri()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_FirmaHareketler.Select(fh => new
                    {
                        fh.FirmaHareketID,
                        UrunAdı=fh.Tbl_Urunler.UrunAdi,
                        fh.Adet,
                        PersonelAdSoyad = fh.Tbl_Personeller.PersonelAd + " " + fh.Tbl_Personeller.PersonelSoyad,
                        fh.Tbl_Sirketler.SirketAd,
                        fh.Fiyat,
                        fh.Toplam,
                        fh.FaturaID,
                        fh.Tarih,
                        fh.Notlar
                    }).ToList();
                    gridControlFirmaHareket.DataSource = spendingList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetSahisMusteriHareketleri()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_MusteriHareketler.Select(fh => new
                    {
                        fh.MusteriHareketID,
                        UrunAdı = fh.Tbl_Urunler.UrunAdi,
                        fh.Adet,
                        PersonelAdSoyad = fh.Tbl_Personeller.PersonelAd + " " + fh.Tbl_Personeller.PersonelSoyad,
                        MusteriAdSoyad=fh.Tbl_Musteriler.MusteriAd +" "+ fh.Tbl_Musteriler.MusteriSoyad,
                        fh.Fiyat,
                        fh.Toplam,
                        fh.FaturaID,
                        fh.Tarih,
                        fh.Notlar
                    }).ToList();
                    gridControlMusteriHareket.DataSource = spendingList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
