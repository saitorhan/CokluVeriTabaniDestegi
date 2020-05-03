using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CokluDbDestegi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxDb.SelectedIndex = 0;
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            IKisi iKisi = null;

            if (comboBoxDb.SelectedIndex == 0)
            {
                iKisi = new MsSqlKisiIslemleri();
            }

            else if(comboBoxDb.SelectedIndex == 1)
            {
                iKisi = new MySqlKisiIslemleri();
            }

            Kisi kisi = new Kisi
            {
                Isim = textBoxAd.Text,
                Soyisim = textBoxSoyad.Text,
                Telefon = textBoxTelefon.Text
            };

            int kisiEkle = iKisi.KisiEkle(kisi);
            MessageBox.Show(kisiEkle.ToString());
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            IKisi iKisi = null;

            if (comboBoxDb.SelectedIndex == 0)
            {
                iKisi = new MsSqlKisiIslemleri();
            }

            else if (comboBoxDb.SelectedIndex == 1)
            {
                iKisi = new MySqlKisiIslemleri();
            }

            kisiBindingSource.DataSource = iKisi.KisileriGetir();
        }
    }
}
