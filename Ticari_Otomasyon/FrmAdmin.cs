﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ticari_Otomasyon.Models;

namespace Ticari_Otomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 database = new DboTicariOtomasyonEntities1();

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Eğer checkEdit işaretlendiyse, şifreyi göster
                if (checkEdit1.Checked)
                {
                    txtSifre.Properties.UseSystemPasswordChar=false;
                }
                else // İşaret kaldırılırsa, şifreyi yine gizle
                {
                    txtSifre.Properties.UseSystemPasswordChar = true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string userName= txtKullaniciAdi.Text;
            string password= txtSifre.Text;

            try
            {
                using (var context = new DboTicariOtomasyonEntities1())
                {
                    var user = context.Tbl_Admin
                        .FirstOrDefault(u => u.AdminKullaniciAdi == userName && u.AdminSifre == password);

                    if (user != null) //user değişkeni veri tabanında varsa ve textedit nesneleriyle uyuşuyorsa.
                    {
                        MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Ana formu açın veya bir sonraki işlemi başlatın.
                        FrmAna frmAna = new FrmAna();
                        frmAna.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            try
            {
                FrmVeriTabani baglantiVeriTabanı = new FrmVeriTabani();
                baglantiVeriTabanı.Show();
                this.Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
