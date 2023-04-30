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
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }

        SqlConnection bglntı = new SqlConnection("Data Source=DESKTOP-0V73418\\SQLEXPRESS;Initial Catalog=SecimTablo;Integrated Security=True");

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Grafikler_Load(object sender, EventArgs e)
        {
            bglntı.Open();
            SqlCommand ilceadları = new SqlCommand("Select ILCEAD from Table_Prt", bglntı);
            SqlDataReader dr = ilceadları.ExecuteReader();

            while (dr.Read())
            {

                comboBox1.Items.Add(dr[0]);
                // comboBox1.Items(dr[0]);

            }
            bglntı.Close();


            // Grafiğe çekme oyları

            bglntı.Open();
            SqlCommand grfk = new SqlCommand("Select Sum(APARTİ),Sum(BPARTİ),Sum(CPARTİ),Sum(DPARTİ),Sum(EPARTİ) FROM Table_Prt",bglntı);

            SqlDataReader rt = grfk.ExecuteReader();

            while (rt.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti,",rt[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", rt[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", rt[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", rt[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", rt[4]);
            }

            bglntı.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bglntı.Open();

            SqlCommand tara = new SqlCommand("Select * From Table_Prt where ILCEAD=@P1",bglntı);
            tara.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dx = tara.ExecuteReader();

            while (dx.Read())
            {
                progressBar1.Value = int.Parse(dx[2].ToString());
                label7.Text = dx[2].ToString();
                progressBar2.Value = int.Parse(dx[3].ToString());
                label8.Text = dx[3].ToString();
                progressBar3.Value = int.Parse(dx[4].ToString());
                label9.Text = dx[4].ToString();
                progressBar4.Value = int.Parse(dx[5].ToString());
                label10.Text = dx[5].ToString();
                progressBar5.Value = int.Parse(dx[6].ToString());
                label11.Text = dx[6].ToString();

            }




            bglntı.Close();
        }
    }
}
