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

namespace prueba
{
    public partial class Form2 : Form
    {
        DataGridView d;
        MySqlConnection sql;
        public Form2(DataGridView d)
        {
            InitializeComponent();
            this.d = d;
            sql = new MySqlConnection("server=localhost;user id=root;database=examen;password=admin");
            cargaFamilias();
        }
        private void cargaFamilias()
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select familia from familias", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo, descripcion, familia;
            float precio;
            int stock, codfam;

            codigo = textBox1.Text;
            descripcion = textBox2.Text;
            precio = float.Parse(textBox3.Text);
            stock = Int32.Parse(textBox4.Text);

            familia = comboBox1.Text;
            sql.Open();
            MySqlCommand select = new MySqlCommand("Select codigo from familias where Familia = '"+ familia + "'", sql);
            MySqlDataReader reader = select.ExecuteReader();
            reader.Read();
            codfam = reader.GetInt32(0);
            sql.Close();
            sql.Open();
            MySqlCommand añadir = new MySqlCommand("Insert into articulos values ('"+ codigo + "','" + descripcion + "'," + precio + "," + stock + "," + codfam + ")", sql);
            añadir.ExecuteReader(0);
            sql.Close();
            this.Close();
        }
    }
}
