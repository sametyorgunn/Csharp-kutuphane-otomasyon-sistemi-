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
    public partial class kitapekle : Form
    {   //veritanına baglanmak için bgl nesnemizi oledbconnection sınıfından üretiyoruz data source ve application 
        //konumunu ekliyorum.
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");

        public kitapekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*buton1 tıklandıgında baglantımızı aktif edip oledbcommand sınıdfından cmd nesnemizi olusuturoruz.ve 
             insert into komutuyla veritatabanımızın kitap tablosuna barkodno,kitapadi,yazari vs. degerlerine
            textboxlarda girdigimiz verileri aktarıyoruz.
            ardından kayıt işlemi basarılı mesajımızı verip baglantıyı kapatıyoruz.*/
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("insert into kitap(barkodno,kitapadi,yazari,sayfasayisi,rafno)values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')",bgl);
            cmd.ExecuteNonQuery();
            MessageBox.Show("kitap başarıyla kaydedildi");
            bgl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buton2 tıklandıgında textboxlara girilen verileri temizliyoruz.
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
