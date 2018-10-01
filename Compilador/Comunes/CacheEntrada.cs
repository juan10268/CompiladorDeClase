using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class CacheEntrada
    {
        private List<Linea> listaLineas = new List<Linea>();

        private static CacheEntrada instancia = new CacheEntrada();
        private CacheEntrada() { }
        public static CacheEntrada obtenerInstancia() {
            return instancia;
        }

        public void agregarLinea(Linea linea) {
            listaLineas.Add(linea);
        }
      
        public Linea devolverLinea(int numeroLinea) {

            return (existeLinea(numeroLinea))
                    ? obtenerListaLineas().ElementAt(numeroLinea - 1)
                    : new Linea(obtenerListaLineas().Count + 1, "@EOF@");
        }

        public bool existeLinea(int numeroLinea) {
            if(listaLineas.Count() >= numeroLinea)
            {
                return true;
            }

            return false;
        }

        public void limpiar() {
            listaLineas.Clear(); 
        }

        public List<Linea> obtenerListaLineas()
        {
            if(listaLineas==null)
            {
                listaLineas = new List<Linea>();
            }
            return listaLineas;
        } 
    }
}
