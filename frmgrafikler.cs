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
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-8S3J1T5\\SQLEXPRESS;Initial Catalog=\"c# geliştirme\";Integrated Security=True;Encrypt=False;");

        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            // GRAFİK 1
            con.Open();
            SqlCommand cmdg1 = new SqlCommand("select PerSehir,count(*) From tbl_personel Group By PerSehir", con);
            SqlDataReader drrg1 = cmdg1.ExecuteReader();
            while (drrg1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(drrg1[0], drrg1[1]);
            }
            con.Close();

            // GRAFİK 2
            con.Open();
            SqlCommand cmdg2 = new SqlCommand("select PerMeslek, avg(PerMaas) From tbl_personel Group By perMeslek" ,con);
            SqlDataReader drrg2 = cmdg2.ExecuteReader();
            while (drrg2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(drrg2[0], drrg2[1]);
            }

            con.Close();
        }
    }
}
