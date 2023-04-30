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

namespace Seçimİstatistik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bglntı = new SqlConnection("Data Source=DESKTOP-0V73418\\SQLEXPRESS;Initial Catalog=SecimTablo;Integrated Security=True");


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grafikler grfk = new Grafikler();
            grfk.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bglntı.Open();

            SqlCommand oyver = new SqlCommand("insert into Table_Prt(ILCEAD,APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ) values(@axx,@apart,@bpart,@cpart,@dpart,@epart)", bglntı);
            oyver.Parameters.AddWithValue("@axx", textBox1.Text);
            oyver.Parameters.AddWithValue("@apart", textBox2.Text);
            oyver.Parameters.AddWithValue("@bpart", textBox3.Text);
            oyver.Parameters.AddWithValue("@cpart", textBox4.Text);
            oyver.Parameters.AddWithValue("@dpart", textBox5.Text);
            oyver.Parameters.AddWithValue("@epart", textBox6.Text);
            oyver.ExecuteNonQuery();
            bglntı.Close();

            MessageBox.Show("Oy Girişi Gerçekleşti","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }
    }
}
