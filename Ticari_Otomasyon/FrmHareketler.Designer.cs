namespace Ticari_Otomasyon
{
    partial class FrmHareketler
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
            this.gridControlMusteriHareket = new DevExpress.XtraGrid.GridControl();
            this.gridViewMusteriHareket = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlFirmaHareket = new DevExpress.XtraGrid.GridControl();
            this.gridViewFirmaHareket = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlStokHareket = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriHareket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMusteriHareket)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFirmaHareket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFirmaHareket)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokHareket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xtraTabPage1.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage1.Controls.Add(this.gridControlMusteriHareket);
            this.xtraTabPage1.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.reviewers1;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1600, 699);
            this.xtraTabPage1.Text = "Şahıs Musteri Hareketleri";
            // 
            // gridControlMusteriHareket
            // 
            this.gridControlMusteriHareket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMusteriHareket.Location = new System.Drawing.Point(0, 0);
            this.gridControlMusteriHareket.MainView = this.gridViewMusteriHareket;
            this.gridControlMusteriHareket.Name = "gridControlMusteriHareket";
            this.gridControlMusteriHareket.Size = new System.Drawing.Size(1600, 699);
            this.gridControlMusteriHareket.TabIndex = 2;
            this.gridControlMusteriHareket.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMusteriHareket});
            // 
            // gridViewMusteriHareket
            // 
            this.gridViewMusteriHareket.GridControl = this.gridControlMusteriHareket;
            this.gridViewMusteriHareket.Name = "gridViewMusteriHareket";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xtraTabPage2.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage2.Controls.Add(this.gridControlFirmaHareket);
            this.xtraTabPage2.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.travel_hotel;
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1600, 699);
            this.xtraTabPage2.Text = "Kurumsal Müşteri Hareketleri";
            // 
            // gridControlFirmaHareket
            // 
            this.gridControlFirmaHareket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFirmaHareket.Location = new System.Drawing.Point(0, 0);
            this.gridControlFirmaHareket.MainView = this.gridViewFirmaHareket;
            this.gridControlFirmaHareket.Name = "gridControlFirmaHareket";
            this.gridControlFirmaHareket.Size = new System.Drawing.Size(1600, 699);
            this.gridControlFirmaHareket.TabIndex = 0;
            this.gridControlFirmaHareket.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFirmaHareket});
            // 
            // gridViewFirmaHareket
            // 
            this.gridViewFirmaHareket.GridControl = this.gridControlFirmaHareket;
            this.gridViewFirmaHareket.Name = "gridViewFirmaHareket";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xtraTabPage3.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage3.Controls.Add(this.gridControlStokHareket);
            this.xtraTabPage3.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.shopping_box;
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1600, 699);
            this.xtraTabPage3.Text = "Stok Hareketleri";
            // 
            // gridControlStokHareket
            // 
            this.gridControlStokHareket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStokHareket.Location = new System.Drawing.Point(0, 0);
            this.gridControlStokHareket.MainView = this.gridView1;
            this.gridControlStokHareket.Name = "gridControlStokHareket";
            this.gridControlStokHareket.Size = new System.Drawing.Size(1600, 699);
            this.gridControlStokHareket.TabIndex = 0;
            this.gridControlStokHareket.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlStokHareket;
            this.gridView1.Name = "gridView1";
            // 
            // FrmHareketler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 753);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmHareketler";
            this.Text = "Hareketler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmHareketler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriHareket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMusteriHareket)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFirmaHareket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFirmaHareket)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokHareket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gridControlMusteriHareket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMusteriHareket;
        private DevExpress.XtraGrid.GridControl gridControlFirmaHareket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFirmaHareket;
        private DevExpress.XtraGrid.GridControl gridControlStokHareket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}