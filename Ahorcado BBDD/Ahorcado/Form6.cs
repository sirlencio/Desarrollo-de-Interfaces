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
    public partial class Form6 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=ahorcado;password=admin");
        usuario user;
        int opc;
        public Form6(usuario user)
        {
            InitializeComponent();
            this.user = user;
            cargaCombo();
        }

        private void cargaCombo()
        {
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select distinct categoria from biblioteca", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            sql.Close();
        }
        private void cargaTabla()
        {
            sql.Open();
            MySqlCommand cmdpuntos = new MySqlCommand("Select palabra from biblioteca where categoria like '" + comboBox1.Text + "'", sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmdpuntos);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label2.Visible = true;

            label3.Visible = true;
            textBox2.Visible = true;

            button5.Visible = true;

            label4.Visible = true;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            comboBox1.Enabled = false;
            opc = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox2.Visible = true;

            button5.Visible = true;

            label4.Visible = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            comboBox1.Enabled = false;
            opc = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(dr == DialogResult.Yes)
            {
                if (comboBox1.Text != "")
                {
                    sql.Open();
                    MySqlCommand cmddelete = new MySqlCommand("delete from biblioteca where categoria like '" + comboBox1.Text + "'", sql);
                    cmddelete.ExecuteNonQuery();
                    sql.Close();
                }
                else
                {
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(dr == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string palabra = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    sql.Open();
                    MySqlCommand cmddelete = new MySqlCommand("delete from biblioteca where categoria like '" + comboBox1.Text + "' and palabra like '" + palabra + "'", sql);
                    cmddelete.ExecuteNonQuery();
                    sql.Close();
                }
                else
                {
                    System.Media.SystemSounds.Exclamation.Play();
                }
                cargaTabla();
            }            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label2.Visible = false;


            label3.Visible = false;
            textBox2.Visible = false;

            button5.Visible = false;

            label4.Visible = false;

            if (opc == 0)
            {
                sql.Open();
                MySqlCommand cmdinsert = new MySqlCommand("insert into biblioteca values ('" + textBox1.Text + "','" + textBox2.Text + "')", sql);
                cmdinsert.ExecuteNonQuery();
                sql.Close();
            }
            else
            {
                sql.Open();
                MySqlCommand cmdinsert = new MySqlCommand("insert into biblioteca values ('" + comboBox1.Text + "','" + textBox2.Text + "')", sql);
                cmdinsert.ExecuteNonQuery();
                sql.Close();
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            comboBox1.Enabled = true;

            cargaCombo();
            cargaTabla();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
