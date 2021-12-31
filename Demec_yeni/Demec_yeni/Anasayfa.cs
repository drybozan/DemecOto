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
    public partial class Anasayfa : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog = DemeçOto; Integrated Security = True");

        public Anasayfa()
        {
            InitializeComponent();
        }

        public string ad;
        public string sifre;
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            musteriIslembtn.Hide();
            aracbakimbtn.Hide();
            calisanbtn.Hide();
            aracislembtn.Hide();
            kullanicibtn.Hide();
            raporbtn.Hide();          


        }
        public void button5_Click(object sender, EventArgs e)
        {
            musteriIslemleri musteriIslemleri = new musteriIslemleri();           
            
            ad = kullaniciadtxt.Text;
            sifre = sifretxt.Text;
            musteriIslemleri.Adal(ad);
            musteriIslemleri.Sifreal(sifre);
            musteriIslemleri.Show();
            this.Hide();
        }

        AracIslemler aracislemler = new AracIslemler();
        private void aracislembtn_Click(object sender, EventArgs e)
        {
            ad = kullaniciadtxt.Text;
            sifre = sifretxt.Text;
            aracislemler.Adal(ad);
            aracislemler.Sifreal(sifre);
            aracislemler.Show();
            this.Hide();

        }

        private void calisanbtn_Click(object sender, EventArgs e)
        {
            CalisanIslemler calisanislemler = new CalisanIslemler();
            ad = kullaniciadtxt.Text;
            sifre = sifretxt.Text;
            calisanislemler.Adal(ad);
            calisanislemler.Sifreal(sifre);
            calisanislemler.Show();
            this.Hide();
        }

     

        private void aracbakimbtn_Click(object sender, EventArgs e)
        {
            AracBakimAnasayfa aracBakimAnasayfa = new AracBakimAnasayfa();
            ad = kullaniciadtxt.Text;
            sifre = sifretxt.Text;
            aracBakimAnasayfa.Adal(ad);
            aracBakimAnasayfa.Sifreal(sifre);          
            aracBakimAnasayfa.Show();
            this.Hide();

        }

        private void kullanicibtn_Click(object sender, EventArgs e)
        {
            Kullanıcılar kullanıcılar = new Kullanıcılar();
            ad = kullaniciadtxt.Text;
            sifre = sifretxt.Text;
            kullanıcılar.Adal(ad);
            kullanıcılar.Sifreal(sifre);          
            kullanıcılar.Show();
            this.Hide();
        }

        private void raporbtn_Click(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            ad = kullaniciadtxt.Text;
            sifre = sifretxt.Text;
            rapor.Adal(ad);
            rapor.Sifreal(sifre);
            rapor.Show();
            this.Hide();
        }
      
            
        public void girisKontrol(string a,string b) {

       
            con.Open();
            SqlCommand query = new SqlCommand("Select * from Kullanıcılar where kullanıcıAd='" + a + "' and sifre='" + b + "'", con);
            SqlDataReader sdr = query.ExecuteReader();

            if (sdr.Read())
            {
                if (Convert.ToChar(sdr["yetki"]) == '1')
                {
                    musteriIslembtn.Show();
                    aracbakimbtn.Show();
                    calisanbtn.Show();
                    aracislembtn.Show();
                    kullanicibtn.Show();
                    raporbtn.Show();
                    

                }

                else if (Convert.ToChar(sdr["yetki"]) == '2')
                {
                    musteriIslembtn.Show();
                    aracbakimbtn.Show();
                    calisanbtn.Show();                 

                }
                else
                {
                    MessageBox.Show("kullanıcı ad veya şifre yanlış..");
                }
            }


            con.Close();
        }
     
        
        

        public void degerata(string a, string s)
        {
            kullaniciadtxt.Text = a;
            sifretxt.Text = s;
        }

        private void cikisbutton_Click_1(object sender, EventArgs e)
        {
            musteriIslembtn.Hide();
            aracbakimbtn.Hide();
            calisanbtn.Hide();
            aracislembtn.Hide();
            kullanicibtn.Hide();
            raporbtn.Hide();

            kullaniciadtxt.Clear();
            sifretxt.Clear();
        }

        private void girisbutton_Click_1(object sender, EventArgs e)
        {
            ad = kullaniciadtxt.Text;
            sifre = sifretxt.Text;
            girisKontrol(ad, sifre);
        }
    }
}
