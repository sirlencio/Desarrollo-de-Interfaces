namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items.Contains(textBox1.Text))
                {
                    MessageBox.Show("Ya esta metida la palabra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            comboBox1.Items.Add(textBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Usted ha seleccionado la palabra " + comboBox1.SelectedItem.ToString() + " que se encuentra en la posicion " + comboBox1.SelectedIndex.ToString();
        }
    }
}