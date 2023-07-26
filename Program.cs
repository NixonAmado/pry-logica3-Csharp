/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

// Declaración e inicialización de un diccionario:

using System;
using System.Collections.Generic;
using System.Threading;

class Usuario
    {
   
        public string nombre { get; set; }
        public int edad { get; set; }
        public List<string> hobbies { get; set; }

        public  Usuario(string nombre,int edad, List<string> hobbies)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.hobbies = hobbies;
        }

        
    }    

class Program {
    static Dictionary <long, Usuario> DicUsuarios = new Dictionary <long, Usuario>(); 
    
    static void Main() {
        string opcion;
        do
        {
           MostrarMenu();
           opcion = ElegirOpcion();
            
           switch(opcion)
           {
                case "1": 
                    Console.Clear();                
                    Console.WriteLine(
                        "\n".PadRight(60) + "AGREGAR USUARIO\n" +
                        "".PadRight(25) + "__________________________________________________________________________________\n\n"
                        
                        );
                    AgregarUsuario();
                    break;
                
                case "2": 
                    Console.Clear();                
                    Console.WriteLine("\n".PadRight(60) + "TABLA CON USUARIO FILTRADO\n");
                        
                    MostrarUsuario();
                    Thread.Sleep(5000);
                    break;
                
               case "3": 
                    Console.Clear();                
                    Console.WriteLine(
                        "\n".PadRight(60) + "TABLA CON TODOS LOS USUARIOS DISPONIBLES\n" +
                        "".PadRight(34) + "__________________________________________________________________________________\n\n"
                        );
                    MostrarUsuarios();
                    break;
                
               case "4": 
                    Console.Clear();                
                    Console.WriteLine(
                        "\n".PadRight(70) + "ELIMINAR USUARIO\n" +
                        "".PadRight(35) + "__________________________________________________________________________________\n\n"
                        );
                    EliminarUsuario();
                    break;
           }
            
            
        } while (opcion != "5");


    }
    static void MostrarMenu(){
        Console.Clear();
        Console.WriteLine("".PadRight(50) + "************************************************");
        Console.WriteLine("".PadRight(50) + "                       Menu                     ");
        Console.WriteLine("".PadRight(50) + "************************************************");
        Console.WriteLine("".PadRight(50) + "                1. Agregar usuario              ");
        Console.WriteLine("".PadRight(50) + "                2. Mostrar usuario              ");
        Console.WriteLine("".PadRight(50) + "                3. Mostrar todos los usuarios   ");
        Console.WriteLine("".PadRight(50) + "                4. Eliminar usuario             ");
        Console.WriteLine("".PadRight(50) + "                5. Salir                        ");
    }
    
    static string ElegirOpcion(){
        Console.Write("Ingrese una opcion: ");
        return Console.ReadLine();

    }    
    
    static void AgregarUsuario(){
        Console.Write("Ingresar numero de identificacion: ");
        long numeroId = Convert.ToInt64(Console.ReadLine()); 
        
        Console.Write("Ingresar nombre: ");
        string nombre = Console.ReadLine(); 
        
        Console.Write("Ingresar edad: ");
        int edad = Convert.ToInt32(Console.ReadLine()); 
        
        Console.Write("Ingrese el numero de hobbies: ");
        long hobbiesNum = Convert.ToInt32(Console.ReadLine()); 
        
        int contador = 0;
        List<string> ListaHobbies = new List<string>(); 
        while(contador < hobbiesNum )
        {
            contador++;
            Console.Write($"Ingrese el hobbie N°{contador}: ");
            string hobbie = Console.ReadLine();
            ListaHobbies.Add(hobbie);
        }
        
        Console.WriteLine(string.Join(" ", ListaHobbies));
        Usuario NuevoUsuario = new Usuario(nombre,edad,ListaHobbies);
      
        DicUsuarios.Add(numeroId,NuevoUsuario);
        Console.WriteLine(string.Join(" ", DicUsuarios));
    }
    
    
    
    
    static void MostrarUsuario(){
        string tablaUsuario =
        "\n\n" +
        "".PadRight(30) +
        "\tID".PadRight(20) +
        "NOMBRE".PadRight(20) +
        "EDAD".PadRight(20) +
        "HOBBIES\n" +
        "".PadRight(30) +
        "______________________________________________________________________________________________\n";
        
        Console.Write("Ingresar id del usuario que desea ver : ");
        long IdVerUsuario = Convert.ToInt64(Console.ReadLine());
        //ICollection<int> claves = DicUsuarios.Keys;
        
        if (DicUsuarios.ContainsKey(IdVerUsuario))
        {
            
            tablaUsuario+=
            "".PadRight(30) +
            $"\t{IdVerUsuario}".PadRight(20) + 
            $"{DicUsuarios[IdVerUsuario].nombre}".PadRight(20) +
            $"{DicUsuarios[IdVerUsuario].edad}".PadRight(20) +
            $"{string.Join("-", DicUsuarios[IdVerUsuario].hobbies)}";
            
            Console.WriteLine(tablaUsuario);
            
        }else{
            Console.WriteLine("no exite");
        }
    }
    
    
    static void MostrarUsuarios(){
         string tablaUsuario =
         "".PadRight(30) +
        "\tID".PadRight(20) +
        "NOMBRE".PadRight(20) +
        "EDAD".PadRight(20) +
        "HOBBIES\n" +
        "".PadRight(30) +
        "______________________________________________________________________________________________\n";
        
        foreach(var key in DicUsuarios.Keys)
        {
            tablaUsuario+=
            "".PadRight(30) +
            $"\t{key}".PadRight(20) + 
            $"{DicUsuarios[key].nombre}".PadRight(20) +
            $"{DicUsuarios[key].edad}".PadRight(20) +
            $"{string.Join("-", DicUsuarios[key].hobbies)}\n";
            
        }
        Console.WriteLine(tablaUsuario);
        Thread.Sleep(5000);
    }            
    
    static void EliminarUsuario()
    {
        MostrarUsuarios();
        Console.Write("ID usuario a eliminar: ");
        long EliminarId = Convert.ToInt64(Console.ReadLine());
        DicUsuarios.Remove(EliminarId);
    }
    
        
}


