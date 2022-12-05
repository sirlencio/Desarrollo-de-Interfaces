using Microsoft.VisualBasic;
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
        string palabra;
        char[] huecos;
        int aciertos, fallos, ronda = 0, puntuacion = 0;
        Boolean terminado = false;
        usuario user;
        public Form2(string[] baraja, string cat, usuario user)
        {
            InitializeComponent();
            this.baraja = baraja;
            labelCat.Text = "Categoria: " + cat;
            this.user = user;
            iniciar();
        }
        public void iniciar()
        {
            Random random = new Random();
            int nrandom = random.Next(0, baraja.Length);
            palabra = baraja[nrandom]; //Elegimos una palabra aleatoria de nuestra baraja de palabras

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
            labelAciertos.Text = "Aciertos: " + aciertos;
            labelErrores.Text = "Errores: " + fallos;
            if (ronda != 11)
            {
                labelRondas.Text = "Rondas " + ronda + "/10";
            }

            if (ronda == 10)
            {
                MessageBox.Show("Esta sera la ultima ronda", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            if (ronda == 11)
            {
                MessageBox.Show("Esta era la ultima ronda", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // user.nombre = Interaction.InputBox("Introduzca el nombre de usuario", "Atencion", "user");
                user.puntuacion = puntuacion;
                user.nronda = ronda;
                this.Close();
            }
            //Ponemos todos los labels en negro
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
            reintentar.Visible = false;
            terminar.Visible = true;
            terminado = false;
            panel1.Visible = true;
            revelar.Visible = true;

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
        private void form2TeclaPulsada(object sender, KeyEventArgs e) //Metodo que comprueba las teclas pulsadas por teclado
        {
            if (!terminado) 
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
                                puntuacion = puntuacion + 2;
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
                                puntuacion = puntuacion + 2;
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
        private void juego()
        {
            //Control fallos
            switch (fallos)
            {
                case 1:
                    vida1.Visible = true;
                    vivo.Visible = false;
                    puntuacion = puntuacion - 1;
                    break;
                case 2:
                    vida2.Visible = true;
                    vida1.Visible = false;
                    puntuacion = puntuacion - 1;
                    break;
                case 3:
                    vida3.Visible = true;
                    vida2.Visible = false;
                    puntuacion = puntuacion - 1;
                    break;
                case 4:
                    vida4.Visible = true;
                    vida3.Visible = false;
                    puntuacion = puntuacion - 1;
                    break;
                case 5:
                    vida5.Visible = true;
                    vida4.Visible = false;
                    puntuacion = puntuacion - 1;
                    break;
                case 6:
                    vida6.Visible = true;
                    vida5.Visible = false;
                    puntuacion = puntuacion - 1;
                    break;
                case 7:
                    muerto.Visible = true;
                    vida6.Visible = false;
                    labelJug.Text = palabra;
                    terminado = true;
                    panel1.Visible = false;
                    terminar.Visible = true;
                    reintentar.Visible = true;
                    revelar.Visible = false;
                    puntuacion = puntuacion - 5;
                    MessageBox.Show("Has perdido", "Lo siento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
            //Si gana
            if (!labelJug.Text.Contains("_") && !terminado)
            {
                MessageBox.Show("Has ganado", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                puntuacion = puntuacion + 10;
                panel1.Visible = false;
                terminado = true;
                revelar.Visible = false;
                reintentar.Visible = true;
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
        private void revelar_Click(object sender, EventArgs e)
        {
            muerto.Visible= true;
            vivo.Visible= false;
            panel1.Visible= false;
            labelJug.Text = palabra;
            terminado = true;
            reintentar.Visible= true;
        }
        private void terminar_Click(object sender, EventArgs e)
        {
           // user.nombre = Interaction.InputBox("Introduzca el nombre de usuario", "Atencion", "user");
            user.puntuacion = puntuacion;
            user.nronda = ronda;
            this.Close();
        }
        private void reintentar_Click(object sender, EventArgs e)
        {
            iniciar();
        }
    }
}
