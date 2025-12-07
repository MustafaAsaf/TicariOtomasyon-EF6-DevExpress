namespace Ticari_Otomasyon
{
    partial class FrmSatisAnaliz
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUrunler = new System.Windows.Forms.TabPage();
            this.gridUrunler = new System.Windows.Forms.DataGridView();
            this.tabKategoriler = new System.Windows.Forms.TabPage();
            this.gridKategoriler = new System.Windows.Forms.DataGridView();
            this.tabPersoneller = new System.Windows.Forms.TabPage();
            this.gridPersoneller = new System.Windows.Forms.DataGridView();
            this.tabSatislar = new System.Windows.Forms.TabPage();
            this.gridSatis = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtAIResponse = new System.Windows.Forms.Panel();
            this.panelInputArea = new System.Windows.Forms.Panel();
            this.btnSoruGonder = new System.Windows.Forms.Button();
            this.txtSoru = new System.Windows.Forms.TextBox();
            this.lblGeminiSoru = new System.Windows.Forms.Label();
            this.lblGeminiCevap = new System.Windows.Forms.Label();
            this.txtCevap = new System.Windows.Forms.RichTextBox();
            this.btnYorumla = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabUrunler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunler)).BeginInit();
            this.tabKategoriler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKategoriler)).BeginInit();
            this.tabPersoneller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPersoneller)).BeginInit();
            this.tabSatislar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSatis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.txtAIResponse.SuspendLayout();
            this.panelInputArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUrunler);
            this.tabControl1.Controls.Add(this.tabKategoriler);
            this.tabControl1.Controls.Add(this.tabPersoneller);
            this.tabControl1.Controls.Add(this.tabSatislar);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1051, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUrunler
            // 
            this.tabUrunler.Controls.Add(this.gridUrunler);
            this.tabUrunler.Location = new System.Drawing.Point(4, 32);
            this.tabUrunler.Name = "tabUrunler";
            this.tabUrunler.Padding = new System.Windows.Forms.Padding(3);
            this.tabUrunler.Size = new System.Drawing.Size(1043, 524);
            this.tabUrunler.TabIndex = 0;
            this.tabUrunler.Text = "Ürün Bazlı Analiz";
            this.tabUrunler.UseVisualStyleBackColor = true;
            // 
            // gridUrunler
            // 
            this.gridUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUrunler.BackgroundColor = System.Drawing.Color.White;
            this.gridUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUrunler.Location = new System.Drawing.Point(3, 3);
            this.gridUrunler.Name = "gridUrunler";
            this.gridUrunler.RowHeadersWidth = 51;
            this.gridUrunler.Size = new System.Drawing.Size(1037, 518);
            this.gridUrunler.TabIndex = 0;
            // 
            // tabKategoriler
            // 
            this.tabKategoriler.Controls.Add(this.gridKategoriler);
            this.tabKategoriler.Location = new System.Drawing.Point(4, 32);
            this.tabKategoriler.Name = "tabKategoriler";
            this.tabKategoriler.Padding = new System.Windows.Forms.Padding(3);
            this.tabKategoriler.Size = new System.Drawing.Size(1043, 524);
            this.tabKategoriler.TabIndex = 1;
            this.tabKategoriler.Text = "Kategori Bazlı Analiz";
            this.tabKategoriler.UseVisualStyleBackColor = true;
            // 
            // gridKategoriler
            // 
            this.gridKategoriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridKategoriler.BackgroundColor = System.Drawing.Color.White;
            this.gridKategoriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKategoriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKategoriler.Location = new System.Drawing.Point(3, 3);
            this.gridKategoriler.Name = "gridKategoriler";
            this.gridKategoriler.RowHeadersWidth = 51;
            this.gridKategoriler.Size = new System.Drawing.Size(1037, 518);
            this.gridKategoriler.TabIndex = 0;
            // 
            // tabPersoneller
            // 
            this.tabPersoneller.Controls.Add(this.gridPersoneller);
            this.tabPersoneller.Location = new System.Drawing.Point(4, 32);
            this.tabPersoneller.Name = "tabPersoneller";
            this.tabPersoneller.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersoneller.Size = new System.Drawing.Size(1043, 524);
            this.tabPersoneller.TabIndex = 2;
            this.tabPersoneller.Text = "Personel Performansı";
            this.tabPersoneller.UseVisualStyleBackColor = true;
            // 
            // gridPersoneller
            // 
            this.gridPersoneller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPersoneller.BackgroundColor = System.Drawing.Color.White;
            this.gridPersoneller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPersoneller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPersoneller.Location = new System.Drawing.Point(3, 3);
            this.gridPersoneller.Name = "gridPersoneller";
            this.gridPersoneller.RowHeadersWidth = 51;
            this.gridPersoneller.Size = new System.Drawing.Size(1037, 518);
            this.gridPersoneller.TabIndex = 0;
            // 
            // tabSatislar
            // 
            this.tabSatislar.Controls.Add(this.gridSatis);
            this.tabSatislar.Location = new System.Drawing.Point(4, 32);
            this.tabSatislar.Name = "tabSatislar";
            this.tabSatislar.Padding = new System.Windows.Forms.Padding(3);
            this.tabSatislar.Size = new System.Drawing.Size(1043, 524);
            this.tabSatislar.TabIndex = 3;
            this.tabSatislar.Text = "Satış Bazlı Analiz";
            this.tabSatislar.UseVisualStyleBackColor = true;
            // 
            // gridSatis
            // 
            this.gridSatis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSatis.BackgroundColor = System.Drawing.Color.White;
            this.gridSatis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSatis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSatis.Location = new System.Drawing.Point(3, 3);
            this.gridSatis.Name = "gridSatis";
            this.gridSatis.RowHeadersWidth = 51;
            this.gridSatis.Size = new System.Drawing.Size(1037, 518);
            this.gridSatis.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtAIResponse);
            this.splitContainer1.Size = new System.Drawing.Size(1374, 560);
            this.splitContainer1.SplitterDistance = 1051;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtAIResponse
            // 
            this.txtAIResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtAIResponse.Controls.Add(this.panelInputArea);
            this.txtAIResponse.Controls.Add(this.lblGeminiCevap);
            this.txtAIResponse.Controls.Add(this.txtCevap);
            this.txtAIResponse.Controls.Add(this.btnYorumla);
            this.txtAIResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAIResponse.Location = new System.Drawing.Point(0, 0);
            this.txtAIResponse.Name = "txtAIResponse";
            this.txtAIResponse.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.txtAIResponse.Size = new System.Drawing.Size(319, 560);
            this.txtAIResponse.TabIndex = 0;
            // 
            // panelInputArea
            // 
            this.panelInputArea.BackColor = System.Drawing.Color.White;
            this.panelInputArea.Controls.Add(this.btnSoruGonder);
            this.panelInputArea.Controls.Add(this.txtSoru);
            this.panelInputArea.Controls.Add(this.lblGeminiSoru);
            this.panelInputArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInputArea.Location = new System.Drawing.Point(0, 410);
            this.panelInputArea.Name = "panelInputArea";
            this.panelInputArea.Size = new System.Drawing.Size(319, 150);
            this.panelInputArea.TabIndex = 6;
            // 
            // btnSoruGonder
            // 
            this.btnSoruGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSoruGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoruGonder.FlatAppearance.BorderSize = 0;
            this.btnSoruGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoruGonder.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSoruGonder.ForeColor = System.Drawing.Color.White;
            this.btnSoruGonder.Location = new System.Drawing.Point(13, 98);
            this.btnSoruGonder.Name = "btnSoruGonder";
            this.btnSoruGonder.Size = new System.Drawing.Size(294, 40);
            this.btnSoruGonder.TabIndex = 4;
            this.btnSoruGonder.Text = "SORUYU GÖNDER";
            this.btnSoruGonder.UseVisualStyleBackColor = false;
            this.btnSoruGonder.Click += new System.EventHandler(this.btnSoruGonder_Click);
            // 
            // txtSoru
            // 
            this.txtSoru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoru.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoru.Location = new System.Drawing.Point(13, 35);
            this.txtSoru.Multiline = true;
            this.txtSoru.Name = "txtSoru";
            this.txtSoru.Size = new System.Drawing.Size(294, 57);
            this.txtSoru.TabIndex = 3;
            // 
            // lblGeminiSoru
            // 
            this.lblGeminiSoru.AutoSize = true;
            this.lblGeminiSoru.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGeminiSoru.ForeColor = System.Drawing.Color.DimGray;
            this.lblGeminiSoru.Location = new System.Drawing.Point(10, 10);
            this.lblGeminiSoru.Name = "lblGeminiSoru";
            this.lblGeminiSoru.Size = new System.Drawing.Size(126, 20);
            this.lblGeminiSoru.TabIndex = 2;
            this.lblGeminiSoru.Text = "Gemini\'ye Danış:";
            // 
            // lblGeminiCevap
            // 
            this.lblGeminiCevap.AutoSize = true;
            this.lblGeminiCevap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGeminiCevap.ForeColor = System.Drawing.Color.DimGray;
            this.lblGeminiCevap.Location = new System.Drawing.Point(10, 60);
            this.lblGeminiCevap.Name = "lblGeminiCevap";
            this.lblGeminiCevap.Size = new System.Drawing.Size(106, 20);
            this.lblGeminiCevap.TabIndex = 0;
            this.lblGeminiCevap.Text = "Gemini Yanıtı:";
            // 
            // txtCevap
            // 
            this.txtCevap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCevap.BackColor = System.Drawing.Color.White;
            this.txtCevap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCevap.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtCevap.Location = new System.Drawing.Point(13, 83);
            this.txtCevap.Name = "txtCevap";
            this.txtCevap.ReadOnly = true;
            this.txtCevap.Size = new System.Drawing.Size(294, 321);
            this.txtCevap.TabIndex = 1;
            this.txtCevap.Text = "";
            // 
            // btnYorumla
            // 
            this.btnYorumla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btnYorumla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYorumla.FlatAppearance.BorderSize = 0;
            this.btnYorumla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYorumla.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYorumla.ForeColor = System.Drawing.Color.White;
            this.btnYorumla.Location = new System.Drawing.Point(13, 12);
            this.btnYorumla.Name = "btnYorumla";
            this.btnYorumla.Size = new System.Drawing.Size(294, 45);
            this.btnYorumla.TabIndex = 5;
            this.btnYorumla.Text = "Tabloyu Yorumla (AI)";
            this.btnYorumla.UseVisualStyleBackColor = false;
            this.btnYorumla.Click += new System.EventHandler(this.btnYorumla_Click);
            // 
            // FrmSatisAnaliz
            // 
            this.ClientSize = new System.Drawing.Size(1374, 560);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmSatisAnaliz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSatisAnaliz_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabUrunler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunler)).EndInit();
            this.tabKategoriler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKategoriler)).EndInit();
            this.tabPersoneller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPersoneller)).EndInit();
            this.tabSatislar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSatis)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.txtAIResponse.ResumeLayout(false);
            this.txtAIResponse.PerformLayout();
            this.panelInputArea.ResumeLayout(false);
            this.panelInputArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUrunler;
        private System.Windows.Forms.TabPage tabKategoriler;
        private System.Windows.Forms.DataGridView gridKategoriler;
        private System.Windows.Forms.TabPage tabPersoneller;
        private System.Windows.Forms.DataGridView gridPersoneller;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel txtAIResponse;
        private System.Windows.Forms.Label lblGeminiCevap;
        private System.Windows.Forms.RichTextBox txtCevap;
        private System.Windows.Forms.Label lblGeminiSoru;
        private System.Windows.Forms.TextBox txtSoru;
        private System.Windows.Forms.Button btnSoruGonder;
        private System.Windows.Forms.Button btnYorumla;
        private System.Windows.Forms.TabPage tabSatislar;
        private System.Windows.Forms.DataGridView gridUrunler;
        private System.Windows.Forms.DataGridView gridSatis;

        // Input paneli (Normal formda da şık durması için)
        private System.Windows.Forms.Panel panelInputArea;
    }
}