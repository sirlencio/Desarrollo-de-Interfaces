using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(int index)
        {
            InitializeComponent();
            dataGridView1.Rows[index].Selected= true;
        }
        private void modificar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                Form3 modificacion = new Form3(dataGridView1, 1, index);
                modificacion.ShowDialog();
            }
            else
            {
                MessageBox.Show("No ha seleccionado una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void insertar_Click(object sender, EventArgs e)
        {
            Form3 insertar = new Form3(dataGridView1, 0);
            insertar.ShowDialog();
        }

        private void notacurso()
        {
            double medias = 0;
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                medias += double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            if(dataGridView1.RowCount > 0)
            {
                double totalnotas = dataGridView1.RowCount;
                textBox1.Text = (medias / totalnotas).ToString("N2");
            }
            else
            {
                textBox1.Text = "0";
            }

        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            notacurso();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            notacurso();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            notacurso();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DialogResult dg = MessageBox.Show("Esta seguro??", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
        }
    }
}
