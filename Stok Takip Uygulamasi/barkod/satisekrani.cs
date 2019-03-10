using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace barkod
{
    public partial class satisekrani : Form
    {


        public satisekrani()
        {
            InitializeComponent();
        }

        private void satisekrani_Load(object sender, EventArgs e)
        {
            this.Focus();

        }

        private void toplampara_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sepet1.BackColor = Color.Gainsboro;
            sepet2.BackColor = Color.Gainsboro;
            sepet3.BackColor = Color.Green;
            sepet4.BackColor = Color.Gainsboro;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 5);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 10);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 20);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 0.25);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 0.50);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 50);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 100);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtalinan.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) + 200);

        }
        static SqlDataReader reader;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();

            if (textBox3.Text != "")
            {
                int brkd = Convert.ToInt32(textBox3.Text);

                string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";
                SqlConnection baglanti = new SqlConnection(baglanticumlesi);
                SqlCommand komut = new SqlCommand("Select * from urun where barkod=" + brkd + "", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();


                reader = komut.ExecuteReader();
                while (reader.Read())
                {

                    row.Cells[0].Value = reader[0];
                    row.Cells[1].Value = reader[1];
                    row.Cells[2].Value = reader[2];
                    row.Cells[3].Value = txtadet.Text;
                    int temp = Convert.ToInt32(reader[2]) * Convert.ToInt32(txtadet.Text);
                    row.Cells[4].Value = temp;
                    toplampara.Text = Convert.ToString(Convert.ToDouble(toplampara.Text) + temp);
                    dataGridView1.Rows.Add(row);
                    textBox3.Text = (""); txtadet.Text = ("1"); break;
                }
                /*for (int i = 0; i < parcaadi.Length; i++)
                {
                    if (kod[i] == Convert.ToInt32(textBox3.Text))
                    {
                        row.Cells[0].Value = kod[i]; 
                        row.Cells[1].Value = parcaadi[i];
                        row.Cells[2].Value = fiyat[i];
                        row.Cells[3].Value = txtadet.Text;
                        int temp = fiyat[i] * Convert.ToInt32(txtadet.Text);
                        row.Cells[4].Value = temp;
                        toplampara.Text = Convert.ToString(Convert.ToDouble(toplampara.Text) + temp);
                        dataGridView1.Rows.Add(row);
                       
                    }
                    }*/

                paraustu.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) - Convert.ToDouble(toplampara.Text));

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {



        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                double aa = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                toplampara.Text = Convert.ToString(Convert.ToDouble(toplampara.Text) - aa);


            }
            paraustu.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) - Convert.ToDouble(toplampara.Text));

        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void txtalinan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtalinan.Text != "")
                    paraustu.Text = Convert.ToString(Convert.ToDouble(txtalinan.Text) - Convert.ToDouble(toplampara.Text));
                else   txtalinan.Text = "0";
            }
            catch
            {
                MessageBox.Show("HATALI PARA GİRİŞİ");

            }

        }
        private void toplampara_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtadet_TextChanged(object sender, EventArgs e)
        {

        }

        private void satisekrani_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

            Form pp = new panel();

            pp.Show();
            this.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            MessageBox.Show("asdasd");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtalinan.Text = "00";
            toplampara.Text = "00";
            paraustu.Text = "00";
            textBox1.Text = "";
        }

        private void satisiptal_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void sepet1_Click(object sender, EventArgs e)
        {
            sepet1.BackColor = Color.Green;
            sepet2.BackColor = Color.Gainsboro;
            sepet3.BackColor = Color.Gainsboro;
            sepet4.BackColor = Color.Gainsboro;

        }

        private void sepet2_Click(object sender, EventArgs e)
        {
            sepet1.BackColor = Color.Gainsboro;
            sepet2.BackColor = Color.Green;
            sepet3.BackColor = Color.Gainsboro;
            sepet4.BackColor = Color.Gainsboro;
        }

        private void sepet4_Click(object sender, EventArgs e)
        {
            sepet1.BackColor = Color.Gainsboro;
            sepet2.BackColor = Color.Gainsboro;
            sepet3.BackColor = Color.Gainsboro;
            sepet4.BackColor = Color.Green;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
                string baglanticumlesi = "Data Source =.; Initial Catalog=seckin;Integrated Security=true;";

                SqlConnection baglanti = new SqlConnection(baglanticumlesi);

                for (int i = 0; i < dataGridView1.Rows.Count-1; ++i)
                {
                    int sip = 1;
                    string tarih = DateTime.Now.ToString();
                    string musteriadi = textBox1.Text;
                    int urun_barkod = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    string urun_adi = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    double urun_birimfiyat = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    int urun_miktar = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    double urun_tutar = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    
                    SqlCommand komut = new SqlCommand("insert into tbl_siparis (siparis_no,musteri_adi,urun_barkod,urun_adi,urun_birimfiyat,urun_miktar,urun_tutar,tarih) " +
                        "values (" + sip + ",'" + musteriadi + "'," + urun_barkod + ",'" + urun_adi + "'," + urun_birimfiyat + "," + urun_miktar + "," + urun_tutar + ",'" + tarih + "')", baglanti);
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    komut.ExecuteNonQuery();
                }

                MessageBox.Show("Sipariş Başarılı");
            

            
        }
    }
}
