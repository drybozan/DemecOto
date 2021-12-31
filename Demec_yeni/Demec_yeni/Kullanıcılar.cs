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
    public partial class Kullanıcılar : Form
    {
        public Kullanıcılar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog = DemeçOto; Integrated Security = True");
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

        private void Kullanıcılar_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            con.Open();
            SqlCommand query = new SqlCommand("Select * from kullanıcılar", con);
            SqlDataReader sdr = query.ExecuteReader();

            listView1.View = View.Details;
            listView1.Columns.Add("KULLANICI AD ", 140);
            listView1.Columns.Add("ŞİFRE", 140);
            listView1.Columns.Add("YETKİSİ", 140);

            while (sdr.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr["kullanıcıAd"].ToString();
                satir.SubItems.Add(sdr["sifre"].ToString());
                satir.SubItems.Add(sdr["yetki"].ToString());


                ;

                listView1.Items.Add(satir);
            }

            con.Close();
        }

        private void MusteriEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            string query1 = "insert into kullanıcılar (kullanıcıAd,sifre,yetki) values(@kullanıcıAd,@sifre,@yetki)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@kullanıcıAd", textBox1.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@yetki", comboBox1.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            Kullanıcılar_Load(e, e);


        }

        private void MusteriSil_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from kullanıcılar where kullanıcıAd=@kullanıcıAd and sifre=@sifre and yetki=@yetki";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@kullanıcıAd", textBox1.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@yetki", comboBox1.SelectedItem);


            cmd.ExecuteNonQuery();
            con.Close();
            Kullanıcılar_Load(e, e);
        }

        private void geridon_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
            anasayfa.girisKontrol(ad, sifre);
            anasayfa.degerata(ad, sifre);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }  
}
