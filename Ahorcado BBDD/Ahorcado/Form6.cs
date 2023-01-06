using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form6 : Form
    {
        usuario user;
        public Form6(usuario user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
