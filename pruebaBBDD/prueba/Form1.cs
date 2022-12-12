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
            Form2 form2 = new Form2(dataGridView1);
            form2.ShowDialog();
            cargarTabla();
        }
    }
}
