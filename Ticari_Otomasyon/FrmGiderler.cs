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
using DevExpress.XtraEditors;

namespace Ticari_Otomasyon
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
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
                    var expensesList = values.Tbl_Giderler.Select(g=>new
                    {
                        ID=g.GiderId,
                        Ay=g.GiderAy,
                        Yıl=g.GiderYıl,
                        Elektrik = g.GiderElektrik,
                        Su=g.GiderSu,
                        Doğalgaz=g.GiderDogalgaz,
                        Internet=g.GiderInternet,
                        Maaşlar=g.GiderMaaslar,
                        Ekstralar=g.GiderEkstra,
                        Notlar=g.GiderNotlar
                    }).ToList();
                    gridControl1.DataSource = expensesList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetYear()
        {
            int currentYear = DateTime.Now.Year;

            comboBoxYil.Properties.Items.Clear();

            for (int i = 0; i <= 3; i++)
            {
                comboBoxYil.Properties.Items.Add((currentYear + i).ToString());
            }

            comboBoxYil.SelectedItem = currentYear.ToString();
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            GetYear();
            GetAll();
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
                // Kullanıcıdan onay al
                DialogResult result = MessageBox.Show(
                    "Bu kaygı eklemek istiyor musunuz?",
                    "Gider Ekleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Eğer kullanıcı "Hayır" derse işlemi iptal et
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Gider ekleme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal giderElektrik, giderSu, giderDogalgaz, giderInternet, giderMaaslar, giderEkstra;
                string giderAy, giderYil, giderNotlar;

                Tbl_Giderler tblGiderler = new Tbl_Giderler();

                giderAy = comboBoxAy.SelectedItem.ToString();
                giderYil = comboBoxYil.SelectedItem.ToString();
                giderElektrik = Convert.ToDecimal(txtElektrik.Text);
                giderSu = Convert.ToDecimal(txtSu.Text);
                giderDogalgaz = Convert.ToDecimal(txtDogalgaz.Text);
                giderInternet = Convert.ToDecimal(txtInternet.Text);
                giderMaaslar = Convert.ToDecimal(txtMaaslar.Text);
                giderEkstra = Convert.ToDecimal(txtEkstra.Text);
                giderNotlar = txtNotlar.Text;

                // Yeni işlem ekle
                tblGiderler.GiderAy = giderAy;
                tblGiderler.GiderYıl = giderYil;
                tblGiderler.GiderElektrik = giderElektrik;
                tblGiderler.GiderSu = giderSu;
                tblGiderler.GiderDogalgaz = giderDogalgaz;
                tblGiderler.GiderInternet = giderInternet;
                tblGiderler.GiderMaaslar = giderMaaslar;
                tblGiderler.GiderEkstra = giderEkstra;
                tblGiderler.GiderNotlar = giderNotlar;

                dataBase.Tbl_Giderler.Add(tblGiderler);
                dataBase.SaveChanges();

                MessageBox.Show("Yeni Veri Eklendi!", "GİDERLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAll();  // Listeyi yeniler
                ClearForm(groupControl1); // Formu temizler
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hatalı Veri Girişi. Lütfen Bilgileri Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0) // Seçili satır varsa
            {
                comboBoxAy.Text = gridView1.GetFocusedRowCellValue("Ay").ToString();
                comboBoxYil.Text = gridView1.GetFocusedRowCellValue("Yıl").ToString();
                txtElektrik.Text = gridView1.GetFocusedRowCellValue("Elektrik").ToString();
                txtSu.Text = gridView1.GetFocusedRowCellValue("Su").ToString();
                txtDogalgaz.Text = gridView1.GetFocusedRowCellValue("Doğalgaz").ToString();
                txtInternet.Text = gridView1.GetFocusedRowCellValue("Internet").ToString();
                txtMaaslar.Text = gridView1.GetFocusedRowCellValue("Maaşlar").ToString();
                txtEkstra.Text = gridView1.GetFocusedRowCellValue("Ekstralar").ToString();
                txtNotlar.Text = gridView1.GetFocusedRowCellValue("Notlar").ToString();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm(groupControl1);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Seçili satır kontrolü
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")); // ID'yi al
                    var removeValues = dataBase.Tbl_Giderler.Find(id);

                    if (removeValues != null)
                    {
                        // Kullanıcıya onay mesajı göster
                        DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?",
                            "Silme Onayı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" derse sil
                        {
                            dataBase.Tbl_Giderler.Remove(removeValues);
                            dataBase.SaveChanges();

                            MessageBox.Show("Kayıt Silindi", "GİDERLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetAll(); // Listeyi yenile
                            ClearForm(groupControl1); // Formu temizle
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silinecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hatalı İşlem! Lütfen Silinecek Kaydı Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0) // Eğer seçili satır varsa
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GiderId")); // Seçili satırdaki "GiderId" değerini al
                    var updateExpensest = dataBase.Tbl_Giderler.Find(id); // ID'ye göre veriyi bul

                    if (updateExpensest != null)
                    {
                        // Kullanıcıdan onay al
                        DialogResult result = MessageBox.Show("Bu kaydı güncellemek istiyor musunuz?",
                                                              "Güncelleme Onayı",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Kullanıcı "Evet" dediyse güncelle
                        {

                            updateExpensest.GiderAy = comboBoxAy.SelectedItem.ToString();
                            updateExpensest.GiderYıl = comboBoxYil.SelectedItem.ToString();
                            updateExpensest.GiderElektrik = Convert.ToDecimal(txtElektrik.Text);
                            updateExpensest.GiderSu = Convert.ToDecimal(txtSu.Text);
                            updateExpensest.GiderDogalgaz = Convert.ToDecimal(txtDogalgaz.Text);
                            updateExpensest.GiderInternet = Convert.ToDecimal(txtInternet.Text);
                            updateExpensest.GiderMaaslar = Convert.ToDecimal(txtMaaslar.Text);
                            updateExpensest.GiderEkstra = Convert.ToDecimal(txtEkstra.Text);
                            updateExpensest.GiderNotlar = txtNotlar.Text;

                            dataBase.SaveChanges(); // Veritabanına değişiklikleri kaydet
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetAll(); // Listeyi yenile
                            ClearForm(groupControl1); // Formu temizle
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu! " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
