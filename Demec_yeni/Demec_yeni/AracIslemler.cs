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
    public partial class AracIslemler : Form
    {
        public AracIslemler()
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

        private void AracIslemler_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            con.Open();
           
            SqlCommand query = new SqlCommand("Select * from Arac ", con);
            SqlDataReader sdr = query.ExecuteReader();

            listView1.View = View.Details;           
            listView1.Columns.Add("Arac Adı", 70);
            listView1.Columns.Add("Marka", 70);
            listView1.Columns.Add("Model", 70);
            listView1.Columns.Add("Renk", 70);
            listView1.Columns.Add("Yakıt", 70);
            listView1.Columns.Add("Vites", 80);
            listView1.Columns.Add("Kasa Tipi", 70);
            listView1.Columns.Add("Motor Gücü", 70);
            listView1.Columns.Add("Fiyat", 100);
            listView1.Columns.Add("Yıl", 50);
          

            while (sdr.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr["AracAd"].ToString();               
                satir.SubItems.Add(sdr["marka"].ToString());
                satir.SubItems.Add(sdr["model"].ToString());
                satir.SubItems.Add(sdr["renk"].ToString());
                satir.SubItems.Add(sdr["yakit"].ToString());
                satir.SubItems.Add(sdr["vites"].ToString());
                satir.SubItems.Add(sdr["kasatipi"].ToString());
                satir.SubItems.Add(sdr["motorgucu"].ToString());
                satir.SubItems.Add(sdr["fiyat"].ToString());
                satir.SubItems.Add(sdr["yil"].ToString());
              
                listView1.Items.Add(satir);
            }
            con.Close();

            listView2.Clear();
            con.Open();

            SqlCommand query2 = new SqlCommand("Select * from SatilanAraclar ", con);
            SqlDataReader sdr2 = query2.ExecuteReader();

            listView2.View = View.Details;
            listView2.Columns.Add("Arac Adı", 70);
            listView2.Columns.Add("Satış Id", 70);
            listView2.Columns.Add("Satış Tarihi", 120);
            listView2.Columns.Add("Satış Fiyatı", 120);


            while (sdr2.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr2["AracAd"].ToString();
                satir.SubItems.Add(sdr2["satisId"].ToString());
                satir.SubItems.Add(sdr2["satisFiyati"].ToString());
                satir.SubItems.Add(sdr2["tarih"].ToString());
                
                listView2.Items.Add(satir);
            }
            con.Close();
        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void aracekle_Click(object sender, EventArgs e)
        {          

            try
            {
                con.Open();
                string query1 = "insert into Arac(aracAd,marka, model, renk, yakit, vites, kasaTipi,motorGucu,fiyat,yil) values(@marka,@aracAd,@model, @renk, @yakit, @vites, @kasaTipi,@motorGucu,@fiyat,@yil)";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@aracAd", textBox1.Text);
                cmd.Parameters.AddWithValue("@marka", textBox2.Text);
                cmd.Parameters.AddWithValue("@model", textBox3.Text);
                cmd.Parameters.AddWithValue("@renk", textBox5.Text);
                cmd.Parameters.AddWithValue("@yakit", comboBox1.Text);
                cmd.Parameters.AddWithValue("@vites", comboBox2.Text);
                cmd.Parameters.AddWithValue("@kasaTipi", comboBox3.Text);
                cmd.Parameters.AddWithValue("@motorGucu", Convert.ToInt32(textBox6.Text));
                cmd.Parameters.AddWithValue("@fiyat", Convert.ToInt64(textBox7.Text));
                cmd.Parameters.AddWithValue("@yil", textBox4.Text); ;
                cmd.ExecuteNonQuery();
                con.Close();
                AracIslemler_Load(e, e);
                MessageBox.Show("Arac ekleme başarıyla gerçekleşti.");
            }
            catch
            {
                MessageBox.Show("Bu arac zaten var.");
            }

        }

        private void aracguncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            
                string query1 = "update arac set marka=@marka ,model=@model, renk=@renk, yakit=@yakit, vites=@vites, kasaTipi=@kasaTipi,motorGucu=@motorGucu,fiyat=@fiyat,yil=@yil where aracAd= @aracAd";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@marka", textBox2.Text);
                cmd.Parameters.AddWithValue("@aracAd", textBox1.Text);
                cmd.Parameters.AddWithValue("@model", textBox3.Text);
                cmd.Parameters.AddWithValue("@renk", textBox5.Text);
                cmd.Parameters.AddWithValue("@yakit", comboBox1.Text);
                cmd.Parameters.AddWithValue("@vites", comboBox2.Text);
                cmd.Parameters.AddWithValue("@kasaTipi", comboBox3.Text);
                cmd.Parameters.AddWithValue("@motorGucu", Convert.ToInt32(textBox6.Text));
                cmd.Parameters.AddWithValue("@fiyat", Convert.ToInt64(textBox7.Text));
                cmd.Parameters.AddWithValue("@yil", textBox4.Text);
                         
            cmd.ExecuteNonQuery();            
                con.Close();
            AracIslemler_Load(e, e);

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aracsil_Click(object sender, EventArgs e)
        {
            con.Open();

            string query1 = "delete from arac where aracAd=@aracAd";
            SqlCommand cmd = new SqlCommand(query1, con);
           // cmd.Parameters.AddWithValue("@marka", textBox2.Text);
            cmd.Parameters.AddWithValue("@aracAd", textBox1.Text);
            //cmd.Parameters.AddWithValue("@model", textBox3.Text);
            //cmd.Parameters.AddWithValue("@renk", textBox5.Text);
            //cmd.Parameters.AddWithValue("@yakit", comboBox1.Text);
            //cmd.Parameters.AddWithValue("@vites", comboBox2.Text);
            //cmd.Parameters.AddWithValue("@kasaTipi", comboBox3.Text);
            //cmd.Parameters.AddWithValue("@motorGucu", Convert.ToInt32(textBox6.Text));
            //cmd.Parameters.AddWithValue("@fiyat", Convert.ToInt64(textBox7.Text));
            //cmd.Parameters.AddWithValue("@yil", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            AracIslemler_Load(e, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
            anasayfa.girisKontrol(ad, sifre);
            anasayfa.degerata(ad, sifre);

        }

        private void ismeGoreAracGetir_Click(object sender, EventArgs e)
        {
            

            listView3.Clear();
            con.Open();

            SqlCommand query2 = new SqlCommand("exec sp_ismeGoreAracGetir "+textBox8.Text , con);
            SqlDataReader sdr2 = query2.ExecuteReader();


            listView3.View = View.Details;
            listView3.Columns.Add("Arac Adı", 70);
            listView3.Columns.Add("Marka", 70);
            listView3.Columns.Add("Model", 70);
            listView3.Columns.Add("Renk", 70);
            listView3.Columns.Add("Yakıt", 70);
            listView3.Columns.Add("Vites", 80);
            listView3.Columns.Add("Kasa Tipi", 70);
            listView3.Columns.Add("Motor Gücü", 70);
            listView3.Columns.Add("Fiyat", 100);
            listView3.Columns.Add("Yıl", 50);


            while (sdr2.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr2["AracAd"].ToString();
                satir.SubItems.Add(sdr2["marka"].ToString());
                satir.SubItems.Add(sdr2["model"].ToString());
                satir.SubItems.Add(sdr2["renk"].ToString());
                satir.SubItems.Add(sdr2["yakit"].ToString());
                satir.SubItems.Add(sdr2["vites"].ToString());
                satir.SubItems.Add(sdr2["kasatipi"].ToString());
                satir.SubItems.Add(sdr2["motorgucu"].ToString());
                satir.SubItems.Add(sdr2["fiyat"].ToString());
                satir.SubItems.Add(sdr2["yil"].ToString());

                listView3.Items.Add(satir);
            }
            con.Close();
        }
    }
    }

