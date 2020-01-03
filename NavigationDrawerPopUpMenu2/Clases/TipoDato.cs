using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class TipoDato
    {

        private int id { get; set; }
        private string nombre { get; set; }
        int identificador = 1;
        int[] tipos = { 17, 21, 18,20,19};
        String[] tipoPalabra = {"string", "double", "char", "bool", "real","integer" };
        //ArrayList tipos = new ArrayList();
        int[] operadores = { 11 };
        int[] funciones = { };



        public TipoDato()
        {
         
           




        }

        public TipoDato(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public string RecoTipo(int numero)
        {
            string res="";

            if (tipos.Contains(numero)) {
                res = "tipo";
            }

            if (operadores.Contains(numero))
            {
                res = "operador";
            }
            if (identificador==numero)
            {
                res = "identificador";
            }
            return res;
        }

        public string RecoTipo(String p)
        {
            string res = "";

            if (tipoPalabra.Contains(p))
            {
                res = "tipo";
            }

            if (p.Substring(0,1).Equals('#'))
            {
                res = "identificador";
            }


            return res;
        }


    }
}
