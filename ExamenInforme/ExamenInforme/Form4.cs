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

namespace ExamenInforme
{
    public partial class Form4 : Form
    {
        String nhab;
        public Form4(String nhab)
        {
            this.nhab = nhab;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'worldDataSet.city' Puede moverla o quitarla según sea necesario.
            this.cityTableAdapter.Fill(this.worldDataSet.city);

            ReportParameter p = new ReportParameter("ParametroNhab", nhab);
            reportViewer1.LocalReport.SetParameters(p);

            this.reportViewer1.RefreshReport();
        }
    }
}
