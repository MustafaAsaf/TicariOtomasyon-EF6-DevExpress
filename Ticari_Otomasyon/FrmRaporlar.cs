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
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet.Tbl_Giderler' table. You can move, or remove it, as needed.
            this.Tbl_GiderlerTableAdapter.Fill(this.DboTicariOtomasyonDataSet.Tbl_Giderler);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet.Tbl_Personeller' table. You can move, or remove it, as needed.
            this.Tbl_PersonellerTableAdapter.Fill(this.DboTicariOtomasyonDataSet.Tbl_Personeller);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet.Tbl_Sirketler' table. You can move, or remove it, as needed.
            this.Tbl_SirketlerTableAdapter.Fill(this.DboTicariOtomasyonDataSet.Tbl_Sirketler);

            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet.Tbl_Musteriler' table. You can move, or remove it, as needed.
            this.Tbl_MusterilerTableAdapter.Fill(this.DboTicariOtomasyonDataSet.Tbl_Musteriler);

            this.reportViewerMusteri.RefreshReport();
            this.reportViewerFirma.RefreshReport();
            this.reportViewerPersonel.RefreshReport();
            this.reportViewerGiderler.RefreshReport();
            this.reportViewerGiderler.RefreshReport();
        }


    }
}
