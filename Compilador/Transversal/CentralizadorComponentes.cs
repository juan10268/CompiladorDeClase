using Compilador.AnalizadorLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Transversal
{
    class CentralizadorComponentes
    {

        private CentralizadorComponentes()
        {

        }

        public static void sincronizar(ComponenteLexico componente)
        {
            if(componente != null)
            {
                switch (componente.Tipo)
                {
                    case TipoComponente.PALABRA_RESERVADA:
                    case TipoComponente.SIMBOLO:
                        if (TablaPalabrasReservadas.obtenerInstancia().esPalabraReservada(componente))
                        {
                            TablaPalabrasReservadas.obtenerInstancia().agregar(componente);

                        }else
                        {
                            TablaSimbolos.obtenerInstancia().agregar(componente);
                        }
                        break;

                    case TipoComponente.LITERAL:
                        TablaLiterales.obtenerInstancia().agregar(componente);
                        break;

                    case TipoComponente.DUMMY:
                        TablaDummies.obtenerInstancia().agregar(componente);
                        break;
                }
            }
        }
    }
}
