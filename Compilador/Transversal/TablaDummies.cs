using Compilador.AnalizadorLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Transversal
{
    class TablaDummies
    {
        private static TablaDummies INSTACIA = new TablaDummies();
        private Dictionary<string, List<ComponenteLexico>> dummies = new Dictionary<string, List<ComponenteLexico>>(); //Porque un mismo simbolo se puede tener en varios lugares

        private TablaDummies() { }

        public static TablaDummies obtenerInstancia()
        {
            return INSTACIA;
        }

        private List<ComponenteLexico> obtenerDummy(string lexema)
        {
            if (!dummies.ContainsKey(lexema))
            {
                dummies.Add(lexema, new List<ComponenteLexico>());
            }
            return dummies[lexema];
        }

        public void agregar(ComponenteLexico componente)
        {
            if (componente != null && componente.Lexema != null && componente.Tipo.Equals(TipoComponente.LITERAL))
            {
                obtenerDummy(componente.Lexema).Add(componente);
            }
        }

        public Dictionary<string, List<ComponenteLexico>> obtenerLiterales()
        {
            return dummies;
        }

    }
}


