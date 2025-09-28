namespace Ticari_Otomasyon
{
    partial class FrmRaporlar
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Tbl_SirketlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet = new Ticari_Otomasyon.DboTicariOtomasyonDataSet();
            this.Tbl_MusterilerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tbl_GiderlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tbl_PersonellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerFirma = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerMusteri = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerGiderler = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerPersonel = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Tbl_MusterilerTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSetTableAdapters.Tbl_MusterilerTableAdapter();
            this.Tbl_SirketlerTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSetTableAdapters.Tbl_SirketlerTableAdapter();
            this.Tbl_PersonellerTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSetTableAdapters.Tbl_PersonellerTableAdapter();
            this.Tbl_GiderlerTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSetTableAdapters.Tbl_GiderlerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_SirketlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_MusterilerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_GiderlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_PersonellerBindingSource)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tbl_SirketlerBindingSource
            // 
            this.Tbl_SirketlerBindingSource.DataMember = "Tbl_Sirketler";
            this.Tbl_SirketlerBindingSource.DataSource = this.DboTicariOtomasyonDataSet;
            // 
            // DboTicariOtomasyonDataSet
            // 
            this.DboTicariOtomasyonDataSet.DataSetName = "DboTicariOtomasyonDataSet";
            this.DboTicariOtomasyonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Tbl_MusterilerBindingSource
            // 
            this.Tbl_MusterilerBindingSource.DataMember = "Tbl_Musteriler";
            this.Tbl_MusterilerBindingSource.DataSource = this.DboTicariOtomasyonDataSet;
            // 
            // Tbl_GiderlerBindingSource
            // 
            this.Tbl_GiderlerBindingSource.DataMember = "Tbl_Giderler";
            this.Tbl_GiderlerBindingSource.DataSource = this.DboTicariOtomasyonDataSet;
            // 
            // Tbl_PersonellerBindingSource
            // 
            this.Tbl_PersonellerBindingSource.DataMember = "Tbl_Personeller";
            this.Tbl_PersonellerBindingSource.DataSource = this.DboTicariOtomasyonDataSet;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.reportViewerFirma);
            this.xtraTabPage2.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.normalpriority;
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1600, 699);
            this.xtraTabPage2.Text = "Firma Raporları";
            // 
            // reportViewerFirma
            // 
            this.reportViewerFirma.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetFirmalar";
            reportDataSource1.Value = this.Tbl_SirketlerBindingSource;
            this.reportViewerFirma.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerFirma.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportFirmalar.rdlc";
            this.reportViewerFirma.Location = new System.Drawing.Point(0, 0);
            this.reportViewerFirma.Name = "reportViewerFirma";
            this.reportViewerFirma.ServerReport.BearerToken = null;
            this.reportViewerFirma.Size = new System.Drawing.Size(1600, 699);
            this.reportViewerFirma.TabIndex = 1;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.reportViewerMusteri);
            this.xtraTabPage1.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.bo_mydetails;
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1600, 699);
            this.xtraTabPage1.Text = "Müşteri Raporları";
            // 
            // reportViewerMusteri
            // 
            this.reportViewerMusteri.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetMusteriler";
            reportDataSource2.Value = this.Tbl_MusterilerBindingSource;
            this.reportViewerMusteri.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerMusteri.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportMusteriler.rdlc";
            this.reportViewerMusteri.Location = new System.Drawing.Point(0, 0);
            this.reportViewerMusteri.Name = "reportViewerMusteri";
            this.reportViewerMusteri.ServerReport.BearerToken = null;
            this.reportViewerMusteri.Size = new System.Drawing.Size(1600, 699);
            this.reportViewerMusteri.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(38, 38, 38, 38);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1602, 753);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.reportViewerGiderler);
            this.xtraTabPage4.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.bluedatabarsolid;
            this.xtraTabPage4.Margin = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1600, 699);
            this.xtraTabPage4.Text = "Gider Raporları";
            // 
            // reportViewerGiderler
            // 
            this.reportViewerGiderler.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetGiderler";
            reportDataSource3.Value = this.Tbl_GiderlerBindingSource;
            this.reportViewerGiderler.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerGiderler.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportGiderler.rdlc";
            this.reportViewerGiderler.Location = new System.Drawing.Point(0, 0);
            this.reportViewerGiderler.Name = "reportViewerGiderler";
            this.reportViewerGiderler.ServerReport.BearerToken = null;
            this.reportViewerGiderler.Size = new System.Drawing.Size(1600, 699);
            this.reportViewerGiderler.TabIndex = 0;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.reportViewerPersonel);
            this.xtraTabPage5.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.mr;
            this.xtraTabPage5.Margin = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(1600, 699);
            this.xtraTabPage5.Text = "Personel Raporları";
            // 
            // reportViewerPersonel
            // 
            this.reportViewerPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSetPersoneller";
            reportDataSource4.Value = this.Tbl_PersonellerBindingSource;
            this.reportViewerPersonel.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewerPersonel.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportPersoneller.rdlc";
            this.reportViewerPersonel.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPersonel.Name = "reportViewerPersonel";
            this.reportViewerPersonel.ServerReport.BearerToken = null;
            this.reportViewerPersonel.Size = new System.Drawing.Size(1600, 699);
            this.reportViewerPersonel.TabIndex = 0;
            // 
            // Tbl_MusterilerTableAdapter
            // 
            this.Tbl_MusterilerTableAdapter.ClearBeforeFill = true;
            // 
            // Tbl_SirketlerTableAdapter
            // 
            this.Tbl_SirketlerTableAdapter.ClearBeforeFill = true;
            // 
            // Tbl_PersonellerTableAdapter
            // 
            this.Tbl_PersonellerTableAdapter.ClearBeforeFill = true;
            // 
            // Tbl_GiderlerTableAdapter
            // 
            this.Tbl_GiderlerTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 753);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmRaporlar";
            this.Text = "Raporlar";
            this.Load += new System.EventHandler(this.FrmRaporlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_SirketlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_MusterilerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_GiderlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_PersonellerBindingSource)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerMusteri;
        private System.Windows.Forms.BindingSource Tbl_MusterilerBindingSource;
        private DboTicariOtomasyonDataSet DboTicariOtomasyonDataSet;
        private DboTicariOtomasyonDataSetTableAdapters.Tbl_MusterilerTableAdapter Tbl_MusterilerTableAdapter;
        private System.Windows.Forms.BindingSource Tbl_SirketlerBindingSource;
        private DboTicariOtomasyonDataSetTableAdapters.Tbl_SirketlerTableAdapter Tbl_SirketlerTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerFirma;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPersonel;
        private System.Windows.Forms.BindingSource Tbl_PersonellerBindingSource;
        private DboTicariOtomasyonDataSetTableAdapters.Tbl_PersonellerTableAdapter Tbl_PersonellerTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerGiderler;
        private System.Windows.Forms.BindingSource Tbl_GiderlerBindingSource;
        private DboTicariOtomasyonDataSetTableAdapters.Tbl_GiderlerTableAdapter Tbl_GiderlerTableAdapter;
    }
}