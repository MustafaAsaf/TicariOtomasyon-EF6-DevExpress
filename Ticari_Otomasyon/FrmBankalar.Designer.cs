namespace Ticari_Otomasyon
{
    partial class FrmBankalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBankalar));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.comboBoxFirmalar = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapTuru = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtTarih = new System.Windows.Forms.MaskedTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTelefon = new System.Windows.Forms.MaskedTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtYetkili = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapNo = new DevExpress.XtraEditors.TextEdit();
            this.txtIBAN = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxIlce = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxIl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtSube = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtBankaAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxFirmalar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIBAN.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSube.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankaAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 710;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 1463;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged_1);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1284, 830);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // comboBoxFirmalar
            // 
            this.comboBoxFirmalar.Location = new System.Drawing.Point(147, 452);
            this.comboBoxFirmalar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.comboBoxFirmalar.Name = "comboBoxFirmalar";
            this.comboBoxFirmalar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxFirmalar.Properties.Appearance.Options.UseFont = true;
            this.comboBoxFirmalar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxFirmalar.Size = new System.Drawing.Size(212, 28);
            this.comboBoxFirmalar.TabIndex = 47;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(44, 455);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(96, 21);
            this.labelControl4.TabIndex = 46;
            this.labelControl4.Text = "ŞİRKET ADI:";
            // 
            // txtHesapTuru
            // 
            this.txtHesapTuru.Location = new System.Drawing.Point(147, 410);
            this.txtHesapTuru.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtHesapTuru.Name = "txtHesapTuru";
            this.txtHesapTuru.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtHesapTuru.Properties.Appearance.Options.UseFont = true;
            this.txtHesapTuru.Size = new System.Drawing.Size(212, 28);
            this.txtHesapTuru.TabIndex = 45;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(37, 413);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(104, 21);
            this.labelControl10.TabIndex = 44;
            this.labelControl10.Text = "HESAP TÜRÜ:";
            // 
            // txtTarih
            // 
            this.txtTarih.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtTarih.Location = new System.Drawing.Point(147, 368);
            this.txtTarih.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtTarih.Mask = "00/00/0000";
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.Size = new System.Drawing.Size(212, 28);
            this.txtTarih.TabIndex = 43;
            this.txtTarih.ValidatingType = typeof(System.DateTime);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(82, 372);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 21);
            this.labelControl3.TabIndex = 42;
            this.labelControl3.Text = "TARİH:";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtTelefon.Location = new System.Drawing.Point(147, 327);
            this.txtTelefon.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtTelefon.Mask = "(999) 000-0000";
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(212, 28);
            this.txtTelefon.TabIndex = 41;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(62, 330);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 21);
            this.labelControl5.TabIndex = 40;
            this.labelControl5.Text = "TELEFON:";
            // 
            // txtYetkili
            // 
            this.txtYetkili.Location = new System.Drawing.Point(147, 285);
            this.txtYetkili.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtYetkili.Name = "txtYetkili";
            this.txtYetkili.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtYetkili.Properties.Appearance.Options.UseFont = true;
            this.txtYetkili.Size = new System.Drawing.Size(212, 28);
            this.txtYetkili.TabIndex = 39;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(72, 288);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 21);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "YETKİLİ:";
            // 
            // txtHesapNo
            // 
            this.txtHesapNo.Location = new System.Drawing.Point(147, 243);
            this.txtHesapNo.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtHesapNo.Name = "txtHesapNo";
            this.txtHesapNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtHesapNo.Properties.Appearance.Options.UseFont = true;
            this.txtHesapNo.Size = new System.Drawing.Size(212, 28);
            this.txtHesapNo.TabIndex = 37;
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(147, 205);
            this.txtIBAN.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtIBAN.Properties.Appearance.Options.UseFont = true;
            this.txtIBAN.Size = new System.Drawing.Size(212, 28);
            this.txtIBAN.TabIndex = 36;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(91, 167);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(46, 21);
            this.labelControl11.TabIndex = 34;
            this.labelControl11.Text = "ŞUBE:";
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.comboBoxFirmalar);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtHesapTuru);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.txtTarih);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtTelefon);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtYetkili);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtHesapNo);
            this.groupControl1.Controls.Add(this.txtIBAN);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.comboBoxIlce);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.comboBoxIl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.txtSube);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtBankaAdi);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(406, 830);
            this.groupControl1.TabIndex = 5;
            // 
            // comboBoxIlce
            // 
            this.comboBoxIlce.Location = new System.Drawing.Point(147, 122);
            this.comboBoxIlce.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.comboBoxIlce.Name = "comboBoxIlce";
            this.comboBoxIlce.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxIlce.Properties.Appearance.Options.UseFont = true;
            this.comboBoxIlce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxIlce.Size = new System.Drawing.Size(212, 28);
            this.comboBoxIlce.TabIndex = 30;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(97, 125);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 21);
            this.labelControl7.TabIndex = 29;
            this.labelControl7.Text = "İLÇE:";
            // 
            // comboBoxIl
            // 
            this.comboBoxIl.Location = new System.Drawing.Point(147, 80);
            this.comboBoxIl.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.comboBoxIl.Name = "comboBoxIl";
            this.comboBoxIl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxIl.Properties.Appearance.Options.UseFont = true;
            this.comboBoxIl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxIl.Properties.SelectedIndexChanged += new System.EventHandler(this.comboBoxIl_Properties_SelectedIndexChanged);
            this.comboBoxIl.Size = new System.Drawing.Size(212, 28);
            this.comboBoxIl.TabIndex = 27;
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClear.ImageOptions.SvgImage")));
            this.btnClear.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnClear.Location = new System.Drawing.Point(302, 518);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 52);
            this.btnClear.TabIndex = 25;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpdate.ImageOptions.SvgImage")));
            this.btnUpdate.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnUpdate.Location = new System.Drawing.Point(238, 518);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(57, 52);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnDelete.Location = new System.Drawing.Point(173, 518);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 52);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnAdd.Location = new System.Drawing.Point(110, 518);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 52);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSave.Location = new System.Drawing.Point(45, 518);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 52);
            this.btnSave.TabIndex = 20;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(84, 83);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(53, 21);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "ŞEHİR:";
            // 
            // txtSube
            // 
            this.txtSube.Location = new System.Drawing.Point(147, 163);
            this.txtSube.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtSube.Name = "txtSube";
            this.txtSube.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtSube.Properties.Appearance.Options.UseFont = true;
            this.txtSube.Size = new System.Drawing.Size(212, 28);
            this.txtSube.TabIndex = 13;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(55, 247);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(84, 21);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "HESAP NO:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(92, 208);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 21);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "IBAN:";
            // 
            // txtBankaAdi
            // 
            this.txtBankaAdi.Location = new System.Drawing.Point(147, 38);
            this.txtBankaAdi.Margin = new System.Windows.Forms.Padding(8);
            this.txtBankaAdi.Name = "txtBankaAdi";
            this.txtBankaAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtBankaAdi.Properties.Appearance.Options.UseFont = true;
            this.txtBankaAdi.Size = new System.Drawing.Size(212, 28);
            this.txtBankaAdi.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(47, 41);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(93, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "BANKA ADI:";
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
            // FrmBankalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1710, 840);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmBankalar";
            this.Text = "Bankalar";
            this.Load += new System.EventHandler(this.Frm_Bankalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxFirmalar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIBAN.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSube.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankaAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxFirmalar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtHesapTuru;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.MaskedTextBox txtTarih;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.MaskedTextBox txtTelefon;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtYetkili;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtHesapNo;
        private DevExpress.XtraEditors.TextEdit txtIBAN;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxIlce;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxIl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtSube;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtBankaAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}