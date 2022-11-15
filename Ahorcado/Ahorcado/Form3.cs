using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        public Form3(ArrayList array)
        {
            InitializeComponent();
            foreach(usuario user in array)
            {
                dataGridView1.Rows.Add(user.nombre, user.puntuacion, user.nronda);
                dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
                dataGridView1.ClearSelection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }        
}
