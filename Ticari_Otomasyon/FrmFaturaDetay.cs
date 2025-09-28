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
    public partial class FrmFaturaDetay : Form
    {
        public FrmFaturaDetay()
        {
            InitializeComponent();
        }
        private DboTicariOtomasyonEntities1 db = new DboTicariOtomasyonEntities1();
        public int _faturaID;

        public void GetAll2()
        {
            var detaylar = db.Tbl_FaturaDetay
                .Where(f => f.FaturaID == _faturaID)   // 🔴 burası değişti
                .Select(f => new
                {
                    ID = f.FaturaDetayID,
                    f.FaturaID,
                    f.UrunID,
                    UrunAd = f.FaturaDetayUrunAd,
                    Miktar = f.FaturaDetayMiktar,
                    Fiyat = f.FaturaDetayFiyat,
                    Tutar = f.FaturaDetayTutar
                })
                .ToList();

            gridControl1.DataSource = detaylar;
        }


        private void FrmFaturaDetay_Load(object sender, EventArgs e)
        {
           GetAll2();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ((gridView1.GetFocusedRowCellValue("ID") != null)) //FaturaDetayID alanı boş değilse yani kayıt varsa
                {
                    FrmFaturaUrunDetay urunDetayForm = new FrmFaturaUrunDetay();
                    // Verileri çek
                    urunDetayForm._faturaDetayID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));//FaturaDetayID hücresini al
                    urunDetayForm._urunAd = gridView1.GetFocusedRowCellValue("UrunAd")?.ToString();
                    urunDetayForm._miktar = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Miktar"));
                    urunDetayForm._fiyat = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Fiyat"));
                    urunDetayForm._tutar = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Tutar"));
                    urunDetayForm._faturaID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("FaturaID"));
                    urunDetayForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata: {exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    
    }
}
