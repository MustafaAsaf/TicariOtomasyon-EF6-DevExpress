using DevExpress.XtraEditors;
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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
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
                    var spendingList = values.Tbl_Notlar.Select(note => new
                    {
                        note.NotID,
                        note.NotTarih,
                        note.NotSaat,
                        note.NotBaslik,
                        note.NotDetay,
                        note.NotOlusturan,
                        note.NotHitap
                    }).ToList();
                    gridControl1.DataSource = spendingList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            GetAll(); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.SaveChanges();
            MessageBox.Show("Kaydedildi !");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm(groupControl1);
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

                Tbl_Notlar tblNotlar = new Tbl_Notlar();
                tblNotlar.NotTarih = txtTarih.Text;
                tblNotlar.NotSaat=txtSaat.Text;
                tblNotlar.NotBaslik=txtBaslik.Text;
                tblNotlar.NotOlusturan = txtGonderen.Text;
                tblNotlar.NotHitap = txtAlici.Text;
                tblNotlar.NotDetay = txtKonu.Text;

                dataBase.Tbl_Notlar.Add(tblNotlar);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Not Eklendi!", "NOTLAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();
                ClearForm(groupControl1);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır kontrolü
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("NotID")); // ID'yi al
                    var removeValues = dataBase.Tbl_Notlar.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Notlar.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Not Silindi", "NOTLAR", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            GetAll(); // Listeyi yenile
                            ClearForm(groupControl1); // Formu temizle
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silinecek Not bulunamadı!", "Hata", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hatalı İşlem! Lütfen Silinecek Kaydı Kontrol Ediniz!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(
                        gridView1.GetFocusedRowCellValue("NotID")); // Seçili satırdaki "BankaId" değerini al
                    var updateNote = dataBase.Tbl_Notlar.Find(id); // ID'ye göre veriyi bul

                    if (updateNote != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                            "Güncelleme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {
                            updateNote.NotTarih = txtTarih.Text;
                            updateNote.NotSaat = txtSaat.Text;
                            updateNote.NotBaslik = txtBaslik.Text;
                            updateNote.NotOlusturan = txtGonderen.Text;
                            updateNote.NotHitap = txtAlici.Text;
                            updateNote.NotDetay = txtKonu.Text;

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Not başarıyla güncellendi!", "NOTLAR", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            GetAll(); // Listeyi yenile
                            ClearForm(groupControl1); // Formu temizle
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek NOT bulunamadı!", "Hata", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir Not seçin!", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu! " + ex.Message, "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa
                {
                    txtTarih.Text = gridView1.GetFocusedRowCellValue("NotTarih").ToString();
                    txtSaat.Text = gridView1.GetFocusedRowCellValue("NotSaat").ToString();
                    txtBaslik.Text = gridView1.GetFocusedRowCellValue("NotBaslik").ToString();
                    txtKonu.Text = gridView1.GetFocusedRowCellValue("NotDetay").ToString();
                    txtGonderen.Text = gridView1.GetFocusedRowCellValue("NotOlusturan").ToString();
                    txtAlici.Text = gridView1.GetFocusedRowCellValue("NotHitap").ToString();

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
