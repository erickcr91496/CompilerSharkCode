using Microsoft.Win32;
using NavigationDrawerPopUpMenu2.Clases;
using NavigationDrawerPopUpMenu2.Clases.Sintactico;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace NavigationDrawerPopUpMenu2
{
    /// <summary>
    /// Lógica de interacción para winLexical.xaml
    /// </summary>
    public partial class winSintactico : UserControl
    {
        
        //Gramatica g= new Gramatica(@"C:\Users\Samantha1\Desktop\Gramatica_SLR.xml");
        //Transicion tr = new Transicion(@"C:\Users\Samantha1\Desktop\Gramatica_SLR.xml");
         Gramatica g= new Gramatica(@"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZADOR SINTACTICO\v4\ProyectoACSv3\archivos\Gramatica_SLR_1.xml");
        Transicion tr = new Transicion(@"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZADOR SINTACTICO\v4\ProyectoACSv3\archivos\Gramatica_SLR_1.xml");

        public winSintactico()
        {
            InitializeComponent();
        }

        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
        FirstNext fn = new FirstNext();
        TipoDato td = new TipoDato();
        Movimiento afd = new Movimiento();
      
   
        ArrayList Listafin;
        ArrayList reconocidos = new ArrayList();
        ArrayList noreconocidos = new ArrayList();
        List<FirstNext> FN = new List<FirstNext>();
        TDS tds = new TDS();
        List<string> der= new List<string>();
        List<char> izq = new List<char>();
        List<Produccion> P = new List<Produccion>();
        List<Transicion> GoTo = new List<Transicion>();
        List<Transicion> accion = new List<Transicion>();

        winLexical wl = new winLexical();
        List<Token>  tkr = new List<Token>();
        List<Token> listatkr = winLexical.Alfa;
        //List<Token>  listtk = new List<Token>();
        public Stack<object> pila = new Stack<object>();
        int nerror = 0;
        int idtk = 0;
        int estado;
        int n;
        int newEstado;
        int regla;
        Token tk = new Token();
        AnalizadorSLR slr = new AnalizadorSLR();


      //  string path = @"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZADOR SINTACTICO\v4\ProyectoACSv3\archivos\Alfabeto2.xml";
        loadAlfabeto alfabeto = new loadAlfabeto();
        List<Token> listaAlfabeto = loadAlfabeto.obtenerAlfabetoErrores();


        public string Imprimir() {
            string lista = "";
            foreach (var tk in tkr)
            {
                Console.WriteLine(""+tk.Lexema);
                lista +=tk.Lexema;
            }
            return lista;
        }
       

        private void Btn_fyn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog buscar = new OpenFileDialog();
            buscar.Filter = "Archivos TXT|*.txt";
            if (buscar.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(buscar.FileName, System.Text.Encoding.ASCII);
                while (!sr.EndOfStream) // mientras no llegue a la linea final
                {
                    string[] linea = sr.ReadLine().Split('\t');
                   string nt = linea[0];
                   string first = linea[1];
                  string  next = linea[2];
                    FirstNext fn = new FirstNext(nt, first, next);
                    FN.Add(fn);

                }
                sr.Close();
            }

            tbl_fn.ItemsSource= FN;

        }

        private void Txtb_gramatica_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_cargarGramatica_Click(object sender, RoutedEventArgs e)// carga las producciones usando metodos de la clase Gramatica
        {
               
            int r = winLexical.Listorec.Count;
            for (int i = 0; i < r; i++)
            {
                int numToken = winLexical.Listorec[i].NumToken;
                char sinonimo = winLexical.Listorec[i].Sinonimo;
                string nombreToken = winLexical.Listorec[i].NombreToken;
                string lexema = winLexical.Listorec[i].Lexema;

                Token t = new Token(numToken, sinonimo, nombreToken, lexema);
                tkr.Add(t);
                Console.WriteLine("Tokens reco"+tkr[i].Lexema);
            }
            Token tr = new Token(tkr.Count+1, '~', "blanco", "$");
            // tbl_reco.ItemsSource = tkr;
            tkr.Add(tr);
           // tbl_reco.ItemsSource = tkr;


            der = g.AsignarListaT();
            izq = g.AsignarNoT();
            P = g.AsignarProd();

            txtb_gramatica.AppendText("T= {");
            for (int i = 0; i < der.Count; i++)
            {
               
                txtb_gramatica.AppendText(der[i]+", " );
            }
            txtb_gramatica.AppendText("}\n");

            txtb_gramatica.AppendText("N= {");
            for (int i = 0; i < izq.Count; i++)
            {

                txtb_gramatica.AppendText(izq[i] + ", ");
            }
            txtb_gramatica.AppendText("}");

            txtb_gramatica.AppendText("P= {");
            for (int i = 0; i < P.Count; i++)
            {

                txt_produccion.AppendText(P[i].n +" : "+P[i].izq+" -> "+P[i].der+"\n");
            }
            txtb_gramatica.AppendText("}");
        }

        private void Btn_cargarAP_Click(object sender, RoutedEventArgs e)// carga el Goto y accion usando metodos de la clase Transicion
        {
            GoTo = tr.list_GoTo();
            accion = tr.Accion();

            for (int i = 0; i < accion.Count; i++)
            {
                txtb_accion.AppendText(accion[i].eInicial + "   " + accion[i].lee + "   " + accion[i].eFinal + "\n");
            }
            for (int i = 0; i < GoTo.Count; i++)
            {
                txt_Goto.AppendText(GoTo[i].eInicial + "   " + GoTo[i].lee + "   " + GoTo[i].eFinal + "\n");
            }
           
        }
        // METODO PARA LA RECUPERACION DE ERRORES-----------******************************************************

            // METODO QUE ME DEVUELVE LA LISTA DE  SIMBOLOS SIGUIENTES A LEER DEL ESTADO 

        public List<char> listaSimbSiguientes(int estado)
        {
            List<char> lista = new List<char>();
            for (int i = 0; i < accion.Count; i++)
            {
                if (accion[i].eInicial == estado)
                {
                    lista.Add(accion[i].lee);
                   Console.WriteLine("siguientes del estado"+estado+" es "+ accion[i].lee);
                }
            }
            return lista;
        }

        // METODO QUE DEVUELVE QUE EL SIGUIENTE ESTADO RECUPERADO 

        public String imprimirError(int estado)
        {
            int newestado = -1;
            string print = "";
            string res = "Error : Posiblemente te fale poner:  ";
            List<char> listaSimbolos = listaSimbSiguientes(estado);

            foreach (char r in listaSimbolos)
            {
                int pos = listatkr.FindIndex(x => x.Sinonimo == r);
                Console.WriteLine("la pos es : " + pos);
                newestado = buscarColumna(estado, r);
                if (newestado < 200 && newestado != 0)
                {
                    //Console.WriteLine("ERROR.... LO CORRECTO SERIA ( " + tkr[pos].Lexema + " )");
                    return res += listatkr[pos].Lexema + "\n";
                }
            }

            return res;

        }






        public int estadoCorrecto(int estado)
        {
            int newestado = -1;

            List<char> listaSimbolos = listaSimbSiguientes(estado);

            foreach (char r in listaSimbolos)
            {
                int posicion = listatkr.FindIndex(x => x.Sinonimo == r);
                newestado = buscarColumna(estado, r);

                if (newestado < 200 && newestado != 0)
                {
                    //Console.WriteLine("ERROR.... LO CORRECTO SERIA ( " + listatkr[posicion].Lexema +" )");
                    return newestado;
                }
            }

            return 0;

        }
        

        private void Btn_movimiento_Click(object sender, RoutedEventArgs e)
        {
               
            // tb_error.AppendText(Imprimir());
            //   listaSimbSiguientes(2);
            // Imprimir();
            pila.Push(estado); 
            List<Printsintactico> print = new List<Printsintactico>();
            String cadenapila="";
            String entrada="";
            string accion = "";
            do

            {
                                            
                estado = Convert.ToInt16(pila.First());
         
                char sinonimo = tkr[idtk].Sinonimo;

                newEstado = buscarColumna(estado, sinonimo);

                if (newEstado == 0)
                {
                    newEstado = estadoCorrecto(estado);
                    tb_error.AppendText("" + imprimirError(estado));
                 //   Console.WriteLine("estadooooooo:  " + newEstado);
                    
                    if (newEstado == 0)
                    {
                        Console.WriteLine("Error de estructura");
                        break;
                    }
                    nerror++;
                }

                if (newEstado != 0)
                {
                    for (int i = 0; i < pila.Count; i++)
                    {
                        cadenapila += pila.ElementAt(i) + ", ";
                    }
                    print.Add(new Printsintactico(cadenapila, "", ""));
                    cadenapila = "";

                    for (int i = idtk; i < tkr.Count; i++)
                    {
                        entrada += tkr.ElementAt(i).Sinonimo + " ";
                    }
                    print[print.Count - 1].entrada = entrada;
                    entrada = "";

                }

                if (newEstado > 0 && newEstado < 200)
                {

                    pila.Push(sinonimo);
                    
                    pila.Push(newEstado);
                                                          idtk++;
                    print[print.Count - 1].accion = "desplaza";


                }
                else if (newEstado < 0)
                {//aqui es reconocimiento de regla
                    int regla0 = P[15].n;
                    int regla = -newEstado; //cambiamos de signo para que busque la regla 
                    char parteizq = P[regla-1].izq;
                    String parteder = P[regla-1].der;
                    print[print.Count - 1].accion = "reconoce" +" ("+parteizq+"-->"+parteder+")";
                    int longitud_regla;
                    if (P[regla - 1].der.Equals("λ"))
                    {
                        longitud_regla = 0;
                    }

                    else
                    {
                       longitud_regla = P[regla - 1].der.Length;
                    }
                    char noterminal = P[regla-1].izq; // pendiente

                    for (int i = 1; i <= 2 * longitud_regla; i++)
                    {
                        object y=pila.Last();
                        pila.Pop();
                    }
                    int numeropila = Convert.ToInt16(pila.First());
                    estado = buscarColumnaGoTo(numeropila, noterminal);

                    pila.Push(noterminal);

                    if (estado == 0)
                    {
                        break;
                    }

                    pila.Push(estado);

                  
                }
                else if (newEstado == 999)
                {
                    print[print.Count - 1].accion = "Fin";
                 
                    break;
                }
                else if(newEstado == 0)
                {
                    buscarColumna(estado, sinonimo);
                    nerror++;
                }
            } while (nerror <= 5);
            if (newEstado == 999 && nerror == 0)
            {
             tb_error.AppendText("programa fuente reconocido sin errores sintácticos");
            }
            else
            {
                print[print.Count - 1].accion = "error";
                
                tb_error.AppendText("programa fuente con errores sintácticos");
            }





            tbl_movimientos.ItemsSource = print;

        }


        int buscarColumna(int estado, char c)
        {

            int res = 0;
            for (int i = 0; i < accion.Count; i++)
            {
                int est = estado;
                int a = accion[i].eInicial;
                if (accion[i].eInicial == estado)

                {
                    char caracter = c;
                    char lee = accion[i].lee;
                    int fin = accion[i].eFinal;

                    if (lee.Equals(caracter))
                    {
                        res = accion[i].eFinal;
                        break;
                    }
                    
                }
            }
            return res;
        }

        

        int buscarColumnaGoTo(int estado, char c)
        {
            int res = 0;
            for (int i = 0; i < GoTo.Count; i++)
            {
                int est = estado;
                int a = GoTo[i].eInicial;
                if (GoTo[i].eInicial == estado)

                {
                    char caracter = c;
                    char lee = GoTo[i].lee;
                    int fin = GoTo[i].eFinal;

                    if (lee.Equals(caracter))
                    {
                        res = GoTo[i].eFinal;
                              break;
                    }
                  
                }
            }
            return res;
        }


        public void imprimir(string a)
        {
            Console.WriteLine(a);
        }
        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {

        }
       
    }
}
