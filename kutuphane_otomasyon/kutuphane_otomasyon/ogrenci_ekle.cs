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
    public partial class ogrenci_ekle : Form
    {
        //veritanına baglanmak için bgl nesnemizi oledbconnection sınıfından üretiyoruz data source ve application konumunu ekliyorum
        
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");

        public ogrenci_ekle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buton2 tıklandıgında insert komutu ile ogrenci tableındaki  bilgilere tcno.adı vs  textboxlara girilen dataları aktarıyoruz.
            //islem basarılı mesajı verip baglantıyı kapatıyoruz.
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("insert into ogrenci (tcno,adi,soyadi,telefon,adres) values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')",bgl);
            cmd.ExecuteNonQuery();
            MessageBox.Show("kayıt işlemi başarılı");
            bgl.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //buton1 tıklandıgında textboxlara girilen verileri temizliyoruz.
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
    }
}
