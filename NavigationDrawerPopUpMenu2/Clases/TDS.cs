using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class TDS
    {
        public int nToken{ get; set; }
        public string tipo { get; set; }
        public int size { get; set; }
        public string valor { get; set; }

        public TDS(int nToken, string tipo, int size, string valor)
        {
            this.nToken = nToken;
            this.tipo = tipo;
            this.size = size;
            this.valor = valor;
        }

        public TDS()
        {
      
        }
       
    }
    




}
