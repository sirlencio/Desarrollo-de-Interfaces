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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 alumnos = new Form2();
            alumnos.ShowDialog();
        }

        private void buscadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Form5 buscador = new Form5(dg);
            buscador.ShowDialog();*/
        }
    }
}
