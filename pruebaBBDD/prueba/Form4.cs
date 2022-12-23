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
    public partial class Form4 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=examen;password=admin");
        int total = 0;
        public Form4()
        {
            InitializeComponent();
            cargarTabla();
        }

        private void cargarTabla()
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from familias", sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(comando);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            int idfam = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());

            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from articulos where codfamilia = " + idfam, sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(comando);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView2.DataSource = t;
            sql.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.SelectedCells[0].RowIndex;
            string desc = dataGridView2.Rows[index].Cells[1].Value.ToString();
            int precio = Int32.Parse(dataGridView2.Rows[index].Cells[2].Value.ToString());

            listBox1.Items.Add(desc + " " + precio + "€");

            total += precio;

            double media = total / listBox1.Items.Count;

            label1.Text = "N total: " + listBox1.Items.Count + " , precio medio: " + media;
        }
    }
}