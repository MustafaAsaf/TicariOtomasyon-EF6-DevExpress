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
    public partial class FrmSatisAnaliz : Form
    {

        private readonly DboTicariOtomasyonEntities1 _context;
        private readonly SalesAnalyticsService _analyticsService;
        private GeminiClient _geminiClient;
        public FrmSatisAnaliz()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            _context = new DboTicariOtomasyonEntities1();
            _analyticsService = new SalesAnalyticsService(_context);
        }

        private void FrmSatisAnaliz_Load(object sender, EventArgs e)
        {
            dtBaslangic.Value = DateTime.Today.AddMonths(-1);
            dtBitis.Value = DateTime.Today;

            LoadKategoriFilter();
            LoadPersonelFilter();
            LoadAllData();
        }

        private void LoadKategoriFilter()
        {
            try
            {
                var kategoriler = _context.Tbl_Kategoriler
                    .OrderBy(k => k.KategoriAdi)
                    .ToList();

                cmbKategori.DataSource = kategoriler;
                cmbKategori.DisplayMember = "KategoriAdi";
                cmbKategori.ValueMember = "KategoriID";
                cmbKategori.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler yüklenirken hata oluştu: " + ex.Message);
            }
        }
        private void LoadPersonelFilter()
        {
            try
            {
                var personeller = _context.Tbl_Personeller
                    .OrderBy(p => p.PersonelAd)
                    .ThenBy(p => p.PersonelSoyad)
                    .ToList();

                cmbPersonel.DataSource = personeller;
                cmbPersonel.DisplayMember = "PersonelAd";
                cmbPersonel.ValueMember = "PersonelID";
                //cmbPersonel.ValueMember = "PersonellD";
                cmbPersonel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personeller yüklenirken hata oluştu: " + ex.Message);
            }
        }
        private void LoadAllData()
        {
            DateTime? baslangic = chkTarihFiltre.Checked ? (DateTime?)dtBaslangic.Value.Date : null;
            DateTime? bitis = chkTarihFiltre.Checked ? (DateTime?)dtBitis.Value.Date : null;

            int? kategoriId = null;
            if (cmbKategori.SelectedItem != null)
            {
                kategoriId = (int)((Tbl_Kategoriler)cmbKategori.SelectedItem).KategoriID;
            }

            // Ürün bazlı
            var productSummary = _analyticsService.GetProductSalesSummary(
                baslangic,
                bitis,
                kategoriId,
                (int)nudMinAdet.Value);

            gridUrunler.DataSource = productSummary;

            // Kategori bazlı
            var categorySummary = _analyticsService.GetCategorySalesSummary(
                baslangic,
                bitis);

            gridKategoriler.DataSource = categorySummary;

            // Personel bazlı
            var employeeSummary = _analyticsService.GetEmployeeSalesSummary(
                baslangic,
                bitis);

            if (cmbPersonel.SelectedItem != null)
            {
                int selectedPersonelId = (int)((Tbl_Personeller)cmbPersonel.SelectedItem).PersonellD;
                employeeSummary = employeeSummary
                    .Where(e => e.PersonelID == selectedPersonelId)
                    .ToList();
            }

            gridPersoneller.DataSource = employeeSummary;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnGeminiYorumla_Click(object sender, EventArgs e)
        {
            try
            {
                if (_geminiClient == null)
                {
                    try
                    {
                        _geminiClient = new GeminiClient();
                    }
                    catch (Exception ex)
                    {
                        txtGeminiCevap.Text = "Gemini istemcisi oluşturulamadı: " + ex.Message;
                        return;
                    }
                }

                txtGeminiCevap.Text = "Gemini'den yanıt bekleniyor...";

                var prompt = BuildSummaryPromptForActiveTab();
                if (string.IsNullOrWhiteSpace(prompt))
                {
                    txtGeminiCevap.Text = "Analiz edilecek veri bulunamadı.";
                    return;
                }

                using (var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    var response = await _geminiClient.GetInsightsAsync(prompt, cts.Token);
                    txtGeminiCevap.Text = string.IsNullOrWhiteSpace(response)
                        ? "Gemini yanıt döndürmedi."
                        : response;
                }
            }
            catch (Exception ex)
            {
                txtGeminiCevap.Text = "Gemini çağrısı sırasında hata oluştu: " + ex.Message;
            }
        }

        private async void btnGeminiSoruGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (_geminiClient == null)
                {
                    try
                    {
                        _geminiClient = new GeminiClient();
                    }
                    catch (Exception ex)
                    {
                        txtGeminiCevap.Text = "Gemini istemcisi oluşturulamadı: " + ex.Message;
                        return;
                    }
                }

                txtGeminiCevap.Text = "Gemini'den yanıt bekleniyor...";

                var baseSummary = BuildSummaryPromptForActiveTab(includeInstruction: false);
                var userQuestion = txtGeminiSoru.Text;

                if (string.IsNullOrWhiteSpace(userQuestion))
                {
                    txtGeminiCevap.Text = "Lütfen bir soru yazın.";
                    return;
                }

                var prompt = "Aşağıda bir ticari otomasyon sisteminden alınmış satış özet verileri ve bir kullanıcı sorusu var.\n" +
                             "Verileri dikkate alarak soruyu Türkçe, kısa ama içgörülü şekilde yanıtla.\n\n" +
                             "SATIŞ ÖZETİ:\n" + (string.IsNullOrWhiteSpace(baseSummary) ? "(Özet veri yok)\n" : baseSummary + "\n") +
                             "KULLANICI SORUSU:\n" + userQuestion;

                using (var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    var response = await _geminiClient.GetInsightsAsync(prompt, cts.Token);
                    txtGeminiCevap.Text = string.IsNullOrWhiteSpace(response)
                        ? "Gemini yanıt döndürmedi."
                        : response;
                }
            }
            catch (Exception ex)
            {
                txtGeminiCevap.Text = "Gemini çağrısı sırasında hata oluştu: " + ex.Message;
            }
        }

        /// <summary>
        /// Aktif sekmedeki veriyi kısa bir metinsel özet haline getirip prompt olarak hazırlar.
        /// </summary>
        private string BuildSummaryPromptForActiveTab(bool includeInstruction)
        {
            var instruction = includeInstruction
                ? "Bu veriler bir ticari otomasyon sistemindeki satış özetleridir. Kısa bir analiz ve geliştirme önerileri üret.\n"
                : string.Empty;

            if (tabControl1.SelectedTab == tabUrunler)
            {
                var list = gridUrunler.DataSource as IList<SalesAnalyticsService.ProductSalesSummaryDto>;
                if (list == null || list.Count == 0)
                {
                    return string.Empty;
                }

                var top = list.Take(20)
                    .Select(x => new
                    {
                        x.UrunAdi,
                        x.KategoriAdi,
                        x.AltKategoriAdi,
                        x.ToplamAdet,
                        x.ToplamCiro
                    })
                    .ToList();

                var sb = new System.Text.StringBuilder();
                sb.AppendLine(instruction);
                sb.AppendLine("ÜRÜN SATIŞ ÖZETİ (ilk 20 kayıt):");

                foreach (var item in top)
                {
                    sb.AppendLine(
                        $"- Ürün: {item.UrunAdi}, Kategori: {item.KategoriAdi}/{item.AltKategoriAdi}, Adet: {item.ToplamAdet}, Ciro: {item.ToplamCiro:0.##}");
                }

                return sb.ToString();
            }

            if (tabControl1.SelectedTab == tabKategoriler)
            {
                var list = gridKategoriler.DataSource as IList<SalesAnalyticsService.CategorySalesSummaryDto>;
                if (list == null || list.Count == 0)
                {
                    return string.Empty;
                }

                var top = list.Take(20).ToList();
                var sb = new System.Text.StringBuilder();
                sb.AppendLine(instruction);
                sb.AppendLine("KATEGORİ SATIŞ ÖZETİ (ilk 20 kayıt):");

                foreach (var item in top)
                {
                    sb.AppendLine(
                        $"- Kategori: {item.KategoriAdi}, Ürün Sayısı: {item.UrunSayisi}, Adet: {item.ToplamAdet}, Ciro: {item.ToplamCiro:0.##}");
                }

                return sb.ToString();
            }

            if (tabControl1.SelectedTab == tabPersoneller)
            {
                var list = gridPersoneller.DataSource as IList<SalesAnalyticsService.EmployeeSalesSummaryDto>;
                if (list == null || list.Count == 0)
                {
                    return string.Empty;
                }

                var top = list.Take(20).ToList();
                var sb = new System.Text.StringBuilder();
                sb.AppendLine(instruction);
                sb.AppendLine("PERSONEL SATIŞ PERFORMANSI (ilk 20 kayıt):");

                foreach (var item in top)
                {
                    sb.AppendLine(
                        $"- Personel: {item.AdSoyad}, Satış Sayısı: {item.SatisSayisi}, Adet: {item.ToplamAdet}, Ciro: {item.ToplamCiro:0.##}");
                }

                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
