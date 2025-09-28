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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();


        /// <summary>
        /// Bu metottaki sorgu, ürünleri UrunAdi alanına göre gruplayıp, her bir ürünün toplam adetini getiriyor.
        /// </summary>
        private void groupProduct()
        {
            var sonuc = dataBase.Tbl_Urunler.GroupBy(u => u.UrunAdi)
                .Select(g => new
                {
                    UrunAdi=g.Key,
                    ToplamAdet=g.Sum(x => x.UrunAdet)
                }).ToList();
            gridControl1.DataSource=sonuc;
        }


        /// <summary>
        /// Alt kategoriye göre her bir alt kategoride kaç adet ürün var bunu öğreniyoruz.
        /// </summary>
        private void pastaGrafikCategory()
        {
            using (var context = new DboTicariOtomasyonEntities1())
            {
                var veriler = context.Tbl_Urunler
                    .GroupBy(u => u.Tbl_AltKategoriler.AltKategoriAdi)
                    .Select(g => new
                    {
                        AltKategoriAdi = g.Key,
                        ToplamAdet = g.Sum(x => x.UrunAdet)
                    })
                    .ToList();

                chartControl1.Series.Clear();

                Series seri = new Series("Alt Kategoriler", ViewType.Pie);

                foreach (var item in veriler)
                {
                    seri.Points.Add(new SeriesPoint(item.AltKategoriAdi, item.ToplamAdet));
                }

                seri.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                seri.Label.TextPattern = "{A}: {V} adet ({VP:P0})";
                chartControl1.Series.Add(seri);
            }

        }


        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            groupProduct();
            pastaGrafikCategory();
            /* chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 4);
               chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 8);
               chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 6);
               chartControl1.Series["Series 1"].Points.AddPoint("Trabzon", 5);*/
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //FORM STOK DETAY
        }
    }
}
