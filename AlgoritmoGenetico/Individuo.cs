using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico {

    class Individuo {

        public List<Double> elementos = new List<double>();
        private Double aptitud;

        /// <summary>
        /// Contructor que se utiliza en la primera generación
        /// </summary>
        public Individuo (int tamanio) {

            for (int i = 0; i < tamanio; i++) {

                elementos.Add(GenerarValor());
            }

            this.aptitud = CalcularAptitud();
        }

        /// <summary>
        /// Contructor vacio que se utiliza para crear a los hijos
        /// </summary>
        public Individuo () {

        }

        /// <summary>
        /// Generador de valores para la primera generación
        /// </summary>
        /// <returns>un valor entre -5.20 y 5.20</returns>
        public Double GenerarValor () {

            Random random= new Random();
            int valorEntero = random.Next(-5120, 5121);
            return valorEntero / 1000.0;
        }

        /// <summary>
        /// Metodo que calcula la aptitud del individuo
        /// </summary>
        /// <returns></returns>
        public Double CalcularAptitud () {

            Double suma = 0;
            foreach (Double elemento in elementos) {

                suma += (Math.Pow(elemento, 2) - (10 * Math.Cos(2 * Math.PI * elemento)));
            }

            return Math.Round((100 + suma), 3);
        }

        /// <summary>
        /// Metodo que modifica la aptitud
        /// </summary>
        /// <param name="aptitud"></param>
        public void SetAptitud (Double aptitud) {

            this.aptitud = aptitud;
        }

        /// <summary>
        /// Metodo que obtiene la aptitud del individuo
        /// </summary>
        /// <returns></returns>
        public Double GetAptitud () {

            return this.aptitud;
        }
    }
}
