using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace personel_kayit
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8S3J1T5\\SQLEXPRESS;Initial Catalog=\"c# geliştirme\";Integrated Security=True;Encrypt=False;");
        
        void Temizle() 
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyAd.Text = "";
            msktxtMaas.Text = "";
            txtMeslek.Text = "";
            cmbSehir.Text = "";
            rbBekar.Checked = false;
            rbEvli.Checked = false;
        }

        void Listele()
        {
            this.tbl_personelTableAdapter.Fill(this._c__geliştirmeDataSet.tbl_personel);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_personel (PerAd, PerSoyad, PerSehir, PerMaas, PerDurum, PerMeslek)" + 
            "VALUES (@ad, @soyad, @sehir, @maas, @durum, @meslek)", con);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
            cmd.Parameters.AddWithValue("@sehir", cmbSehir.Text); // Seçilen şehirin adını alır
            cmd.Parameters.AddWithValue("@maas", msktxtMaas.Text);
            cmd.Parameters.AddWithValue("@durum", lblDurum.Text); // lblDurum.Text değerini kullanmamız gerekiyor
            cmd.Parameters.AddWithValue("@meslek", txtMeslek.Text); // Meslek için varsayılan bir değer ekleyebilirsiniz.
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Personel eklendi :)");
            Temizle();
        }

        private void rbEvli_CheckedChanged(object sender, EventArgs e) // radioButton evli
        {   
            if(rbEvli.Checked == true)
            {
                lblDurum.Text = "True";
            }
            
        }

        private void rbBekar_CheckedChanged(object sender, EventArgs e) // radioButton bekar
        {
            if(rbBekar.Checked == true)
            {
                lblDurum.Text = "False";
            }
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktxtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            lblDurum.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void lblDurum_TextChanged(object sender, EventArgs e)
        {
            if (lblDurum.Text == "True")
            {
                rbEvli.Checked = true;
            }
            if (lblDurum.Text == "False")
            {
                rbBekar.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Tbl_personel where PerId=@id",con);
            cmd.Parameters.AddWithValue("@id",txtId.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("kayıt silindi !");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Tbl_personel set PerAd=@ad, PerSoyad=@soyad, PerMaas=@maas, PerDurum=@durum, PerMeslek=@meslek where PerId=@id",con);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
            cmd.Parameters.AddWithValue("@sehir", cmbSehir.Text);
            cmd.Parameters.AddWithValue("@maas", msktxtMaas.Text);
            cmd.Parameters.AddWithValue("@durum", lblDurum.Text);
            cmd.Parameters.AddWithValue("@meslek", txtMeslek.Text);
            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("personel güncellendi :)");
        }

        private void btnİstatistikler_Click(object sender, EventArgs e)
        {
            Frmistatistik frmistatistik = new Frmistatistik();
               frmistatistik.Show();   
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            frmgrafikler frmgrafikler = new frmgrafikler();
            frmgrafikler.Show();
        }
    }
}
