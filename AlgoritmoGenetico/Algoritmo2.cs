using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoGenetico {
    class Algoritmo2 {

        List<Individuo2> poblacion = new List<Individuo2>();
        List<Individuo2> posiblesPadres = new List<Individuo2>();
        List<Individuo2> padres = new List<Individuo2>();
        List<Individuo2> nuevaPoblacion = new List<Individuo2>();
        int numeroGeneraciones = 0, tamanioPoblacion = 100,
            generaciones = 700;
        Individuo2 mejor = null;

        /// <summary>
        /// Metodo que genera la población del algoritmo
        /// </summary>
        public void GenerarPoblacion () {
            Console.WriteLine("");
            Console.WriteLine(
                "=============== GENERANDO POBLACION ===============");
            Console.WriteLine("");

            for (int i = 0; i < tamanioPoblacion; i++) {

                poblacion.Add(new Individuo2(7));
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
                    NumeroRandom(1, 100)));
            }

            while (padres.Count() < 2) {

                if (NumeroRandom(0, 20) < 15) {

                    if (padres.Contains(ObtenerMejorPadres(posiblesPadres))) {

                        padres.Add(PadreAleatorio());

                    } else {

                        padres.Add(ObtenerMejorPadres(posiblesPadres));
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
        public Individuo2 ObtenerIndividuo (List<Individuo2> listaDisponible, int posicion) {

            int contador = 1;

            foreach (Individuo2 elemento in listaDisponible) {

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
        /// <param name="listaDisponible">Lista de población dada</param>
        /// <returns>Mejor individuo de la poblacion</returns>
        public Individuo2 ObtenerMejorPoblacion (List<Individuo2> listaDisponible) {

            if (this.mejor == null) {

                this.mejor = listaDisponible [0];
            }

            foreach (Individuo2 elemento in listaDisponible) {

                if ((this.mejor.GetAptitud() > elemento.GetAptitud()) &&
                    (this.mejor.GetRestricciones() >= elemento.GetRestricciones())) {

                    this.mejor = elemento;
                }
            }

            return this.mejor;
        }

        /// <summary>
        /// Metodo que obtiene el mejor individuo de los padres
        /// </summary>
        /// <returns></returns>
        public Individuo2 ObtenerMejorPadres (List<Individuo2> listaDisponible) {

            Individuo2 mejorPadre = ObtenerIndividuo(listaDisponible, 1);

            foreach (Individuo2 elemento in listaDisponible) {

                if ((mejorPadre.GetAptitud() > elemento.GetAptitud()) &&
                    (mejorPadre.GetRestricciones() >= elemento.GetRestricciones())) {

                    mejorPadre = elemento;
                }
            }

            return mejorPadre;
        }

        /// <summary>
        /// Metodo que Obtiene un padre aleatorio de 
        /// </summary>
        /// <returns></returns>
        public Individuo2 PadreAleatorio () {

            Boolean bandera = true;
            Individuo2 elemento = null;

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

            int cMin = 0, cMax = 0;
            Individuo2 hijo1 = new Individuo2();
            Individuo2 hijo2 = new Individuo2();
            Individuo2 papa1 = ObtenerIndividuo(padres, 1);
            Individuo2 papa2 = ObtenerIndividuo(padres, 2);
            padres.Clear();

            for (int i = 0; i < 7; i++) {

                if (papa1.elementos [i] > papa2.elementos [i]) {

                    cMax = papa1.elementos [i];
                    cMin = papa2.elementos [i];

                } else {

                    cMax = papa2.elementos [i];
                    cMin = papa1.elementos [i];
                }

                int resultante = cMax - cMin;
                int alpha = NumeroRandom(0, 2);
                hijo1.elementos.Add(
                    NumeroRandom(
                        (cMin - (resultante * alpha)),
                        (cMax + (resultante * alpha))));
                hijo2.elementos.Add(
                    NumeroRandom(
                        (cMin - (resultante * alpha)),
                        (cMax + (resultante * alpha))));
            }

            Mutacion(hijo1);
            Mutacion(hijo2);
            hijo1.CalcularAptitud();
            hijo2.CalcularAptitud();
            nuevaPoblacion.Add(hijo1);
            nuevaPoblacion.Add(hijo2);
        }

        /// <summary>
        /// Metodo que muta el cromosoma del inidviduo
        /// </summary>
        /// <param name="hijo"></param>
        public void Mutacion (Individuo2 hijo) {

            if (NumeroRandom(0, 20) != 19) {

                int valor = NumeroRandom(0, 7);
                hijo.elementos [valor] = hijo.elementos[valor] * -1;
            }
        }

        /// <summary>
        /// Metodo que remplaza la población
        /// </summary>
        /// <param name="listaPoblacion">Población original</param>
        /// <param name="listaReemplazo">Población que remplazara</param>
        public void Elitismo () {

            Individuo2 individuo = ObtenerIndividuo(nuevaPoblacion, NumeroRandom(0, 101));
            nuevaPoblacion.Remove(individuo);
            poblacion.Clear();

            foreach (Individuo2 elemento in nuevaPoblacion) {

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
            ObtenerMejorPoblacion(poblacion);
            Console.WriteLine("GENERACION NUMERO " + numeroGeneraciones +
                ", APTITUD: " + this.mejor.GetAptitud() +
                ", NUMERO RESTRICCIONES: " + this.mejor.GetRestricciones());

            while (numeroGeneraciones < generaciones) {

                while (nuevaPoblacion.Count() < tamanioPoblacion) {

                    SeleccionarPadres();
                    CruzaPadres();
                }

                Elitismo();
                numeroGeneraciones++;
                ObtenerMejorPoblacion(poblacion);
                Console.WriteLine("GENERACION NUMERO " + numeroGeneraciones +
                ", APTITUD: " + this.mejor.GetAptitud() +
                ", NUMERO RESTRICCIONES: " + this.mejor.GetRestricciones());
            }
        }

    }
}
