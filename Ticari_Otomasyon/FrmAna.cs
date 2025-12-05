using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ticari_Otomasyon
{
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;  // Ekranı kapla
        }

        private void barButtonExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }


        public void ClearForm(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextEdit textEdit) // DevExpress TextEdit
                {
                    textEdit.Text = string.Empty;
                }
                else if (control is MaskedTextBox maskedTextBox) // MaskedTextBox
                {
                    maskedTextBox.Clear();
                }
                else if (control is NumericUpDown numericUpDown) // NumericUpDown
                {
                    numericUpDown.Value = numericUpDown.Minimum;
                }
                else if (control is RichTextBox richTextBox) // RichTextBox
                {
                    richTextBox.Clear();
                }

                // Eğer kontrol bir panel, groupbox veya başka bir container ise içindekileri de temizle
                if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }

        private void barButtonClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearForm(this);
        }

        private FrmUrunler frmUrunler;
        private void barButtonUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewStock")) //Stok görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (frmUrunler == null || frmUrunler.IsDisposed) // Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    frmUrunler = new FrmUrunler();
                    frmUrunler.MdiParent = this;
                    frmUrunler.Show();
                }
                else
                {
                    frmUrunler.Activate();
                }
            }
            
        }

        private FrmMusteriler _frmMusteriler;
        private void A_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewCustomers")) // Müşteri görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmMusteriler == null || _frmMusteriler.IsDisposed) // Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmMusteriler = new FrmMusteriler();
                    _frmMusteriler.MdiParent = this;
                    _frmMusteriler.Show();
                }
                else
                {
                    _frmMusteriler.Activate(); // Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
           
        }
        private void FrmAna_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable; // veya sabit çerçeve (FixedSingle)
            this.Bounds = Screen.PrimaryScreen.WorkingArea; // Görev çubuğu alanı hariç ekran

            //Uygulama çalıştığı zaman ekranda ilk olarak ANA FORM açılsın.
            if (_frmAyarlar == null || _frmAnaSayfa.IsDisposed)
            {
                _frmAnaSayfa = new FrmAnaSayfa();
                _frmAnaSayfa.MdiParent = this;
                _frmAnaSayfa.WindowState = FormWindowState.Maximized;
                _frmAnaSayfa.Show();
            }
            else
            {
                _frmAnaSayfa.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
            }


        }

        private FrmSirketler _frmSirketler;
        private void barButtonFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewCustomers")) // Şirket görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmSirketler == null || _frmSirketler.IsDisposed) // Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmSirketler = new FrmSirketler();
                    _frmSirketler.MdiParent = this;
                    _frmSirketler.WindowState = FormWindowState.Maximized;  // Alt formu tam ekran yap (MDI Container içinde)
                    _frmSirketler.Show();
                }
                else
                {
                    _frmSirketler.Activate(); // Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
        }


        private FrmPersoneller _frmPersoneller;
        private void barButtonPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewPersonnel")) // Personel görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmPersoneller == null || _frmPersoneller.IsDisposed) // Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmPersoneller = new FrmPersoneller();
                    _frmPersoneller.MdiParent = this;
                    _frmPersoneller.Show();
                }
                else
                {
                    _frmPersoneller.Activate(); // Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
        }


        private FrmRehber _frmRehber;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewDirectory")) //Rehberi görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmRehber == null || _frmRehber.IsDisposed) // Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmRehber = new FrmRehber();
                    _frmRehber.MdiParent = this;
                    _frmRehber.Show();
                }
                else
                {
                    _frmRehber.Activate(); // Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
        }

        private FrmGiderler _frmGiderler;
        private void barButtonGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!CurrentUser.HasPermission("ViewExpenses")) //Gider görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmGiderler == null || _frmGiderler.IsDisposed) // Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmGiderler = new FrmGiderler();
                    _frmGiderler.MdiParent = this;
                    _frmGiderler.Show();
                }
                else
                {
                    _frmGiderler.Activate(); // Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }

           
        }

        private FrmBankalar _frmBankalar;
        private void barButtonBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewBanks")) //Bankaları görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmBankalar == null || _frmBankalar.IsDisposed) // Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmBankalar = new FrmBankalar();
                    _frmBankalar.MdiParent = this;
                    _frmBankalar.Show();
                }
                else
                {
                    _frmBankalar.Activate(); // Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
           
        }

        private FrmFaturalar _frmFaturalar;
        private void barButtonFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewInvoices"))// Fatura görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmFaturalar == null || _frmFaturalar.IsDisposed)// Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmFaturalar = new FrmFaturalar();
                    _frmFaturalar.MdiParent = this;
                    _frmFaturalar.Show();
                }
                else
                {
                    _frmFaturalar.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
        }

        private FrmNotlar _frmNotlar;
        private void barButtonNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewNotes")) //Notları görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmNotlar == null || _frmNotlar.IsDisposed)// Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmNotlar = new FrmNotlar();
                    _frmNotlar.MdiParent = this;
                    _frmNotlar.Show();
                }
                else
                {
                    _frmNotlar.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
            
        }

        public FrmHareketler _frmHareketler;
        private void barButtonHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewMovements")) //Hareketleri görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmHareketler == null || _frmHareketler.IsDisposed)// Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmHareketler = new FrmHareketler();
                    _frmHareketler.MdiParent = this;
                    _frmHareketler.Show();
                }
                else
                {
                    _frmHareketler.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
        }

        private FrmRaporlar _frmRaporlar;
        private void barButtonRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewReports")) //Raporları görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmRaporlar == null || _frmRaporlar.IsDisposed)// Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmRaporlar = new FrmRaporlar();
                    _frmRaporlar.MdiParent = this;
                    _frmRaporlar.Show();
                }
                else
                {
                    _frmRaporlar.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
        }

        private FrmStoklar _frmStoklar;
        private void barButtonStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewStock")) //Stok görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmStoklar == null || _frmStoklar.IsDisposed)// Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmStoklar = new FrmStoklar();
                    _frmStoklar.MdiParent = this;
                    _frmStoklar.Show();
                }
                else
                {
                    _frmStoklar.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
           
        }

        private FrmKasa _frmKasa;
        private void barButtonKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewVault"))// Kasa görüntüleme izni yoksa
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmKasa == null || _frmKasa.IsDisposed)// Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmKasa = new FrmKasa();
                    _frmKasa.MdiParent = this;
                    _frmKasa.WindowState = FormWindowState.Maximized;  // Alt formu tam ekran yap (MDI Container içinde)
                    _frmKasa.Show();
                }
                else
                {
                    _frmKasa.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }


        }

        private FrmAyarlar _frmAyarlar;
        private void barButtonSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ManageSettings"))
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmAyarlar == null || _frmAyarlar.IsDisposed)// Formun null olup olmadığını VEYA kapatılıp kapatılmadığını kontrol et
                {
                    _frmAyarlar = new FrmAyarlar();
                    _frmAyarlar.Show();
                }
                else
                {
                    _frmAyarlar.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
                }
            }
            
        }

        private FrmAnaSayfa _frmAnaSayfa;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmAyarlar== null || _frmAnaSayfa.IsDisposed)
            {
                _frmAnaSayfa = new FrmAnaSayfa();
                _frmAnaSayfa.MdiParent = this;
                _frmAnaSayfa.WindowState = FormWindowState.Maximized;
                _frmAnaSayfa.Show();
            }
            else
            {
                _frmAnaSayfa.Activate();// Eğer açıksa aktif hale getir (isteğe bağlı)
            }
        }

        private FrmSatisAnaliz _frmSatisAnaliz;
        private void barButtonSatisAnaliz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewAnalysis"))
            {
                MessageBox.Show("Bu ekrana erişim izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (_frmSatisAnaliz == null || _frmSatisAnaliz.IsDisposed)
                {
                    _frmSatisAnaliz = new FrmSatisAnaliz();
                    _frmSatisAnaliz.MdiParent = this;
                    _frmSatisAnaliz.WindowState = FormWindowState.Maximized;
                    _frmSatisAnaliz.Show();
                }
                else
                {
                    _frmSatisAnaliz.Activate();
                }
            }

         
        }
    }
}
