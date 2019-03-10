using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barkod
{
    public partial class Form1 : Form
    {
        Form panel = new panel();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciadi, sifre;
            kullaniciadi = txtkullaniciadi.Text.ToLower();
            sifre = txtsifre.Text.ToLower();
            if (kullaniciadi == "admin" && sifre == "admin")
            {  
                panel.Show();
                this.Hide();
                

            }
            else
                MessageBox.Show("GİRİŞ HATALI");
        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {
            string kullaniciadi, sifre;
            kullaniciadi = txtkullaniciadi.Text.ToLower();
            sifre = txtsifre.Text.ToLower();
            if (kullaniciadi == "admin" && sifre == "admin")
            {
                panel.Show();
                this.Hide();


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtkullaniciadi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
