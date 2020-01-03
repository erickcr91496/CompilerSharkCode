using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases.Sintactico
{
    class Printsintactico
    {
        public string pila{ get; set; } 
        public string entrada { get; set; }
        public string accion { get; set; }
        public Printsintactico(string pila, string entrada, string accion)
        {
            this.pila = pila;
            this.entrada = entrada;
            this.accion = accion;
        }
    }
}
