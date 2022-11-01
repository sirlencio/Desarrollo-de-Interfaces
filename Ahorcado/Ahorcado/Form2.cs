using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form2 : Form
    {
        string[] baraja;
        public Form2(string[] baraja)
        {
            InitializeComponent();
            this.baraja = baraja;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = baraja[0];
        }
    }
}
