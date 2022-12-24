namespace DoubleIntergral.App
{
    public class LegendrePolynom
    {
        public int n; // Полином Лежандра степени n

        public LegendrePolynom(int n)
        { // Создание объекта в конструкторе

            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Степень должна быть неотрицательной");
            }

            this.n = n;
            Console.WriteLine("Задан полином Лежандра степени {0}", n);
        }

        public virtual double ComputePolynom(double argument) // Вычисление полинома Лежандра степени n
        {
            double P0 = 1.0;
            double P1 = argument;
            double P2 = (3.0 * argument * argument - 1) / 2.0;

            int i = 1;
            /* if (n < 0)
                 return -1; */

            if (n == 0)
                return P0;
            else if (n == 1)
                return P1;
            else
            {
                while (i < n)
                {
                    P2 = 2.0 * argument * P1 - P0 - (argument * P1 - P0) / (i + 1);
                    P0 = P1;
                    P1 = P2;
                    i++;
                }
                return P2;
            }
        }

        public virtual double Dichotomy(double a, double b, double eps) // Нахождение корня функции на отрезке
        {
            double c;
            if (ComputePolynom(a) * ComputePolynom(b) <= 0)
            {

                int iteration = 1;
                do
                {
                    c = (a + b) / 2;
                    if (ComputePolynom(c) * ComputePolynom(a) < 0)
                    {
                        b = c;
                    }
                    else if (ComputePolynom(c) * ComputePolynom(a) > 0)
                    {
                        a = c;
                    }
                    else if (ComputePolynom(c) == 0)
                    {
                        return c;
                    }
                    iteration++;


                }
                while (Math.Abs(a - b) >= eps);

                return c;
            }
            else
            {
                return 999;
            }

        }

       public double[] GetRoots() // Получение массива корней полинома Лежандра
        {
            int i = 0;
            double[] massiv = new double[n];

            for (double x = -1.0; x <= 1; x = x + 0.001)
            {
                double root = Dichotomy(x, x + 0.001, 0.00001);
                if (root != 999)
                {
                    massiv[i] = root;
                    i++;
                }
            }
            return massiv;
        } 
    }
}