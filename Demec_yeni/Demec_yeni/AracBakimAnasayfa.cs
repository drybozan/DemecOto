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
    public partial class AracBakimAnasayfa : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog = DemeçOto; Integrated Security = True");
        public AracBakimAnasayfa()
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
        private void AracBakimAnasayfa_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            con.Open();

            SqlCommand query = new SqlCommand("Select m.tc,bakimBaslangic,bakimBitis,yagBakimId,sasiId,yagFiltreId,havaFiltreId," +
                "sanzimanYagId,sogutmaSistemId,balansId,lastikRotId,lastikId,frenId,antifirizId,toplammaliyet " +
                "from AracBakim a join musteriler m on a.musteriId=m.musteriId ", con);
            SqlDataReader sdr = query.ExecuteReader();

            listView1.View = View.Details;
            listView1.Columns.Add("Müşteri TC", 100);
            listView1.Columns.Add("Bakım Başlangıç Tarih", 120);
            listView1.Columns.Add("Bakım Bitiş Tarih", 120);
            listView1.Columns.Add("Yağ Bakım", 80);
            listView1.Columns.Add("Sasi Bakım", 80);
            listView1.Columns.Add("Yağ Filtre Değişim", 100);
            listView1.Columns.Add("HavaFiltre Değişim", 100);
            listView1.Columns.Add("Sanziman Yağ Değişim", 120);
            listView1.Columns.Add("Soğutma Değişim", 100);
            listView1.Columns.Add("Balans Ayar", 80);
            listView1.Columns.Add("Lastik Rot Ayar", 100);
            listView1.Columns.Add("Lastik Değişim", 100);
            listView1.Columns.Add("Fren Ayar", 80);
            listView1.Columns.Add("Antifiriz Ekleme", 100);
            listView1.Columns.Add("Toplam Maliyet", 120);
           


            while (sdr.Read())
            {
                var satir = new ListViewItem();
                satir.Text = sdr["tc"].ToString();
                satir.SubItems.Add(sdr["bakimBaslangic"].ToString());
                satir.SubItems.Add(sdr["bakimBitis"].ToString());
                satir.SubItems.Add(sdr["yagBakimId"].ToString());
                satir.SubItems.Add(sdr["sasiId"].ToString());
                satir.SubItems.Add(sdr["yagFiltreId"].ToString());
                satir.SubItems.Add(sdr["havaFiltreId"].ToString());
                satir.SubItems.Add(sdr["sanzimanYagId"].ToString());
                satir.SubItems.Add(sdr["sogutmaSistemId"].ToString());
                satir.SubItems.Add(sdr["balansId"].ToString());
                satir.SubItems.Add(sdr["lastikRotId"].ToString());
                satir.SubItems.Add(sdr["lastikId"].ToString());
                satir.SubItems.Add(sdr["frenId"].ToString());
                satir.SubItems.Add(sdr["antifirizId"].ToString());
                satir.SubItems.Add(sdr["toplammaliyet"].ToString());
                listView1.Items.Add(satir);

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();            
            anasayfa.Show();
            this.Hide();
            anasayfa.girisKontrol(ad, sifre);
            anasayfa.degerata(ad, sifre);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AracBakimIslemler aracBakimIslemler = new AracBakimIslemler();
            aracBakimIslemler.Adal(ad);
            aracBakimIslemler.Sifreal(sifre);
            aracBakimIslemler.Show();
            this.Hide();

        }

        public void degerAta(string a, string b){
            ad = a;
            sifre = b;
             }
    }
}
