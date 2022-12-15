using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 gestion = new Form2();
            gestion.ShowDialog();
        }

        private void combosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 combos = new Form4();
            combos.ShowDialog();
        }
    }
}
