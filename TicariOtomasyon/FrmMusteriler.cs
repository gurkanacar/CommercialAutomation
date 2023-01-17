using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TicariOtomasyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        //alt iki metot iller ve ilceler combobox cikartma
        void sehirListesi()
        {
            SqlCommand komut = new SqlCommand("SELECT SEHIR FROM TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        //alt metot  ilceler combobox cikartma
        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR =@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirListesi();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //VERILERI KAYDETME
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", msktel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTc.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", cmbil.Text);
            komut.Parameters.AddWithValue("@p8", cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Musteri Sisteme Basari Ile eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //VERILERI SILME  KOTU YOL  (SIMDILIK)
            SqlCommand komutsil = new SqlCommand("DELETE FROM TBL_MUSTERILER WHERE ID = @p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MUSTERI BASARI ILE SILINDI", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //DATAGRID DEKI VERILERI TEXTBOXLARA TASIMA KOMUTLARI
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                msktel.Text = dr["TELEFON"].ToString();
                msktel2.Text = dr["TELEFON2"].ToString();
                mskTc.Text = dr["TC"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtVergid.Text = dr["VERGIDAIRE"].ToString();
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //GUNCELLEME KOMUTLARI
            SqlCommand komut = new SqlCommand("UPDATE TBL_MUSTERILER SET AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGIDAIRE=@p10 WHERE ID =@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", msktel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTc.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", cmbil.Text);
            komut.Parameters.AddWithValue("@p8", cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergid.Text);
            komut.Parameters.AddWithValue("@p11", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MUSTERI BILGISI GUNCELLENDI", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }
    }
}
