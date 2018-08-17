using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Дирихле
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 10;
            double e = 0.0001, w = 0.1;
            double h = 1.0 / N;
            double[,] y = new double[N + 1, N + 1];

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    if (i == 0)
                        y[i, j] = M3(j * h);
                    else if (i == N)
                        y[i, j] = M4(j * h);

                    else if (j == 0)
                        y[i, j] = M1(i * h);
                    else if (j == N)
                        y[i, j] = M2(i * h);

                    else
                    {
                        y[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    Console.WriteLine("y[{0}{1}] = {2}]", i, j, y[i, j]);
                }
            }

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    if (i == 0 || i == N || j == 0 || j == N)
                    {
                        y[i, j] = U(i * h, j * h);
                    }
                    else
                    {
                        y[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    //Console.WriteLine("y[{0},{1}] = {2}", i, j, y[i, j]);
                }
            }

            Console.WriteLine("КИ=количество итераций АП=абсолютная погрешность ОП=относительная погрешность");
            Console.WriteLine();
            int t = 1;
            for (double k = 1; k <= 2 + e; k += w)
            {
                double max = e, z = 0, z1 = 0;
                while (max >= e)
                {
                    max = 0;
                    z = 0;
                    z1 = 0;
                    for (int i = 1; i < N; i++)
                        for (int j = 1; j < N; j++)
                        {
                            double b = y[i, j];
                            y[i, j] = k * (y[i - 1, j] + y[i, j - 1] + y[i + 1, j] + y[i, j + 1] + h * h * f(i * h, j * h)) / 4 + (1 - k) * y[i, j];
                            if (max <= Math.Abs((y[i, j] - b) / y[i, j]))
                                max = Math.Abs((y[i, j] - b) / y[i, j]);

                        }
                    t++;
                    for (int i = 0; i < N; i++)
                        for (int j = 0; j < N; j++)
                        {

                            z1 = Math.Abs(U(i * h, j * h) - y[i, j]);
                            z = Math.Abs((U(i * h, j * h) - y[i, j]) / y[i, j]);

                        }

                }
                Console.WriteLine("w = {0} КИ = {1} АП = {2} ОП = {3}", k, t, z1, z);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static double U(double x1, double x2)
        {
            return x1 * x1 * x1 + 7 * (x2 * x2 * x2) + x1 + 7 * x2 + 0.7;
        }
        static double f(double x1, double x2)
        {
            return -6 * x1 - 42 * x2;
        }
        static double M1(double x1)
        {
            return U(x1, 0);
        }

        static double M2(double x1)
        {
            return U(x1, 1);
        }

        static double M3(double x2)
        {
            return U(0, x2);
        }

        static double M4(double x2)
        {
            return U(1, x2);
        }
    }
}
