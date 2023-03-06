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

namespace ExamenInforme
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;user id=examen;database=world;password=examen");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form2 todo = new Form2();
                todo.ShowDialog();
            }
            if (radioButton2.Checked)
            {
                Form3 paisciudad = new Form3();
                paisciudad.ShowDialog();
            }
            if(radioButton3.Checked && textBox1.Text != "")
            {
                Form4 nhab = new Form4(textBox1.Text);
                nhab.ShowDialog();
            }
            if(radioButton4.Checked && comboBox1.Text != "")
            {
                Pais p = (Pais) comboBox1.SelectedItem;
                Form5 pais = new Form5(p.Code, p.Nombre);
                pais.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("SELECT name, code FROM country where name is not null", conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            Pais p;
            while (reader.Read())
            {
                p = new Pais(reader.GetString(0), reader.GetString(1));
                comboBox1.Items.Add(p);
            }
            reader.Close();
            conexion.Close();
        }
    }
    class Pais
    {
        private String code;
        private String nombre;

        public Pais(String nombre, String code)
        {
            this.nombre = nombre;
            this.code = code;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Code { get => code; set => code = value; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
