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
        public Form6()
        {
            InitializeComponent();
            cargaCombo();
        }

        private void cargaCombo()
        {
            comboBox1.Items.Clear();
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

        private void buttonInsCat_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                sql.Open();
                MySqlCommand cmdinsert = new MySqlCommand("insert into biblioteca values ('" + textBox1.Text + "','" + textBox2.Text + "')", sql);
                cmdinsert.ExecuteNonQuery();
                sql.Close();
                label4.Visible = false;
                label5.Visible = false;
            }
            else if(textBox1.Text == "" && textBox2.Text != "")
            {
                label4.Text = "Debe introducir una categoria";
                label4.Visible = true;
            }
            else if(textBox2.Text == "" && textBox1.Text != "")
            {
                label5.Text = "Debe introducir una palabra";
                label5.Visible = true;
            }
            else
            {
                label4.Text = "Debe introducir una categoria";
                label5.Text = "Debe introducir una palabra";
                label4.Visible = true;
                label5.Visible = true;
            }
            cargaCombo();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonEliCat_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                label4.Text = "Debe seleccionar una categoria";
                label4.Visible = true;
            }
            else
            {
                DialogResult dg = MessageBox.Show("Esta seguro que desea borrar el usuario y sus puntuaciones??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    sql.Open();
                    MySqlCommand cmdinsert = new MySqlCommand("delete from biblioteca where categoria like '" + comboBox1.Text + "'", sql);
                    cmdinsert.ExecuteNonQuery();
                    sql.Close();
                    cargaCombo();
                    cargaTabla();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                }
            }
        }

        private void buttonInsPal_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "")
            {
                sql.Open();
                MySqlCommand cmdinsert = new MySqlCommand("insert into biblioteca values ('" + comboBox1.Text + "','" + textBox2.Text + "')", sql);
                cmdinsert.ExecuteNonQuery();
                sql.Close();
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (comboBox1.Text == "" && textBox2.Text != "")
            {
                label4.Text = "Debe seleccionar una categoria";
                label4.Visible = true;
            }
            else if (textBox2.Text == "" && comboBox1.Text != "")
            {
                label5.Text = "Debe introducir una palabra";
                label5.Visible = true;
            }
            else
            {
                label4.Text = "Debe seleccionar una categoria";
                label5.Text = "Debe introducir una palabra";
                label4.Visible = true;
                label5.Visible = true;
            }
            cargaCombo();
            cargaTabla();
        }

        private void buttonEliPal_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                for(int i = 0; i< dataGridView1.SelectedRows.Count; i++)
                {
                    DialogResult dg = MessageBox.Show("Esta seguro que desea borrar la categoria??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dg == DialogResult.Yes)
                    {
                        sql.Open();
                        MySqlCommand cmdinsert = new MySqlCommand("delete from biblioteca where categoria like '" + comboBox1.Text + "' and palabra like '" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + "'", sql);
                        cmdinsert.ExecuteNonQuery();
                        sql.Close();
                        label4.Visible = false;
                        label5.Visible = false;
                    }
                }
            }
            else
            {
                label5.Text = "Debe seleccionar una palabra";
                label5.Visible = true;
            }
            cargaCombo();
            cargaTabla();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}