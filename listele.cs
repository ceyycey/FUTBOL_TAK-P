using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BAA_FUTBOLCU_TAKİP
{
    public partial class listele : Form
    {
        sqlbaglantisi bag = new sqlbaglantisi();

        public listele()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT * FROM Tbl_Futbolcular";
           // komut.Connection = bag;

            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();

            adap.Fill(tablo);

            dataGridView1.DataSource = tablo;
        }

        private void listele_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 goster = new Form1();
            goster.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
