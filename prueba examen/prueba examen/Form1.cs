using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba_examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataGridView1, 0);
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
            DialogResult dg = MessageBox.Show("Esta seguro??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dg == DialogResult.Yes)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(index);
            }
        }

        private void actualizar()
        {
            int total = 0;
            int cant, precio;
            for(int i = 0; i <dataGridView1.RowCount; i++)
            {
                cant = Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                precio = Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                total = total + (cant * precio);
            }
            textBox1.Text = total.ToString();
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            actualizar();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            actualizar();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            actualizar();
        }
    }
}
