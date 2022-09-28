namespace Ejercicio_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(comboBox1.SelectedIndex == 0)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int total = Int32.Parse(textBox1.Text);
            int entregado = Int32.Parse(textBox2.Text);
            calCambio(total, entregado);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int total = Int32.Parse(textBox1.Text);
            int entregado = Int32.Parse(textBox2.Text);
            calCambio(total, entregado);
        }

        private void calCambio(int total, int entregado)
        {

            if (total > 0 & entregado > 0)
            {
                int cambio = total - entregado;
                textBox3.Text = cambio.ToString();
            }
        }
    }
}