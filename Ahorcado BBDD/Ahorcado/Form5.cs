using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form5 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=ahorcado;password=admin");
        usuario user = new usuario();
        public Form5(usuario user)
        {
            InitializeComponent();
            this.user = user;
            cargar();
        }

        private void cargar()
        {
            sql.Open();
            MySqlCommand cmdpuntos = new MySqlCommand("Select fecha, categoria, nrondas, puntuacion from puntuaciones where id_user like '" + user.Nombre + "' order by fecha desc", sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmdpuntos);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string fecha = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sql.Open();
                MySqlCommand cmddelete = new MySqlCommand("delete from puntuaciones where id_user like " + user.Nombre + " and fecha like '" + fecha + "'", sql);
                cmddelete.ExecuteNonQuery();
                sql.Close();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
