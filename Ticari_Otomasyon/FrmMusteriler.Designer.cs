namespace Ticari_Otomasyon
{
    partial class FrmMusteriler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMusteriler));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.txtVergiDairesi = new DevExpress.XtraEditors.TextEdit();
            this.txtMusteriTelefon2 = new System.Windows.Forms.MaskedTextBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtMusteriAdres = new System.Windows.Forms.RichTextBox();
            this.comboBoxIlce = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxIl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtTcNo = new System.Windows.Forms.MaskedTextBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.txtMusteriTelefon1 = new System.Windows.Forms.MaskedTextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtMusteriMail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtMusteriSoyad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMusteriAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 1065;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 2439;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(10);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(10);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1284, 830);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.Location = new System.Drawing.Point(157, 513);
            this.txtVergiDairesi.Margin = new System.Windows.Forms.Padding(6);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtVergiDairesi.Properties.Appearance.Options.UseFont = true;
            this.txtVergiDairesi.Size = new System.Drawing.Size(226, 28);
            this.txtVergiDairesi.TabIndex = 36;
            // 
            // txtMusteriTelefon2
            // 
            this.txtMusteriTelefon2.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtMusteriTelefon2.Location = new System.Drawing.Point(157, 157);
            this.txtMusteriTelefon2.Margin = new System.Windows.Forms.Padding(6);
            this.txtMusteriTelefon2.Mask = "(999) 000-0000";
            this.txtMusteriTelefon2.Name = "txtMusteriTelefon2";
            this.txtMusteriTelefon2.Size = new System.Drawing.Size(226, 28);
            this.txtMusteriTelefon2.TabIndex = 35;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(50, 160);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(90, 21);
            this.labelControl11.TabIndex = 34;
            this.labelControl11.Text = "TELEFON 2:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(19, 516);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(124, 21);
            this.labelControl10.TabIndex = 32;
            this.labelControl10.Text = "VERGİ DAİRESİ:";
            // 
            // txtMusteriAdres
            // 
            this.txtMusteriAdres.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtMusteriAdres.Location = new System.Drawing.Point(158, 357);
            this.txtMusteriAdres.Margin = new System.Windows.Forms.Padding(6);
            this.txtMusteriAdres.Name = "txtMusteriAdres";
            this.txtMusteriAdres.Size = new System.Drawing.Size(226, 144);
            this.txtMusteriAdres.TabIndex = 31;
            this.txtMusteriAdres.Text = "";
            // 
            // comboBoxIlce
            // 
            this.comboBoxIlce.Location = new System.Drawing.Point(158, 317);
            this.comboBoxIlce.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxIlce.Name = "comboBoxIlce";
            this.comboBoxIlce.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxIlce.Properties.Appearance.Options.UseFont = true;
            this.comboBoxIlce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxIlce.Size = new System.Drawing.Size(226, 28);
            this.comboBoxIlce.TabIndex = 30;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(100, 320);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 21);
            this.labelControl7.TabIndex = 29;
            this.labelControl7.Text = "İLÇE:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(81, 360);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 21);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "ADRES:";
            // 
            // comboBoxIl
            // 
            this.comboBoxIl.Location = new System.Drawing.Point(157, 277);
            this.comboBoxIl.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxIl.Name = "comboBoxIl";
            this.comboBoxIl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxIl.Properties.Appearance.Options.UseFont = true;
            this.comboBoxIl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxIl.Size = new System.Drawing.Size(226, 28);
            this.comboBoxIl.TabIndex = 27;
            this.comboBoxIl.SelectedIndexChanged += new System.EventHandler(this.comboBoxIl_SelectedIndexChanged_1);
            // 
            // txtTcNo
            // 
            this.txtTcNo.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtTcNo.Location = new System.Drawing.Point(157, 197);
            this.txtTcNo.Margin = new System.Windows.Forms.Padding(6);
            this.txtTcNo.Mask = "00000000000";
            this.txtTcNo.Name = "txtTcNo";
            this.txtTcNo.Size = new System.Drawing.Size(226, 28);
            this.txtTcNo.TabIndex = 26;
            this.txtTcNo.ValidatingType = typeof(int);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClear.ImageOptions.SvgImage")));
            this.btnClear.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnClear.Location = new System.Drawing.Point(324, 594);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 50);
            this.btnClear.TabIndex = 25;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // txtMusteriTelefon1
            // 
            this.txtMusteriTelefon1.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtMusteriTelefon1.Location = new System.Drawing.Point(158, 117);
            this.txtMusteriTelefon1.Margin = new System.Windows.Forms.Padding(6);
            this.txtMusteriTelefon1.Mask = "(999) 000-0000";
            this.txtMusteriTelefon1.Name = "txtMusteriTelefon1";
            this.txtMusteriTelefon1.Size = new System.Drawing.Size(226, 28);
            this.txtMusteriTelefon1.TabIndex = 24;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtVergiDairesi);
            this.groupControl1.Controls.Add(this.txtMusteriTelefon2);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.txtMusteriAdres);
            this.groupControl1.Controls.Add(this.comboBoxIlce);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.comboBoxIl);
            this.groupControl1.Controls.Add(this.txtTcNo);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.txtMusteriTelefon1);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.txtMusteriMail);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtMusteriSoyad);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtMusteriAd);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(406, 830);
            this.groupControl1.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpdate.ImageOptions.SvgImage")));
            this.btnUpdate.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnUpdate.Location = new System.Drawing.Point(255, 594);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 50);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnDelete.Location = new System.Drawing.Point(187, 594);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 50);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnAdd.Location = new System.Drawing.Point(119, 594);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 50);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSave.Location = new System.Drawing.Point(50, 594);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 50);
            this.btnSave.TabIndex = 20;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(87, 280);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(53, 21);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "ŞEHİR:";
            // 
            // txtMusteriMail
            // 
            this.txtMusteriMail.Location = new System.Drawing.Point(158, 237);
            this.txtMusteriMail.Margin = new System.Windows.Forms.Padding(6);
            this.txtMusteriMail.Name = "txtMusteriMail";
            this.txtMusteriMail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtMusteriMail.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriMail.Size = new System.Drawing.Size(226, 28);
            this.txtMusteriMail.TabIndex = 13;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(32, 240);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(108, 21);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "MAİL ADRESİ:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(81, 200);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(59, 21);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "T.C NO:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(66, 120);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 21);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "TELEFON:";
            // 
            // txtMusteriSoyad
            // 
            this.txtMusteriSoyad.Location = new System.Drawing.Point(157, 75);
            this.txtMusteriSoyad.Margin = new System.Windows.Forms.Padding(8);
            this.txtMusteriSoyad.Name = "txtMusteriSoyad";
            this.txtMusteriSoyad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtMusteriSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriSoyad.Size = new System.Drawing.Size(226, 28);
            this.txtMusteriSoyad.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(80, 78);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 21);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "SOYAD:";
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.Location = new System.Drawing.Point(158, 36);
            this.txtMusteriAd.Margin = new System.Windows.Forms.Padding(8);
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtMusteriAd.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriAd.Size = new System.Drawing.Size(226, 28);
            this.txtMusteriAd.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(113, 39);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "AD:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1288, 834);
            this.panelControl2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.67252F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.32749F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1710, 840);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(1297, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(410, 834);
            this.panelControl1.TabIndex = 0;
            // 
            // FrmMusteriler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1710, 840);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMusteriler";
            this.Text = "Müşteriler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMusteriler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.TextEdit txtVergiDairesi;
        private System.Windows.Forms.MaskedTextBox txtMusteriTelefon2;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.RichTextBox txtMusteriAdres;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxIlce;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxIl;
        private System.Windows.Forms.MaskedTextBox txtTcNo;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private System.Windows.Forms.MaskedTextBox txtMusteriTelefon1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtMusteriMail;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtMusteriSoyad;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMusteriAd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}