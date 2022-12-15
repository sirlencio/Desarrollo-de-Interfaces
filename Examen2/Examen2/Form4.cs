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

namespace Examen2
{
    public partial class Form4 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=examen;database=examen;password=examen");
        public Form4()
        {
            InitializeComponent();
            cargarProvincias();
            cargarVendedores();
        }

        private void cargarVendedores()
        {
            vendedor v;
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select codigo, nombre from vendedores", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                v = new vendedor(reader.GetInt32(0), reader.GetString(1));
                comboBox2.Items.Add(v);
            }
            sql.Close();
        }

        private void cargarProvincias()
        {
            provincia p;
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from provincias", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                p = new provincia(reader.GetInt32(0), reader.GetString(1));
                comboBox1.Items.Add(p);
            }
            sql.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            provincia p = (provincia)comboBox1.SelectedItem;
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from vendedores where provincia = " + p.id, sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(comando);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            vendedor v = (vendedor)comboBox2.SelectedItem;
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from ventas where codvendedor = " + v.id, sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(comando);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView2.DataSource = t;
            sql.Close();
        }
    }
    public class provincia
    {
        public int id;
        public string nombre;
        public provincia(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return nombre;
        }
    }
    public class vendedor
    {
        public int id;
        public string nombre;
        public vendedor(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
