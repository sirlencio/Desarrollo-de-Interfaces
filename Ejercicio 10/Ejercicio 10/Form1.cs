namespace Ejercicio_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            float precio1 = float.Parse(textBox3.Text);
            float precio2 = float.Parse(textBox6.Text);
            float precio3 = float.Parse(textBox9.Text);
            int cant1 = Int32.Parse(textBox2.Text);
            int cant2 = Int32.Parse(textBox5.Text);
            int cant3 = Int32.Parse(textBox8.Text);
            float total = (precio1 * cant1) + (precio2 * cant2) + (precio3 * cant3);

            textBox10.Text = total + "";
            textBox11.Text = total * 1.21 + "";
        }
    }
}