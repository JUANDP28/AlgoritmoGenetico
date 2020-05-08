using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico {
    class Program {

        List<Individuo> poblacion = new List<Individuo>();

        public void GenerarPoblacion () {
            Console.WriteLine("");
            Console.WriteLine("=============== GENERANDO POBLACION ===============");
            Console.WriteLine("");
            for (int i = 0; i < 100; i++) {
                poblacion.Add(new Individuo());
            }
            Console.WriteLine("");
            Console.WriteLine("=============== POBLACION GENERADA ===============");
            Console.WriteLine("");
        }

        public void ImprimirAptitud () {
            foreach (Individuo elemento in poblacion) {
                Console.WriteLine("APTITUD: " + elemento.GetAptitud());
            }
        }
        static void Main (string [] args) {

            Program algoritmo = new Program();
            algoritmo.GenerarPoblacion();
            algoritmo.ImprimirAptitud();
            
        }
    }
}
