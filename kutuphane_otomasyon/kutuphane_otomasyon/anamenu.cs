using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kutuphane_otomasyon
{
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }
        //her form sayfası için birer nesne olusturup show metodu ile formların görünmesini sağladım.
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form oe = new ogrenci_ekle();
            oe.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        { //ogr sil formundan os nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form os = new ogrenci_sil();
            os.Show();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        { //ogr guncelle formundan guncelle nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form guncelle = new ogrenci_guncelle();
            guncelle.Show();
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        { //ogrenci listeke formundan listele nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form listele = new ogrenci_listele();
            listele.Show();
        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        { //kitapekle formundan ke nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form ke = new kitapekle();
            ke.Show();
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        { //kitapsil formundan ks nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form ks = new kitapsil();
            ks.Show();
        }

        private void güncelleToolStripMenuItem1_Click(object sender, EventArgs e)
        { //kitapguncelle formundan ktpguncelle nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form ktpguncelle = new kitapguncelle();
            ktpguncelle.Show();
        }

        private void listeleToolStripMenuItem1_Click(object sender, EventArgs e)
        { //kitaplistele formundan li nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form li = new kitaplistele();
            li.Show();
        }

        private void geçKalanKitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        { //kitapver formundan ktpver nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form ktpver = new kitapver();
            ktpver.Show();
        }

        private void geçKalanKitaplarToolStripMenuItem1_Click(object sender, EventArgs e)
        { //geckalankitaplar formundan gecknktp nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form gecknktp = new geckalankitaplar();
            gecknktp.Show();
        }

        private void cezaSistemiToolStripMenuItem_Click(object sender, EventArgs e)
        {   //ceza sistemi formundan cz nesnesi olusturup show metodu ile gösterilmesini saglıyorum.
            Form cz = new cezasistemi();
            cz.Show();
        }
    }
}
