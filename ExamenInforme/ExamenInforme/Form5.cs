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
    public partial class Form5 : Form
    {
        String cod, nombre;
        public Form5(String cod, String nombre)
        {
            this.cod = cod;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'worldDataSet.city' Puede moverla o quitarla según sea necesario.
            this.cityTableAdapter.Fill(this.worldDataSet.city);


            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("ParametroCode", cod);
            parametros[1] = new ReportParameter("ParametroNombre", nombre);
            reportViewer1.LocalReport.SetParameters(parametros);


            this.reportViewer1.RefreshReport();
        }
    }
}
