using Compilador.ManejadorErrores;
using Compilador.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Compilador.AnalizadorLexico
{
    class AnalisisLexico
    {
        private int numeroLineaActual = 0;
        private String contenidoLineaActual;
        private int puntero;
        private String caracterActual;

        private void devolverPuntero() {
            puntero = puntero - 1;
        }

        public AnalisisLexico() {
            cargarNuevaLinea();
        }

        private void cargarNuevaLinea(){
            if (!"@EOF@".Equals(contenidoLineaActual))
            {
                //Para cambiar a la linea siguiente
                numeroLineaActual = numeroLineaActual + 1;
                puntero = 1;
                contenidoLineaActual = CacheEntrada.obtenerInstancia().devolverLinea(numeroLineaActual).Contenido;
            }
            else if (contenidoLineaActual == null)
            {
                contenidoLineaActual = CacheEntrada.obtenerInstancia().devolverLinea(1).Contenido;
            }
        }

        private void leerSiguienteCaracter(){
            if ("@EOF@".Equals(contenidoLineaActual))
            {
                caracterActual = "@EOF@";
            }
            else if (puntero > contenidoLineaActual.Length)
            {
                caracterActual = "@FL@";
                puntero = puntero + 1;
            }
            else
            {
                caracterActual = contenidoLineaActual.Substring((puntero - 1), 1);
                puntero = puntero + 1;
            }
        }

        public ComponenteLexico devolverComponenteLexico(){
            int estadoActual = 0;
            String lexema = "";
            Boolean continuarAnalisis = true;
            ComponenteLexico componente= null;

            while (continuarAnalisis)
            {
                switch (estadoActual)
                {
                    case 0:
                        leerSiguienteCaracter();
                        // Devora los espacios en blanco
                        while (" ".Equals(caracterActual))
                        {
                            leerSiguienteCaracter();
                        }
                        if (char.IsLetter(caracterActual.ToCharArray()[0]) | "$".Equals(caracterActual) | "_".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 4;
                        }
                        else if (char.IsDigit(caracterActual.ToArray()[0]))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 1;
                        }
                        else if ("+".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 5;
                        }
                        else if ("-".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 6;
                        }
                        else if ("*".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 7;
                        }
                        else if ("/".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 8;
                        }
                        else if ("%".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 9;
                        }
                        else if ("(".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 10;
                        }
                        else if (")".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 11;
                        }
                        else if ("@EOF@".Equals(caracterActual))
                        {
                            estadoActual = 12;
                        }
                        else if ("=".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 19;
                        }
                        else if ("<".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 20;
                        }
                        else if (">".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 21;
                        }
                        else if (":".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 22;
                        }
                        else if ("!".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 30;
                        }
                        else if ("@FL@".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 18;
                        }
                        break;

                    case 1:
                        leerSiguienteCaracter();
                        if (char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 1;
                        }
                        else if (",".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 2;
                        }
                        else
                        {
                            estadoActual = 14;
                        }
                        break;
                    case 2:
                        leerSiguienteCaracter();
                        if (char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 3;
                        }
                        else
                        {
                            estadoActual = 17;
                        }
                        break;
                    case 3:
                        leerSiguienteCaracter();
                        if (char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 3;
                        }
                        else
                        {
                            estadoActual = 15;
                        }

                        break;
                    case 4:
                        leerSiguienteCaracter();
                        if (char.IsLetter(caracterActual.ToCharArray()[0]) || char.IsDigit(caracterActual.ToCharArray()[0])
                            || "$".Equals(caracterActual) || "_".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 4;
                        }
                        else
                        {
                            estadoActual = 16;
                        }
                        break;

                    case 5:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "SUMA");
                        break;
                    case 6:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "RESTA");
                        break;

                    case 7:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "MULTIPLICACION");
                        break;
                    case 8:
                        leerSiguienteCaracter();
                        if ("*".Equals(caracterActual))
                        {
                            estadoActual = 34;
                        }
                        else if ("/".Equals(caracterActual))
                        {
                            estadoActual = 36;
                        }
                        else
                        {
                            estadoActual = 33;
                        }
                        break;
                    case 9:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "MODULO");
                        break;
                    case 10:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "PARENTESIS ABRE");
                        break;
                    case 11:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "PARENTESIS CIERRA");
                        break;
                    case 12:
                        continuarAnalisis = false;
                        lexema = caracterActual;
                        componente = formarComponente(lexema, "FIN DE ARCHIVO");
                        break;
                    case 13:
                        // retorna salto de linea
                        lexema = "";
                        cargarNuevaLinea();
                        estadoActual = 0;
                        break;

                    case 14:
                        devolverPuntero();
                        continuarAnalisis = false;
                        //Formacion del componente Lexico
                        componente = formarComponente(lexema, "NUMERO ENTERO");
                        componente.Tipo = TipoComponente.LITERAL;
                        CentralizadorComponentes.sincronizar(componente);

                        break;

                    case 15:
                        devolverPuntero();
                        continuarAnalisis = false;
                        //Formacion del Componente Lexico
                        componente = formarComponente(lexema, "NUMERO DECIMAL");
                        break;

                    case 16:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "IDENTIFICADOR"); //No poner lo de componente.Tipo = TipoComponente.LITERAL;
                        CentralizadorComponentes.sincronizar(componente); //Para asignarlo en simbolos o literales
                        break;

                    case 17: // CONTROLA ERROR DE NUMERO DECIMAL NO VALIDO
                        devolverPuntero();
                        continuarAnalisis = false;
                        //99.9 es el DUMMY que se le va poner a este tipo de error (Se crea un comodin )
                        componente = formarComponente("99.9", "NUMERO DECIMAL");
                        componente.Tipo = TipoComponente.DUMMY;
                        reportarError(lexema + caracterActual, "Se recibió " + caracterActual + " y se esperaba un digito.",
                            "Número decimal no valido.", "Asegúrese que después del punto siga un dígito.");
                        CentralizadorComponentes.sincronizar(componente);
                        break;

                    case 18:
                        devolverPuntero();
                        continuarAnalisis = false;
                        //Stopper: El programa debe de parar porque no controla ese símbolo
                        reportarError(lexema + caracterActual, "Se recibió " + caracterActual + " que es un símbolo no válido.",
                            "Símbolo no valido o reconocido por el lenguaje", "Asegúrese de que los símbolos de programa fuente sean válidos.");
                        throw new Exception("Error léxico no controlable!");
                    case 19:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "IGUALDAD");
                        break;
                    case 20:
                        leerSiguienteCaracter();
                        if (">".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 23;
                        }
                        else if ("=".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 24;
                        }
                        else
                        {
                            estadoActual = 25;
                        }
                        break;
                    case 21:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 26;
                        }
                        else
                        {
                            estadoActual = 27;
                        }
                        break;
                    case 22:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 28;
                        }
                        else
                        {
                            estadoActual = 29;
                        }
                        break;
                    case 23:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "DIFERENCIA");
                        break;
                    case 24:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "MENOR O IGUAL");
                        break;
                    case 25:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "MENOR");
                        break;
                    case 26:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "MAYOR O IGUAL");
                        break;
                    case 27:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "MAYOR");
                        break;
                    case 28:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "ASIGNACION");
                        break;
                    case 29:// ERROR ASIGNACION NO VALIDA
                        devolverPuntero();
                        continuarAnalisis = false;
                        componente = formarComponente(lexema + '=', "ASIGNACION");
                        break;
                    case 30:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema = lexema + caracterActual;
                            estadoActual = 31;
                        }
                        else
                        {
                            estadoActual = 32;
                        }
                        break;
                    case 31:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "DIFERENCIA");
                        break;
                    case 32: // ERROR DIFERENTE QUE NO VALIDA
                        devolverPuntero();
                        continuarAnalisis = false;
                        componente = formarComponente(lexema + '=', "DIFERENCIA");
                        break;
                    case 33:
                        continuarAnalisis = false;
                        componente = formarComponente(lexema, "DIVISION");
                        break;

                    case 34:
                        leerSiguienteCaracter();
                        if (caracterActual == "*")
                        {
                            estadoActual = 35;
                        }
                        else if ("@FL@".Equals(caracterActual))
                        {
                            estadoActual = 37;
                        }
                        else if ("@EOF@".Equals(caracterActual))
                        {
                            estadoActual = 38;
                        }
                        else
                        {
                            estadoActual = 34;
                        }
                        break;

                    case 35:
                        leerSiguienteCaracter();
                        if ("*".Equals(caracterActual))
                        {
                            estadoActual = 35;
                        }
                        else if ("/".Equals(caracterActual))
                        {
                            caracterActual = "";
                            lexema = "";
                            estadoActual = 0;
                        }
                        else
                        {
                            estadoActual = 34;
                        }

                        break;
                    case 36:
                        leerSiguienteCaracter();
                        if (caracterActual != "@FL@")
                        {
                            estadoActual = 36;
                        }
                        else
                        {
                            estadoActual = 13;
                        }

                        break;
                    case 37:   // FIN DE LINEA
                        cargarNuevaLinea();
                        estadoActual = 34;

                        break;
                    case 38: // ERROR COMENTARIO NO VALIDO
                        componente = formarComponente(lexema + '*' + '/', " ");
                        estadoActual = 12;
                        break;

                }
            }

            return componente;
        }

        private ComponenteLexico formarComponente(String lexema, String categoria){

            if ("@EOF@".Equals(lexema)){ return new ComponenteLexico(lexema, categoria, 0, 0, 0); }
            return new ComponenteLexico(lexema, categoria, numeroLineaActual, puntero - lexema.Length, puntero - 1);
           
        }

        private void reportarError(String lexema, String causa, String falla, String solucion)
        {
            ManejadorErrores.ManejadorErrores.obtenerInstancia().reportar(new Error(lexema, TipoError.LEXICO, numeroLineaActual,
                puntero - lexema.Length, puntero - 1, causa, falla, solucion));
        }

    }
}
