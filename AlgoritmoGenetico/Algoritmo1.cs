using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoGenetico {

    class Algoritmo1 {

        List<Individuo> poblacion = new List<Individuo>();
        List<Individuo> posiblesPadres = new List<Individuo>();
        List<Individuo> padres = new List<Individuo>();
        List<Individuo> nuevaPoblacion = new List<Individuo>();
        int numeroGeneraciones = 0, tamanioPoblacion = 100,
            generaciones = 700;

        /// <summary>
        /// Metodo que genera la población del algoritmo
        /// </summary>
        public void GenerarPoblacion () {

            Console.WriteLine("");
            Console.WriteLine(
                "=============== GENERANDO POBLACION ===============");
            Console.WriteLine("");

            for (int i = 0; i < tamanioPoblacion; i++) {

                poblacion.Add(new Individuo(10));
            }

            Console.WriteLine("");
            Console.WriteLine(
                "=============== POBLACION GENERADA ===============");
            Console.WriteLine("");
        }

        /// <summary>
        /// Metodo que selecciona los padres para el nuevo individuo
        /// </summary>
        public void SeleccionarPadres () {

            while (posiblesPadres.Count() < 10) {

                posiblesPadres.Add(ObtenerIndividuo(poblacion,
                    NumeroRandom(1, 101)));
            }

            while (padres.Count() < 2) {

                if (NumeroRandom(0, 20) != 19) {

                    if (padres.Contains(ObtenerMejor(posiblesPadres))) {

                        padres.Add(PadreAleatorio());

                    } else {

                        padres.Add(ObtenerMejor(posiblesPadres));
                    }

                } else {

                    padres.Add(PadreAleatorio());
                }
            }

            posiblesPadres.Clear();
        }

        /// <summary>
        /// Metodo que genera un numero aleatorio segun los parametros
        /// </summary>
        /// <param name="minimio">Valor minimo del rango</param>
        /// <param name="maximo">Valor maximo del rango</param>
        /// <returns>Valor de tipo entero entre el rango proporcionado</returns>
        public int NumeroRandom (int minimio, int maximo) {

            Random random = new Random();
            return random.Next(minimio, maximo);
        }

        /// <summary>
        /// Metodo que obtiene un individuo de la lista dada en una
        /// posición especifica
        /// </summary>
        /// <param name="listaDisponible">lista donde buscara</param>
        /// <param name="posicion">posición del individuo</param>
        /// <returns>Individuo de la lista dada</returns>
        public Individuo ObtenerIndividuo (List<Individuo> listaDisponible, int posicion) {

            int contador = 1;

            foreach (Individuo elemento in listaDisponible) {

                if (contador == posicion) {

                    return elemento;
                }

                contador++;
            }

            return null;
        }

        /// <summary>
        /// Metodo que devuelve el mejor Inidividuo de la poblacion dada
        /// </summary>
        /// <param name="listaDisponible"></param>
        /// <returns></returns>
        public Individuo ObtenerMejor (List<Individuo> listaDisponible) {

            Individuo mejor = ObtenerIndividuo(listaDisponible, 1);

            foreach (Individuo elemento in listaDisponible) {

                if (elemento.GetAptitud() < mejor.GetAptitud()) {

                    mejor = elemento;
                }
            }

            return mejor;
        }

        /// <summary>
        /// Metodo que Obtiene un padre aleatorio de 
        /// </summary>
        /// <returns></returns>
        public Individuo PadreAleatorio () {

            Boolean bandera = true;
            Individuo elemento = null;

            while (bandera) {

                elemento = ObtenerIndividuo(posiblesPadres, NumeroRandom(1, 11));

                if (!padres.Contains(elemento)) {

                    bandera = false;
                }
            }

            return elemento;
        }

        /// <summary>
        /// Metodo de cruza
        /// </summary>
        public void CruzaPadres () {

            Double cMin = 0.0, cMax = 0.0;
            Individuo hijo1 = new Individuo();
            Individuo hijo2 = new Individuo();
            Individuo papa1 = ObtenerIndividuo(padres, 1);
            Individuo papa2 = ObtenerIndividuo(padres, 2);
            padres.Clear();

            for (int i = 0; i < 10; i++) {

                if (papa1.elementos [i] > papa2.elementos [i]) {

                    cMax = papa1.elementos [i];
                    cMin = papa2.elementos [i];

                } else {

                    cMax = papa2.elementos [i];
                    cMin = papa1.elementos [i];
                }

                Double resultante = cMax - cMin;
                int alpha = NumeroRandom(0, 2);
                hijo1.elementos.Add(
                    (NumeroRandom(
                        (int) ((cMin - (resultante * alpha)) * 1000),
                        (int) ((cMax + (resultante * alpha)) * 1000)))
                        / 1000.0);
                hijo2.elementos.Add(
                    (NumeroRandom(
                        (int) ((cMin - (resultante * alpha)) * 1000),
                        (int) ((cMax + (resultante * alpha)) * 1000)))
                        / 1000.0);
            }

            Mutacion(hijo1);
            Mutacion(hijo2);
            hijo1.SetAptitud(hijo1.CalcularAptitud());
            hijo2.SetAptitud(hijo2.CalcularAptitud());
            nuevaPoblacion.Add(hijo1);
            nuevaPoblacion.Add(hijo2);
        }

        /// <summary>
        /// Metodo que muta el cromosoma del inidviduo
        /// </summary>
        /// <param name="hijo"></param>
        public void Mutacion (Individuo hijo) {

            if (NumeroRandom(0, 20) != 19) {

                int valor = NumeroRandom(0, 10);
                hijo.elementos [valor] = hijo.elementos [valor] * -1;
            }
        }

        /// <summary>
        /// Metodo que remplaza la población
        /// </summary>
        /// <param name="listaPoblacion">Población original</param>
        /// <param name="listaReemplazo">Población que remplazara</param>
        public void Elitismo () {

            Individuo individuo = ObtenerIndividuo(nuevaPoblacion, NumeroRandom(0, 101));
            nuevaPoblacion.Remove(individuo);
            nuevaPoblacion.Add(ObtenerMejor(poblacion));
            poblacion.Clear();

            foreach (Individuo elemento in nuevaPoblacion) {

                poblacion.Add(elemento);
            }

            nuevaPoblacion.Clear();
        }

        /// <summary>
        /// Metodo que inicializa el algoritmo
        /// </summary>
        public void Empezar () {

            GenerarPoblacion();
            numeroGeneraciones++;
            Console.WriteLine("GENERACION NUMERO " + numeroGeneraciones +
                ", APTITUD: " + ObtenerMejor(poblacion).GetAptitud());

            while (numeroGeneraciones < generaciones) {

                while (nuevaPoblacion.Count() < tamanioPoblacion) {

                    SeleccionarPadres();
                    CruzaPadres();
                }

                Elitismo();
                numeroGeneraciones++;
                Console.WriteLine("GENERACION NUMERO " + numeroGeneraciones +
                    ", APTITUD: " + ObtenerMejor(poblacion).GetAptitud());
            }
        }
    }
}
