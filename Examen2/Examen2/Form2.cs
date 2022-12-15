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

namespace Examen2
{
    public partial class Form2 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=examen;database=examen;password=examen");
        public Form2()
        {
            InitializeComponent();
            cargarTablas();
        }
        private void cargarTablas()
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from vendedores", sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(comando);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();

            sql.Open();
            comando = new MySqlCommand("Select * from ventas", sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            t=new DataTable();
            adapter.Fill(t);
            dataGridView2.DataSource = t;
            sql.Close();
        }

        // Datagridview1 Vendedores
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 alta = new Form3();
            alta.ShowDialog();
            cargarTablas();
        }

        private void button2_Click(object sender, EventArgs e) // Baja vendedores
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dg = MessageBox.Show("Esta seguro??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    string codigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    sql.Open();
                    MySqlCommand añadir = new MySqlCommand("delete from vendedores where codigo like '" + codigo + "'", sql);
                    añadir.ExecuteNonQuery();
                    sql.Close();
                    cargarTablas();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Form3 mod = new Form3(dataGridView1, 1, index);
            mod.ShowDialog();
            cargarTablas();
        }

        // Datagridview2 Ventas
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // Baja venta
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DialogResult dg = MessageBox.Show("Esta seguro??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    string codigo = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    sql.Open();
                    MySqlCommand añadir = new MySqlCommand("delete from ventas where codigo like '" + codigo + "'", sql);
                    añadir.ExecuteNonQuery();
                    sql.Close();
                    cargarTablas();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            string codigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            sql.Open();
            MySqlCommand comando = new MySqlCommand("select count(importe) from ventas where codvendedor like '" + codigo + "'", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            label1.Text = "Total Ventas: " + reader.GetInt64(0);
            sql.Close();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button5.Enabled = true;
            button6.Enabled = true;
        }


    }
}
