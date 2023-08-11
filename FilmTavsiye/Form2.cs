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

namespace FilmTavsiye
{
    public partial class Form2 : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2QTTN24;Initial Catalog=Denemedb;Integrated security=true");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string query = "Select Notes,Score from movies where movie_title ='" +label2.Text+ "'";
            
            SqlCommand cmd = new SqlCommand(query, conn);

            comboBox1.SelectedIndex = 0;

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                label3.Text = dr.GetValue(1).ToString()+"/10";
                label4.Text = dr.GetValue(0).ToString();



                
            }

            conn.Close();

            label5.Text = "My score and note about film:";
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();


            SqlCommand cmd = new SqlCommand("update movies set Score='"+comboBox1.Text+"', Notes='"+textBox1.Text+"' where movie_title ='" +label2.Text+ "'",conn);

            cmd.ExecuteNonQuery();
          

            conn.Close();

            label3.Text = comboBox1.Text+"/10";
            label4.Text = textBox1.Text;

            textBox1.Clear();


        }

        
    }
}
