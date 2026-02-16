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

namespace personel_kayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-8S3J1T5\\SQLEXPRESS;Initial Catalog=\"c# geliştirme\";Integrated Security=True;Encrypt=False;");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * From tbl_giris where kullaniciAdi=@p1 and sifre=@p2",con);
            cmd.Parameters.AddWithValue("@p1", txtKulaniciAdi.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                //this.Close(); çalışmıyor!!!
                
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
            }
            con.Close();
        }
    }
}
