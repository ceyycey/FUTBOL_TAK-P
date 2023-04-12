using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.OleDb;
using System.Data.SqlClient;

namespace BAA_FUTBOLCU_TAKİP
{
    public partial class kayit : Form
    {


        sqlbaglantisi bag = new sqlbaglantisi();
        //sqlbaglantisi komut = new sqlbaglantisi();//??????????????
       // OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=veri.accdb");
      //  OleDbCommand kmt = new OleDbCommand();



        public kayit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sonuc;
            sonuc = serialPort1.ReadExisting();
            if (sonuc != "")
            {
                label1.Text = sonuc;
            }
        }

        private void kayit_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = Form1.portismi;
            serialPort1.BaudRate = Convert.ToInt16(Form1.banthizi);


            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.Open();
                    label8.Text = "Bağlantı Sağlandı";
                    label8.ForeColor = Color.Green;

                }
                catch
                {
                    label8.Text = "Bağlantı Sağlanamadı";
                    label8.ForeColor = Color.Red;

                }





            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = "___________";
            textBox1.Text = "";
            textBox2.Text = "";
            // textBox3.Text = "";
            comboBox3.Text = "Seçiniz";
            comboBox4.Text = "Seçiniz";
            comboBox5.Text = "Seçiniz";
            textBox3.Text = "";
            label9.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyaları (jpg) |*.jpg|Tüm Dosyalar |*.*";
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\foto";
            dosya.RestoreDirectory = true;

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                string di = dosya.SafeFileName;
                textBox3.Text = di;

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            //bag.baglanti().Open();
            // bag.Open();
            // kmt.Connection = bag;
            SqlCommand komut = new SqlCommand ("insert into Tbl_Futbolcular (kid,isim,soyisim,grup,mevki,paket,resimbilgisi,kursbas,kursbit,dogtar,okul,veli,tel1,tel2) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)", bag.baglanti());  
            komut.Parameters.AddWithValue("@p1", label1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text); 
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            komut.Parameters.AddWithValue("@p4", comboBox3.Text);
            komut.Parameters.AddWithValue("@p5", comboBox4.Text);
            komut.Parameters.AddWithValue("@p6", comboBox5.Text);
            komut.Parameters.AddWithValue("@p7", textBox3.Text);
            komut.Parameters.AddWithValue("@p8", dateTimePicker1.Value.Date);
            komut.Parameters.AddWithValue("@p9", dateTimePicker2.Value.Date);
            komut.Parameters.AddWithValue("@p10", dateTimePicker3.Value.Date);
            komut.Parameters.AddWithValue("@p11", textBox4.Text);
            komut.Parameters.AddWithValue("@p12", textBox5.Text);
            komut.Parameters.AddWithValue("@p13", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p14", maskedTextBox2.Text);
           

            komut.ExecuteNonQuery(); 
            label9.Text = "Kayıt Yapıldı";
            label9.ForeColor = Color.Green;


            





            bag.baglanti().Close();
           // bag.Close();

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void kayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                timer1.Stop();
                serialPort1.Close();

           
        }

        private void kayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 goster = new Form1();
            goster.Show();
        }
    }
}
