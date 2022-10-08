using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventana_tabla
{
    public partial class Form2 : Form
    {
        DataGridView d;
        int opc, index = 9;
        public Form2(DataGridView d, int opc)
        {
            InitializeComponent();
            this.d = d;
            this.opc = opc;
        }
        public Form2(DataGridView d, int opc, int index)
        {
            InitializeComponent();
            this.d = d;
            this.opc = opc;
            this.index = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(opc == 1)
            {
                d.Rows.Add(textBox1.Text, textBox2.Text);
                Close();
            }
            else if(opc == 2)
            {
                d.Rows[index].Cells[0].Value = textBox1.Text;
                d.Rows[index].Cells[1].Value = textBox2.Text;
                Form1 frm = new Form1(d);
                Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (opc != 1)
            {
                textBox1.Text = d.Rows[index].Cells[0].Value + "";
                textBox2.Text = d.Rows[index].Cells[1].Value + "";
            }
        }
    }
}
