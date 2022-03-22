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
    public partial class kitaplistele : Form
    { //veritanına baglanmak için bgl nesnemizi oledbconnection sınıfından üretiyoruz data source ve application 
        //konumunu ekliyorum.ve datatable sınıfından bir tablo nesnesi olusturuyoruz.
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");
        DataTable tablo = new DataTable();
        public kitaplistele()
        {
            InitializeComponent();
        }

        private void kitaplistele_Load(object sender, EventArgs e)
        {
            /* baglantımızı aktif edip kitap tablemızdan select komutu ile tüm kitap verilerini datagriedview de görünmesini saglıyoruz.*/
            bgl.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from kitap ", bgl);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bgl.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {    /*fazla data oldugunu varsayarsak görüntülemek istedigimiz kişiyi bulmakta kolaylık sağlamak için 
              textboxımıza girilen kitap adi bilgisini kıyaslanıyor ve sadece o datanın getirilmesi sağlanıyor.
              bu işlemi try catch bloguna alıyorum olası hata durumunda hata kaynak kodu nu mesaj olarak alıyoruz*/
            try
            {
                bgl.Open();
                OleDbCommand cmd = new OleDbCommand("select * from kitap where kitapadi like('%" + textBox1.Text + "%') ", bgl);
                cmd.ExecuteNonQuery();
                DataTable tablo1 = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                bgl.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bgl.Close();
        }
    }
}
