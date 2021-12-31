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
    public partial class AracBakimIslemler : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog = DemeçOto; Integrated Security = True");
        public AracBakimIslemler()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void AracBakimIslemler_Load(object sender, EventArgs e)
        {

        }

        public void ListeleBakimleri(string sorgu) {

            listView1.Clear();
            con.Open();

            SqlCommand query = new SqlCommand("Select m.tc,c.calisantc,islemTarih,teslimTarih,maliyet from " + sorgu + " x join musteriler m on x.musteriId=m.musteriId join Calisanlar c on c.calisanId=x.teknisyenId", con);
            SqlDataReader sdr = query.ExecuteReader();

            listView1.View = View.Details;
            listView1.Columns.Add("Müşteri TC", 120);
            listView1.Columns.Add("Teknisyen TC", 120);
            listView1.Columns.Add("İşlem Tarih", 120);
            listView1.Columns.Add("Teslim Tarih", 120);
            listView1.Columns.Add("Maliyet", 120);


            while (sdr.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr["tc"].ToString();
                satir.SubItems.Add(sdr["calisantc"].ToString());
                satir.SubItems.Add(sdr["islemTarih"].ToString());
                satir.SubItems.Add(sdr["teslimTarih"].ToString());
                satir.SubItems.Add(sdr["maliyet"].ToString());

                listView1.Items.Add(satir);

            }
            con.Close();
        }

        private void BakimSec(string bakim)
        {
           // string _bakim = bakim;
            if (textBox1.Text == "")
            {
                ListeleBakimleri(bakim);
            }
            else
            {
                int musteriId = 0;
                int teknisyenId = 0;
                con.Open();
                SqlCommand query = new SqlCommand("select musteriId from musteriler where tc ='" + textBox1.Text.Trim() + "'", con);
                SqlDataReader sdr = query.ExecuteReader();
                if (sdr.Read())
                    musteriId = Convert.ToInt32(sdr["musteriId"]);
                sdr.Close();

                SqlCommand query1 = new SqlCommand("select calisanId from calisanlar where calisantc ='" + textBox2.Text.Trim() + "'", con);
                SqlDataReader sdr1 = query1.ExecuteReader();
                if (sdr1.Read())
                    teknisyenId = Convert.ToInt32(sdr1["calisanId"]);
                sdr1.Close();
                string query2 = "insert into " + bakim + " (teknisyenId,islemTarih, teslimTarih, maliyet, musteriId) values(@teknisyenId,@islemTarih, @teslimTarih,@maliyet,@musteriId)";
                SqlCommand cmd = new SqlCommand(query2, con);


                cmd.Parameters.AddWithValue("@musteriId", musteriId);
                cmd.Parameters.AddWithValue("@teknisyenId", teknisyenId);
                cmd.Parameters.AddWithValue("@islemTarih",Convert.ToDateTime (textBox3.Text));
                cmd.Parameters.AddWithValue("@teslimTarih",Convert.ToDateTime( textBox4.Text));
                cmd.Parameters.AddWithValue("@maliyet", Convert.ToInt32(textBox5.Text));

                cmd.ExecuteNonQuery();
                con.Close();
                ListeleBakimleri(bakim);
            }
        }
    


    private void antifirizekleme_Click(object sender, EventArgs e)
    {

            BakimSec("antifirizEkleme");
   
    }

        private void hvaFiltreDegisim_Click(object sender, EventArgs e)
        {
            BakimSec("HavaFiltreDegisim");
        }

        private void balansAyar_Click(object sender, EventArgs e)
        {
            BakimSec("BalansAyar");
        }

        private void frenAyar_Click(object sender, EventArgs e)
        {
            BakimSec("FrenAyar");
        }

        private void yagBakim_Click(object sender, EventArgs e)
        {
            BakimSec("YagBakim");
        }

        private void sasiYaglama_Click(object sender, EventArgs e)
        {
            BakimSec("SasiYaglama");
        }

        private void sznmyagdegisim_Click(object sender, EventArgs e)
        {
            BakimSec("SanzimanYagDegisim");
        }

        private void sgtmaTmzlik_Click(object sender, EventArgs e)
        {
            BakimSec("SogutmaSistemTemizlik");
        }

        private void lastikDegisim_Click(object sender, EventArgs e)
        {
            BakimSec("LastikDegisim");
        }

        private void lastikrotayar_Click(object sender, EventArgs e)
        {
            BakimSec("LastikRotAyar");
        }

        private void yagFiltreDegisim_Click(object sender, EventArgs e)
        {
            BakimSec("YagFiltreDegisim");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AracBakimAnasayfa aba = new AracBakimAnasayfa();
            aba.degerAta(ad, sifre);
            aba.Show();
            this.Hide();

           
        }
    }

}
       



    

