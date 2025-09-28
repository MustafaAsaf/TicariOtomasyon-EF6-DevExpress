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

namespace Ticari_Otomasyon
{
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        private DboTicariOtomasyonEntities1 dataBase = new DboTicariOtomasyonEntities1();

        public void GetFirmalar()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var directoryList = values.Tbl_Sirketler.Select(d => new
                    {
                       d.SirketAd,
                       d.YetkiliAdSoyad,
                       d.SirketTelefon1,
                       d.SirketTelefon2,
                       d.SirketTelefon3,
                       d.SirketMail,
                       d.SirketFax, 
                    }).ToList();
                    gridControlFirmalar.DataSource = directoryList;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA");
            }
        }

        public void GetMusteriler()
        {
            try
            {
                using (var values = new DboTicariOtomasyonEntities1())
                {
                    var spendingList = values.Tbl_Musteriler.Select(m => new
                    {
                      m.MusteriAd,
                      m.MusteriSoyad,
                      m.MusteriTelefon,
                      m.MusteriTelefon2,
                      m.MusteriMail
                    }).ToList();
                    gridControlMusteriler.DataSource = spendingList;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA");
            }
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            GetFirmalar();
            GetMusteriler();
        }

        private void gridViewMusteriler_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string musteriMail = gridViewMusteriler.GetFocusedRowCellValue("MusteriMail")?.ToString();// Geçerli satırdaki "MusteriMail" hücresinin değerini al
                // Eğer null değilse Form2'yi aç ve değeri gönder
                if (!string.IsNullOrEmpty(musteriMail))
                {
                    FrmMailMusteriler form2 = new FrmMailMusteriler();
                    form2.mail = musteriMail;
                    form2.Show();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            

        }

        private void gridViewFirmalar_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string faturaRehber = gridViewFirmalar.GetFocusedRowCellValue("SirketMail")?.ToString();// Geçerli satırdaki "SirketMail" hücresinin değerini al
                // Eğer null değilse Form2'yi aç ve değeri gönder
                if (!string.IsNullOrEmpty(faturaRehber))
                {
                    FrmMailFirmalar frmMailFirmalar = new FrmMailFirmalar();
                    frmMailFirmalar.mail = faturaRehber;
                    frmMailFirmalar.Show();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
