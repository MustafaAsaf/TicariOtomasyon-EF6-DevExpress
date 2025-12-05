using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmMailFirmalar : Form
    {
        public FrmMailFirmalar()
        {
            InitializeComponent();
        }

        public string mail;
        private void frmMailFirmalar_Load(object sender, EventArgs e)
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
                mesaj.From = new MailAddress("mustafaasafcelik@gmail.com", "Mustafa Asaf ÇELİK");

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
                MessageBox.Show("Mail Firmaya Gönderilmiştir!", "FİRMALAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            #endregion
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool move;
        int mouse_x;
        int mouse_y;

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
