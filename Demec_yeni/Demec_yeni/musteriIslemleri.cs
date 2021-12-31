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
    public partial class musteriIslemleri : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog = DemeçOto; Integrated Security = True");
        
        public musteriIslemleri()
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

        private void MusteriListeleme_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            con.Open();
            SqlCommand query = new SqlCommand("EXEC sp_musteriDetay ", con);
            SqlDataReader sdr = query.ExecuteReader();

            listView1.View = View.Details;
            listView1.Columns.Add("TC", 80);
            listView1.Columns.Add("ADI", 60);
            listView1.Columns.Add("SOYADI", 60);
            listView1.Columns.Add("TELEFON", 100);
            listView1.Columns.Add("EMAIL", 130);
            listView1.Columns.Add("SATIN ALDIĞI ARAÇ", 60);
            listView1.Columns.Add("SATIŞ FİYATI", 100);
            listView1.Columns.Add("TARİH", 120);





            while (sdr.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr["tc"].ToString();
                satir.SubItems.Add(sdr["ad"].ToString());
                satir.SubItems.Add(sdr["soyad"].ToString());
                satir.SubItems.Add(sdr["tel"].ToString());
                satir.SubItems.Add(sdr["email"].ToString());
                satir.SubItems.Add(sdr["aracAd"].ToString());
                satir.SubItems.Add(sdr["satisFiyati"].ToString());
                satir.SubItems.Add(sdr["tarih"].ToString());

                ;

                listView1.Items.Add(satir);
            }

            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void MusteriEkle_Click(object sender, EventArgs e)
        {
            int satisId = 0;
            con.Open();
            SqlCommand query = new SqlCommand("select satisId from satilanaraclar where aracAd ='" + comboBox2.SelectedItem + "'", con);
            SqlDataReader sdr = query.ExecuteReader();
            if (sdr.Read())
                satisId = Convert.ToInt32(sdr["satisId"]);
            sdr.Close();
            string query1 = "insert into Musteriler(ad,soyad,tc, tel, email, satisId) values(@ad,@soyad,@tc, @tel, @email, @satisId)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            cmd.Parameters.AddWithValue("@tel", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.Parameters.AddWithValue("@satisId", satisId);
          
            cmd.ExecuteNonQuery();
           con.Close();
        }


        private void musteriIslemleri_Load(object sender, EventArgs e)
        {
            con.Open();           

            string query = "Select * from satilanaraclar";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                 comboBox2.Items.Add( sdr["aracAd"].ToString());
            }

         
            
            con.Close();
        }

        private void MusteriGuncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            int satisId = 0;
            SqlCommand query1 = new SqlCommand("select satisId from satilanaraclar where aracAd ='" + comboBox2.SelectedItem + "'", con);
            SqlDataReader sdr = query1.ExecuteReader();
            if (sdr.Read())
                satisId = Convert.ToInt32(sdr["satisId"]);
            sdr.Close();
            string query = "update Musteriler set ad=@ad,soyad=@soyad, tel=@tel, email=@email, satisId=@satisId where tc=@tc";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            cmd.Parameters.AddWithValue("@tel", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.Parameters.AddWithValue("@satisId", satisId);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void MusteriSil_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from musteriler where tc=@tc";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            //cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            //cmd.Parameters.AddWithValue("@tel", textBox4.Text);
            //cmd.Parameters.AddWithValue("@email", textBox5.Text);
            //cmd.Parameters.AddWithValue("@satisId", Convert.ToInt64(comboBox2.Text));

            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void geridon_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
            anasayfa.girisKontrol(ad, sifre);
            anasayfa.degerata(ad, sifre);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void musterininaldigiArac_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            con.Open();
            SqlCommand query = new SqlCommand("exec sp_musterininAldiğiAraclar "+ textBox1.Text, con);
            SqlDataReader sdr = query.ExecuteReader();
       

            listView2.View = View.Details;
            listView2.Columns.Add("TC", 100);
            listView2.Columns.Add("ADI", 100);
            listView2.Columns.Add("SOYADI", 100);
            listView2.Columns.Add("SATIN ALDIĞI ARAÇ", 60);
            listView2.Columns.Add("SATIŞ FİYATI", 100);
            listView2.Columns.Add("TARİH", 120);





            while (sdr.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr["tc"].ToString();
                satir.SubItems.Add(sdr["ad"].ToString());
                satir.SubItems.Add(sdr["soyad"].ToString());           
                satir.SubItems.Add(sdr["aracAd"].ToString());
                satir.SubItems.Add(sdr["satisFiyati"].ToString());
                satir.SubItems.Add(sdr["tarih"].ToString());

                ;

                listView2.Items.Add(satir);
            }

            con.Close();

        }
    }
}
