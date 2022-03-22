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
    public partial class kitapver : Form
    {
        //veritanına baglanmak için bgl nesnemizi oledbconnection sınıfından üretiyoruz data source ve application 
        //konumunu ekliyorum.ve datatable sınıfından bir tablo ve tablo1 nesnesi olusturuyoruz.
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");
        DataTable tablo = new DataTable();
        DataTable tablo1 = new DataTable();

        public kitapver()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*baglantımızı açıp oledbcommand sınıfından cmd nesnesi olsturuyoruz. textbox1 e girilen tcno degerini ogrenci table ındaki veriler
             ile kıyaslayıp select komutu ile ona ait diger adi,soyadı,telefon ve adres gibi datalarında getirilmesini sağlıyoruz.
            */
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("select * from ogrenci where tcno LIKE'" + textBox1.Text.ToString() + "'", bgl);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr["adi"].ToString();
                textBox3.Text = dr["soyadi"].ToString();
                textBox4.Text = dr["telefon"].ToString();
                textBox5.Text = dr["adres"].ToString();

            }
            bgl.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            /*yukarıdaki işemin aynısını kitap içinde yapıyoruz textbox10 a girilen barkod no degerini kitap tableında ki barkodno degerleriyle
             kıyaslayıp o barkod numarasına ait kitabın datalarını ilgili textboxlara cekilmesini select komutu aracılıgıyla sağlıyoruz.*/
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kitap where barkodno LIKE'" + textBox10.Text.ToString() + "'", bgl);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox9.Text = dr["kitapadi"].ToString();
                textBox8.Text = dr["yazari"].ToString();
                textBox7.Text = dr["sayfasayisi"].ToString();
                textBox6.Text = dr["rafno"].ToString();

            }
            bgl.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*buton1 e tıklandıgında baglantımmızı aktif edip oledbcommand dan cmd nesnesi olsuturup 
             insert komutu ile textbxlarımıza girilen dataları kitapver table ımıza aktarıyoruz.
            ve select komutu ile kitap tableındaki datalrın datagriedviewde görünmesini saglıyoruz.
            ardından kayıt işlemi basarılı mesajını verip baglantımızı kapatıyoruz.*/
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("insert into kitapver (tcno,adi,soyadi,telefon,adres,barkodno,kitapadi,yazar,sayfasayisi,rafno,verilistarihi,teslimtarihi) values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox10.Text+"','"+textBox9.Text+"','"+textBox8.Text+"','"+textBox7.Text+"','"+textBox6.Text+"','"+dateTimePicker1.Text+"','"+dateTimePicker2.Text+"')",bgl);
            cmd.ExecuteNonQuery();
            tablo.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from kitap ", bgl);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            MessageBox.Show("kayıt verim işlemi başarıyla tamamlandı.");
            bgl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();//buton2 ye tıklandıgında textboxlarımıza girilen verilerin temizlenmesini saglıyoruz.
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
           
        }

        private void kitapver_Load(object sender, EventArgs e)
        {
            /*kitap ver load sayfamızda baglantımızı acıp tablomuzu temileyip select komutu ile kitap tableımızda ki verileri cekiyoruz.
             ve datagriedviewde görünmesini saglıyoruz.
            ardından baglantımızı kapatıyoruz bu sayfada kişiler fonksiyonumuzuda çalısmasını saglıyoruz.
            hem ogrenileri hemde kitapları 2 farklı datagriedviewde göstermem işlem kolaylıgı ve veriyi bulmada kolaylık saglasın diye yaptım.*/
            bgl.Open();
            tablo.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from kitap ", bgl);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bgl.Close();

            kisiler();
        }
        public void kisiler()
        {
            /*kisiler fonksiyonmuz yenibiri datagriedview de tüm ogrencilerimizi ve tüm datalarının görünmesini saglıyoruz.*/
            bgl.Open();
            tablo1.Clear();
            OleDbDataAdapter db = new OleDbDataAdapter("select * from ogrenci ", bgl);
            db.Fill(tablo1);
            dataGridView2.DataSource = tablo1;
            bgl.Close();
        }
    }
}
