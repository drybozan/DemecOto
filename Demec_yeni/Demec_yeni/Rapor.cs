using Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Globalization;


namespace Demec_yeni
{
    public partial class Rapor : Form
    {
        public string dosyayolu;

        SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog =DemeçOto; Integrated Security = True");
        public Rapor()
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
        private void Rapor_Load(object sender, EventArgs e)
        {
            //comboxa markaları sıralar
            con.Open();

            string query = "Select * from arac";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                comboBox1.Items.Add(sdr["marka"].ToString());
            }
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //markaları listeler
            con.Open();

            dataGridView1.Refresh();
            SqlDataAdapter da1 = new SqlDataAdapter("exec sp_markayaGoreAracGetir '" + comboBox1.SelectedItem + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();


        }

        private void yedekle_Click(object sender, EventArgs e)
        {
            //VT YEDEKLE
            if (textBox1.Text.Count() > 0)
            {
                con.Open();
                String komut = "BACKUP DATABASE[DemeçOto] TO DISK = N'" + textBox1.Text + "' WITH NOFORMAT, NOINIT, NAME = N'calisma-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                SqlCommand sorgu = new SqlCommand(komut, con);
                sorgu.ExecuteNonQuery();
                MessageBox.Show("Yedekleme Başarılı", "Yedekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();


            }
        }

        private void sec_Click(object sender, EventArgs e)
        {
            //dosya yolu

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Yedek Dosyası | *.bak";
            fileDialog.CheckFileExists = false;
            fileDialog.Title = "Yedek dosyası seçiniz";
            fileDialog.FileName = "yedek.bak";
            fileDialog.ShowDialog();
            if (fileDialog.FileName != "yedek.bak")
            {
                textBox1.Text = fileDialog.FileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //yedekten dön
            if (textBox1.Text.Count() > 0)
            {
                con.Open();
                String komut = "USE [master] ALTER DATABASE[DemeçOto] SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                               "RESTORE DATABASE[DemeçOto] FROM DISK = N'" + textBox1.Text + "' WITH FILE = 1, REPLACE, STATS = 5 " +
                               "ALTER DATABASE[DemeçOto] SET MULTI_USER";
                SqlCommand sorgu = new SqlCommand(komut, con);
                sorgu.ExecuteNonQuery();
                MessageBox.Show("Geri Yükleme Başarılı", "Geri Yükleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        { //TARİHE GÖRE ARAÇ SATIŞLARINI GETİR          

            con.Open();

            dataGridView1.Refresh();
            SqlDataAdapter da1 = new SqlDataAdapter("exec sp_tariheGoreSatisGetir '" + textBox2.Text + "','" + textBox3.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();





        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            //datagrid içindeki verileri excele yazar

            ExcelPackage package = new ExcelPackage();
            package.Workbook.Worksheets.Add("sayfa1");

            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();


            var columns = dataGridView1.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = columns[i].HeaderText;

            }
            int rowIndex = 2;
            var rows = dataGridView1.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Cells[0] != null)
                {
                    for (int j = 0; j < rows[i].Cells.Count; j++)
                    {

                        worksheet.Cells[rowIndex, j + 1].Value = rows[i].Cells[j].Value;

                    }
                    rowIndex++;

                }
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası | *.xlsx";
            saveFileDialog.ShowDialog();

            Stream stream = saveFileDialog.OpenFile();
            package.SaveAs(stream);
            stream.Close();
            MessageBox.Show("Excel dosyanız başarıyla kaydedildi.");


        }


        private void button4_Click(object sender, EventArgs e)
        {
            ////excelden veri okur
            ExcelYoluSec();

            dataGridView1.DataSource = ExcelOku();
        }
        private static string ExcelYol = "";
        public static string ExcelYoluSec()
        {
            string Platform = "";
            OpenFileDialog ac = new OpenFileDialog();

            if (Environment.Is64BitProcess)
            { ac.Filter = "Excel dosyaları(*.xlsx)|*.xlsx"; Platform = "x64. Sadece XLSX Dosyaları"; }
            else
            { ac.Filter = "Excel dosyaları(*.xls)|*.xls"; Platform = "x86. Sadece XLS Dosyaları"; }

            ac.Title = "Platform " + Platform;
            ac.ShowDialog();
            ExcelYol = ac.FileName.ToString();
            return ExcelYol;
        }
        public static DataTable ExcelOku()
        {
            DataTable dtexcel = new DataTable();

            if (ExcelYol.Trim().Length > 0)
            {
                DataTable schemaTable = new DataTable();
                string strConn = "";


                if (Environment.Is64BitProcess)
                    strConn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + ExcelYol + "; Extended Properties = \"Excel 12.0; HDR = Yes; IMEX = 0\"";
                else
                    strConn = "Provider = Microsoft.Jet.OLEDB.4.0;  Data Source=" + ExcelYol + "; Extended Properties = \"Excel 8.0; HDR = Yes; IMEX = 0\"";


                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT  * FROM [" + sheet + "]";
                    OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                    dtexcel.Locale = CultureInfo.CurrentCulture;
                    daexcel.Fill(dtexcel);

                }
                conn.Close();

            }
            else
            {
                MessageBox.Show("Okunacak EXCEL dosyası bulunamadı. Lütfen önce okunacak EXCEL dosyası seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return dtexcel;
        }



        private void button1_Click(object sender, EventArgs e)
        {//GERİ DÖN BUTONU
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
            anasayfa.girisKontrol(ad, sifre);
            anasayfa.degerata(ad, sifre);
        }


        private void exceleKaydet_Click(object sender, EventArgs e)
        {
            //SQLDEN EXPORT EDER
            con.Open();

            dataGridView1.Refresh();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from calisanlar", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();

            button2_Click_1(e, e);

            MessageBox.Show("Datanız başarıyla aktarıldı.");
        }

        private void button3_Click(object sender, EventArgs e)
        { //SQL'E IMPORT EDER

            button4_Click(e, e);

            
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source = DESKTOP-9RM4DG7\\SQLEXPRESS; Initial Catalog = DemeçOto; Integrated Security = True")
)
                {

                    con.Open();

                    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                    {

                        string ad = dataGridView1.Rows[i].Cells["ad"].Value.ToString();
                        string soyad = dataGridView1.Rows[i].Cells["soyad"].Value.ToString();
                        string tel = dataGridView1.Rows[i].Cells["tel"].Value.ToString();
                        string calisantc = dataGridView1.Rows[i].Cells["calisantc"].Value.ToString();
                        string email = dataGridView1.Rows[i].Cells["email"].Value.ToString();
                        string gorev = dataGridView1.Rows[i].Cells["gorev"].Value.ToString();


                        string query = @"INSERT INTO calisanlar values ('" + ad + "','" + soyad + "','" + tel + "','" + calisantc + "','" + email + "','" + gorev + "')";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.ExecuteNonQuery();


                    }
                    

            }
            }
            finally { }

            con.Close();

            MessageBox.Show("Datanız başarıyla veritabanına aktarıldı.");
        }
    }
}
