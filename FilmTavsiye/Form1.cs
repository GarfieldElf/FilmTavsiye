using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Data.OleDb;

namespace FilmTavsiye
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2QTTN24;Initial Catalog=Denemedb;Integrated security=true");

        public Form1()
        {
            InitializeComponent();
          



        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'denemedbDataSet.movies' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.moviesTableAdapter.Fill(this.denemedbDataSet.movies);



            SqlCommand cmd = new SqlCommand("Select * from movies order by movie_title desc", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

          
            MovieList.DataSource = dt;
            MovieList.DisplayMember = "movie_title";
            MovieList.ValueMember = "vote_average";
     

            label1.Text = "ADD MOVIE";
            button1.Text = "Insert ";
            button2.Text = "Delete"; 
            

        }


        private void MovieList_DoubleClicked(object sender, EventArgs e)
        {
            

            Form2 f2 = new Form2();


            f2.label2.Text = MovieList.GetItemText(MovieList.SelectedItem);
            f2.label1.Text = MovieList.GetItemText(MovieList.SelectedValue);


            f2.moviename.Text = "Movie Name";
            f2.averagevote.Text = "Average Vote";
            f2.button1.Text = "Add";
          

            f2.ShowDialog();



            

        }

        private void button1_Click(object sender, EventArgs e) //add movie name into listbox
        {

            if (string.IsNullOrEmpty(textBox1.Text)) {

                return;
            }

            conn.Open();
           
            SqlCommand cmd = new SqlCommand("insert into movies(movie_title) values('"+textBox1.Text+" (Benim Eklediğim Filmler)"+"')",conn);

            cmd.ExecuteNonQuery();
            conn.Dispose();

            conn.Close();

        
           textBox1.Clear();
           
        }

        private void button2_Click(object sender, EventArgs e) // listelenen filmlerden seçileni siliyor databaseden değil       
        {
            DataRowView Secilensatir = MovieList.SelectedItem as DataRowView;

            if(Secilensatir == null)
            {
                return;
            }

            Secilensatir.Row.Delete();

        }

     





    }
}
