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
    public partial class Form4 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=ahorcado;password=admin");
        usuario user = new usuario();
        public Form4(usuario user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select nombre from usuarios where pwd like '" + textBox1.Text + "' and nombre like '" + user.Nombre + "'", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                sql.Close();

                if (textBox2.Text == textBox3.Text)
                {
                    sql.Open();
                    MySqlCommand update = new MySqlCommand("update usuarios set pwd = '" + textBox2.Text + "' where nombre = '" + user.Nombre + "'", sql);
                    update.ExecuteNonQuery();
                    sql.Close();

                    label4.Text = "Contraseña cambiada correctamente";
                    label4.ForeColor = Color.Green;
                    label4.Visible = true;

                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl as Label != label4)
                        {
                            ctrl.Enabled = false;
                        }
                    }

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 2000;
                    timer.Tick += (s, e) => this.Close();
                    timer.Start();

                }
                else
                {
                    label4.Text = "Las contraseñas no coinciden";
                    label4.Visible = true;
                }
            }
            else
            {
                label4.Text = "La contraseña antigua es incorrecta";
                label4.Visible = true;
                sql.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar == false)
            {
                textBox1.UseSystemPasswordChar = true;
                label1.Text = "\uD83D\uDD12";
            }
            else
            {
                textBox1.UseSystemPasswordChar = false;
                label1.Text = "\uD83D\uDD13";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
                label2.Text = "\uD83D\uDD12";
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                label2.Text = "\uD83D\uDD13";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (textBox3.UseSystemPasswordChar == false)
            {
                textBox3.UseSystemPasswordChar = true;
                label3.Text = "\uD83D\uDD12";
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
                label3.Text = "\uD83D\uDD13";
            }
        }

        private void resetLabel(object sender, EventArgs e)
        {
            label4.Visible = false;
        }
    }
}
