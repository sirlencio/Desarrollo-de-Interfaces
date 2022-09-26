namespace aplication
{
    public partial class Form1 : Form
    {
        int num;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int intro = Int32.Parse(textBox1.Text);
            if (intro > num)
            {
                label2.Text = "Es mas pequeño";
            }
            if (intro < num)
            {
                label2.Text = "Es mas grande";
            }
            if (intro == num)
            {
                label3.Visible = false;
                label2.Text = "HAS GANADO";
                button1.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            num = random.Next(0, 51);
        }
    }
}