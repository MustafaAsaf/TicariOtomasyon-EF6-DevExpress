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
using Ticari_Otomasyon.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ticari_Otomasyon
{
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }


        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();
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
        public void GetSehirler()
        {
            comboBoxIl.Properties.Items.Clear(); // Önce temizle
            var sehirler = dataBase.Tbl_Sehirler.Select(s => s.SehirAdi).ToList();

            comboBoxIl.Properties.Items.AddRange(sehirler);
        }
        public void GetFirmalar()
        {
            comboBoxFirmalar.Properties.Items.Clear(); // Önce temizle
            var firmalar = dataBase.Tbl_Sirketler.Select(s => s.SirketAd).ToList();
            comboBoxFirmalar.Properties.Items.AddRange(firmalar);
        }
        public void GetIlceler()
        {
            if (comboBoxIl.SelectedIndex == -1) return;

            string selectedCityName = comboBoxIl.SelectedItem.ToString();

            // Seçilen şehrin ID'sini bulalım
            var selectedCity = dataBase.Tbl_Sehirler.FirstOrDefault(s => s.SehirAdi == selectedCityName);
            if (selectedCity == null) return;

            comboBoxIlce.Properties.Items.Clear(); // Önce temizle
            var ilceler = dataBase.Tbl_Ilceler
                .Where(d => d.SehirId == selectedCity.SehirId)
                .Select(i => i.IlceAdi)
                .ToList();

            comboBoxIlce.Properties.Items.AddRange(ilceler);
        }
        public void GetAll()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_Bankalar.Select(bank => new
                    {
                        bank.BankaId,
                        bank.BankaAdi,
                        bank.BankaSehir,
                        bank.BankaIlce,
                        bank.BankaSube,
                        bank.BankaIBAN,
                        bank.BankaHesapNo,
                        bank.BankaYetkili,
                        bank.BankaTelefon,
                        bank.BankaTarih,
                        bank.BankaHesapTuru,
                        bank.Tbl_Sirketler.SirketAd

                    }).ToList();
                    gridControl1.DataSource = spendingList;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA");
            }
        }

        private void Frm_Bankalar_Load(object sender, EventArgs e)
        {
            GetFirmalar();
            GetAll();
            GetSehirler();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

     
        private void comboBoxIl_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetIlceler();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi");
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa
            {
                txtBankaAdi.Text = gridView1.GetFocusedRowCellValue("BankaAdi").ToString();
                comboBoxIl.Text = gridView1.GetFocusedRowCellValue("BankaSehir").ToString();
                comboBoxIlce.Text = gridView1.GetFocusedRowCellValue("BankaIlce").ToString();
                txtSube.Text = gridView1.GetFocusedRowCellValue("BankaSube").ToString();
                txtIBAN.Text = gridView1.GetFocusedRowCellValue("BankaIBAN").ToString();
                txtHesapNo.Text = gridView1.GetFocusedRowCellValue("BankaHesapNo").ToString();
                txtYetkili.Text = gridView1.GetFocusedRowCellValue("BankaYetkili").ToString();
                txtTelefon.Text = gridView1.GetFocusedRowCellValue("BankaTelefon").ToString();
                txtTarih.Text = gridView1.GetFocusedRowCellValue("BankaTarih").ToString();
                txtHesapTuru.Text = gridView1.GetFocusedRowCellValue("BankaHesapTuru").ToString();
                comboBoxFirmalar.Text = gridView1.GetFocusedRowCellValue("SirketAd").ToString();

            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm(groupControl1);
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(
                        gridView1.GetFocusedRowCellValue("BankaId")); // Seçili satırdaki "BankaId" değerini al
                    var updateProduct = dataBase.Tbl_Bankalar.Find(id); // ID'ye göre veriyi bul

                    if (updateProduct != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                            "Güncelleme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {
                            updateProduct.BankaAdi = txtBankaAdi.Text;
                            updateProduct.BankaSehir = comboBoxIl.SelectedItem.ToString();
                            updateProduct.BankaSube = txtSube.Text;
                            updateProduct.BankaIBAN = txtIBAN.Text;
                            updateProduct.BankaHesapNo = txtHesapNo.Text;
                            updateProduct.BankaYetkili = txtYetkili.Text;
                            updateProduct.BankaTelefon = txtTelefon.Text;
                            updateProduct.BankaTarih = Convert.ToDateTime(txtTarih.Text);
                            updateProduct.BankaHesapTuru = txtHesapTuru.Text;
                            updateProduct.SirketID = comboBoxFirmalar.SelectedIndex + 1;

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Bankalar", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            GetAll(); // Listeyi yenile
                            ClearForm(groupControl1); // Formu temizle
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu! " + ex.Message, "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır kontrolü
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BankaId")); // ID'yi al
                    var removeValues = dataBase.Tbl_Bankalar.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Bankalar.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "BANKALAR", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            GetAll(); // Listeyi yenile
                            ClearForm(groupControl1); // Formu temizle
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silinecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bu kaydı eklemek istiyor musunuz?",
                    "Kayıt Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Kayıt ekleme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                Tbl_Bankalar tblBankalar = new Tbl_Bankalar();
                tblBankalar.BankaAdi = txtBankaAdi.Text;
                tblBankalar.BankaSehir = comboBoxIl.SelectedItem.ToString();
                tblBankalar.BankaSube = txtSube.Text;
                tblBankalar.BankaIBAN = txtIBAN.Text;
                tblBankalar.BankaHesapNo = txtHesapNo.Text;
                tblBankalar.BankaYetkili = txtYetkili.Text;
                tblBankalar.BankaTelefon = txtTelefon.Text;
                tblBankalar.BankaTarih = Convert.ToDateTime(txtTarih.Text);
                tblBankalar.BankaHesapTuru = txtHesapTuru.Text;
                tblBankalar.SirketID = comboBoxFirmalar.SelectedIndex + 1;


                dataBase.Tbl_Bankalar.Add(tblBankalar);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Kayıt Eklendi!", "BANKALAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();
                ClearForm(groupControl1);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

