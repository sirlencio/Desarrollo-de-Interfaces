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

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
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
            DataGridView filtro = new DataGridView();
            DataGridView aux = new DataGridView();
            aux = dataGridView1;
            filtro.Columns.Add("0", "Nombre");
            filtro.Columns.Add("0", "betoven");
            filtro.Rows.Add("Pepe", "9");
            string busqueda = textBox1.Text;
            dataGridView1.Rows.Clear();
            foreach (DataGridViewRow r in filtro.SelectedRows)
            {
                int index = dataGridView1.Rows.Add(r.Clone() as DataGridViewRow);
                foreach (DataGridViewCell o in r.Cells)
                {
                    dataGridView1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                }
            }
            /* for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                 string nombre = dataGridView1.Rows[i].Cells[0].Value + "";
                 if (nombre.Contains(busqueda))
                 {
                     String not = dataGridView1.Rows[i].Cells[1].Value + "";

                     //filtro.Rows.Add(nombre, not);
                     dataGridView1.DataSource = filtro;
                     label2.Text = nombre;
                 }
             }*/
        }
    }
}