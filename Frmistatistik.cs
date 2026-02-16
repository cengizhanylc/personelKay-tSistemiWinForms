using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace personel_kayit
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-8S3J1T5\\SQLEXPRESS;Initial Catalog=\"c# geliştirme\";Integrated Security=True;Encrypt=False;");


        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            // TOPLAM PERSONEL SAYISI
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(*) From tbl_personel", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                lblTopPer.Text = dr1[0].ToString();
            }
            con.Close();

            // EVLİ PERSONEL SAYISI 
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select count(*) From tbl_personel where PerDurum=1",con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPer.Text = dr2[0].ToString();
            }
            con.Close();

            // BEKAR PERSONEL SAYISI 
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select count(*) From tbl_personel where PerDurum=0",con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPer.Text = dr3[0].ToString();
            }
            con.Close();

            // FARKLI ŞEHİR SAYISI
            con.Open();
            SqlCommand cmd4 = new SqlCommand("select count(distinct(PerSehir)) From tbl_personel",con);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            con.Close();

            //TOPLAM MAAŞ
            con.Open();
            SqlCommand cmd5 = new SqlCommand("select sum(PerMaas) From tbl_personel",con);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                lblTopMaas.Text = dr5[0].ToString();
            }
            con.Close();

            //ORTALAMA MAAŞ
            con.Open();
            SqlCommand cmd6 = new SqlCommand("select avg(PerMaas) From tbl_personel", con);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text = dr6[0].ToString();
            }
            con.Close();

        }
    }
}
