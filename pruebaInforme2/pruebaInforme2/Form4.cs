using Microsoft.Reporting.WinForms;
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
    public partial class Form4 : Form
    {
        int nhab;
        public Form4(int nhab)
        {
            this.nhab = nhab;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'poblacionesDataSet.poblaciones' Puede moverla o quitarla según sea necesario.
            this.poblacionesTableAdapter.Fill(this.poblacionesDataSet.poblaciones);

            ReportParameter p = new ReportParameter("ParametroNhab", nhab.ToString());
            reportViewer1.LocalReport.SetParameters(p);

            this.reportViewer1.RefreshReport();
        }
    }
}
