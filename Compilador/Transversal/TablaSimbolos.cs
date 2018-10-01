using Compilador.AnalizadorLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Transversal
{
    public class TablaSimbolos
    {
        private static TablaSimbolos INSTACIA = new TablaSimbolos();
        private Dictionary<string, List<ComponenteLexico>> simbolos = new Dictionary<string, List<ComponenteLexico>>(); //Porque un mismo simbolo se puede tener en varios lugares

        private TablaSimbolos() { }
    
        public static TablaSimbolos obtenerInstancia()
        {
            return INSTACIA;
        }

        private List<ComponenteLexico> obtenerSimbolo(string lexema)
        {
            if (!simbolos.ContainsKey(lexema))
            {
                simbolos.Add(lexema, new List<ComponenteLexico>());
            }
            return simbolos[lexema];
        }

        public void agregar(ComponenteLexico componente)
        {
            if (componente != null && componente.Lexema != null && componente.Tipo.Equals(TipoComponente.SIMBOLO))
            {
                obtenerSimbolo(componente.Lexema).Add(componente);
            }
        }

        public Dictionary<string, List<ComponenteLexico>> obtenerSimbolos()
        {
            return simbolos;
        }

    }
}
