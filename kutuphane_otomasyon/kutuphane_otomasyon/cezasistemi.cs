using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kutuphane_otomasyon
{
    public partial class cezasistemi : Form
    {       //bağlantı kurup datasource ile dosyanın konumunu yazıp baglantı kurdum.
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");

        public cezasistemi()
        {
            InitializeComponent();
        }

        private void cezasistemi_Load(object sender, EventArgs e)
        {
            /*string türünde tarih degeri olusturdum. ve  şuanki zamanı (kısa tarih yani saat vs. gözükmeden) atadım.
             baglantıyı actım oledbdataAdapter sınıfından nesne olusturdum ve veritabanından kitaver tablosundan teslim tarihi 
            tarih degerinden küçük olanları çekmesini sağladım.
            datatable sınıfından tablo nesnesi olsuturup. bu verilerin tabloda gösterilmesini sağladım
            datagriedviewcellstyle sınıfından style nesnesi olsuturdum.
            for dongusu ile satır ve sutunların yani satırların i. ve sutunların 11. indexindeki cell in kırmızı renkte olmasını sagladım
            bu hücre geciken kitapların son tarih degerinin bulundugu hücre.*/
            string tarih = DateTime.Now.ToShortDateString();
            bgl.Open();
            OleDbDataAdapter cmd = new OleDbDataAdapter("select * from kitapver where teslimtarihi <'" + tarih + "'", bgl);
            DataTable tablo = new DataTable();
            cmd.Fill(tablo);
            dataGridView1.DataSource = tablo;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            bgl.Close();
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                for (int j = 0; j < tablo.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        
        {/*btarih ve ktarih diye iki tane datetime türünde deger olusturdum ve datetimepicker lara girilen tarih degerlerini
          datetime türüne cevrdim tarihleri birbiriden cıkartıp sadece gün degerininin labbel4 de gözükmesini sagladım.*/

            DateTime bTarih = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime kTarih = Convert.ToDateTime(dateTimePicker2.Text);
            TimeSpan Sonuc = kTarih - bTarih;
            label4.Text = Sonuc.TotalDays.ToString();
        }
    }
}
