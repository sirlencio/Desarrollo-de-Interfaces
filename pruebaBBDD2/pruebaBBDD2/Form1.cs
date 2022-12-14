using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace pruebaBBDD2
{
    public partial class Form1 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=examen;database=prueba;persistsecurityinfo=True;pwd=examen");
        float total = 0;
        modelos seleccionado;
        marcas seleccionada;
        public Form1()
        {
            InitializeComponent();
            cargaCombo();
        }

        private void cargaCombo() // Carga objetos marcas en el combobox1
        {
            marcas m;
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from marcas", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                m = new marcas(reader.GetDouble(0), reader.GetString(1));
                comboBox1.Items.Add(m);
            }
            sql.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // Cuando selecciono una marca, carga sus modelos en el combobox2 como objetos
        {
            reseteo();
            comboBox2.Items.Clear();
            marcas marca = (marcas) comboBox1.SelectedItem;
            seleccionada = (marcas)comboBox1.SelectedItem;
            modelos m;

            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from modelos where id_marca = " + marca.id, sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(3))
                {
                    m = new modelos(reader.GetDouble(0), reader.GetDouble(1), reader.GetString(2), 0f); ;
                    comboBox2.Items.Add(m);
                }
                else
                {
                    m = new modelos(reader.GetDouble(0), reader.GetDouble(1), reader.GetString(2), reader.GetFloat(3)); ;
                    comboBox2.Items.Add(m);
                }
            }
            label4.Text = comboBox2.Items.Count + " modelos";
            sql.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            reseteo();
            modelos modelo = (modelos)comboBox2.SelectedItem;
            seleccionado = (modelos)comboBox2.SelectedItem;
            if (modelo.precioBase == 0)
            {
                textBox1.Visible = true;
                button1.Visible = true;
                label2.Text = "Precio:";
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
            }
            else
            {
                label2.Text = "Precio: " + modelo.precioBase;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                button2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("update modelos set preciobase = " + textBox1.Text + " where id = " + seleccionado.id, sql);
            comando.ExecuteNonQuery();
            sql.Close();
            seleccionado.precioBase = float.Parse(textBox1.Text);

            checkBox1.Visible = true;
            checkBox2.Visible = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            calcTotal();
            button1.Visible = false;
            textBox1.Visible = false;
            button2.Visible = true;
        }

        private void reseteo()
        {
            foreach (RadioButton r in groupBox1.Controls)
            {
                if (r.Text == "Blanco")
                {
                    r.Checked = true;
                }
                else
                {
                    r.Checked = false;
                }
            }
            foreach (RadioButton r in groupBox2.Controls)
            {
                if (r.Text == "Dos")
                {
                    r.Checked = true;
                }
                else
                {
                    r.Checked = false;
                }
            }
            label2.Text = "Precio";
            textBox1.Visible = false;
            button1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            textBox1.Text = "";
            label3.Text = "Precio Final";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            button2.Visible = false;
        }
        private void calcTotal()
        {
            total = seleccionado.precioBase;
            if (checkBox1.Checked)
            {
                total += 1000;
            }
            if (checkBox2.Checked)
            {
                total += 500;
            }

            var checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if(checkedButton != null && checkedButton.Text != "Blanco")
            {
                total += 300;
            }

            var checkedButton2 = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedButton2 != null && checkedButton2.Text != "Dos")
            {
                total += 800;
            }
            label3.Text = "Precio Final: " + total + " €";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            calcTotal();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            calcTotal();
        }

        private void radioButtonGroup1_CheckedChanged(object sender, EventArgs e)
        {
            calcTotal();
        }

        private void radioButtonGroup2_CheckedChanged(object sender, EventArgs e)
        {
            calcTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Insert into compra values ('"+ seleccionada.marca +"','"+seleccionado.nombre+ "'," + total + ")", sql);
            comando.ExecuteNonQuery();
            sql.Close();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
    public class marcas
    {
        public double id;
        public string marca;
        public marcas(double id, string marca)
        {
            this.id = id;
            this.marca = marca;
        }
        public override string ToString()
        {
            return marca;
        }
    }
    public class modelos
    {
        public double id_marca, id;
        public string nombre;
        public float precioBase;
        public modelos(double id_marca, double id, string marca, float precioBase)
        {
            this.id_marca = id_marca;
            this.id = id;
            this.nombre = marca;
            this.precioBase = precioBase;
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
