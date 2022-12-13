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

namespace prueba
{
    public partial class Form1 : Form
    {
        MySqlConnection sql;
        public Form1()
        {
            InitializeComponent();
            sql = new MySqlConnection("server=localhost;user id=root;database=examen;password=admin");
            cargarTabla();
        }
        private void cargarTabla()
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from articulos", sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(comando);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 crea = new Form2(0);
            crea.ShowDialog();
            cargarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Form2 mod = new Form2(dataGridView1, 1, index);
            mod.ShowDialog();
            cargarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult dg = MessageBox.Show("Esta seguro??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    string codigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    sql.Open();
                    MySqlCommand añadir = new MySqlCommand("delete from articulos where codigo like '"+ codigo + "'", sql);
                    añadir.ExecuteReader(0);
                    sql.Close();
                    cargarTabla();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                cargarTabla();
            }
            else
            {
                string desc = textBox1.Text;
                sql.Open();
                MySqlCommand command = new MySqlCommand("Select codigo, descripcion from articulos where descripcion like '" + desc + "%'", sql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                sql.Close();
            }
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
