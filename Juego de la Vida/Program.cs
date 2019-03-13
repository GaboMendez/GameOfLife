using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Juego_de_la_Vida
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca el # Columnas: ");
            int.TryParse(Console.ReadLine(), out int x);
            if (x <= 0)
            {
                Console.WriteLine("Caracter no valido.");
            }
            else
                Console.WriteLine("Introduzca el # Filas: ");

            int.TryParse(Console.ReadLine(), out int y);
            Celulas Matriz = new Celulas(x, y);
            Matriz.sizeX = x;
            Matriz.sizeY = y;
            if (y <= 0)
            {
                Console.WriteLine("Caracter no valido.");
            }
            else
            {


                Console.WriteLine("¿Que desea hacer?");
                Console.WriteLine("1.Generar Matriz aleatoria.\n2.Generar tu propia Matriz.\n3.Salir");
                int.TryParse(Console.ReadLine(), out int opcion);
              
                switch (opcion)
                {
                    case 1:
                        bool seguir = true;
                        Console.WriteLine("Esta es su Matriz: ");
                        Matriz.RamdomMatriz();
                        Matriz.GenerarMatriz();
                        while (seguir)
                        {
                            Console.WriteLine("Deseas ejecutar el programa automaticamente? \n1.Si \n2.No");
                            string automatic = Console.ReadLine();
                            if (automatic == "Si" || automatic == "1" || automatic == "si")
                            {
                                Console.WriteLine("Cuanta veces quieres que se ejecute? ");
                                int number;
                                int a = 0;
                                int.TryParse(Console.ReadLine(), out number);
                                Console.Clear();
                                if (number == 0)
                                {
                                    Console.WriteLine("Caracter no valido.");
                                }
                                while (a < number)
                                {
                                    Thread.Sleep(250);
                                    Console.Clear();
                                    Matriz.Avanzar();
                                    Matriz.Final();
                                    Console.WriteLine("Esta es la Ejecucion #" + (a + 1) + ".");
                                    a++;
                                }
                                Console.WriteLine("Gracias por Utilizarme :v");
                                break;


                            }
                            else if (automatic == "No" || automatic == "2" || automatic == "no")
                            {

                                Console.WriteLine("Presione ENTER para continuar!");
                                Console.ReadLine();
                                while (true)
                                {
                                    //Console.Clear();
                                    Matriz.Avanzar();
                                    Matriz.Final();

                                    Console.WriteLine("Presione ENTER para continuar, escriba 'Salir' o 'Exit' para Salir. ");
                                    string outt = Console.ReadLine();
                                    if (outt == "Salir" || outt == "Exit" || outt == "salir" || outt == "exit")
                                    {
                                        seguir = false;
                                        Console.WriteLine("Gracias por utilizarme! :v");
                                        break;
                                    }

                                }

                            }
                            else Console.WriteLine("Caracter no valido!");
                            continue;
                        }
                        break;

                    case 2:
                        bool seguir2 = true;
                        Matriz.GenerarMiMatriz();
                        Console.WriteLine("Esta es su Matriz: ");
                        Matriz.GenerarMatrizPropia();
                        while (seguir2)
                        {
                            Console.WriteLine("Deseas ejecutar el programa automaticamente? \n1.Si \n2.No");
                            string automatic = Console.ReadLine();
                            if (automatic == "Si" || automatic == "1" || automatic == "si")
                            {
                                Console.WriteLine("Cuanta veces quieres que se ejecute? ");
                                int number;
                                int a = 0;
                                int.TryParse(Console.ReadLine(), out number);
                                Console.Clear();
                                if (number == 0)
                                {
                                    Console.WriteLine("Caracter no valido.");
                                }
                                while (a < number)
                                {
                                    Thread.Sleep(250);
                                    Console.Clear();
                                    Matriz.AvanzarMiMatriz();
                                    Matriz.FinalMiMatriz();
                                    Console.WriteLine("Esta es la Ejecucion #" + (a + 1) + ".");
                                    a++;
                                }
                                Console.WriteLine("Gracias por Utilizarme :v");
                                break;


                            }
                            else if (automatic == "No" || automatic == "2" || automatic == "no")
                            {

                                Console.WriteLine("Presione ENTER para continuar!");
                                Console.ReadLine();
                                while (true)
                                {
                                    //Console.Clear();
                                    Matriz.AvanzarMiMatriz();
                                    Matriz.FinalMiMatriz();

                                    Console.WriteLine("Presione ENTER para continuar, escriba 'Salir' o 'Exit' para Salir. ");
                                    string outt = Console.ReadLine();
                                    if (outt == "Salir" || outt == "Exit" || outt == "salir" || outt == "exit")
                                    {
                                        seguir2 = false;
                                        Console.WriteLine("Gracias por utilizarme! :v");
                                        break;
                                    }

                                }

                            }
                            else Console.WriteLine("Caracter no valido!");
                            continue;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Pase buen dia! :3");
                        break;

                    default:
                        Console.WriteLine("Se ha introducido caracter invalido.");
                        break;

                }
            }
            Console.ReadLine();
        }
    }
}
