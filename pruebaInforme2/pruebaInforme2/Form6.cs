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
    public partial class Form6 : Form
    {
        String hasta, desde;
        public Form6(String hasta, String desde)
        {
            this.hasta = hasta;
            this.desde = desde;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'poblacionesDataSet.poblaciones' Puede moverla o quitarla según sea necesario.
            this.poblacionesTableAdapter.Fill(this.poblacionesDataSet.poblaciones);

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("ParametroHasta", hasta);
            parametros[1] = new ReportParameter("ParametroDesde", desde);
            reportViewer1.LocalReport.SetParameters(parametros);

            this.reportViewer1.RefreshReport();
        }
    }
}
