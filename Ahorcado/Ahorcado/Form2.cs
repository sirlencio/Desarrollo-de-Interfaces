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
        int aciertos, fallos, ronda = 0;
        Boolean perdido = false;
        public Form2(string[] baraja, string cat)
        {
            InitializeComponent();
            this.baraja = baraja;
            labelCat.Text = "Categoria: " + cat;
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
            labelRondas.Text = "Rondas " + ronda + "/10";

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
            reintentar.Visible = false;
            terminar.Visible = false;
            perdido = false;

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
            if (!perdido) 
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
            //Si gana
            if (!labelJug.Text.Contains("_"))
            {
                DialogResult dialog = MessageBox.Show("Has ganado!! \nQuieres seguir jugando?", "Felicidades", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    if (ronda == 9)
                    {
                        MessageBox.Show("Esta sera la ultima ronda", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        iniciar();
                    }
                    else if(ronda == 10)
                    {
                        MessageBox.Show("Esta era la ultima ronda", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else
                    {
                        iniciar();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            //Si va perdiendo
            switch (fallos)
            {
                case 1:
                    vida1.Visible= true;
                    vivo.Visible= false;
                    break;
                case 2:
                    vida2.Visible = true;
                    vida1.Visible = false;
                    break;
                case 3:
                    vida3.Visible = true;
                    vida2.Visible = false;
                    break;
                case 4:
                    vida4.Visible = true;
                    vida3.Visible = false;
                    break;
                case 5:
                    vida5.Visible = true;
                    vida4.Visible = false;
                    break;
                case 6:
                    vida6.Visible = true;
                    vida5.Visible = false;
                    break;
                case 7:
                    muerto.Visible = true;
                    vida6.Visible = false;
                    labelJug.Text = palabra;
                    perdido = true;
                    panel1.Visible = false;
                    break;
            }

        }
        private void revelar_Click(object sender, EventArgs e)
        {
            muerto.Visible= true;
            vivo.Visible= false;
            panel1.Visible= false;
            labelJug.Text = palabra;
            perdido = true;
            terminar.Visible= true;
            reintentar.Visible= true;
        }
        private void terminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void reintentar_Click(object sender, EventArgs e)
        {
            iniciar();
        }
    }
}
