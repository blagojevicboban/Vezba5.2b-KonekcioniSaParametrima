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

namespace Vezba5._2b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            try
            {
                konekcija.ConnectionString = 
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SkolaDB.mdf;Integrated Security=True");
                konekcija.Open();
                SqlCommand komanda = new SqlCommand
                    (textBox1.Text, konekcija);
                DataTable tabela = new DataTable();
                SqlDataReader citac = komanda.ExecuteReader();
                tabela.Load(citac);
                dataGridView1.DataSource = tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            try
            {
                konekcija.ConnectionString =
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SkolaDB.mdf;Integrated Security=True");
                konekcija.Open();
                string upit = "SELECT * FROM Ucenici WHERE Generacija=" 
                    + comboBox1.Text;
                // prenos parametara
                SqlParameter parGod = new SqlParameter();
                parGod.ParameterName = "@Generacija1";
                parGod.Value = comboBox1.Text;
                string parupit =
                    "SELECT * FROM Ucenici WHERE Generacija=@Generacija2";
                SqlCommand komanda = new SqlCommand
                    (parupit, konekcija);
                // 1- nacin
                komanda.Parameters.Add(parGod); 
                // 2- nacin
                komanda.Parameters.AddWithValue("@Generacija2", comboBox1.Text);
                DataTable tabela = new DataTable();
                SqlDataReader citac = komanda.ExecuteReader();
                tabela.Load(citac);
                dataGridView1.DataSource = tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
        }
    }
}
