using Compilador.AnalizadorLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Transversal
{
    public class TablaPalabrasReservadas
    {
        private static TablaPalabrasReservadas INSTACIA = new TablaPalabrasReservadas(); //Singleton
        private Dictionary<string, ComponenteLexico> palabrasReservadas = new Dictionary<string, ComponenteLexico>();
        private Dictionary<string, List<ComponenteLexico>> palabrasReservadasIngresadas = new Dictionary<string, List<ComponenteLexico>>();

        public static TablaPalabrasReservadas obtenerInstancia()
        {
            return INSTACIA;
        }


        private TablaPalabrasReservadas()
        {
            palabrasReservadas.Add("INICIO", new ComponenteLexico("INICIO", "INSTRUCCION INICIO", 0, 0, 0));
            palabrasReservadas.Add("FIN", new ComponenteLexico("FIN", "INSTRUCCION FIN", 0, 0, 0)); 
            palabrasReservadas.Add("SI", new ComponenteLexico("SI", "CONDICIONAL SI", 0, 0, 0));
            palabrasReservadas.Add("SINO", new ComponenteLexico("SINO", "CONDICIONAL SINO", 0, 0, 0));
            palabrasReservadas.Add("ENTONCES", new ComponenteLexico("ENTONCES", "INSTRUCCION ENTONCES", 0, 0, 0));
            palabrasReservadas.Add("HACER", new ComponenteLexico("HACER", "INSTRUCCION HACER", 0, 0, 0));
            palabrasReservadas.Add("HASTA", new ComponenteLexico("HASTA", "INSTRUCCION HASTA", 0, 0, 0));
            palabrasReservadas.Add("PARA", new ComponenteLexico("PARA", "INSTRUCCION PARA", 0, 0, 0));
            palabrasReservadas.Add("MIENTRAS", new ComponenteLexico("MIENTRAS", "INSTRUCCION MIENTRAS", 0, 0, 0));

            palabrasReservadas.Add("ENTERO", new ComponenteLexico("ENTERO", "NUMERO ENTERO", 0, 0, 0));
            palabrasReservadas.Add("DECIMAL", new ComponenteLexico("DECIMAL", "NUMERO DECIMAL", 0, 0, 0));
            palabrasReservadas.Add("FECHA", new ComponenteLexico("FECHA", "FECHA", 0, 0, 0));
            palabrasReservadas.Add("TEXTO", new ComponenteLexico("TEXTO", "TEXTO", 0, 0, 0));
            palabrasReservadas.Add("CARACTER", new ComponenteLexico("CARACTER", "CARACTER", 0, 0, 0));
        }

        public Dictionary<string, ComponenteLexico> obtenerPalabrasReservadas()
        {
            return palabrasReservadas;
        }

        public bool esPalabraReservada(ComponenteLexico componente)
        {
            if (componente != null && palabrasReservadas.ContainsKey(componente.Lexema)) ;
            return false;

        }

        private List<ComponenteLexico> obtenerPalabraReservada(String lexema)
        {
            if (!palabrasReservadasIngresadas.ContainsKey(lexema))
            {
                palabrasReservadasIngresadas.Add(lexema, new List<ComponenteLexico>());
            }
            return palabrasReservadasIngresadas[lexema];
        }

        public void agregar(ComponenteLexico componente)
        {
            if (componente != null && componente.Lexema != null && esPalabraReservada(componente))
            {
                componente.Tipo = TipoComponente.PALABRA_RESERVADA;
                componente.Categoria = palabrasReservadas[componente.Lexema].Categoria;
                obtenerPalabraReservada(componente.Lexema).Add(componente);
            }
        }
    }
}
