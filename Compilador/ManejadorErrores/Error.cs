using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.ManejadorErrores
{
    public class Error
    {
        public String Lexema { get; set; }
        public TipoError Tipo { get; set; }
        public int NumeroLinea { get; set; }
        public int PosicionInicial { get; set; } //Se manejaria con el puntero
        public int PosicionFinal { get; set; }
        public String Causa { get; set; }
        public String Falla { get; set; }
        public String Solucion { get; set; }

        public Error(){}

        public Error(String Lexema, TipoError tipoError, int NumeroLinea, int PosicionInicial, int PosicionFinal, String causa, String falla, String solucion)
        {
            this.NumeroLinea = NumeroLinea;
            this.PosicionInicial = PosicionInicial;
            this.PosicionFinal = PosicionFinal;
            this.Lexema = Lexema;
            this.Tipo = tipoError;
            this.Causa = causa;
            this.Falla = falla;
            this.Solucion = solucion;
        }

        public String imprimir()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append("Lexema-> " + Lexema + "\n");
            resultado.Append("Tipo-> " + Tipo + "\n");
            resultado.Append("Numero de Linea-> " + NumeroLinea + "\n");
            resultado.Append("Posicion Inicial-> " + PosicionInicial + "\n");
            resultado.Append("Posicion Final-> " + PosicionFinal + "\n");
            resultado.Append("Causa-> " + Causa + "\n");
            resultado.Append("Falla-> " + Falla + "\n");
            resultado.Append("Solucion-> " + Solucion + "\n");
            return resultado.ToString();
        }
    }
}
