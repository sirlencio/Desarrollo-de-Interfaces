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
    public partial class Form3 : Form
    {
        DataGridView dg;
        int tipo, index;
        public Form3(DataGridView dg, int tipo)
        {
            InitializeComponent();
            this.dg = dg;
            this.tipo = tipo;
        }
        public Form3(DataGridView dg, int tipo, int index)
        {
            InitializeComponent();
            this.dg = dg;
            this.tipo = tipo;
            this.index = index;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Falta algun campo por introducir", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (tipo == 0)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 notas = new Form4(textBox3, tipo);
            notas.ShowDialog();
            String[] array = textBox3.Text.Split(',');
            double ntotal = 0;
            int total = 0;
            for (int i = 0; i<array.Length; i++)
            {
                if (!array[i].Equals("-"))
                {
                    ntotal += double.Parse(array[i]);
                    total++;
                }

            }
            double media;
            if(ntotal == 0 && total == 0)
            {
                media = 0;
            }
            else 
            {
                media = ntotal / total;
            }
            textBox4.Text = media.ToString("N2");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if(tipo == 1)
            {
                textBox1.Text = dg.Rows[index].Cells[0].Value.ToString();
                textBox2.Text = dg.Rows[index].Cells[1].Value.ToString();
                textBox3.Text = dg.Rows[index].Cells[2].Value.ToString();
                textBox4.Text = dg.Rows[index].Cells[3].Value.ToString();
                button2.Text = "Modificar";
            }
            else
            {
                button2.Text = "Insertar";
            }
        }
    }
}
