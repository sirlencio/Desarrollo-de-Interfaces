namespace Ejercicio_12
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

        private void button1_Click(object sender, EventArgs e)
        {
            String frase = textBox1.Text;
            int chars  = 0;
            int espacios = 0;
            if (!listBox1.Items.Contains(frase))
            {
                listBox1.Items.Add(frase);
            }
           for (int i = 0; i < listBox1.Items.Count; i++)
            {
                String palabra = listBox1.Items[i].ToString();
                chars = palabra.Length + chars;
                for (int j = 0; j < palabra.Length; j++)
                {
                    if (palabra[j] == " "[0])
                    {
                        espacios++;
                    }
                }
                
            }
            textBox2.Text = "Tiene " + listBox1.Items.Count + " palabras" + Environment.NewLine +
                "Tiene " + chars + " caracteres" + Environment.NewLine +
                "Tiene " + espacios + " espacios en blanco";
        }
    }
}