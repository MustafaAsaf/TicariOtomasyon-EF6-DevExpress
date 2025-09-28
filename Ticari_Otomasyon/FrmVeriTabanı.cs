using Org.BouncyCastle.Tls;
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
    public partial class FrmVeriTabanı : Form
    {
        public FrmVeriTabanı()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdmin frmAdmin = new FrmAdmin();
                frmAdmin.Show();
                this.Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName = txtServerName.Text;
            Properties.Settings.Default.AuthType = cbAuthentication.SelectedItem.ToString();
            Properties.Settings.Default.Username = txtKullaniciAdi.Text;
            Properties.Settings.Default.Password = txtSifre.Text;
            Properties.Settings.Default.Save();
        }
    }
}
