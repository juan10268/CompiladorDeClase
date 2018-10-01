using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class Linea
    {
        private int numero;
        private String contenido;

        public Linea(int Numero, string Contenido)
        {
            this.numero = Numero;
            this.contenido = Contenido;
        }

        public Linea() { }
        public int Numero { get => numero; set => numero = value; }
        public string Contenido { get => contenido; set => contenido = value; }
    }
}
