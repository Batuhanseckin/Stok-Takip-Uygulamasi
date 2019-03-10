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

    public partial class panel : Form
    {
        Form satisekrani = new satisekrani();
        Form urunekle = new urunekle();
        public panel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            satisekrani.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            urunekle.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            satisekrani.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string time = now.ToString("T");
            MessageBox.Show(time);
            DateTime theDate = DateTime.UtcNow;

            string custom = theDate.ToString("d");

            MessageBox.Show(custom);
            

        }
    }
}
