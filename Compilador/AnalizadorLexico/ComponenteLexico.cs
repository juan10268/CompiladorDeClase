using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.AnalizadorLexico
{
    public class ComponenteLexico
    {
        public String Lexema { get; set; }
        public String Categoria { get; set; }
        public int NumeroLinea { get; set; }
        public int PosicionInicial { get; set; } //Se manejaria con el puntero
        public int PosicionFinal { get; set; }
        public TipoComponente Tipo { get; set; }

        public ComponenteLexico()
        {
        }

        public ComponenteLexico(String Lexema, String Categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal){
            this.NumeroLinea = NumeroLinea;
            this.PosicionInicial = PosicionInicial;
            this.PosicionFinal = PosicionFinal;
            this.Lexema = Lexema;
            this.Categoria = Categoria;
            Tipo = TipoComponente.SIMBOLO;
        }

        public String imprimir(){
            StringBuilder resultado = new StringBuilder();
            resultado.Append("Categoria-> " + Categoria+ "\n");
            resultado.Append("Lexema-> " + Lexema + "\n");
            resultado.Append("Numero de Linea-> " + NumeroLinea + "\n");
            resultado.Append("Posicion Inicial-> " + PosicionInicial + "\n");
            resultado.Append("Posicion Final-> " + PosicionFinal + "\n");

            return resultado.ToString();
        }
    }
}

