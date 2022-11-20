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
    public partial class Form2 : Form
    {
        DataGridView dg;
        int n, index;
        public Form2(DataGridView dg, int n)
        {
            InitializeComponent();
            this.dg = dg;
            this.n = n;
        }
        public Form2(DataGridView dg, int n, int index)
        {
            InitializeComponent();
            this.dg = dg;
            this.n = n;
            this.index= index;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (n == 0)
            {
                button1.Text = "Añadir";
            }
            else
            {
                textBox1.Text = dg.Rows[index].Cells[0].Value.ToString();
                textBox2.Text = dg.Rows[index].Cells[1].Value.ToString();
                textBox3.Text = dg.Rows[index].Cells[2].Value.ToString();
                textBox4.Text = dg.Rows[index].Cells[3].Value.ToString();
                button1.Text = "Modificar";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                dg.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                Close();
            }
            else
            {
                dg.Rows[index].Cells[0].Value = textBox1.Text;
                dg.Rows[index].Cells[1].Value = textBox2.Text;
                dg.Rows[index].Cells[2].Value = textBox3.Text;
                dg.Rows[index].Cells[3].Value = textBox4.Text;
                Close();
            }
        }
    }
}
