namespace Ticari_Otomasyon
{
    partial class FrmRehber
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMusteriler = new DevExpress.XtraGrid.GridControl();
            this.gridViewMusteriler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlFirmalar = new DevExpress.XtraGrid.GridControl();
            this.gridViewFirmalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMusteriler)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFirmalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFirmalar)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1602, 753);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControlMusteriler);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1600, 723);
            this.xtraTabPage1.Text = "Müşteriler";
            // 
            // gridControlMusteriler
            // 
            this.gridControlMusteriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMusteriler.Location = new System.Drawing.Point(0, 0);
            this.gridControlMusteriler.MainView = this.gridViewMusteriler;
            this.gridControlMusteriler.Name = "gridControlMusteriler";
            this.gridControlMusteriler.Size = new System.Drawing.Size(1600, 723);
            this.gridControlMusteriler.TabIndex = 1;
            this.gridControlMusteriler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMusteriler});
            // 
            // gridViewMusteriler
            // 
            this.gridViewMusteriler.GridControl = this.gridControlMusteriler;
            this.gridViewMusteriler.Name = "gridViewMusteriler";
            this.gridViewMusteriler.DoubleClick += new System.EventHandler(this.gridViewMusteriler_DoubleClick);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControlFirmalar);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1600, 723);
            this.xtraTabPage2.Text = "Firmalar";
            // 
            // gridControlFirmalar
            // 
            this.gridControlFirmalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFirmalar.Location = new System.Drawing.Point(0, 0);
            this.gridControlFirmalar.MainView = this.gridViewFirmalar;
            this.gridControlFirmalar.Name = "gridControlFirmalar";
            this.gridControlFirmalar.Size = new System.Drawing.Size(1600, 723);
            this.gridControlFirmalar.TabIndex = 0;
            this.gridControlFirmalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFirmalar});
            // 
            // gridViewFirmalar
            // 
            this.gridViewFirmalar.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridViewFirmalar.Appearance.Row.BorderColor = System.Drawing.Color.Transparent;
            this.gridViewFirmalar.GridControl = this.gridControlFirmalar;
            this.gridViewFirmalar.Name = "gridViewFirmalar";
            this.gridViewFirmalar.DoubleClick += new System.EventHandler(this.gridViewFirmalar_DoubleClick);
            // 
            // FrmRehber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 753);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmRehber";
            this.Text = "Rehber";
            this.Load += new System.EventHandler(this.FrmRehber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMusteriler)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFirmalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFirmalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControlFirmalar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFirmalar;
        private DevExpress.XtraGrid.GridControl gridControlMusteriler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMusteriler;
    }
}