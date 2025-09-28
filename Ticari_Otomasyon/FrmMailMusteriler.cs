using DevExpress.XtraEditors.TextEditController.IME;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Ticari_Otomasyon
{
    public partial class FrmMailMusteriler : Form
    {
        public FrmMailMusteriler( )
        {
            InitializeComponent();
            
        }

        public string mail;
        private void FrmMailMusteriler_Load(object sender, EventArgs e)
        {
            txtAliciMailAdresi.Text = mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            #region MyRegion
            try
            {

                DialogResult result = MessageBox.Show(
                    "Maili Göndermek İstiyormusunuz?",
                    "Mail Gönderme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Mail Göderme İşlemi.", "Bilgi", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress("mustafaasafcelik@gmail.com","Mustafa Asaf ÇELİK");

                mesaj.To.Add(txtAliciMailAdresi.Text); // 📥 Alıcı e-posta adresi
                mesaj.Subject = txtKonu.Text;
                // mesaj.Body = $"<h3>Merhaba,</h3><p>{txtMesaj.Text}</p>";
                //mesaj.Body = $"<p>{txtMesaj.Text}</p>";
                mesaj.Body = txtMesaj.Text;// 📩 Mail içeriği

                mesaj.ReplyToList.Add(new MailAddress("mustafaasafcelik@gmail.com"));
                SmtpClient istemci = new SmtpClient("smtp.gmail.com", 587);
                istemci.Credentials = new NetworkCredential("mustafaasafcelik@gmail.com", "kghiaufsmlozrvmg");
                istemci.EnableSsl = true;

                istemci.Send(mesaj);
                MessageBox.Show("Mail Müşteriye Gönderilmiştir!", "MÜŞTERİLER", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            #endregion

       

           


        }


    }
}
