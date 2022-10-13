using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Ventana_tabla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(DataGridView d)
        {
            InitializeComponent();
            this.dataGridView1 = d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataGridView1, 1);
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Form2 form2 = new Form2(dataGridView1, 2, index);
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.RemoveAt(index);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[0].IsNewRow)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text.ToLower();
            if (busqueda.Length != 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string nombre = dataGridView1.Rows[i].Cells[0].Value + "";
                    if (nombre.ToLower().Contains(busqueda))
                    {
                        dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Visible = false;
                    }
                }
            }
            else
            {
                for(int j = 0; j<dataGridView1.Rows.Count - 1; j++)
                {
                    dataGridView1.Rows[j].Visible = true;
                }
            }

            
        }
    }
}