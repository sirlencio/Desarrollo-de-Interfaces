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

namespace pruebaBBDD2
{
    public partial class Form2 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=examen;database=prueba;password=examen");
        public Form2()
        {
            InitializeComponent();
            cargarTabla();
        }

        private void cargarTabla()
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from modelos", sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(comando);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                cargarTabla();
            }
            else
            {
                string filtro = textBox1.Text;
                sql.Open();
                MySqlCommand command = new MySqlCommand("Select * from modelos where nombre like '" + filtro + "%'", sql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                sql.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            int idmarca = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());

            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select nombre from marcas where id = " + idmarca, sql);
            MySqlDataReader stockTotal = comando.ExecuteReader();
            stockTotal.Read();
            label1.Text = "Marca: " + stockTotal.GetString(0);
            sql.Close();
        }
    }
}
