namespace Ejercicio7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n1 = Int32.Parse(textBox1.Text);
            int n2 = Int32.Parse(textBox2.Text);
            int n3 = Int32.Parse(textBox3.Text);

            int sum = n1 + n2 + n3;
            int rest = n1 - n2 - n3;   
            int mult = n1 * n2 * n3;
            double div = n1 / n2 / n3;

            if (suma.Checked)
            {
                rdo.Text = "Resultados: \n" + sum;
            }
            if (resta.Checked)
            {
                rdo.Text = "Resultados: \n" + rest;
            }
            if (multiplica.Checked)
            {
                rdo.Text = "Resultados: \n" + mult;
            }
            if (divide.Checked)
            {
                rdo.Text = "Resultados: \n" + div;
            }
            if (todas.Checked)
            {
                rdo.Text = "Resultados: \nSuma: " + sum
                                      +"\nResta: " + rest
                                      +"\nMultiplicacion: " + mult 
                                      +"\nDivision: " + div;
            }
        }
    }
}