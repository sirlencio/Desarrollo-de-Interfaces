using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaInforme2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'poblacionesDataSet.poblaciones' Puede moverla o quitarla según sea necesario.
            this.poblacionesTableAdapter.Fill(this.poblacionesDataSet.poblaciones);

            this.reportViewer1.RefreshReport();
        }
    }
}
