﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class loadAlfabeto
    {

        private XDocument documento;
        public  List<Token> listAlfabeto { get; set; }
        public XDocument Documento { get => documento; set => documento = value; }
        public static string path = @"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZADOR SINTACTICO\v4\ProyectoACSv3\archivos\Alfabeto2.xml";

        public void getRuta_alfabeto(string ruta)
        {
            this.Documento = XDocument.Load(ruta);
            listAlfabeto = generarListaAlfabeto(Documento);
        }

        public  List<Token> generarListaAlfabeto(XDocument d)
        {
            // Extraer alfabeto -> conjunto de estados
            var tokens = from cje in d.Descendants("alfabeto") select cje;
            List<Token> l_tokens = new List<Token>();

            // inicializo variables
            int numtoken = 0;
            char simbolo = ' ';
            string nombretoken = "";
            string lexema = "";
            foreach (XElement u in tokens.Elements("token")) // leo la estructura
            {
                numtoken = int.Parse(u.Element("numtoken").Value);
                simbolo = char.Parse(u.Element("sinonimo").Value);
                nombretoken = u.Element("nombretoken").Value;
                lexema = u.Element("lexema").Value;
                l_tokens.Add(new Token(numtoken, simbolo, nombretoken, lexema));
            }
            return l_tokens;
        }
        public static List<Token> obtenerAlfabetoErrores()
        {
            XDocument d = XDocument.Load(path);
            // Extraer alfabeto -> conjunto de estados
            var tokens = from cje in d.Descendants("alfabeto") select cje;
            List<Token> l_tokens = new List<Token>();

            // inicializo variables
            int numtoken = 0;
            char simbolo = ' ';
            string nombretoken = "";
            string lexema = "";
            foreach (XElement u in tokens.Elements("token")) // leo la estructura
            {
                numtoken = int.Parse(u.Element("numtoken").Value);
                simbolo = char.Parse(u.Element("sinonimo").Value);
                nombretoken = u.Element("nombretoken").Value;
                lexema = u.Element("lexema").Value;
                l_tokens.Add(new Token(numtoken, simbolo, nombretoken, lexema));
            }
            return l_tokens;
        }

    }
}
