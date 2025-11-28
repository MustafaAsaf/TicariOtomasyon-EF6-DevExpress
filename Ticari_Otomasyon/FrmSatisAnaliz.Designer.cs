namespace Ticari_Otomasyon
{
    partial class FrmSatisAnaliz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGeminiCevap = new System.Windows.Forms.Label();
            this.txtGeminiCevap = new System.Windows.Forms.RichTextBox();
            this.lblGeminiSoru = new System.Windows.Forms.Label();
            this.txtGeminiSoru = new System.Windows.Forms.TextBox();
            this.btnGeminiYorumla = new System.Windows.Forms.Button();
            this.panelGemini = new System.Windows.Forms.Panel();
            this.btnGeminiSoruGonder = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUrunler = new System.Windows.Forms.TabPage();
            this.gridUrunler = new System.Windows.Forms.DataGridView();
            this.tabKategoriler = new System.Windows.Forms.TabPage();
            this.gridKategoriler = new System.Windows.Forms.DataGridView();
            this.tabPersoneller = new System.Windows.Forms.TabPage();
            this.gridPersoneller = new System.Windows.Forms.DataGridView();
            this.btnKapat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMinAdet = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPersonel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.chkTarihFiltre = new System.Windows.Forms.CheckBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.panelGemini.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabUrunler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunler)).BeginInit();
            this.tabKategoriler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKategoriler)).BeginInit();
            this.tabPersoneller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPersoneller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAdet)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGeminiCevap
            // 
            this.lblGeminiCevap.AutoSize = true;
            this.lblGeminiCevap.Location = new System.Drawing.Point(9, 177);
            this.lblGeminiCevap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeminiCevap.Name = "lblGeminiCevap";
            this.lblGeminiCevap.Size = new System.Drawing.Size(122, 16);
            this.lblGeminiCevap.TabIndex = 5;
            this.lblGeminiCevap.Text = "Gemini Yanıtı / Özet";
            // 
            // txtGeminiCevap
            // 
            this.txtGeminiCevap.Location = new System.Drawing.Point(13, 197);
            this.txtGeminiCevap.Margin = new System.Windows.Forms.Padding(4);
            this.txtGeminiCevap.Name = "txtGeminiCevap";
            this.txtGeminiCevap.ReadOnly = true;
            this.txtGeminiCevap.Size = new System.Drawing.Size(425, 319);
            this.txtGeminiCevap.TabIndex = 4;
            this.txtGeminiCevap.Text = "";
            // 
            // lblGeminiSoru
            // 
            this.lblGeminiSoru.AutoSize = true;
            this.lblGeminiSoru.Location = new System.Drawing.Point(9, 66);
            this.lblGeminiSoru.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeminiSoru.Name = "lblGeminiSoru";
            this.lblGeminiSoru.Size = new System.Drawing.Size(139, 16);
            this.lblGeminiSoru.TabIndex = 3;
            this.lblGeminiSoru.Text = "Gemini\'ye Soru Sorun:";
            // 
            // txtGeminiSoru
            // 
            this.txtGeminiSoru.Location = new System.Drawing.Point(13, 86);
            this.txtGeminiSoru.Margin = new System.Windows.Forms.Padding(4);
            this.txtGeminiSoru.Multiline = true;
            this.txtGeminiSoru.Name = "txtGeminiSoru";
            this.txtGeminiSoru.Size = new System.Drawing.Size(425, 41);
            this.txtGeminiSoru.TabIndex = 2;
            // 
            // btnGeminiYorumla
            // 
            this.btnGeminiYorumla.Location = new System.Drawing.Point(13, 12);
            this.btnGeminiYorumla.Margin = new System.Windows.Forms.Padding(4);
            this.btnGeminiYorumla.Name = "btnGeminiYorumla";
            this.btnGeminiYorumla.Size = new System.Drawing.Size(200, 28);
            this.btnGeminiYorumla.TabIndex = 0;
            this.btnGeminiYorumla.Text = "Seçili Veriyi Yorumla";
            this.btnGeminiYorumla.UseVisualStyleBackColor = true;
            this.btnGeminiYorumla.Click += new System.EventHandler(this.btnGeminiYorumla_Click);
            // 
            // panelGemini
            // 
            this.panelGemini.Controls.Add(this.lblGeminiCevap);
            this.panelGemini.Controls.Add(this.txtGeminiCevap);
            this.panelGemini.Controls.Add(this.lblGeminiSoru);
            this.panelGemini.Controls.Add(this.txtGeminiSoru);
            this.panelGemini.Controls.Add(this.btnGeminiSoruGonder);
            this.panelGemini.Controls.Add(this.btnGeminiYorumla);
            this.panelGemini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGemini.Location = new System.Drawing.Point(0, 0);
            this.panelGemini.Margin = new System.Windows.Forms.Padding(4);
            this.panelGemini.Name = "panelGemini";
            this.panelGemini.Size = new System.Drawing.Size(454, 656);
            this.panelGemini.TabIndex = 0;
            // 
            // btnGeminiSoruGonder
            // 
            this.btnGeminiSoruGonder.Location = new System.Drawing.Point(13, 135);
            this.btnGeminiSoruGonder.Margin = new System.Windows.Forms.Padding(4);
            this.btnGeminiSoruGonder.Name = "btnGeminiSoruGonder";
            this.btnGeminiSoruGonder.Size = new System.Drawing.Size(120, 28);
            this.btnGeminiSoruGonder.TabIndex = 1;
            this.btnGeminiSoruGonder.Text = "Soruyu Gönder";
            this.btnGeminiSoruGonder.UseVisualStyleBackColor = true;
            this.btnGeminiSoruGonder.Click += new System.EventHandler(this.btnGeminiSoruGonder_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 98);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelGemini);
            this.splitContainer1.Size = new System.Drawing.Size(1312, 656);
            this.splitContainer1.SplitterDistance = 853;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUrunler);
            this.tabControl1.Controls.Add(this.tabKategoriler);
            this.tabControl1.Controls.Add(this.tabPersoneller);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(853, 656);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUrunler
            // 
            this.tabUrunler.Controls.Add(this.gridUrunler);
            this.tabUrunler.Location = new System.Drawing.Point(4, 25);
            this.tabUrunler.Margin = new System.Windows.Forms.Padding(4);
            this.tabUrunler.Name = "tabUrunler";
            this.tabUrunler.Padding = new System.Windows.Forms.Padding(4);
            this.tabUrunler.Size = new System.Drawing.Size(845, 627);
            this.tabUrunler.TabIndex = 0;
            this.tabUrunler.Text = "Ürün Bazlı Analiz";
            this.tabUrunler.UseVisualStyleBackColor = true;
            // 
            // gridUrunler
            // 
            this.gridUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUrunler.Location = new System.Drawing.Point(4, 4);
            this.gridUrunler.Margin = new System.Windows.Forms.Padding(4);
            this.gridUrunler.Name = "gridUrunler";
            this.gridUrunler.RowHeadersWidth = 51;
            this.gridUrunler.Size = new System.Drawing.Size(837, 619);
            this.gridUrunler.TabIndex = 0;
            // 
            // tabKategoriler
            // 
            this.tabKategoriler.Controls.Add(this.gridKategoriler);
            this.tabKategoriler.Location = new System.Drawing.Point(4, 25);
            this.tabKategoriler.Margin = new System.Windows.Forms.Padding(4);
            this.tabKategoriler.Name = "tabKategoriler";
            this.tabKategoriler.Padding = new System.Windows.Forms.Padding(4);
            this.tabKategoriler.Size = new System.Drawing.Size(845, 627);
            this.tabKategoriler.TabIndex = 1;
            this.tabKategoriler.Text = "Kategori Bazlı Analiz";
            this.tabKategoriler.UseVisualStyleBackColor = true;
            // 
            // gridKategoriler
            // 
            this.gridKategoriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKategoriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKategoriler.Location = new System.Drawing.Point(4, 4);
            this.gridKategoriler.Margin = new System.Windows.Forms.Padding(4);
            this.gridKategoriler.Name = "gridKategoriler";
            this.gridKategoriler.RowHeadersWidth = 51;
            this.gridKategoriler.Size = new System.Drawing.Size(837, 619);
            this.gridKategoriler.TabIndex = 0;
            // 
            // tabPersoneller
            // 
            this.tabPersoneller.Controls.Add(this.gridPersoneller);
            this.tabPersoneller.Location = new System.Drawing.Point(4, 25);
            this.tabPersoneller.Margin = new System.Windows.Forms.Padding(4);
            this.tabPersoneller.Name = "tabPersoneller";
            this.tabPersoneller.Padding = new System.Windows.Forms.Padding(4);
            this.tabPersoneller.Size = new System.Drawing.Size(845, 627);
            this.tabPersoneller.TabIndex = 2;
            this.tabPersoneller.Text = "Personel Performansı";
            this.tabPersoneller.UseVisualStyleBackColor = true;
            // 
            // gridPersoneller
            // 
            this.gridPersoneller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPersoneller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPersoneller.Location = new System.Drawing.Point(4, 4);
            this.gridPersoneller.Margin = new System.Windows.Forms.Padding(4);
            this.gridPersoneller.Name = "gridPersoneller";
            this.gridPersoneller.RowHeadersWidth = 51;
            this.gridPersoneller.Size = new System.Drawing.Size(837, 619);
            this.gridPersoneller.TabIndex = 0;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Location = new System.Drawing.Point(1196, 17);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(4);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 28);
            this.btnKapat.TabIndex = 12;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Min. Toplam Adet:";
            // 
            // nudMinAdet
            // 
            this.nudMinAdet.Location = new System.Drawing.Point(141, 43);
            this.nudMinAdet.Margin = new System.Windows.Forms.Padding(4);
            this.nudMinAdet.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMinAdet.Name = "nudMinAdet";
            this.nudMinAdet.Size = new System.Drawing.Size(96, 22);
            this.nudMinAdet.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Personel :";
            // 
            // cmbPersonel
            // 
            this.cmbPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonel.FormattingEnabled = true;
            this.cmbPersonel.Location = new System.Drawing.Point(729, 44);
            this.cmbPersonel.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPersonel.Name = "cmbPersonel";
            this.cmbPersonel.Size = new System.Drawing.Size(219, 24);
            this.cmbPersonel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(660, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kategori:";
            // 
            // cmbKategori
            // 
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(729, 12);
            this.cmbKategori.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(219, 24);
            this.cmbKategori.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Başlangıç:";
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.Location = new System.Drawing.Point(344, 12);
            this.dtBaslangic.Margin = new System.Windows.Forms.Padding(4);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(265, 22);
            this.dtBaslangic.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bitiş :";
            // 
            // dtBitis
            // 
            this.dtBitis.Location = new System.Drawing.Point(344, 42);
            this.dtBitis.Margin = new System.Windows.Forms.Padding(4);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(265, 22);
            this.dtBitis.TabIndex = 2;
            // 
            // chkTarihFiltre
            // 
            this.chkTarihFiltre.AutoSize = true;
            this.chkTarihFiltre.Location = new System.Drawing.Point(16, 15);
            this.chkTarihFiltre.Margin = new System.Windows.Forms.Padding(4);
            this.chkTarihFiltre.Name = "chkTarihFiltre";
            this.chkTarihFiltre.Size = new System.Drawing.Size(103, 20);
            this.chkTarihFiltre.TabIndex = 1;
            this.chkTarihFiltre.Text = "Tarih Filtrele";
            this.chkTarihFiltre.UseVisualStyleBackColor = true;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Location = new System.Drawing.Point(1088, 17);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(4);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(100, 28);
            this.btnYenile.TabIndex = 0;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.btnKapat);
            this.panelFilters.Controls.Add(this.label5);
            this.panelFilters.Controls.Add(this.nudMinAdet);
            this.panelFilters.Controls.Add(this.label4);
            this.panelFilters.Controls.Add(this.cmbPersonel);
            this.panelFilters.Controls.Add(this.label3);
            this.panelFilters.Controls.Add(this.cmbKategori);
            this.panelFilters.Controls.Add(this.label1);
            this.panelFilters.Controls.Add(this.dtBaslangic);
            this.panelFilters.Controls.Add(this.label2);
            this.panelFilters.Controls.Add(this.dtBitis);
            this.panelFilters.Controls.Add(this.chkTarihFiltre);
            this.panelFilters.Controls.Add(this.btnYenile);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1312, 98);
            this.panelFilters.TabIndex = 3;
            // 
            // FrmSatisAnaliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 754);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelFilters);
            this.Name = "FrmSatisAnaliz";
            this.Text = "Satış Analiz (AI)";
            this.Load += new System.EventHandler(this.FrmSatisAnaliz_Load);
            this.panelGemini.ResumeLayout(false);
            this.panelGemini.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabUrunler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunler)).EndInit();
            this.tabKategoriler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKategoriler)).EndInit();
            this.tabPersoneller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPersoneller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAdet)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGeminiCevap;
        private System.Windows.Forms.RichTextBox txtGeminiCevap;
        private System.Windows.Forms.Label lblGeminiSoru;
        private System.Windows.Forms.TextBox txtGeminiSoru;
        private System.Windows.Forms.Button btnGeminiYorumla;
        private System.Windows.Forms.Panel panelGemini;
        private System.Windows.Forms.Button btnGeminiSoruGonder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUrunler;
        private System.Windows.Forms.DataGridView gridUrunler;
        private System.Windows.Forms.TabPage tabKategoriler;
        private System.Windows.Forms.DataGridView gridKategoriler;
        private System.Windows.Forms.TabPage tabPersoneller;
        private System.Windows.Forms.DataGridView gridPersoneller;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMinAdet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPersonel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.CheckBox chkTarihFiltre;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Panel panelFilters;
    }
}