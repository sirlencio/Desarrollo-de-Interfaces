using Microsoft.VisualBasic;
using MySqlConnector;
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
        MySqlConnection sql = new MySqlConnection("server=localhost;user id=root;database=ahorcado;password=admin");
        string palabra, categoria;
        char[] huecos;
        int aciertos, fallos, ronda = 0, puntuacion = 0;
        bool terminado = false;
        usuario user;
        public Form3(usuario user, string categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            this.user = user;
            iniciar();
        }
        public void iniciar()
        {
            // Seleccionamos una palabra aleatoria guardandola en un arraylist           
            ArrayList palabras = new ArrayList();
            sql.Open();
            MySqlCommand comando = new MySqlCommand("Select palabra from biblioteca where categoria like '" + categoria + "'", sql);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                palabras.Add(reader.GetString(0));
            }
            sql.Close();

            Random random = new Random();
            int nrandom = random.Next(0, palabras.Count);
            palabra = (string)palabras[nrandom];

            //Rellenamos la palabra a jugar con barras bajas y espacios
            huecos = new char[(palabra.Length * 2) - 1];
            for (int i = 0; i < huecos.Length; i++)
            {
                if (i % 2 == 0)
                {
                    huecos[i] = '_';
                }
                else
                {
                    huecos[i] = ' ';
                }
            }
            labelJug.Text = new string(huecos);

            //Reiniciamos los fallos y aciertos
            aciertos = 0;
            fallos = 0;
            ronda++;
            labelCat.Text = "Categoria: " + categoria;
            labelAciertos.Text = "Aciertos: " + aciertos;
            labelErrores.Text = "Errores: " + fallos;
            if (ronda != 11)
            {
                labelRondas.Text = "Rondas " + ronda + "/10";
            }

            //Ponemos todos los labels en blanco
            foreach (Label labels in panel1.Controls)
            {
                labels.ForeColor = Color.White;
            }

            vivo.Visible = true;
            vida1.Visible = false;
            vida2.Visible = false;
            vida3.Visible = false;
            vida4.Visible = false;
            vida5.Visible = false;
            vida6.Visible = false;
            muerto.Visible = false;
            feliz.Visible = false;

            labelResolver.Visible = true;
            labelRendir.Visible = true;
            labelTerminar.Visible = true;
            labelReintentar.Visible = false;
            labelInfo.Visible = false;
            textBox1.Visible = false;
            label17.Visible = false;

            terminado = false;
            panel1.Visible = true;
        }

        public Boolean comprobacion(string intro) //Metodo que comprueba si la letra introducida esta en la palabra
        {
            Boolean acertado = false;
            for (int i = 0; i < huecos.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (palabra[i / 2].ToString().ToLower() == intro.ToLower()) //Si la letra clickeada es igual a la letra que deberia estar
                    {
                        huecos[i] = intro[0];
                        labelJug.Text = new string(huecos);
                        acertado = true;
                    }
                }
            }
            return acertado;
        }

        public void clickLetra(object sender, EventArgs e) //Metodo que controla los clicks en las letras
        {
            Label lb = (Label)sender;
            //Comprueba si no hemos pulsado anteriormente esa letra
            if (lb.ForeColor == Color.White)
            {
                if (comprobacion(lb.Text)) //Si la letra esta en la palabra, sumamos un acierto
                {
                    colorLetra(lb.Text, true);
                    puntuacion = puntuacion + 2;
                    aciertos++;
                }
                else
                {
                    colorLetra(lb.Text, false);
                    fallos++;
                }
            }
            labelAciertos.Text = "Aciertos: " + aciertos;
            labelErrores.Text = "Errores: " + fallos;
            juego();
        }

        private void colorLetra(string intro, Boolean acertado) //Metodo que cambia el color a la letra pulsada
        {
            foreach (Label labels in panel1.Controls)
            {
                if (acertado)
                {
                    if (labels.Text.Equals(intro))
                    {
                        labels.ForeColor = Color.Green;
                    }
                }
                else
                {
                    if (labels.Text.Equals(intro))
                    {
                        labels.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void form3TeclaPulsada(object sender, KeyEventArgs e) // Metodo que comprueba las teclas pulsadas por teclado
        {
            if (terminado == false)
            {
                int valorTecla = e.KeyValue;
                string letraTecla = e.KeyData.ToString();
                //Comprobamos que las teclas pulsadas son letras
                if ((valorTecla >= 65 && valorTecla <= 90) || valorTecla == 192)
                {
                    foreach (Label labels in panel1.Controls)
                    {
                        //Comprobamos que la etiqueta pulsada no este pulsada anteriormente
                        if (labels.Text.Equals(letraTecla) && labels.ForeColor == Color.White)
                        {
                            if (comprobacion(letraTecla))
                            {
                                colorLetra(letraTecla, true);
                                puntuacion += 2;
                                aciertos++;
                            }
                            else
                            {
                                colorLetra(letraTecla, false);
                                fallos++;
                            }
                        }
                        //Comprobamos que la tecla pulsada es la ñ y no se ha pulsado anteriormente
                        else if (valorTecla == 192 && labels.Text.Equals("Ñ") && labels.ForeColor == Color.White)
                        {
                            if (comprobacion("Ñ"))
                            {
                                colorLetra("Ñ", true);
                                puntuacion += 2;
                                aciertos++;
                            }
                            else
                            {
                                colorLetra("Ñ", false);
                                fallos++;
                            }
                        }
                    }
                    labelAciertos.Text = "Aciertos: " + aciertos;
                    labelErrores.Text = "Errores: " + fallos;
                    juego();
                }
            }
        }

        private void labelResolver_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Text = "";
            terminado = true;
            textBox1.Visible = true;
            panel1.Visible = false;
            label17.Visible = true;
            labelResolver.Visible = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (palabra.ToLower().Equals(textBox1.Text.ToLower()))
            {
                puntuacion += 10;

                labelInfo.Text = "¡Has ganado!";
                labelInfo.Visible = true;

                labelRendir.Visible = false;
                labelReintentar.Visible = true;
                labelResolver.Visible = false;
                labelJug.Text = palabra.ToUpper();
                label17.Visible = false;
                textBox1.Visible = false;
                feliz.Visible = true;
                vivo.Visible = true;
                vida1.Visible = false;
                vida2.Visible = false;
                vida3.Visible = false;
                vida4.Visible = false;
                vida5.Visible = false;
                vida6.Visible = false;
            }
            else
            {
                puntuacion -= 5;
                labelInfo.Text = "¡Has perdido!";
                labelInfo.Visible = true;

                label17.Visible = false;
                textBox1.Visible = false;
                muerto.Visible = true;
                vida6.Visible = false;
                labelJug.Text = palabra.ToUpper();
                labelTerminar.Visible = true;
                labelReintentar.Visible = true;
                labelRendir.Visible = false;
                labelResolver.Visible = false;
            }
        }

        private void labelRendir_Click(object sender, EventArgs e)
        {
            muerto.Visible = true;
            vivo.Visible = false;
            panel1.Visible = false;
            labelJug.Text = palabra.ToUpper();
            labelRendir.Visible = false;
            terminado = true;
            textBox1.Visible = false;
            label17.Visible = false;
            labelResolver.Visible = false;
            labelReintentar.Visible = true;
            labelInfo.Text = "¡Has perdido!";
            labelInfo.Visible = true;
            puntuacion -= 5;
        }
        private void labelTerminar_Click(object sender, EventArgs e)
        {
            if (!user.Nombre.Equals("Invitado"))
            {
                sql.Open();
                MySqlCommand cmdinsert = new MySqlCommand("insert into puntuaciones values ('" + user.Nombre + "','" + categoria + "'," + ronda + "," + puntuacion + ",'" + DateTime.Now + "')", sql);
                cmdinsert.ExecuteNonQuery();
                sql.Close();
            }
            this.Close();
        }
        private void labelReintentar_Click(object sender, EventArgs e)
        {
            if (textBox1.ContainsFocus)
            {
                this.ActiveControl = null;
            }
            iniciar();
        }

        private void juego()
        {
            //Control fallos
            switch (fallos)
            {
                case 1:
                    vida1.Visible = true;
                    vivo.Visible = false;
                    puntuacion -= 1;
                    break;
                case 2:
                    vida2.Visible = true;
                    vida1.Visible = false;
                    puntuacion -= 1;
                    break;
                case 3:
                    vida3.Visible = true;
                    vida2.Visible = false;
                    puntuacion -= 1;
                    break;
                case 4:
                    vida4.Visible = true;
                    vida3.Visible = false;
                    puntuacion -= 1;
                    break;
                case 5:
                    vida5.Visible = true;
                    vida4.Visible = false;
                    puntuacion -= 1;
                    break;
                case 6:
                    vida6.Visible = true;
                    vida5.Visible = false;
                    puntuacion -= 1;
                    break;
                case 7:
                    puntuacion -= 5;
                    muerto.Visible = true;
                    vida6.Visible = false;
                    labelJug.Text = palabra.ToUpper();
                    labelResolver.Visible = false;
                    terminado = true;
                    panel1.Visible = false;
                    labelTerminar.Visible = true;
                    labelReintentar.Visible = true;
                    labelRendir.Visible = false;
                    labelResolver.Visible = false;
                    labelInfo.Text = "¡Has perdido!";
                    labelInfo.Visible = true;
                    break;
            }
            //Si gana
            if (!labelJug.Text.Contains("_") && !terminado)
            {
                puntuacion += 10;

                labelInfo.Text = "¡Has ganado!";
                labelInfo.Visible = true;

                panel1.Visible = false;
                terminado = true;
                labelRendir.Visible = false;
                labelReintentar.Visible = true;
                labelResolver.Visible = false;
                feliz.Visible = true;
                vivo.Visible = true;
                vida1.Visible = false;
                vida2.Visible = false;
                vida3.Visible = false;
                vida4.Visible = false;
                vida5.Visible = false;
                vida6.Visible = false;
            }
        }
    }
}
