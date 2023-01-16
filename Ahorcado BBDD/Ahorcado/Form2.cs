using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form2 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=ahorcado;password=admin");
        usuario user = new usuario();
        public Form2(usuario user)
        {
            InitializeComponent();
            this.user = user;
            carga();
        }

        private void carga()
        {
            label1.Text = "¡Bienvenido " + user.Nombre + "!";
            comboBox1.Items.Clear();

            if (user.Super)
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }

            if (user.Nombre.Equals("Invitado")) // Si es un invitado no queremos que pueda cambiar su contraseña ni ver puntuacion
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
            }
            else
            {
                sql.Open();
                MySqlCommand cmdpuntos = new MySqlCommand("Select fecha, categoria, nrondas, puntuacion from puntuaciones where id_user like '" + user.Nombre + "' order by fecha desc limit 3", sql);
                MySqlDataAdapter ad = new MySqlDataAdapter(cmdpuntos);
                DataTable t = new DataTable();
                ad.Fill(t);
                dataGridView1.DataSource = t;
                sql.Close();
            }

            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select distinct categoria from biblioteca", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                label4.Visible = true;
                System.Media.SystemSounds.Exclamation.Play();
            }
            else
            {
                if (!user.Nombre.Equals("Invitado"))
                {
                    sql.Open();
                    MySqlCommand cmd = new MySqlCommand("Select super from usuarios where nombre like @nombre and pwd like @pwd", sql);
                    cmd.Parameters.AddWithValue("@nombre", user.Nombre);
                    cmd.Parameters.AddWithValue("@pwd", user.Pwd);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    user.Super = reader.GetBoolean(0);
                    sql.Close();
                }
                Form3 juego = new Form3(user, comboBox1.Text);
                juego.ShowDialog();
                carga();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 pswd = new Form4(user);
            pswd.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 puntuaciones = new Form5(user);
            puntuaciones.ShowDialog();
            carga();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form6 admin = new Form6();
                admin.ShowDialog();
            }
            else
            {
                Form7 admin = new Form7();
                admin.ShowDialog();
                carga();
            }
        }
    }
}
