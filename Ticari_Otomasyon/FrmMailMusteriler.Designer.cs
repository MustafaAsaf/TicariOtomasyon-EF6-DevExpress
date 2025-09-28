namespace Ticari_Otomasyon
{
    partial class FrmMailMusteriler
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnGonder = new DevExpress.XtraEditors.SimpleButton();
            this.txtMesaj = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtKonu = new DevExpress.XtraEditors.TextEdit();
            this.txtAliciMailAdresi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtKonu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAliciMailAdresi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Calibri", 15F);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(70, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(377, 37);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Müşteri Mail Gönderme Paneli";
            // 
            // btnGonder
            // 
            this.btnGonder.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.Appearance.Options.UseFont = true;
            this.btnGonder.ImageOptions.SvgImage = global::Ticari_Otomasyon.Properties.Resources.floatingobjectsendbehindtext;
            this.btnGonder.Location = new System.Drawing.Point(62, 556);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(333, 57);
            this.btnGonder.TabIndex = 8;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(62, 268);
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(333, 282);
            this.txtMesaj.TabIndex = 7;
            this.txtMesaj.Text = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(62, 238);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 30);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Mesaj";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(62, 168);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 30);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Konu";
            // 
            // txtKonu
            // 
            this.txtKonu.Location = new System.Drawing.Point(62, 198);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKonu.Properties.Appearance.Options.UseFont = true;
            this.txtKonu.Size = new System.Drawing.Size(333, 36);
            this.txtKonu.TabIndex = 4;
            // 
            // txtAliciMailAdresi
            // 
            this.txtAliciMailAdresi.Location = new System.Drawing.Point(62, 118);
            this.txtAliciMailAdresi.Name = "txtAliciMailAdresi";
            this.txtAliciMailAdresi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAliciMailAdresi.Properties.Appearance.Options.UseFont = true;
            this.txtAliciMailAdresi.Size = new System.Drawing.Size(333, 36);
            this.txtAliciMailAdresi.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(62, 88);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 30);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mail Adresi";
            // 
            // FrmMailMusteriler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 665);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtKonu);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtAliciMailAdresi);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMailMusteriler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Mail Gönderme Ekranı";
            this.Load += new System.EventHandler(this.FrmMailMusteriler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKonu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAliciMailAdresi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnGonder;
        private System.Windows.Forms.RichTextBox txtMesaj;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtKonu;
        private DevExpress.XtraEditors.TextEdit txtAliciMailAdresi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}