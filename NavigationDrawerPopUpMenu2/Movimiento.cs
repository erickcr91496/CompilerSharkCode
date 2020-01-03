using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2
{
    class Movimiento
    {
        public Movimiento()
        {
        }


        public Object[,] Prifil(Object[,] mt)
        { // metodo prifil
            Object[] fil = new Object[mt.GetLength(0)];  //columna fil 

            for (int i = 0; i < fil.GetLength(0); i++) //elmgetlengt(0) es para num de filas 
            {
                int cont = 0;

                for (int y = 1; y < mt.GetLength(1); y++)
                {
                    if (!mt[i, y].Equals("-"))
                    {
                        cont++;
                    }
                    fil[i] = cont;
                }
            }

            Object[] prif = new Object[mt.GetLength(0)];// columna prifil
            prif[0] = 1;

            for (int i = 1; i < prif.GetLength(0); i++)
            {
                if (Convert.ToInt16(prif[i - 1]) <= 518)
                {
                    prif[i] = Convert.ToInt16(prif[i - 1]) + Convert.ToInt16(fil[i]);
                }
                else
                {
                    prif[i - 1] = 0;
                }

            }

            Object[,] prifil = new Object[mt.GetLength(0), 3];

            prifil[0, 0] = "X";
            prifil[0, 1] = "Prifil";
            prifil[0, 2] = "fil";
            for (int i = 1; i < prifil.GetLength(0); i++)
            {
                prifil[i, 0] = i - 1;

                prifil[i, 1] = prif[i - 1];

                prifil[i, 2] = fil[i];

            }

            for (int i = 1; i < prifil.GetLength(0); i++)
            {
                for (int j = 1; j < prifil.GetLength(1); j++)
                {
                    if (prifil[i, j] == null)

                    {
                        prifil[i, j] = "-";

                    }
                }
            }
            return prifil;
        }

        public Object[,] Valor(Object[,] mt, int s)
        {  // matriz valor
            Object[,] TVal = new Object[519, 3];
            ArrayList Lista = new ArrayList();// columna de valor

            for (int i = 1; i < mt.GetLength(0); i++)
            {
                for (int j = 1; j < mt.GetLength(1); j++)
                {
                    if (!mt[i, j].Equals("-"))
                    {
                        Lista.Add(mt[i, j]);
                    }
                }
            }

            ArrayList l; //columna de col
            l = new ArrayList();
            {
                for (int i = 1; i < mt.GetLength(0); i++)
                {
                    for (int j = 1; j < mt.GetLength(1); j++)
                    {
                        for (int x = 0; x < Lista.Count; x++)
                            
                                if (mt[i, j].Equals(Lista[x]))
                            {
                                l.Add(mt[0, j]);
                                break;
                            }
                    }
                }
            }

            for (int x = 0; x < l.Count; x++)
            {
                if (l[x].Equals("C")) { 
                    l[x] = ';';

                  }
                
        }

        TVal[0, 0] = "X"; TVal[0, 1] = "valor"; TVal[0, 2] = "Col";
            for (int i = 1; i < 519; i++)
            {
                
                TVal[i, 0] = i;
                TVal[i, 1] = Lista[i - 1];
                TVal[i, 2] = l[i - 1];
            }
            return TVal;
        }

      


        public ArrayList Readtxt(StreamReader sr, ArrayList lista)
        {
            int f = 15;
            int c = 1;
            string[,] texto = new string[f, c]; ; //matriz de transicion
            for (int i = 0; i < f; i++)
            {
                texto[i, 0] = sr.ReadLine();
            }


            List<string[]> tokens = new List<string[]>();
            for (int i = 0; i < f; i++)
            {
                tokens.Add(texto[i, 0].Split(' '));


            }
            lista = new ArrayList();

            for (int i = 0; i < f; i++)
            {
                string[] token = tokens.ElementAt(i);
                for (int j = 0; j < token.Length; j++)
                {
                    if (!token[j].Equals(""))
                    {
                        lista.Add(token[j] + "$");
                    }
                }


            }
            return lista;


        }

        public List<string[]> ReadtxtConMatriz(StreamReader sr)
        {
           
           List <string[]> texto = new List<string[]>(); //matriz de transicion
            
                string linea = sr.ReadLine();
                string[] temp = linea.Split('$');

            texto.Add(temp);
                
            
            return texto;


        }



        public int Buscar(int n, String c, Object[,] prifil, Object[,] Valor)
        {
            int a, b;
            int res = -1;

            a = (int)prifil[n, 1];
            b = (int)prifil[n, 2];


            for (int i = a; i < (a + b); i++)
            {
                if (c.Equals(Valor[i, 2].ToString()))
                {
                   
                    a = Convert.ToInt16(Valor[i, 1]) + 1;
                    res = a;
                    break;
                }
                else
                {
                }
            }

            return res;
        }


        public void Siguiente(Queue<char> myQueue,ArrayList Listafin,int posicionlista)
        {

            myQueue = new Queue<char>();
            char[] cadena = Listafin[posicionlista + 1].ToString().ToCharArray();
            for (int j = 0; j < cadena.Length; j++)
            {
                myQueue.Enqueue(cadena[j]);
            }
          
            posicionlista++;


        }

       



    }
}
