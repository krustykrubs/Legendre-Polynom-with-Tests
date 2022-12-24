using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleIntergral.App
{
    public class GaussQuadrature
    {
        public int k;
        public double[] coefficients;

        public GaussQuadrature(LegendrePolynom polynom)
        {
            this.k = polynom.n;
           // this.coefficients = polynom.GetRoots();
        }

        public virtual double GetCoefficient(int k) // Получение столбца свободных членов в системе уравнений
        {
            if (k % 2 == 0)
            {
                return 2.0 / (k + 1);
            }
            else
            {
                return 0;
            }
        }

        public double[] ComputeSlae(double[] coefficients) // Решение СЛАУ методом Гаусса
        {
            // Подготовка СЛАУ
            double[,] gaussSlae = new double[k, k]; // Матрица n строк на (n + 1) столбцов
            double[] x = new double[k]; // Массив неизвестных весовых коэффициентов Ai
            double[] b = new double[k]; // Массив свободных членов в СЛАУ 

            for (int j = 0; j < k; j++)
            {
                for (int i = 0; i < k; i++)
                {
                    gaussSlae[i, j] = Math.Pow(coefficients[j], i);
                }
            }

            for (int i = 0; i < k; i++)
            {
                b[i] = GetCoefficient(i);
            }

            // Прямой ход
            double summa, p;
            for (int m = 0; m <= k - 1; m++)
                for (int i = m + 1; i <= k - 1; i++)
                {
                    p = gaussSlae[i, m] / gaussSlae[m, m];
                    for (int j = 0; j <= k - 1; j++)
                        gaussSlae[i, j] -= p * gaussSlae[m, j];

                    b[i] -= p * b[m];
                }

            // Обратный ход 
            for (int i = k - 1; i >= 0; i--)
            {
                summa = 0;
                x[i] = 0;

                for (int j = i; j <= k - 1; j++)
                    summa += gaussSlae[i, j] * x[j];
                x[i] = (b[i] - summa) / gaussSlae[i, i];
            }

            return x;

        }

    }
}
