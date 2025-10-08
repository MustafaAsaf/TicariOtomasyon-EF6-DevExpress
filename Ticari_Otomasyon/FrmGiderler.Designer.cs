namespace Ticari_Otomasyon
{
    partial class FrmGiderler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiderler));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.txtNotlar = new System.Windows.Forms.RichTextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEkstra = new DevExpress.XtraEditors.TextEdit();
            this.txtMaaslar = new DevExpress.XtraEditors.TextEdit();
            this.txtSu = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxYil = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxAy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtInternet = new DevExpress.XtraEditors.TextEdit();
            this.txtDogalgaz = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtElektrik = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEkstra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaaslar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxYil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInternet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogalgaz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtElektrik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 682;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 1561;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged_1);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(6);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1284, 830);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // txtNotlar
            // 
            this.txtNotlar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNotlar.Location = new System.Drawing.Point(154, 367);
            this.txtNotlar.Margin = new System.Windows.Forms.Padding(6);
            this.txtNotlar.Name = "txtNotlar";
            this.txtNotlar.Size = new System.Drawing.Size(227, 180);
            this.txtNotlar.TabIndex = 32;
            this.txtNotlar.Text = "";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(68, 370);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 21);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "NOTLAR:";
            // 
            // txtEkstra
            // 
            this.txtEkstra.Location = new System.Drawing.Point(155, 324);
            this.txtEkstra.Margin = new System.Windows.Forms.Padding(6);
            this.txtEkstra.Name = "txtEkstra";
            this.txtEkstra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkstra.Properties.Appearance.Options.UseFont = true;
            this.txtEkstra.Size = new System.Drawing.Size(226, 28);
            this.txtEkstra.TabIndex = 30;
            // 
            // txtMaaslar
            // 
            this.txtMaaslar.Location = new System.Drawing.Point(155, 284);
            this.txtMaaslar.Margin = new System.Windows.Forms.Padding(6);
            this.txtMaaslar.Name = "txtMaaslar";
            this.txtMaaslar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMaaslar.Properties.Appearance.Options.UseFont = true;
            this.txtMaaslar.Size = new System.Drawing.Size(226, 28);
            this.txtMaaslar.TabIndex = 29;
            // 
            // txtSu
            // 
            this.txtSu.Location = new System.Drawing.Point(155, 164);
            this.txtSu.Margin = new System.Windows.Forms.Padding(6);
            this.txtSu.Name = "txtSu";
            this.txtSu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSu.Properties.Appearance.Options.UseFont = true;
            this.txtSu.Size = new System.Drawing.Size(226, 28);
            this.txtSu.TabIndex = 28;
            // 
            // comboBoxYil
            // 
            this.comboBoxYil.Location = new System.Drawing.Point(155, 82);
            this.comboBoxYil.Name = "comboBoxYil";
            this.comboBoxYil.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxYil.Properties.Appearance.Options.UseFont = true;
            this.comboBoxYil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxYil.Size = new System.Drawing.Size(226, 28);
            this.comboBoxYil.TabIndex = 27;
            // 
            // comboBoxAy
            // 
            this.comboBoxAy.Location = new System.Drawing.Point(154, 43);
            this.comboBoxAy.Name = "comboBoxAy";
            this.comboBoxAy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxAy.Properties.Appearance.Options.UseFont = true;
            this.comboBoxAy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxAy.Properties.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos ",
            "Eylül ",
            "Ekim ",
            "Kasım ",
            "Aralık"});
            this.comboBoxAy.Size = new System.Drawing.Size(226, 28);
            this.comboBoxAy.TabIndex = 26;
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClear.ImageOptions.SvgImage")));
            this.btnClear.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnClear.Location = new System.Drawing.Point(321, 601);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 50);
            this.btnClear.TabIndex = 25;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpdate.ImageOptions.SvgImage")));
            this.btnUpdate.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnUpdate.Location = new System.Drawing.Point(252, 601);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 50);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnDelete.Location = new System.Drawing.Point(184, 601);
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
            this.btnAdd.Location = new System.Drawing.Point(116, 601);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 50);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
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
            this.groupControl1.Controls.Add(this.txtNotlar);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtEkstra);
            this.groupControl1.Controls.Add(this.txtMaaslar);
            this.groupControl1.Controls.Add(this.txtSu);
            this.groupControl1.Controls.Add(this.comboBoxYil);
            this.groupControl1.Controls.Add(this.comboBoxAy);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.txtInternet);
            this.groupControl1.Controls.Add(this.txtDogalgaz);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtElektrik);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(406, 830);
            this.groupControl1.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSave.Location = new System.Drawing.Point(47, 601);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 50);
            this.btnSave.TabIndex = 20;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(68, 327);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(67, 21);
            this.labelControl7.TabIndex = 17;
            this.labelControl7.Text = "EKSTRA:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(55, 287);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(80, 21);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "MAAŞLAR:";
            // 
            // txtInternet
            // 
            this.txtInternet.Location = new System.Drawing.Point(155, 244);
            this.txtInternet.Margin = new System.Windows.Forms.Padding(6);
            this.txtInternet.Name = "txtInternet";
            this.txtInternet.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtInternet.Properties.Appearance.Options.UseFont = true;
            this.txtInternet.Size = new System.Drawing.Size(226, 28);
            this.txtInternet.TabIndex = 15;
            // 
            // txtDogalgaz
            // 
            this.txtDogalgaz.Location = new System.Drawing.Point(155, 204);
            this.txtDogalgaz.Margin = new System.Windows.Forms.Padding(6);
            this.txtDogalgaz.Name = "txtDogalgaz";
            this.txtDogalgaz.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDogalgaz.Properties.Appearance.Options.UseFont = true;
            this.txtDogalgaz.Size = new System.Drawing.Size(226, 28);
            this.txtDogalgaz.TabIndex = 13;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(50, 247);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(85, 21);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "İNTERNET:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(43, 207);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(92, 21);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "DOĞALGAZ:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(109, 167);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(26, 21);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "SU:";
            // 
            // txtElektrik
            // 
            this.txtElektrik.Location = new System.Drawing.Point(155, 124);
            this.txtElektrik.Margin = new System.Windows.Forms.Padding(6);
            this.txtElektrik.Name = "txtElektrik";
            this.txtElektrik.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtElektrik.Properties.Appearance.Options.UseFont = true;
            this.txtElektrik.Size = new System.Drawing.Size(226, 28);
            this.txtElektrik.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(54, 127);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(81, 21);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "ELEKTRİK:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(105, 85);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 21);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "YIL:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(108, 46);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "AY:";
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
            // FrmGiderler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1710, 840);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmGiderler";
            this.Text = "Giderler";
            this.Load += new System.EventHandler(this.FrmGiderler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEkstra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaaslar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxYil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInternet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogalgaz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtElektrik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.RichTextBox txtNotlar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEkstra;
        private DevExpress.XtraEditors.TextEdit txtMaaslar;
        private DevExpress.XtraEditors.TextEdit txtSu;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxYil;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxAy;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtInternet;
        private DevExpress.XtraEditors.TextEdit txtDogalgaz;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtElektrik;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}