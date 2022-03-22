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
    public partial class ogrenci_guncelle : Form
    {
        //veritanına baglanmak için bgl nesnemizi oledbconnection sınıfından üretiyoruz data source ve application konumunu ekliyorum

        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");

        public ogrenci_guncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*buton1 tıklandıgında ogrenci tableındaki verilerin update  komutu ile textboxlara girilen veriler ile set ediliyor ve guncelleniyor*/
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("update ogrenci set tcno='" + textBox1.Text + "',adi='" + textBox2.Text + "',soyadi='" + textBox3.Text + "',telefon='" + textBox4.Text + "',adres='" + textBox5.Text + "' where tcno='"+textBox1.Text+"'", bgl);
            cmd.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            MessageBox.Show("güncelleme işlemi başarılı");
            bgl.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*ogrenci tableındaki ogrencileri bulmada textbox1 e girilen tc no tabledaki tcno ile kıyaslanıp bulunan kişisini
             adı,soyadı,tel ve adres bilgilerinin tectboxlarda görünmesi saglanıyor.*/
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("select * from ogrenci where tcno LIKE'" + textBox1.Text.ToString() + "'", bgl);
            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                textBox2.Text = dr["adi"].ToString();
                textBox3.Text = dr["soyadi"].ToString();
                textBox4.Text = dr["telefon"].ToString();
                textBox5.Text = dr["adres"].ToString();

            }
            bgl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buton2 tıklandıgında textboxlara girilen veriler temizleniyor.
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
    }
}
