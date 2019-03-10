using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace barkod
{
    public partial class urunekle : Form
    {
        public urunekle()
        {
            InitializeComponent();
        }
        private void urunekle_Load(object sender, EventArgs e)
        { /*
            DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
            string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
            SqlConnection baglanti = new SqlConnection(baglanticumlesi);
            SqlCommand komut = new SqlCommand("Select * from urun", baglanti);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();


            reader = komut.ExecuteReader();
            while (reader.Read())
            {

                row.Cells[0].Value = reader[0];
                row.Cells[1].Value = reader[1];
                dataGridView2.Rows.Add(row); 
            }
           */
            string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
            SqlConnection baglanti = new SqlConnection(baglanticumlesi);
            string com = "select * from urun";
            SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int barkod = Convert.ToInt32(textBox1.Text);
                string adi = textBox2.Text;
                Double birimfiyat = Convert.ToDouble(textBox3.Text);
                int Stok = Convert.ToInt32(textBox4.Text);
                string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
                SqlConnection baglanti = new SqlConnection(baglanticumlesi);
                SqlCommand komut = new SqlCommand("INSERT INTO urun (barkod, adi, birimfiyat, stok) VALUES ('" + barkod + "','" + adi + "'," + birimfiyat + "," + Stok + ")", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
           

                komut.ExecuteNonQuery();
                string com = "select * from urun";
                SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;

                MessageBox.Show("ÜRÜN BAŞARIYLA EKLENDİ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";


            }
            catch
            {
                MessageBox.Show("bu barkod numarası zaten mevcut");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isimara =(textBox6.Text);
            int bkodu=0;
            if (textBox5.Text != "")
            {
                 bkodu = Convert.ToInt32(textBox5.Text);
            }
            string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
            SqlConnection baglanti = new SqlConnection(baglanticumlesi);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string com = "";
            if((bkodu==0) && (isimara==""))
                {
                 com = "select * from urun";
            }
            else{
                 com = "select * from urun where adi='" + isimara + "' or barkod= " + bkodu + "";
            }
            SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string isimara = (textBox6.Text);
                int bkodu = 0;
                if (textBox5.Text != "")
                {
                    bkodu = Convert.ToInt32(textBox5.Text);
                }
                string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
                SqlConnection baglanti = new SqlConnection(baglanticumlesi);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string com = "";
                if ((bkodu == 0) && (isimara == ""))
                {
                    com = "select * from urun";
                }
                else
                {
                    com = "select * from urun where adi = '" + isimara + "' or barkod like '" + bkodu + "%'";
                }
                SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Yanlış veya eksik bir değer girdiniz.".ToUpper());
            }


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            string isimara = (textBox6.Text);
            int bkodu = 0;
            if (textBox5.Text != "")
            {
                bkodu = Convert.ToInt32(textBox5.Text);
            }
            string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
            SqlConnection baglanti = new SqlConnection(baglanticumlesi);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string com = "";
            if ((bkodu == 0) && (isimara == ""))
            {
                com = "select * from urun";
            }
            else
            {
                com = "select * from urun where adi like '%" + isimara + "%' or barkod like '" + bkodu + "%'";
            }
            SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                int a = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                dataGridView2.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
                
                string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
                SqlConnection baglanti = new SqlConnection(baglanticumlesi);
                SqlCommand komut = new SqlCommand("delete from urun where barkod=" + a + "", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                komut.ExecuteNonQuery();

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                int barkod = Convert.ToInt32(textBox1.Text);
                string adi = textBox2.Text;
                Double birimfiyat = Convert.ToDouble(textBox3.Text);
                int Stok = Convert.ToInt32(textBox4.Text);
                string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
                SqlConnection baglanti = new SqlConnection(baglanticumlesi);
                SqlCommand komut = new SqlCommand("Update urun Set adi='" + adi + "', birimfiyat=" + birimfiyat + ", stok=" + Stok + " where barkod=" + barkod + "", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();


                komut.ExecuteNonQuery();
                string com = "select * from urun";
                SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text ="";
            textBox4.Text = "";
            button4.Enabled = false;
            button6.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = true;
            button6.BackColor = Color.Gainsboro;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
        }
        static SqlDataReader reader;
        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button4.Enabled = true;
            button6.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = false;
            button6.BackColor = Color.Red;

            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                int id  = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                 

                string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
                SqlConnection baglanti = new SqlConnection(baglanticumlesi);
                SqlCommand komut = new SqlCommand("Select * from urun where barkod=" + id + "", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();


                reader = komut.ExecuteReader();
                while (reader.Read())
                {

                   textBox1.Text  = reader[0].ToString();
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                    textBox4.Text = reader[3].ToString();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form pp = new panel();

            pp.Show();
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button4.Enabled = false;
            button6.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = true;
            button6.BackColor = Color.Gainsboro;
        }
    }
}
