using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico {

    class Individuo2 {

        public List<int> elementos = new List<int>();
        private Double aptitud = 0;
        private int restriccionesIncumplidas = 0;

        /// <summary>
        /// Contructor que se utiliza para crear la población
        /// </summary>
        /// <param name="tamanio">numero de variables para la solucion</param>
        public Individuo2 (int tamanio) {

            for (int i = 0; i < tamanio; i++) {

                elementos.Add(NumeroAleatorio(-10, 11));
            }

            CalcularAptitud();
        }

        /// <summary>
        /// Contructor vacio que se utiliza para los hijos
        /// </summary>
        public Individuo2 () {

        }

        /// <summary>
        /// Metodo que genera un valor aleatorio entre el rango proporcionado
        /// </summary>
        /// <param name="minimo">valor minimo del rango</param>
        /// <param name="maximo">valor maximo del rango</param>
        /// <returns>valor en el intervalo</returns>
        public int NumeroAleatorio(int minimo, int maximo) {

            Random random = new Random();
            return random.Next(minimo, maximo);
        }

        /// <summary>
        /// Metodo que calcula la aptitud de los individuos
        /// </summary>
        public void CalcularAptitud () {

            this.aptitud = Math.Pow((elementos [0] - 10), 2) +
                (5 * Math.Pow((elementos [1] - 12), 2)) +
                Math.Pow(elementos [2], 4) +
                (3 * Math.Pow((elementos [3] - 11), 2)) +
                (10 * Math.Pow(elementos [4], 6)) +
                (7 * Math.Pow(elementos [5], 2)) +
                Math.Pow(elementos [6], 4) -
                (4 * elementos [5] * elementos [6]) -
                (10 * elementos [5]) -
                (8 * elementos [6]);

            if (-127 + (2 * Math.Pow(elementos[0], 2)) +
                (3 * Math.Pow(elementos[1], 4)) +
                elementos[2] +
                (4 * Math.Pow(elementos[3], 2)) +
                (5 * elementos[5]) > 0) {

                this.restriccionesIncumplidas++;
            }

            if (-282 + (7 * elementos[0]) +
                (3 * elementos[1]) +
                (10 * Math.Pow(elementos[2], 3)) +
                elementos[3] -
                elementos[5] > 0) {

                this.restriccionesIncumplidas++;
            }

            if (-196 + (23 * elementos[0]) +
                Math.Pow(elementos[1], 2) +
                (6 * Math.Pow(elementos[5], 2)) -
                8 * elementos[6] > 0) {

                this.restriccionesIncumplidas++;
            }

            if ((4 * Math.Pow(elementos[0], 2)) +
                Math.Pow(elementos[1], 2) -
                (3 * elementos[0] * elementos[1]) +
                (2 * Math.Pow(elementos[2], 2)) +
                (5 * elementos[5]) -
                (11 * elementos[6]) > 0) {

                this.restriccionesIncumplidas++;
            }
        }

        /// <summary>
        /// Metodo que obtiene la aptitud
        /// </summary>
        /// <returns>El valor de aptitud</returns>
        public Double GetAptitud () {
            return this.aptitud;
        }

        /// <summary>
        /// Metodo que obtiene el numero de restricciones incumplidas
        /// </summary>
        /// <returns>valor de restricciones incumplidas</returns>
        public int GetRestricciones () {
            return this.restriccionesIncumplidas;
        }

    }
}
