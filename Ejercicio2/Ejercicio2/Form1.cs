namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String palabra = textPalabra.Text;
            char letra = char.Parse(textLetra.Text);
            int cont = 0;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i].Equals(letra))
                {
                    cont++;
                }
            }
            solucion.Text = "Se repite " + cont.ToString() + " veces";
        }
    }
}