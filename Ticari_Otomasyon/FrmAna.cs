using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;  // Ekranı kapla
            xtraTabbedMdiManager1.MdiParent = this;

            xtraTabbedMdiManager1.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            xtraTabbedMdiManager1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Never;
            xtraTabbedMdiManager1.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.False;
           
        }

        public void OpenForm(Form frm)
        {
            foreach (Form item in this.MdiChildren)
            {
                item.Close();
            }

            frm.MdiParent = this;
            frm.Show();
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
        private void barButtonUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewStock")) //Stok görüntüleme izni yoksa
            {
                MessageBox.Show("Bu işlem için izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                OpenForm(new FrmUrunler());
            }
            
        }  
        private void A_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CurrentUser.HasPermission("ViewCustomers")) // Müşteri görüntüleme izni yoksa
            {
                MessageBox.Show("Bu işlem için izniniz yok!",
                    "Yetkisiz Erişim",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {

                OpenForm(new FrmMusteriler());
            }
           
        }
        private void FrmAna_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable; // veya sabit çerçeve (FixedSingle)
            this.Bounds = Screen.PrimaryScreen.WorkingArea; // Görev çubuğu alanı hariç ekran

            //Uygulama çalıştığı zaman ekranda ilk olarak ANA FORM açılsın.
            if (_frmAnaSayfa == null || _frmAnaSayfa.IsDisposed)
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
                OpenForm(new FrmSirketler());
            }
        }       
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
                OpenForm(new FrmPersoneller());
            }
        }
   
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
                OpenForm(new FrmRehber());
            }
        }
   
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
                OpenForm(new FrmGiderler());
            }

           
        }

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
                OpenForm(new FrmBankalar());
            }
           
        }
        
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
                OpenForm(new FrmFaturalar());

            }
        }

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
                OpenForm(new FrmNotlar());
            }
            
        }
     
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
                OpenForm(new FrmHareketler());
            }
        }

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
                OpenForm(new FrmRaporlar());
            }
        }

       
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
                OpenForm(new FrmStoklar());
            }
           
        }

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
                OpenForm(new FrmKasa());
            }


        }
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
                OpenForm(new FrmAyarlar());
            }
            
        }

        private FrmAnaSayfa _frmAnaSayfa;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmAnaSayfa == null || _frmAnaSayfa.IsDisposed)
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
                OpenForm(new FrmSatisAnaliz());
            }

         
        }
    }
}
