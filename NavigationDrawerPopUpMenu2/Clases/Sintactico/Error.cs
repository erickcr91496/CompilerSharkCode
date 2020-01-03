using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavigationDrawerPopUpMenu2.Clases.Sintactico
{
    class Error
    {
        int estado { get; set; }
        int numerror { get; set; }
        string descripcion { get; set; }
        private XDocument archivo { get; set; }
        List<Error> listaErrores { get; set; }

        public Error(String ubicacion)
        {
            this.estado = estado;
            this.numerror = numerror;
            this.descripcion = descripcion;
            this.archivo = XDocument.Load(@ubicacion);
            this.listaErrores = new List<Error>();
        }

        public Error()
        {
        }

        public List<Error> mostrarError()// lee el archivo xml y lo almacena en la estructura correspondiente

        {
                
            var temp = from x in this.archivo.Descendants("E") select x;
            int cont = 0;
            foreach (XElement n in temp.Elements("nerror"))
            {
                Error e = new Error();
                cont++;
                e.estado =cont;
                e.numerror = Convert.ToInt32(n.Value.Substring(0, 2)) ;
                e.descripcion = n.Value.Substring(4);

                listaErrores.Add(e);
            }
            return listaErrores;
        }




    }
}
