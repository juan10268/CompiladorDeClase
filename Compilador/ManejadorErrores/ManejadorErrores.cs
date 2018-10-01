using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.ManejadorErrores
{
    class ManejadorErrores
    {
        private static ManejadorErrores INSTACIA = new ManejadorErrores();
        private Dictionary<TipoError, List<Error>> errores = new Dictionary<TipoError, List<Error>>(); //En el AnalizadorLexico hay muchos errores, sintactico muchos, semantico muchos...

        private ManejadorErrores() { }

        public static ManejadorErrores obtenerInstancia()
        {
            return INSTACIA;
        }

        private List<Error> obtenerErrores(TipoError tipo)
        {
            if (!errores.ContainsKey(tipo))
            {
                errores.Add(tipo, new List<Error>());
            }
            return errores[tipo];
        }

        public void reportar(Error error)
        {
            // Para reportar el error solo es enviarle el tipo del error y el manejador de eerores lo agrega 
            if(error != null)
            {
                obtenerErrores(error.Tipo).Add(error);
            }
        }

        public bool hayErrores(TipoError tipo)
        {
            return obtenerErrores(tipo).Count > 0;
        }

        public bool hayErroresCompilacion()
        {
            bool hayErroresCompilacion = false;
            List<TipoError> tipoErrores = errores.Keys.ToList();
            for(int indice=0; indice < tipoErrores.Count && !hayErroresCompilacion; indice++)
            {
                hayErroresCompilacion = hayErrores(tipoErrores[indice]);
            }

            return hayErroresCompilacion;
        }


    }
}
