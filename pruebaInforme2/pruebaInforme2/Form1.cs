using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaInforme2
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost; user id = root; database=poblaciones");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("SELECT Localidad FROM poblaciones where localidad is not null", conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                String nombre = reader.GetString(0);
                comboBox3.Items.Add(nombre);

            }
            reader.Close();

            MySqlCommand comando2 = new MySqlCommand("SELECT cp FROM poblaciones where cp is not null", conexion);
            MySqlDataReader reader2 = comando2.ExecuteReader();
            while (reader2.Read())
            {
                String nombre = reader2.GetString(0);
                comboBox1.Items.Add(nombre);
                comboBox2.Items.Add(nombre);

            }

            reader2.Close();
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form2 todos = new Form2();
                todos.ShowDialog();
            }

            if(radioButton2.Checked && comboBox1.Text != "" && comboBox2.Text != "")
            {
                Form6 hastadesde = new Form6(comboBox1.Text, comboBox2.Text);
                hastadesde.ShowDialog();
            }


            if (radioButton3.Checked && comboBox3.Text != "")
            {
                Form3 localidad = new Form3(comboBox3.Text);
                localidad.ShowDialog();
            }
            if (radioButton4.Checked && textBox1.Text != "")
            {
                Form4 nhab = new Form4(Int32.Parse(textBox1.Text));
                nhab.ShowDialog();
            }
            if (radioButton5.Checked)
            {
                Form5 letra = new Form5();
                letra.ShowDialog();
            }
        }
    }
    
}
