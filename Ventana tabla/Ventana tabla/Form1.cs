namespace Ventana_tabla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(DataGridView d)
        {
            InitializeComponent();
            this.dataGridView1 = d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataGridView1, 1);
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Form2 form2 = new Form2(dataGridView1, 2, index);
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}