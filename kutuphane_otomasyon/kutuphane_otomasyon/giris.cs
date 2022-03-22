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
    public partial class giris : Form
    {  //datasource ve application konumunu belirtip veritabanımıza baglantı sağladım.
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+"\\kutuphaneotomasyon.accdb");
        
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*buton1 tıklandıgında textboxlarımız boş ise lütfen bilgilerinizi giriniz mesajı verdik
             kullanıcı adı degerimiz bos işe kullanıcı adınıızı girin mesajı
            ve yalnız sifre kısmı boş ise sifre uyarıcı mesajı verdim
            her ikisi girili ise veritabı ile baglantı saglıyoruz ve kullanıcı adı,şifre degerilerine ulasıp 
            mukayese ediyoruz degerler eşleşmez ise kullanıcı adı veya şifre yanlış mesajı 
            eşleşirse hosgeldin + adı,soyadı mesajı veriyorum.sonrada sayfayı anamenü sayfasına yönlendiriyorum.*/
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("lütfen bilgilerinizi giriniz.");
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("kullanıcı adınızı boş bırakmayınız.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("sifre alanını boş bırakmayınız.");
            }
            else
            {
                bgl.Open();
                OleDbCommand cmd = new OleDbCommand("select * from kullanıcıgirisi where kullaniciadi='" + textBox1.Text.ToString() + "'", bgl);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    if (textBox1.Text.ToString() == dr["kullaniciadi"].ToString() && textBox2.Text.ToString() == dr["sifre"].ToString())
                    {
                        MessageBox.Show("hosgeldin " + dr["adı"].ToString() + " " + dr["soyadı"].ToString());
                        Form anamenu = new anamenu();
                        anamenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("kullanıcı adı veya şifre yanlış");
                    }
                }
                else
                {
                    MessageBox.Show("kullanıcı adı veya şifre yanlış");
                }
                bgl.Close();
             }
            }


        }
    }

