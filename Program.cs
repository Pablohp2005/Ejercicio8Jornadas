﻿using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

internal class Program
{

    public static void RellenarDiccionario(Dictionary<string, string> miDiccionario)
    {
        string palabra = "";
        string definicion = "";
        
            Console.WriteLine("Dime la palabra que quieres añadir: ");
            palabra = Console.ReadLine() ?? "0";

            Console.WriteLine("Ahora dime su significado");
            definicion = Console.ReadLine() ?? "0";

            miDiccionario.Add(palabra, definicion);            
    
    }

    public static void RellenarFichero(string ruta, Dictionary<string, string> miDiccionario)
    {

        using StreamWriter fichero = new (ruta, true);
        {
            foreach (var registro in miDiccionario)
            {
                fichero.WriteLine($"{registro.Key}: {registro.Value}");  
            }
        }
          
    }


    public static void LeerFichero(string ruta)
    {
        using StreamReader sr = new StreamReader(ruta);

        while(!sr.EndOfStream)
        {
            string contenido = sr.ReadLine() ?? "0"; 
            string[] clave = contenido.Split(":");
            string palabra = clave[0];
            string descripcion = clave[1];
            Console.WriteLine("Esto es la palabra: " + palabra);

            Console.WriteLine("Esto es la descripcion: " + descripcion);
            
        }

        sr.Close();

    }
    private static void Main(string[] args)
    {
        string respuesta = "";
        string ruta = @"Texto.txt";
        int contador = 1;
        Dictionary<string, string> miDiccionario = new Dictionary<string, string>();
        
        do
        {
            Console.WriteLine("¿Quieres añadir alguna palabra al diccionario?");
            respuesta = Console.ReadLine() ?? "0";
            if(respuesta == "si")
            {
                RellenarDiccionario(miDiccionario);
                
            }
            contador ++;
        } while (respuesta == "si" && contador < 3);
        
        RellenarFichero(ruta, miDiccionario);
        LeerFichero(ruta);
        
        

    }
}