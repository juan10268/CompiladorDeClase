using Compilador.AnalizadorLexico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    public partial class Ingreso : Form
    {

        public Ingreso()
        {
            InitializeComponent();
        }

        private void cBTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBTipoIngreso.Text == "Consola")
            {
                tBArchivo.Text = "";
                tBArchivo.ReadOnly = true;
                rTConsola.ReadOnly = false;
            }
            else
            {
                tBArchivo.ReadOnly = false;
                rTConsola.Text = "";
                rTConsola.ReadOnly = true;
            }
        }

        private void Ingreso_Load(object sender, EventArgs e)
        {
            cBTipoIngreso.Text = "Consola";
            tBArchivo.Text = "";
            rTResultado.ReadOnly = true;
        }

        private void rTResultado_TextChanged(object sender, EventArgs e)
        {

        }

        void leerArchivo()
        {
            StreamReader archivo = new StreamReader(@tBArchivo.Text);
            String lineaActual = archivo.ReadLine();
            int numeroLinea = 1;

            while (lineaActual != null) {

                Linea linea = new Linea(numeroLinea, lineaActual);
               
                CacheEntrada.obtenerInstancia().agregarLinea(linea);
                lineaActual = archivo.ReadLine();
                numeroLinea++;
            }
            archivo.Close();

        }

        void leerPorConsola()
        {
            String[] lineas = rTConsola.Text.Split('\n');
            int numeroLinea = 1;

            foreach (String contenidoLinea in lineas)
            {
                Linea linea = new Linea();
                linea.Contenido = contenidoLinea;
                linea.Numero = numeroLinea;
                CacheEntrada.obtenerInstancia().agregarLinea(linea);
                numeroLinea++;
            }
        }

        void mostrarDatosCargados()
        {



            foreach (Linea linea in CacheEntrada.obtenerInstancia().obtenerListaLineas())
            {
                rTResultado.Text = rTResultado.Text+ linea.Numero+"--> "+ linea.Contenido+ "\n";
            }
        } 

        void limpiar()
        {
            CacheEntrada.obtenerInstancia().limpiar();
            rTResultado.Text = "";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            
        }

        private void compilar()
        {
            AnalisisLexico analisisLexico = new AnalisisLexico();
            ComponenteLexico componente = analisisLexico.devolverComponenteLexico();


            try
            {
                while (!componente.Lexema.Equals("@EOF@"))
                {
                    MessageBox.Show(componente.imprimir());
                    componente = analisisLexico.devolverComponenteLexico();
                }
                MessageBox.Show(componente.imprimir());
                componente = analisisLexico.devolverComponenteLexico();



                if (ManejadorErrores.ManejadorErrores.obtenerInstancia().hayErroresCompilacion())
                {
                    MessageBox.Show("El programa esta mal escrito. Verifique la consola de errores");
                }
                else
                {
                    MessageBox.Show("El programa esta bien escrito");
                }

                //Refrescar tablas de símbolos, literales...aquí. Falta el código para refrescarlas!!
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("El programa esta mal escrito. Verifique la consola " +
                    "de errores ya que se ha presentado un error no controlable!!!" +
                    "El detalle del error no controlable es: " + excepcion.Message);
            }
        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {

            limpiar();
            if ("Consola".Equals(cBTipoIngreso.Text))
            {

                if ("".Equals(rTConsola.Text))
                {
                    MessageBox.Show("En la opción de Consola debes de ingresar los valores manualmente");
                }
                else
                {
                    leerPorConsola();
                }

            }
            else
            {

                if ("".Equals(tBArchivo.Text))
                {

                    MessageBox.Show("En la opción de Archivo debes de ingresar la ruta donde se encuentra para ser compilado");
                }
                else
                {

                    try
                    {
                        leerArchivo();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El archivo no existe o esta dañado, verifique la ruta y vuelva a intentarlo");
                    }
                }
            }
            mostrarDatosCargados();
            compilar();

        }
    }
}
