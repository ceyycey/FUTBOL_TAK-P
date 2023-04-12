using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
//using System.Data.OleDb;
using System.Data.SqlClient;




namespace BAA_FUTBOLCU_TAKİP
{
    public partial class Form1 : Form
    {
        sqlbaglantisi bag = new sqlbaglantisi();
        // sqlbaglantisi kmt = new sqlbaglantisi();//??????



        // OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=veri.accdb");
        // OleDbCommand kmt = new OleDbCommand();

        public static string portismi, banthizi;
        string[] ports = SerialPort.GetPortNames();




        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();
            portismi = comboBox1.Text;
            banthizi = comboBox2.Text;
            try
            {
                serialPort1.PortName = portismi;
                serialPort1.BaudRate = Convert.ToInt16(banthizi);
                serialPort1.Open();
                label1.Text = "Bağlantı Sağlandı";
                label1.ForeColor = Color.Green;

            }
            catch
            {

                serialPort1.Close();
                serialPort1.Open();
                MessageBox.Show("Bağlantı zaten açık");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            timer1.Stop();
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                label1.Text = "Bağlantı Kesildi";
                label1.ForeColor = Color.Red;
            }



        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sonuc;
            sonuc = serialPort1.ReadExisting();

            if (sonuc != "")
            {
                label2.Text = sonuc;
                // bag.baglanti().Close();
                //bag.baglanti().Open();
                //bag.Open();
                //kmt.Connection = bag;
                SqlCommand komut = new SqlCommand("select * from Tbl_Futbolcular where kid=@p1", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", sonuc);
                SqlDataReader dr = komut.ExecuteReader();










                //OleDbDataReader oku = kmt.ExecuteReader();

                if (dr.Read())
                {
                    DateTime bugun = DateTime.Now;
                    pictureBox2.Image = Image.FromFile("foto\\" + dr["resimbilgisi"].ToString());
                    label11.Text = dr["isim"].ToString();
                    label12.Text = dr["soyisim"].ToString();

                    label15.Text = dr["grup"].ToString();
                    label16.Text = dr["mevki"].ToString();
                    label17.Text = dr["paket"].ToString();

                    label13.Text = bugun.ToShortDateString();
                    label14.Text = bugun.ToShortTimeString();

                    label18.Text = dr["kursbas"].ToString();
                    label19.Text = dr["kursbit"].ToString();

                    label20.Text = dr["dogtar"].ToString();
                    label21.Text = dr["okul"].ToString();
                    label22.Text = dr["veli"].ToString();
                    label23.Text = dr["tel1"].ToString();
                    label24.Text = dr["tel2"].ToString();

                    //bag.baglanti().Close();
                    // bag.Close();
                    // bag.baglanti().Open();
                    //bag.Open();
                    //kmt.CommandText = "insert into zaman (isim,soyisim,tarih,saat)VALUES ('" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "')";







                    //kmt.ExecuteReader();
                    //bag.Close();
                    bag.baglanti().Close();
                    // bag.baglanti().Open();





                }
                else
                {
                    pictureBox2.Image = Image.FromFile("foto\\altay.ico");
                    label2.Text = "Kart Kayıtlı Değil";
                    label11.Text = "___________";
                    label12.Text = "___________";

                    label15.Text = "___________";
                    label16.Text = "___________";
                    label17.Text = "___________";
                    label13.Text = "___________";
                    label14.Text = "___________";


                }


                bag.baglanti().Close();
                //bag.Close();
            }





        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (portismi == null || banthizi == null)
            {

                MessageBox.Show("Bağlantını kontrol et");

            }
            else
            {
                timer1.Stop();
                serialPort1.Close();
                label1.Text = "Bağlantı Kapalı";
                label1.ForeColor = Color.Red;
                kayit kyt = new kayit();
                kyt.ShowDialog();


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //bag.baglanti().Close();
            //bag.baglanti().Open();

            SqlCommand komut1 = new SqlCommand("insert into Tbl_Zaman (isim,soyisim,tarih,saat) values(@p15,@p16,@p17,@p18)", bag.baglanti());
            komut1.Parameters.AddWithValue("@p15", label11.Text);
            komut1.Parameters.AddWithValue("@p16", label12.Text);
            komut1.Parameters.AddWithValue("@p17", label13.Text);
            komut1.Parameters.AddWithValue("@p18", label14.Text);

            // komut1.ExecuteReader();
            komut1.ExecuteNonQuery();
            bag.baglanti().Close();

            MessageBox.Show("Giriş Başarılı");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            duzenle kayit = new duzenle();
            this.Hide();
            kayit.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listele list = new listele();
            this.Hide();
            list.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);

            }
            comboBox2.Items.Add("2400");
            comboBox2.Items.Add("4800");
            comboBox2.Items.Add("9600");
            comboBox2.Items.Add("19200");
            comboBox2.Items.Add("115200");

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;


        }
    }
}
