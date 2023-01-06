using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class usuario
    {
        private int id;
        private string nombre;
        private string pwd;
        private Boolean super;

        public usuario()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public bool Super { get => super; set => super = value; }
    }
}
