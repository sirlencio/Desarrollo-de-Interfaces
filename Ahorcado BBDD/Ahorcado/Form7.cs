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
    public partial class Form7 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=ahorcado;password=admin");
        public Form7()
        {
            InitializeComponent();
            cargaUsuarios();
        }

        private void cargaUsuarios()
        {
            sql.Open();
            MySqlCommand cmdpuntos = new MySqlCommand("Select * from usuarios", sql);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmdpuntos);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            sql.Close();
        }

        private void cargaPuntuaciones()
        {
            sql.Open();
            MySqlCommand cmdpuntos = new MySqlCommand("Select * from puntuaciones where id_user like @id", sql);
            cmdpuntos.Parameters.AddWithValue("@id",dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            MySqlDataAdapter ad = new MySqlDataAdapter(cmdpuntos);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView2.DataSource = t;
            sql.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cargaPuntuaciones();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if ((bool)dataGridView1.SelectedRows[0].Cells["super"].Value)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            MySqlCommand cmdinsert = new MySqlCommand("insert into usuarios values (@id, '', @super)", sql);
            cmdinsert.Parameters.AddWithValue("@id", textBox2.Text);
            cmdinsert.Parameters.AddWithValue("@super", checkBox1.Checked);
            cmdinsert.ExecuteNonQuery();
            sql.Close();
            cargaUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Open();
            MySqlCommand cmdupdate = new MySqlCommand("update usuarios set nombre=@nombre, super=@super where nombre like @id", sql);
            cmdupdate.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmdupdate.Parameters.AddWithValue("@super", checkBox1.Checked);
            cmdupdate.Parameters.AddWithValue("@id", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cmdupdate.ExecuteNonQuery();
            sql.Close();
            cargaUsuarios();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Esta seguro que desea borrar el usuario y sus puntuaciones??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dg == DialogResult.Yes)
            {
                sql.Open();
                MySqlCommand cmddelete = new MySqlCommand("delete from usuarios where nombre like @user", sql);
                cmddelete.Parameters.AddWithValue("@user", dataGridView1.SelectedRows[0].Cells[0].Value.ToString()); ;
                cmddelete.ExecuteNonQuery();
                sql.Close();
                cargaUsuarios();
                cargaPuntuaciones();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (filtro.Length != 0)
                {
                    string nombre = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (nombre.ToLower().Contains(filtro))
                    {
                        dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        this.dataGridView1.CurrentCell = null;
                        dataGridView1.Rows[i].Visible = false;
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
        }


    }
}