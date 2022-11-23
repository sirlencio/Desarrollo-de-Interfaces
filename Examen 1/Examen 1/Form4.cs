using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_1
{
    public partial class Form4 : Form
    {
        TextBox nuevo;
        int tipo;
        public Form4(TextBox notas, int tipo)
        {
            InitializeComponent();
            this.nuevo = notas;
            this.tipo = tipo;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if(tipo == 1)
            {
                String [] array = nuevo.Text.Split(',');
                textBox1.Text = array[0];
                textBox2.Text= array[1];
                textBox3.Text= array[2];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nuevo.Text = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text;
            Close();       
        }
    }
}
