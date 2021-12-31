using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demec_yeni
{
    public partial class CalisanIslemler : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog = DemeçOto; Integrated Security = True");

        public CalisanIslemler()
        {
            InitializeComponent();
        }

        public string ad;
        public string sifre;
        public void Adal(string x)
        {
            ad = x;
        }
        public void Sifreal(string y)
        {
            sifre = y;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            con.Open();
            SqlCommand query = new SqlCommand("Select calisantc,ad,soyad,tel,email,gorev from calisanlar ", con);
            SqlDataReader sdr = query.ExecuteReader();

            listView1.View = View.Details;
            listView1.Columns.Add("TC", 100);
            listView1.Columns.Add("ADI", 80);
            listView1.Columns.Add("SOYADI", 80);
            listView1.Columns.Add("TELEFON", 80);
            listView1.Columns.Add("EMAIL", 100);
            listView1.Columns.Add("GÖREVİ", 100);


            while (sdr.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr["calisantc"].ToString();
                satir.SubItems.Add(sdr["ad"].ToString());
                satir.SubItems.Add(sdr["soyad"].ToString());
                satir.SubItems.Add(sdr["tel"].ToString());
                satir.SubItems.Add(sdr["email"].ToString());
                satir.SubItems.Add(sdr["gorev"].ToString());

                ;

                listView1.Items.Add(satir);
            }
            con.Close();
        }

        private void calisanEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            string query1 = "insert into Calisanlar(ad,soyad,tel, calisantc, email, gorev) values(@ad,@soyad, @tel,@tc, @email, @gorev)";
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);           
            cmd.Parameters.AddWithValue("@tel", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.Parameters.AddWithValue("@gorev", textBox6.Text);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void calisanGuncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Calisanlar set ad=@ad,soyad=@soyad, tel=@tel, email=@email, gorev=@gorev  where calisantc=@tc";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@tel", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.Parameters.AddWithValue("@gorev", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void calisanSil_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from calisanlar where calisantc=@tc";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            //cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            //cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            //cmd.Parameters.AddWithValue("@tel", textBox4.Text);
            //cmd.Parameters.AddWithValue("@email", textBox5.Text);
            //cmd.Parameters.AddWithValue("@gorev", textBox6.Text);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
            anasayfa.girisKontrol(ad, sifre);
            anasayfa.degerata(ad, sifre);
        }
    }
}
