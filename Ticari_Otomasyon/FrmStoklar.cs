using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; // EF Include için
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

        DboTicariOtomasyonEntities1 db = new DboTicariOtomasyonEntities1();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            groupProduct();
            pastaGrafikCategory();
            getKategoriler();
            KategoriComboDoldur();
            Listele();
        }

        void Listele()
        {
            var kategoriler = db.Tbl_Kategoriler
                .Select(k => new { k.KategoriID, k.KategoriAdi })
                .ToList();

            gridControlKategoriler.MainView = gridViewKategoriler;
            gridControlKategoriler.DataSource = kategoriler;
            gridControlKategoriler.LevelTree.Nodes.Clear();
            gridControlKategoriler.LevelTree.Nodes.Add("AltKategoriler", gridViewAltKategoriler);

            gridViewKategoriler.PopulateColumns();
            gridViewAltKategoriler.PopulateColumns();

            // Child'ı kendimiz çekeceğiz:
            gridViewKategoriler.MasterRowGetChildList -= gridViewKategoriler_MasterRowGetChildList;
            gridViewKategoriler.MasterRowGetChildList += gridViewKategoriler_MasterRowGetChildList;

            gridViewKategoriler.MasterRowGetRelationName -= gridViewKategoriler_MasterRowGetRelationName;
            gridViewKategoriler.MasterRowGetRelationName += gridViewKategoriler_MasterRowGetRelationName;

            gridViewKategoriler.MasterRowGetRelationCount -= gridViewKategoriler_MasterRowGetRelationCount;
            gridViewKategoriler.MasterRowGetRelationCount += gridViewKategoriler_MasterRowGetRelationCount;
        }
        private void gridViewKategoriler_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1; // her kategorinin bir alt tablo ilişkisi var
        }

        private void gridViewKategoriler_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "AltKategoriler";
        }

        private void gridViewKategoriler_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            int kategoriId = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "KategoriID"));

            var altList = db.Tbl_AltKategoriler
                .Where(a => a.KategoriID == kategoriId)
                .Select(a => new { a.AltKategoriID, a.AltKategoriAdi })
                .ToList();

            e.ChildList = altList;
        }


        private void KategoriComboDoldur()
        {
            var liste = db.Tbl_Kategoriler
                .Select(k => new { k.KategoriID, k.KategoriAdi })
                .ToList();

            cmbKategori.DataSource = liste;
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";
        }

        /// <summary>
        /// Bu metottaki sorgu, ürünleri UrunAdi alanına göre gruplayıp, her bir ürünün toplam adetini getiriyor.
        /// </summary>
        private void groupProduct()
        {
            var sonuc = db.Tbl_Urunler.GroupBy(u => u.UrunAdi)
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

        /// <summary>
        /// gridviewKategoriler nesnesinde kategori isimlerini çağıran metot.
        /// </summary>
        private void getKategoriler()
        {
            var kategoriler = db.Tbl_Kategoriler
                .Select(k => new
                {
                    k.KategoriID,
                    k.KategoriAdi,
                    // AltKategoriler adını kullanıyoruz; LevelTree'de bu isimle bağlayacağız
                    AltKategoriler = k.Tbl_AltKategoriler
                        .Select(a => new { a.AltKategoriID, a.AltKategoriAdi })
                        .ToList()
                }).ToList();

            gridControlKategoriler.DataSource = kategoriler;

            gridViewKategoriler.PopulateColumns();
            gridViewAltKategoriler.PopulateColumns();

            gridViewKategoriler.OptionsDetail.ShowDetailTabs = false;
            gridViewKategoriler.OptionsView.ShowGroupPanel = false;

            // Aynı şekilde tek tıklama ile aç/kapa yapmak için:
            gridViewKategoriler.RowCellClick -= gridViewKategoriler_RowClick;
            gridViewKategoriler.RowCellClick += gridViewKategoriler_RowClick;
        }

      

        private void gridViewKategoriler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = gridViewKategoriler.GetFocusedRow() as Tbl_Kategoriler;
            if (row != null)
            {
                txtKategoriID.Text = row.KategoriID.ToString();
                txtKategoriAdi.Text = row.KategoriAdi;
            }
        }

        private void gridViewAltKategoriler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = gridViewAltKategoriler.GetFocusedRow() as Tbl_AltKategoriler;
            if (row != null)
            {
                txtAltKategoriID.Text = row.AltKategoriID.ToString();
                txtAltKategoriAdi.Text = row.AltKategoriAdi;
                cmbKategori.SelectedValue = row.KategoriID;
            }
        }

        private void gridViewKategoriler_RowClick(object sender, RowClickEventArgs e)
        {

        }
    }
}
