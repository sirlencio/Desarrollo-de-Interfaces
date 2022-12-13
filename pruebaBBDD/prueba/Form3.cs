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
    public partial class Form3 : Form
    {
        MySqlConnection sql;
        public Form3()
        {
            InitializeComponent();
            sql = new MySqlConnection("server=localhost;user id=root;database=examen;password=admin");
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int codfam = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            listView1.Clear();
            label2.Text = "";

            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select sum(stock) from articulos where codfamilia = " + codfam, sql);
            MySqlDataReader stockTotal = comando.ExecuteReader();
            stockTotal.Read();
            if (stockTotal.IsDBNull(0))
            {
                label1.Text = "No tiene stock";
            }
            else
            {
                label1.Text = "Total en stock: " + stockTotal.GetInt32(0);
            }
            sql.Close();

            sql.Open();
            comando = new MySqlCommand("Select descripcion, precio from articulos where codfamilia = " + codfam + " order by descripcion", sql);
            MySqlDataReader listaArt = comando.ExecuteReader();
            while (listaArt.Read())
            {
                if (!listaArt.IsDBNull(0))
                {
                    listView1.Items.Add(listaArt.GetString(0) + "\n" + listaArt.GetFloat(1) + "€");
                }
            }
            sql.Close();

            sql.Open();
            comando = new MySqlCommand("SELECT descripcion, precio FROM articulos WHERE precio = (SELECT MAX(precio) FROM articulos WHERE codfamilia =  " + codfam + ")", sql);
            MySqlDataReader max = comando.ExecuteReader();
            max.Read();
            if (max.HasRows)
            {
                label2.Text = "Caro: " + max.GetString(0) + " " + max.GetFloat(1) + "€\n";
            }
            sql.Close();

            sql.Open();
            comando = new MySqlCommand("SELECT descripcion, precio FROM articulos WHERE precio = (SELECT MIN(precio) FROM articulos WHERE codfamilia =  " + codfam + ")", sql);
            MySqlDataReader min = comando.ExecuteReader();
            min.Read();
            if (min.HasRows)
            {
                label2.Text = label2.Text + "Barato: " + min.GetString(0) + " " + min.GetFloat(1) + "€";
            }
            sql.Close();

        }
    }
}
