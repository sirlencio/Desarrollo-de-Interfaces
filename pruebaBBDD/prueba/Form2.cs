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
        int opc, index;
        public Form2(int opc)
        {
            InitializeComponent();
            this.opc = opc;
            sql = new MySqlConnection("server=localhost;user id=root;database=examen;password=admin");
            cargaFamilias();
        }

        public Form2(DataGridView d, int opc, int index)
        {
            InitializeComponent();
            this.d = d;
            this.opc = opc;
            this.index = index;
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

            if (opc == 1)
            {
                button1.Text = "Modificar";
                textBox1.Text = d.Rows[index].Cells[0].Value.ToString();
                textBox2.Text = d.Rows[index].Cells[1].Value.ToString();
                textBox3.Text = d.Rows[index].Cells[2].Value.ToString();
                textBox4.Text = d.Rows[index].Cells[3].Value.ToString();

                sql.Open();
                MySqlCommand select = new MySqlCommand("Select familia from familias where codigo like '" + d.Rows[index].Cells[4].Value.ToString() + "'", sql);
                MySqlDataReader rd = select.ExecuteReader();
                rd.Read();
                comboBox1.Text = rd.GetString(0);
                sql.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codfam;

            string codigo = textBox1.Text;
            string descripcion = textBox2.Text;
            float precio = float.Parse(textBox4.Text);
            int stock = Int32.Parse(textBox3.Text);
            string familia = comboBox1.Text;

            sql.Open();
            MySqlCommand select = new MySqlCommand("Select codigo from familias where Familia = '" + familia + "'", sql);
            MySqlDataReader reader = select.ExecuteReader();
            reader.Read();
            codfam = reader.GetInt32(0);
            sql.Close();

            if (opc == 0)
            {
                sql.Open();
                MySqlCommand añadir = new MySqlCommand("Insert into articulos values ('" + codigo + "','" + descripcion + "'," + precio + "," + stock + "," + codfam + ")", sql);
                añadir.ExecuteReader(0);
                sql.Close();
            }
            else
            {
                sql.Open();
                MySqlCommand añadir = new MySqlCommand("update articulos set descripcion ='"+ descripcion + "', precio=" + precio + ", stock=" + stock + ", codfamilia=" + codfam + " where codigo = '" + codigo + "'", sql);
                añadir.ExecuteReader(0);
                sql.Close();
            }
            this.Close();
        }
    }
}
