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
    public partial class kitapsil : Form
    {
        //veritanına baglanmak için bgl nesnemizi oledbconnection sınıfından üretiyoruz data source ve application 

        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphaneotomasyon.accdb");

        public kitapsil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*buton1 e  tıklandıgında  baglantımızı aktif edip barkodnosu girilen kitaba ait dataların silinmesini saglıyoruz
             ardından silme işlemi basarılı mesajını verip baglantıyı sonlandırıp 
            textboxımızı temizliyoruz.*/

            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("delete from kitap where barkodno='" + textBox1.Text + "'", bgl);
            cmd.ExecuteNonQuery();
            MessageBox.Show("silme işlemi başarılı");
            bgl.Close();
            textBox1.Clear();
        }
    }
}
