using System;

namespace AlgoritmoGenetico {
    class Program {

        static void Main (string [] args) {

            Boolean bandera = true;

            while (bandera) {

                Console.WriteLine("SELECCIONA UNA OPCIÓN:");
                Console.WriteLine("1) Algortimo 1");
                Console.WriteLine("2) Algoritmo 2");
                Console.WriteLine("3) Salir");
                String opcion = Console.ReadLine();

                switch (opcion) {

                    case "1": Algoritmo1 programa = new Algoritmo1();
                        programa.Empezar();
                        break;

                    case "2": Algoritmo2 programa2 = new Algoritmo2();
                        programa2.Empezar();
                        break;

                    case "3": Console.WriteLine("");
                        Console.WriteLine(" NOS VEMOS");
                        bandera = false;
                        break;

                    default: Console.WriteLine("");
                        Console.WriteLine(" POR FAVOR ESCOJA UNA OPCION VALIDA");
                        Console.WriteLine("");
                        break;
                }
            }

        }
    }
}
