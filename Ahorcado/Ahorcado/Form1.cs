using System.Xml;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        XmlDocument doc = new XmlDocument();
        string[] baraja;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doc.Load("../../../../base.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string text = node.LocalName;
                comboBox1.Items.Add(text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Form2 form2 = new Form2(baraja);
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una categoria", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String nombrenodo = comboBox1.Text;
            XmlNode node = doc.DocumentElement.SelectSingleNode("/categorias/" + nombrenodo);
            int cont = 0;
            foreach (XmlNode node1 in node)
            {
                cont++;
            }
            baraja = new string[cont];
            cont = 0;
            foreach (XmlNode node1 in node)
            {
                String text = node1.InnerText;
                baraja[cont] = text;
                cont++;
            }
        }

    }
}