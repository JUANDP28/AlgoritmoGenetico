using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmoGenetico {
    class Individuo {

        private List<Double> elementos = new List<double>();
        private Double aptitud;

        public Individuo () {

            for (int i = 0; i < 10; i++) {
                elementos.Add(GenerarValor());
            }

            this.aptitud = CalcularAptitud();
        }

        public Double GenerarValor () {
            Random random= new Random();
            int valorEntero = random.Next(-5120, 5121);
            return valorEntero / 1000.0;
        }

        public Double CalcularAptitud () {
            Double suma = 0;
            foreach (Double elemento in elementos) {
                suma += (Math.Pow(elemento, 2) - (10 * Math.Cos(2 * Math.PI * elemento)));
            }
            return Math.Round((100 + suma), 3);
        }

        public Double GetAptitud () {
            return this.aptitud;
        }
    }
}
