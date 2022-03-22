using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace kutuphane_otomasyon
{
    public partial class kitapguncelle : Form
    {     //veritanına baglanmak için bgl nesnemizi oledbconnection sınıfından üretiyoruz data source ve application 
        //konumunu ekliyorum
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");

        public kitapguncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*buton1 tıklandıgında baglantımızı aktif ediyoruz ve oledbcommand sınıfından cmd nesnemizi olusturuyoruz.
             update komutumuz ile kitap tablosundaki barkodno,kitapadi gibi degerlerimize textboxlarda girilen degerleri set ediyoruz
            ardından update işlemi basarılı mesajı verip baglantımızı kapatıyoruz.*/
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("update kitap set barkodno='" + textBox1.Text + "',kitapadi='" + textBox2.Text + "',yazari='" + textBox3.Text + "',sayfasayisi='" + textBox4.Text + "',rafno='" + textBox5.Text + "' where barkodno='" + textBox1.Text + "'", bgl);
            cmd.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            MessageBox.Show("güncelleme işlemi başarılı");
            bgl.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*textbox1 imize yani barkod no yazılacak kısma girilen deger kitap tablomuzdaki barkodno lar ile kıyaslanıp 
             o kitaba özel diger dataları getiriyoruz böylece kolaylık ve bilgi karmaşasından kurtuluyoruz.*/
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kitap where barkodno LIKE'" + textBox1.Text.ToString() + "'", bgl);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr["kitapadi"].ToString();
                textBox3.Text = dr["yazari"].ToString();
                textBox4.Text = dr["sayfasayisi"].ToString();
                textBox5.Text = dr["rafno"].ToString();

            }
            bgl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //güncellenecek yeni bir kitap var ise buton ikiye tıklandıgında textboxların temizlenmesini saglıyoruz.
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
