using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.ManejadorErrores
{
    public enum TipoError
    {
        LEXICO, SINTACTICO, SEMANTICO, GENERADOR_CODIGO_INTERMEDIO, OPTIMIZADOR, GENERADOR_CODIGO_FINAL
    }
}
