using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace МетодПрогонки
{
    class Program
    {

        static double F(double x)
        {
            return -(6.0 * x - Q(x) * U(x));
        }
        static double U(double x)
        {
            return Math.Pow(x, 3) + (x / 7.0) + 7.0;
        }
        static double Q(double x)
        {
            return 7.0 * x;
        }


        static public void Main(string[] args)
        {
            double m1 = 7.0; //Мю1
            double m2 = 57.0 / 7.0; //Мю2
            int N = 100;
            double h = 1.0 / N;
            double a = 1.0 / Math.Pow(h, 2), b = 1.0 / Math.Pow(h, 2), x = 0; //Ai,Bi
            double[] c = new double[150];
            double[] alpha = new double[150];
            double[] beta = new double[150];
            double[] y = new double[150];

            alpha[0] = 0; //51
            beta[0] = m1; //51

            for (int i = 0; i <= N; i++)
            {
                c[i] = (2.0 / Math.Pow(h, 2)) + Q(i * h);
            }
            for (int i = 1; i <= N; i++)
            {
                alpha[i] = b / (c[i - 1] - a * alpha[i - 1]); //49
                beta[i] = (a * beta[i - 1] + F((i - 1) * h)) / (c[i - 1] - a * alpha[i - 1]); //50
            }
            y[N] = m2;//52

            for (int i = N - 1; i >= 0; i--)
            {
                y[i] = alpha[i + 1] * y[i + 1] + beta[i + 1];//48

            }
            double max = 0;
            for (int i = 1; i <= N; i++)
            {
                x = i * h;
                if ((Math.Abs(y[i] - U(x))) / y[i] > max)
                {
                    max = (Math.Abs(y[i] - U(x))) / y[i];
                }
            }
            Console.WriteLine("max = {0}", max);
            Console.WriteLine();

            Console.ReadKey();
        }

    }
}
