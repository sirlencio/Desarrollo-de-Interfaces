using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba_examen
{
    public partial class Form2 : Form
    {
        DataGridView dg;
        int n, index, cant, precio;
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
            textBox1.BackColor = SystemColors.Window;
            textBox2.BackColor = SystemColors.Window;
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

        private void calcSubtotal(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox3.Text, @"^[0-9]+$"))
            {
                textBox3.Text = "";
                cant = 0;

            }
            else if (!Regex.IsMatch(textBox4.Text, @"^[0-9]+$"))
            {
                textBox4.Text = "";
                precio = 0;
            }
            else
            {
                cant = Int32.Parse(textBox3.Text);
                precio = Int32.Parse(textBox4.Text);
            }
            textBox5.Text = (cant * precio) + "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                comprobarDatosPrueba(textBox1.Text);
            }
        }
        private void comprobarDatosPrueba(string id)
        {
            switch (id)
            {
                case ("1"):
                    textBox2.Text = "Tornillo";
                    textBox4.Text = "3";
                    textBox1.BackColor = SystemColors.Window;
                    textBox2.BackColor = SystemColors.Window;
                    break;
                case ("2"):
                    textBox2.Text = "Tuerca";
                    textBox4.Text = "2";
                    textBox1.BackColor = SystemColors.Window;
                    textBox2.BackColor = SystemColors.Window;
                    break;
                case ("3"):
                    textBox2.Text = "Arandela";
                    textBox4.Text = "1";
                    textBox1.BackColor = SystemColors.Window;
                    textBox2.BackColor = SystemColors.Window;
                    break;
                case ("4"):
                    textBox2.Text = "Llave";
                    textBox4.Text = "4";
                    textBox1.BackColor = SystemColors.Window;
                    textBox2.BackColor = SystemColors.Window;
                    break;
                default:
                    textBox1.BackColor = Color.Red;
                    textBox2.BackColor = Color.Red;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cant != 0 && precio != 0)
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
            else
            {
                if(cant == 0)
                {
                    MessageBox.Show("No puede introducir 0 como cantidad", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("No puede introducir 0 como precio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            
        }
    }
}
