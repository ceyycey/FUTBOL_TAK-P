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

namespace BAA_FUTBOLCU_TAKİP
{
    public partial class duzenle : Form
    {
       
        DataTable dt;
        sqlbaglantisi bag = new sqlbaglantisi();
        public duzenle()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //kayittaki yeni kart eklenin aynı kısmı aldım
        private void button1_Click(object sender, EventArgs e)
        {
         
            label1.Text = "___________";
            textBox1.Text = "";
            textBox2.Text = "";
            // textBox3.Text = "";
            comboBox1.Text = "Seçiniz";
            comboBox2.Text = "Seçiniz";
            comboBox3.Text = "Seçiniz";
        
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Futbolcular (kid,isim,soyisim,grup,mevki,paket,resimbilgisi,kursbas,kursbit,dogtar,okul,veli,tel1,tel2) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", label15.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            komut.Parameters.AddWithValue("@p4", comboBox1.Text);
            komut.Parameters.AddWithValue("@p5", comboBox2.Text);
            komut.Parameters.AddWithValue("@p6", comboBox3.Text);
            komut.Parameters.AddWithValue("@p7", textBox5.Text);
            komut.Parameters.AddWithValue("@p8", dateTimePicker1.Value.Date);
            komut.Parameters.AddWithValue("@p9", dateTimePicker2.Value.Date);
            komut.Parameters.AddWithValue("@p10", dateTimePicker3.Value.Date);
            komut.Parameters.AddWithValue("@p11", textBox3.Text);
            komut.Parameters.AddWithValue("@p12", textBox4.Text);
            komut.Parameters.AddWithValue("@p13", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p14", maskedTextBox2.Text);


            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt güncellendi.");

        }

        private void duzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 goster = new Form1();
            goster.Show();
        }
    }
}
