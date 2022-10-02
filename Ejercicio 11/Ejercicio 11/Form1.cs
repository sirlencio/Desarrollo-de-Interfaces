namespace Ejercicio_11
{
    public partial class Ejercicio11 : Form
    {
        int sies = 0;
        int noes = 0;
        int nose = 0;

        public Ejercicio11()
        {
            InitializeComponent();
        }

        private void Ejercicio11_Load(object sender, EventArgs e)
        {
            actualiza();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                sies++;
                actualiza();
            }else if (radioButton2.Checked){
                noes++;
                actualiza();
            }else if(radioButton3.Checked){
                nose++;
                actualiza();
            }
        }
        public void actualiza()
        {
            int rdo = sies + noes + nose;
            if (rdo > 0) { 
            si.Text = sies + " sies   " + (sies * 100) / rdo + "%";
            no.Text = noes + " noes   " + (noes * 100) / rdo + "%";
            nsnc.Text = nose + " no saben   " + (nose * 100) / rdo + "%";
            }
            else
            {
                si.Text = sies + " sies   ";
                no.Text = noes + " noes   ";
                nsnc.Text = nose + " no saben   ";
            }
            total.Text = rdo + " votos totales";
        }
    }
}