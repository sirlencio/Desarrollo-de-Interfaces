using MySqlConnector;
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
    public partial class Form3 : Form
    {
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=examen;database=examen;password=examen");
        DataGridView dg;
        int opc, index, codigo;
        public Form3()
        {
            InitializeComponent();
            cargarProvincias();
        }

        public Form3(DataGridView dg, int opc, int index)
        {
            InitializeComponent();
            this.dg = dg;
            this.opc = opc;
            this.index = index;
            cargarProvincias();
        }

        private void cargarProvincias()
        {
            provincia p; 
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from provincias", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                p = new provincia(reader.GetInt32(0), reader.GetString(1));
                comboBox1.Items.Add(p);
            }
            sql.Close();

            if (opc == 1)
            {
                codigo = Int32.Parse(dg.Rows[index].Cells[0].Value.ToString());
                textBox1.Text = dg.Rows[index].Cells[1].Value.ToString();
                textBox2.Text = dg.Rows[index].Cells[2].Value.ToString();

                sql.Open();
                MySqlCommand select = new MySqlCommand("Select provincia from provincias where id like " + dg.Rows[index].Cells[3].Value.ToString(), sql);
                MySqlDataReader rd = select.ExecuteReader();
                rd.Read();
                comboBox1.Text = rd.GetString(0);
                sql.Close();

                municipio mun;
                sql.Open();
                MySqlCommand selectmun = new MySqlCommand("Select * from municipios where provincia like (select id from provincias where provincia like '" +
                    comboBox1.Text + "')" , sql);
                MySqlDataReader red = selectmun.ExecuteReader();
                while (red.Read())
                {
                    mun = new municipio(red.GetInt32(0), red.GetInt32(1), red.GetString(2));
                    if (mun.id == Int32.Parse(dg.Rows[index].Cells[4].Value.ToString()))
                    {
                        comboBox2.Text = mun.nombre;
                    }
                    comboBox2.Items.Add(mun);
                }
                sql.Close();



                textBox3.Text = dg.Rows[index].Cells[5].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql.Close();
            provincia provselec = (provincia)comboBox1.SelectedItem;
            municipio m;
            comboBox2.Items.Clear();
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select * from municipios where provincia like " + provselec.id, sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                m = new municipio(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                comboBox2.Items.Add(m);
            }
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text !="" && textBox3.Text != "" && comboBox1.Text !="" && comboBox2.Text != "")
            {
                string nombre = textBox1.Text;
                string apellidos = textBox2.Text;
                string tlfno = textBox3.Text;
                string fecha = dateTimePicker1.Text;
                provincia seleccionada = (provincia)comboBox1.SelectedItem;
                int idprov = seleccionada.id;

                municipio seleccionado = (municipio)comboBox2.SelectedItem;
                int idmun = seleccionado.id;

                if (opc == 1) //Modificar
                {
                    sql.Open();
                    MySqlCommand mod = new MySqlCommand("update vendedores set nombre ='" + nombre + "', apellidos='" + apellidos + "', provincia=" + idprov + ", municipio=" + idmun
                        + ",telefono='" + tlfno + "',fechaalta='" + fecha + "' where codigo =" + codigo + "", sql);
                    mod.ExecuteNonQuery();
                    sql.Close();
                }
                else // Alta
                {
                    int id;
                    sql.Open();
                    MySqlCommand contar = new MySqlCommand("Select count(nombre) from vendedores", sql);
                    MySqlDataReader reader = contar.ExecuteReader();
                    reader.Read();
                    id = reader.GetInt32(0) + 1;
                    sql.Close();

                    sql.Open();
                    MySqlCommand añadir = new MySqlCommand("Insert into vendedores values ("+ id + ",'" + nombre + "','" + apellidos + "'," + idprov + "," + idmun + ",'" + tlfno + "','"+ fecha + "')", sql);
                    añadir.ExecuteNonQuery();
                    sql.Close();

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Faltan datos", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public class provincia
        {
            public int id;
            public string nombre;
            public provincia(int id, string nombre)
            {
                this.id = id;
                this.nombre = nombre;
            }
            public override string ToString()
            {
                return nombre;
            }
        }
        public class municipio
        {
            public int id_prov, id;
            public string nombre;
            public municipio(int id, int id_prov, string nombre)
            {
                this.id = id;
                this.id_prov = id_prov;
                this.nombre = nombre;
            }
            public override string ToString()
            {
                return nombre;
            }
        }
    }
}
