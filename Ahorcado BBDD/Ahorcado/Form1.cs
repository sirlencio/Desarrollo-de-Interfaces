using MySqlConnector;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=ahorcado;password=admin");
        usuario user = new usuario();
        public Form1()
        {
            InitializeComponent();
        }
        private Boolean comprobar()
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select id, super from usuarios where nombre like '" + user.Nombre + "' and pwd like '" + user.Pwd + "'", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                sql.Close();
                return false;
            }
            else
            {
                label4.Visible = false;
                user.Id = reader.GetInt32(0);
                user.Super = reader.GetBoolean(1);
                sql.Close();
                return true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            user.Nombre = textBox1.Text;
            user.Pwd = textBox2.Text;
            if (comprobar())
            {
                Form2 menu = new Form2(user);
                menu.ShowDialog();
            }
            else
            {
                label4.Text = "La informacion no coincide";
                label4.Visible = true;
                System.Media.SystemSounds.Exclamation.Play();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                label4.Text = "El nombre de usuario no puede estar vacio";
                System.Media.SystemSounds.Exclamation.Play();
            }
            else
            {
                user.Nombre = textBox1.Text;
                user.Pwd = textBox2.Text;

                sql.Open();
                MySqlCommand cmduser = new MySqlCommand("Select * from usuarios where nombre like '" + user.Nombre + "'", sql);
                MySqlDataReader reader = cmduser.ExecuteReader();
                reader.Read();
                if (!reader.HasRows && !user.Nombre.Equals("Invitado"))
                {
                    sql.Close();
                    sql.Open();
                    MySqlCommand cmdinsert = new MySqlCommand("insert into usuarios values ("+ 0 + ",'" + user.Nombre + "','" + user.Pwd + "'," + "false" + ")", sql);
                    cmdinsert.ExecuteNonQuery();
                    sql.Close();
                    Form2 menu = new Form2(user);
                    menu.ShowDialog();
                }
                else
                {
                    label4.Text = "El usuario ya existe";
                    label4.Visible = true;
                    System.Media.SystemSounds.Exclamation.Play();
                }
                sql.Close();
            }           
        }

        private void escribir(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user.Nombre = "Invitado";
            user.Pwd = "";
            Form2 menu = new Form2(user);
            menu.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
                label5.Text = "\uD83D\uDD12";
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                label5.Text = "\uD83D\uDD13";
            }
        }
    }
}