using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            //cogemos la ruta del proyecto y remplazamos todo lo que nos sobra
            string path = Environment.CurrentDirectory.Replace("\\bin\\Debug", "").Replace("\\netcoreapp3.1", "") +"\\data.txt";
            Console.WriteLine("la ruta es "+ path);
            //Sirve para leer el fichero 
           System.IO.StreamReader file =
               new System.IO.StreamReader(path);
            //dividimos el txt en 3 cachos
            string[] split = new string[3];
           List<AgendaTelefonica> agendaTelefonicaList = new List<AgendaTelefonica>();
            string election = "";
         
            while (election != "salir")
            {

            Console.WriteLine("Pulsa 1 para listar nombres");
            Console.WriteLine("Pulsa 2 para listar ciudades");
            Console.WriteLine("Pulsa 3 para listar telefonos");
            Console.WriteLine("Pulsa 4 para buscar nombres");
            Console.WriteLine("Pulsa 5 para buscar ciudades");
            Console.WriteLine("Pulsa 6 para buscar telefonos");
            Console.WriteLine("Escribe salir para terminar programa");
           election = Console.ReadLine();
                if (election == "salir")
                {
                    file.Close();

                }
                if (election!="salir")
                {

                //leemos el fichero linea a linea 
                while ((line = file.ReadLine()) != null)
            {
                AgendaTelefonica agendaTelefonica = new AgendaTelefonica();

                split = line.Split('|');
                agendaTelefonica.name =  split[0];
                agendaTelefonica.city = split[1];
                agendaTelefonica.phone =   split[2];
                agendaTelefonicaList.Add(agendaTelefonica);
            }
                }

                switch (election)
            {
                case "1":
                    Console.WriteLine("Lista de nombres");

                    foreach (var item in agendaTelefonicaList)
                    {
                        Console.WriteLine(item.name);
                    }

                        break;
                case "2":
                    Console.WriteLine("Lista de ciudades");

                    foreach (var item in agendaTelefonicaList)
                    {
                        Console.WriteLine(item.city);
                    }

                        break;
                case "3":
                    Console.WriteLine("Lista de telefonos");

                    foreach (var item in agendaTelefonicaList)
                    {
                        Console.WriteLine(item.phone);
                    }

                        break;
                case "4":
                    Console.WriteLine("Buscar nombre");
                    Console.WriteLine("Introduzca nombre");
                   string name= Console.ReadLine();

                    var match = agendaTelefonicaList.FirstOrDefault(stringToCheck => stringToCheck.name.Contains(name));
                    if (match != null)
                    {
                        Console.WriteLine("Coincidencia encontrada " + match.name + "ciudad: "+ match.city + "telefono: " + match.phone);
                    }
                    else
                    {
                        Console.WriteLine("No hay coincidencia");
                    }

                        break;
                case "5":
                    string city = Console.ReadLine();
                    Console.WriteLine("Buscar ciudad");
                    Console.WriteLine("Introduzca ciudad");
                    var matchCity = agendaTelefonicaList.FirstOrDefault(stringToCheck => stringToCheck.city.Contains(city));
                    if (matchCity != null)
                    {
                        Console.WriteLine("Coincidencia encontrada nombre: " + matchCity.name + " ciudad:  " + matchCity.city + " telefono:  " + matchCity.phone);
                    }
                    else
                    {
                        Console.WriteLine("No hay coincidencia");
                    }

                        break;
                case "6":
                    Console.WriteLine("Buscar telefono");
                    Console.WriteLine("Introduzca telefono");
                    string phone = Console.ReadLine();
                    var matchphone = agendaTelefonicaList.FirstOrDefault(stringToCheck => stringToCheck.phone.Contains(phone));
                    if (matchphone != null)
                    { 
                        Console.WriteLine("Coincidencia encontrada nombre: " + matchphone.name + " ciudad: " + matchphone.city + " telefono:  " + matchphone.phone);
                    }
                    else
                    {
                        Console.WriteLine("No hay coincidencia");
                    }

                        break;
                
            }
            //file.Close();
             
           //System.Console.ReadLine();
            }

        }
        public class AgendaTelefonica
        {
        
            public string name { get; set; }
            public string city { get; set; }
            public string phone { get; set; }
        }
    }
}
