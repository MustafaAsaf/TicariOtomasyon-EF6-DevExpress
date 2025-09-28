using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Filtering;
using Ticari_Otomasyon.Models;
using DevExpress.XtraEditors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ticari_Otomasyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
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
        public void GetAll()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_Musteriler.Select(mst => new
                    {
                        mst.MusteriID,
                        mst.MusteriAd,
                        mst.MusteriSoyad,
                        mst.MusteriTelefon,
                        mst.MusteriTelefon2,
                        mst.MusteriTC,
                        mst.MusteriMail,
                        mst.MusteriSehir,
                        mst.MusteriIlce,
                        mst.MusteriAdres,
                        mst.MusteriVergiDaire
                    }).ToList();
                    gridControl1.DataSource = spendingList;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA");
            }
        }
        public void GetSehirler()
        {
            comboBoxIl.Properties.Items.Clear(); // Önce temizle
            var sehirler = dataBase.Tbl_Sehirler.Select(s => s.SehirAdi).ToList();

            comboBoxIl.Properties.Items.AddRange(sehirler);
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
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            GetAll();
            GetSehirler();
            gridView1.Columns["MusteriID"].Visible = false;
        }
        
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi !");
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
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

                Tbl_Musteriler tblMusteriler = new Tbl_Musteriler();

                tblMusteriler.MusteriAd = txtMusteriAd.Text;
                tblMusteriler.MusteriSoyad = txtMusteriSoyad.Text;
                tblMusteriler.MusteriTelefon = txtMusteriTelefon1.Text;
                tblMusteriler.MusteriTelefon2 = txtMusteriTelefon2.Text;
                tblMusteriler.MusteriTC = txtTcNo.Text;
                tblMusteriler.MusteriMail = txtMusteriMail.Text;
                tblMusteriler.MusteriSehir = comboBoxIl.EditValue.ToString();
                tblMusteriler.MusteriIlce = comboBoxIlce.EditValue.ToString();
                tblMusteriler.MusteriAdres = txtMusteriAdres.Text;
                tblMusteriler.MusteriVergiDaire = txtVergiDairesi.Text;

                dataBase.Tbl_Musteriler.Add(tblMusteriler);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Kayıt Eklendi!", "MÜŞTERİLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();
                ClearForm(groupControl1);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır kontrolü
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MusteriID")); // ID'yi al
                    var removeValues = dataBase.Tbl_Musteriler.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Musteriler.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "MÜŞTERİLER", MessageBoxButtons.OK,
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
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(
                        gridView1.GetFocusedRowCellValue("MusteriID")); // Seçili satırdaki "UrunID" değerini al
                    var updateProduct = dataBase.Tbl_Musteriler.Find(id); // ID'ye göre veriyi bul

                    if (updateProduct != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                            "Güncelleme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {

                            updateProduct.MusteriAd = txtMusteriAd.Text;
                            updateProduct.MusteriSoyad = txtMusteriSoyad.Text;
                            updateProduct.MusteriTelefon = txtMusteriTelefon1.Text;
                            updateProduct.MusteriTelefon2 = txtMusteriTelefon2.Text;
                            updateProduct.MusteriTC = txtTcNo.Text;
                            updateProduct.MusteriMail = txtMusteriMail.Text;
                            updateProduct.MusteriSehir = comboBoxIl.EditValue.ToString();
                            updateProduct.MusteriIlce = comboBoxIlce.EditValue.ToString();
                            updateProduct.MusteriAdres = txtMusteriAdres.Text;
                            updateProduct.MusteriVergiDaire = txtVergiDairesi.Text;

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Müşteriler", MessageBoxButtons.OK,
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
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm(groupControl1);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa 
                {
                    txtMusteriAd.Text = gridView1.GetFocusedRowCellValue("MusteriAd")?.ToString();
                    txtMusteriSoyad.Text = gridView1.GetFocusedRowCellValue("MusteriSoyad")?.ToString();
                    txtMusteriTelefon1.Text = gridView1.GetFocusedRowCellValue("MusteriTelefon")?.ToString();
                    txtMusteriTelefon2.Text = gridView1.GetFocusedRowCellValue("MusteriTelefon2")?.ToString();
                    txtTcNo.Text = gridView1.GetFocusedRowCellValue("MusteriTC")?.ToString();
                    txtMusteriMail.Text = gridView1.GetFocusedRowCellValue("MusteriMail")?.ToString();
                    txtMusteriAdres.Text = gridView1.GetFocusedRowCellValue("MusteriAdres")?.ToString();
                    txtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("MusteriVergiDaire")?.ToString();
                    comboBoxIl.Text = gridView1.GetFocusedRowCellValue("MusteriSehir")?.ToString();
                    comboBoxIlce.Text = gridView1.GetFocusedRowCellValue("MusteriIlce")?.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show( exception.Message, "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void comboBoxIl_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetIlceler();
        }
    }
}
