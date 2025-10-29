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
            if (!CurrentUser.HasPermission("ViewStock"))
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!", "Yetkisiz erişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            groupProduct();
            pastaGrafikCategory();
            getKategoriler();
            KategoriComboDoldur();
            Listele();
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
                    UrunAdi = g.Key,
                    ToplamAdet = g.Sum(x => x.UrunAdet)
                }).ToList();
            gridControl1.DataSource = sonuc;
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

            gridViewKategoriler.MasterRowExpanded += gridViewKategoriler_MasterRowExpanded;
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

        private void gridViewKategoriler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewKategoriler.FocusedRowHandle >= 0)
            {
                txtKategoriID.Text = gridViewKategoriler.GetFocusedRowCellValue("KategoriID").ToString();
                txtKategoriAdi.Text = gridViewKategoriler.GetFocusedRowCellValue("KategoriAdi").ToString();
                cmbKategori.Text = gridViewKategoriler.GetFocusedRowCellValue("KategoriAdi").ToString();
            }
            seciliTablo = TabloTipi.Kategori;
        }

        private void gridViewKategoriler_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView masterView = sender as GridView;
            GridView childView = masterView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;

            if (childView != null)
            {
                childView.FocusedRowChanged -= gridViewAltKategoriler_FocusedRowChanged;
                childView.FocusedRowChanged += gridViewAltKategoriler_FocusedRowChanged;
            }
        }

        private void gridViewAltKategoriler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
           
            if (view.FocusedRowHandle >= 0)
            {
                txtAltKategoriID.Text = view.GetFocusedRowCellValue("AltKategoriID")?.ToString();
                txtAltKategoriAdi.Text = view.GetFocusedRowCellValue("AltKategoriAdi")?.ToString();
            }
            seciliTablo = TabloTipi.AltKategori;
        }



        //CRUD İŞLEMLERİ
        //Tek butonlarla crud silme işlemi yapacağımız için ENUM oluşturup hangi tablo üzerinde işlem yapılacağının kontrolünü yapmalıyız.
        private enum TabloTipi
        {
            Kategori,
            AltKategori
        }

        private TabloTipi seciliTablo;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliTablo == TabloTipi.Kategori)
                {
                    int id = Convert.ToInt32(gridViewKategoriler.GetFocusedRowCellValue("KategoriID"));
                    var kategori = db.Tbl_Kategoriler
                        .Include("Tbl_AltKategoriler") // Alt kategorileri de birlikte çek
                        .FirstOrDefault(k => k.KategoriID == id);

                    if (kategori != null)
                    {
                        // Bu kategoriye bağlı alt kategoriler var mı?
                        if (kategori.Tbl_AltKategoriler.Any())
                        {
                            DialogResult altResult = MessageBox.Show(
                                "Bu kategoriye bağlı alt kategoriler var. Hepsini silmek istiyor musunuz?",
                                "Alt Kategoriler Bulundu",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (altResult == DialogResult.No)
                                return;

                            // Alt kategorileri topluca sil
                            db.Tbl_AltKategoriler.RemoveRange(kategori.Tbl_AltKategoriler);
                        }

                        DialogResult result = MessageBox.Show(
                            "Bu kategoriyi silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            db.Tbl_Kategoriler.Remove(kategori);
                            db.SaveChanges();

                            MessageBox.Show("Kategori ve bağlı alt kategoriler silindi.", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Listele();
                            ClearForm(this);
                        }
                    }
                }
                else if (seciliTablo == TabloTipi.AltKategori)
                {
                    int id = Convert.ToInt32(txtAltKategoriID.Text);
                    var altKategori = db.Tbl_AltKategoriler.Find(id);

                    if (altKategori != null)
                    {
                        DialogResult result = MessageBox.Show(
                            "Bu alt kategoriyi silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            db.Tbl_AltKategoriler.Remove(altKategori);
                            db.SaveChanges();

                            MessageBox.Show("Alt kategori silindi.", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Listele();
                            ClearForm(this);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm(this);
        }

        public void ClearForm(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                switch (control)
                {
                    // --- Standart Windows Forms Kontrolleri ---
                    case TextBox textBox:
                        textBox.Clear();
                        break;
                    case MaskedTextBox maskedTextBox:
                        maskedTextBox.Clear();
                        break;
                    case RichTextBox richTextBox:
                        richTextBox.Clear();
                        break;
                    case System.Windows.Forms.ComboBox comboBox:
                        comboBox.SelectedIndex = -1; // Seçimi kaldırır
                        comboBox.Text = string.Empty;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false; // İşareti kaldırır
                        break;
                    case RadioButton radioButton:
                        // Genellikle RadioButton'lar bir grup içinde olur ve biri seçili kalır.
                        // Eğer hepsinin seçimini kaldırmak isterseniz bu kodu kullanabilirsiniz.
                        radioButton.Checked = false;
                        break;
                    case NumericUpDown numericUpDown:
                        numericUpDown.Value = numericUpDown.Minimum; // Minimum değere ayarlar
                        break;
                    case DateTimePicker dateTimePicker:
                        dateTimePicker.Value = DateTime.Now; // Geçerli tarihe ayarlar
                        break;

                    // --- DevExpress Kontrolleri ---
                    case DevExpress.XtraEditors.TextEdit textEdit:
                        textEdit.Text = string.Empty;
                        break;
                        // Buraya diğer DevExpress kontrollerini (LookUpEdit, GridLookUpEdit vb.) ekleyebilirsiniz.
                        // case DevExpress.XtraEditors.LookUpEdit lookUpEdit:
                        //     lookUpEdit.EditValue = null;
                        //     break;
                }

                // Eğer kontrolün içinde başka kontroller varsa (Panel, GroupBox, LayoutControl gibi),
                // metodu o kontrol için de çalıştır.
                if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }

        private void gridViewAltKategoriler_Click(object sender, EventArgs e)
        {
            seciliTablo = TabloTipi.AltKategori;
        }

        private void btnAddKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))
                {
                    MessageBox.Show("Lütfen kategori adını girin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bu kategoriyi eklemek istiyor musunuz?",
                    "Kayıt Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                Tbl_Kategoriler kategori = new Tbl_Kategoriler
                {
                    KategoriAdi = txtKategoriAdi.Text
                };

                db.Tbl_Kategoriler.Add(kategori);
                db.SaveChanges();

                MessageBox.Show("Yeni kategori başarıyla eklendi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Listele();
                ClearForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategori eklenirken bir hata oluştu:\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddAltKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewKategoriler.FocusedRowHandle < 0)
                {
                    MessageBox.Show("Lütfen önce bir ana kategori seçin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAltKategoriAdi.Text))
                {
                    MessageBox.Show("Lütfen alt kategori adını girin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bu alt kategoriyi eklemek istiyor musunuz?",
                    "Kayıt Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                int secilenKategoriID = Convert.ToInt32(gridViewKategoriler.GetFocusedRowCellValue("KategoriID"));

                Tbl_AltKategoriler altKategori = new Tbl_AltKategoriler
                {
                    AltKategoriAdi = txtAltKategoriAdi.Text,
                    KategoriID = secilenKategoriID
                };

                db.Tbl_AltKategoriler.Add(altKategori);
                db.SaveChanges();

                MessageBox.Show("Yeni alt kategori başarıyla eklendi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Listele();
                ClearForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Alt kategori eklenirken bir hata oluştu:\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateAltKategori_Click(object sender, EventArgs e)
        {
            try
            {
                // Ana gridin aktif satırı:
                GridView masterView = gridViewKategoriler;
                int masterRowHandle = masterView.FocusedRowHandle;

                // Aktif alt kategori gridini (detail view) al
                GridView activeDetailView = masterView.GetDetailView(masterRowHandle, 0) as GridView;
                if (activeDetailView == null)
                {
                    MessageBox.Show("Lütfen önce bir alt kategori satırını seçin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (activeDetailView.FocusedRowHandle < 0)
                {
                    MessageBox.Show("Lütfen güncellenecek alt kategoriyi seçin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(activeDetailView.GetFocusedRowCellValue("AltKategoriID"));
                var altKategori = db.Tbl_AltKategoriler.Find(id);

                if (altKategori == null)
                {
                    MessageBox.Show("Alt kategori bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bu alt kategoriyi güncellemek istiyor musunuz?",
                    "Güncelleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                altKategori.AltKategoriAdi = txtAltKategoriAdi.Text;
                altKategori.KategoriID = Convert.ToInt32(txtKategoriID.Text);

                db.SaveChanges();

                MessageBox.Show("Alt kategori başarıyla güncellendi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Listele();
                ClearForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu:\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewKategoriler.FocusedRowHandle < 0)
                {
                    MessageBox.Show("Lütfen önce bir kategori seçin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(gridViewKategoriler.GetFocusedRowCellValue("KategoriID"));
                var kategori = db.Tbl_Kategoriler.Find(id);

                if (kategori == null)
                {
                    MessageBox.Show("Güncellenecek kategori bulunamadı!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bu kategoriyi güncellemek istiyor musunuz?",
                    "Güncelleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                kategori.KategoriAdi = txtKategoriAdi.Text;
                db.SaveChanges();

                MessageBox.Show("Kategori başarıyla güncellendi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Listele();
                ClearForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu:\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
