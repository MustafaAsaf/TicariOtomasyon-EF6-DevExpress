using Newtonsoft.Json;
using System;
using System.Configuration; // app.config okumak için (System.Configuration referansı ekli değilse ekleyin)
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ticari_Otomasyon.Models;


namespace Ticari_Otomasyon
{
    public partial class FrmSatisAnaliz : Form
    {
        DboTicariOtomasyonEntities1 db = new DboTicariOtomasyonEntities1();

        public FrmSatisAnaliz()
        {
            InitializeComponent();
        }

        #region Viewleri Gridlere Yükleme

        private void LoadKategoriSatis()
        {
            var values = db.vw_KategoriSatisOzet
                .Select(x => new
                {
                    x.KategoriID,
                    x.KategoriAdi,
                    x.ToplamAdet,
                    x.ToplamSatisTutari
                })
                .ToList();

            gridKategoriler.DataSource = values;
        }

        private void LoadSatisHareketleri()
        {
            var values = db.vw_SatisHareketleri
                .Select(x => new
                {
                    x.HareketID,
                    x.UrunID,
                    x.Adet,
                    x.PersonelID,
                    x.CariID,
                    x.Fiyat,
                    x.Toplam,
                    x.FaturaID,
                    x.Tarih,
                    x.Notlar,
                    x.CariTip
                })
                .ToList();

            gridSatis.DataSource = values;
        }

        private void LoadUrunSatis()
        {
            var values = db.vw_UrunSatisOzet
                .Select(x => new
                {
                    x.UrunID,
                    x.UrunAdi,
                    x.ToplamAdet,
                    x.ToplamSatisTutari,
                    x.OrtalamaSatisFiyati,
                    x.AltKategoriID
                })
                .ToList();

            gridUrunler.DataSource = values;
        }

        private void LoadPersonelSatis()
        {
            var values = db.vw_PersonelSatisOzet
                .Select(x => new
                {
                    x.PersonelID,
                    x.PersonelAdi,
                    x.ToplamAdet,
                    x.ToplamSatisTutari
                })
                .ToList();

            gridPersoneller.DataSource = values;
        }

        private void FrmSatisAnaliz_Load(object sender, EventArgs e)
        {
            LoadKategoriSatis();
            LoadPersonelSatis();
            LoadSatisHareketleri();
            LoadUrunSatis();
        }

        #endregion

        #region Yardımcı Fonksiyonlar

        // Grid -> DataTable
        private DataTable GridToDataTable(DataGridView grid)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in grid.Columns)
                dt.Columns.Add(col.HeaderText);

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                        dRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;

                    dt.Rows.Add(dRow);
                }
            }
            return dt;
        }

        // DataTable -> JSON
        private string DataTableToJson(DataTable table)
        {
            return JsonConvert.SerializeObject(table, Formatting.Indented);
        }

        // Gemini Sorgusu
        private async Task<string> AskAI(string prompt)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string apiKey = ConfigurationManager.AppSettings["GEMINI_API_KEY"]
                            ?? Environment.GetEnvironmentVariable("GEMINI_API_KEY");

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("Gemini API anahtarı bulunamadı.");

            string modelName = "gemini-2.0-flash";   // ✔ DOĞRU MODEL

            string url = $"https://generativelanguage.googleapis.com/v1beta/models/{modelName}:generateContent?key={apiKey}";

            var body = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new { text = prompt }
                }
            }
        }
            };

            string jsonBody = JsonConvert.SerializeObject(body);

            using (HttpClient client = new HttpClient())
            using (var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Gemini API Hatası:\n" + json);

                dynamic obj = JsonConvert.DeserializeObject(json);

                string text = obj?.candidates?[0]?.content?.parts?[0]?.text;

                return text ?? json;
            }
        }




        #endregion



        // Grid verilerini analiz et
        private async void btnYorumla_Click(object sender, EventArgs e)
        {
            DataGridView aktifGrid = null;

            // Eğer tabcontrol kullanıyorsan aktif sekmeye göre seç
            if (tabControl1.SelectedTab == tabKategoriler)
            {
                aktifGrid = gridKategoriler;
            }             
            else if (tabControl1.SelectedTab == tabUrunler)
            {
                aktifGrid = gridUrunler;
            }               
            else if (tabControl1.SelectedTab == tabPersoneller)
            {
                aktifGrid = gridPersoneller;
            }                
            else if (tabControl1.SelectedTab == tabSatislar)
            {
                aktifGrid = gridSatis;
            }
                

            if (aktifGrid == null)
            {
                MessageBox.Show("Herhangi bir grid seçili değil.");
                return;
            }

            DataTable table = GridToDataTable(aktifGrid);
            string json = DataTableToJson(table);

            string prompt = $"Bu veriyi analiz et. Trend, risk, özet ve tavsiye çıkar:\n{json}";

            try
            {
                string result = await AskAI(prompt);
                txtCevap.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yapay zeka çağrısında hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        // Kullanıcı sorusunu yapay zekaya sor
        private async void btnSoruGonder_Click(object sender, EventArgs e)
        {
            string soru = txtSoru.Text.Trim();
            if (string.IsNullOrEmpty(soru))
            {
                MessageBox.Show("Lütfen bir soru yazın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Aktif grid seçimi
            DataGridView aktifGrid = null;
            if (tabControl1.SelectedTab == tabKategoriler)
                aktifGrid = gridKategoriler;
            else if (tabControl1.SelectedTab == tabUrunler)
                aktifGrid = gridUrunler;
            else if (tabControl1.SelectedTab == tabPersoneller)
                aktifGrid = gridPersoneller;
            else if (tabControl1.SelectedTab == tabSatislar)
                aktifGrid = gridSatis;

            if (aktifGrid == null)
            {
                MessageBox.Show("Herhangi bir grid seçili değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                txtCevap.Text = "Yükleniyor... Lütfen bekleyin.";

                // Grid -> JSON
                DataTable table = GridToDataTable(aktifGrid);
                string jsonGrid = DataTableToJson(table);

                // Kullanıcı sorusu + grid JSON’ı
                string combinedPrompt = $"Aşağıdaki veriyi dikkate alarak soruyu cevapla:\n{jsonGrid}\n\nSoru: {soru}";

                string result = await AskAI(combinedPrompt);

                txtCevap.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yapay zeka çağrısında hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


    }
}
