using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuronios {
    /// <summary>
    /// Perceptron simples com apenas um neurônio e 2 entradas
    /// </summary>
    public class SimplePerceptron {

        double[] pesos = new double[2];
        double[] entradas = new double[2];

        float taxaAprendizado = 0.5f;

        public SimplePerceptron() {
            Random rnd = new Random();
            // Gerar os pesos aleatoriamente
            for (int i = 0; i < pesos.Length; i++) {
                pesos[i] = rnd.NextDouble() * (1.0 - -1.0) + -1.0;
            }
        }

        /// <summary>
        /// Pede ao neurônio que calcule uma saida a partir dos valores de entrada
        /// </summary>
        /// <param name="entrada">Dados de entrada</param>
        /// <returns></returns>
        public int adivinhar(double[] entrada) {
            double soma = 0;
            for(int i = 0; i < pesos.Length; i++) {
                soma += entrada[i] * pesos[i];
            }
            int saida = Math.Sign(soma);
            return saida;
        }

        /// <summary>
        /// Treina o neurônio. O treino é feito passando os valores de 
        /// entrada e o resultado esperado para aquelas entradas. 
        /// Ao fim do treino é calculado o erro a partir da saída e o resultado esperado
        /// e os pesos são ajustados de acordo com o erro.
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="resultadoEsperado"></param>
        public void treinar(double[] entrada, int resultadoEsperado) {
            int resultado = adivinhar(entrada);
            int erro = resultadoEsperado - resultado;

            //Ajusta os pesos
            for (int i = 0; i < pesos.Length; i++) {
                pesos[i] += erro * entrada[i] * taxaAprendizado;
            }
        }
    }
}
