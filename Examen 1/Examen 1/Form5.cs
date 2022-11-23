using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Examen_1
{
    public partial class Form5 : Form
    {
        public Form5(DataGridView dg)
        {
            InitializeComponent();
            this.dataGridView1= dg;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.ToLower();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (filtro.Length != 0)
                {
                    string apellido = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (apellido.ToLower().Contains(filtro))
                    {
                        dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Visible = false;
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indselect = dataGridView1.SelectedCells[0].RowIndex;
            Form2 alumnos = new Form2(indselect);
            alumnos.Show();
            this.Close();
        }
    }
}
