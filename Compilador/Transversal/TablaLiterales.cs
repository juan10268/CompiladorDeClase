using Compilador.AnalizadorLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Transversal
{
    class TablaLiterales
    {
        private static TablaLiterales INSTACIA = new TablaLiterales();
        private Dictionary<string, List<ComponenteLexico>> literales = new Dictionary<string, List<ComponenteLexico>>(); //Porque un mismo simbolo se puede tener en varios lugares

        private TablaLiterales() { }

        public static TablaLiterales obtenerInstancia()
        {
            return INSTACIA;
        }

        private List<ComponenteLexico> obtenerLiteral(string lexema)
        {
            if (!literales.ContainsKey(lexema))
            {
                literales.Add(lexema, new List<ComponenteLexico>());
            }
            return literales[lexema];
        }

        public void agregar(ComponenteLexico componente)
        {
            if (componente != null && componente.Lexema != null && componente.Tipo.Equals(TipoComponente.LITERAL))
            {
                obtenerLiteral(componente.Lexema).Add(componente);
            }
        }

        public Dictionary<string, List<ComponenteLexico>> obtenerLiterales()
        {
            return literales;
        }

    }
}

