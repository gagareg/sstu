using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Струна2
{
    class Program
    {
        static double u(double x, double t)
        {
            return 8 * Math.Pow(x, 3) * Math.Pow(t, 3) + x * t + 8 * x + 1;
        }
        static double f(double x, double t)
        {
            return 48 * Math.Pow(x, 3) * t - 48 * Math.Pow(t, 3) * x;
        }
        static double u0(double x)
        {
            return 8 * x + 1;
        }
        static double u1(double x)
        {
            return x;
        }
        static double m1()
        {
            return 1;
        }
        static double m2(double t)
        {
            return 8 * Math.Pow(t, 3) + t + 9;
        }
        static double y1(double x, double tay)
        {
            return 0.5 * Math.Pow(tay, 2) * f(x, 0) + u0(x) + tay * u1(x);
            
        }
        
        static void Filling(ref double[,] y, double x, double t, int N, int M)
        {
            for (int i = 0; i <= N; i++)
            {
                y[i, 0] = u0(i * x);

            }
            for (int j = 0; j <= M; j++)
            {
                y[0, j] = m1();
                y[N, j] = m2(j * t);
            }
            for (int i = 1; i < N; i++)
            {
                y[i, 1] = y1(i * x, t);
            }

        }
        static void zapu(ref double[,] y, double h, double tay, int N, int M)
        {
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    y[i, j] = u(h * i, j * tay);
                }
            }
        }
        static double maxz(double[,] y, double[,] u, int N, int M)
        {
            double max = 0;
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (max < Math.Abs((y[i, j] - u[i, j]) / y[i, j])) max = Math.Abs((y[i, j] - u[i, j]) / y[i, j]);
                }
            }
            return max;
        }
        static void Progon(ref double[,] y, int N, int M, double h, double tay, double sig)
        {
            double gamma = tay / h;
            for (int j = 1; j < M; j++)
            {
                double[] alf = new double[N + 1];
                double[] bet = new double[N + 1];
                bet[1] = y[0, j + 1];
                alf[1] = 0;
                for (int i = 1; i < N; i++)
                {
                    double Lj = y[i - 1, j] - 2 * y[i, j] + y[i + 1, j];
                    double Lj1 = y[i - 1, j - 1] - 2 * y[i, j - 1] + y[i + 1, j - 1];
                    double A = sig * gamma * gamma;
                    double C = 1 + 2.0 * sig * gamma * gamma;
                    double B = sig * gamma * gamma;
                    double F = (2 * y[i, j] - y[i, j - 1]) + gamma * gamma * (1 - 2 * sig) * Lj +
                        sig * gamma * gamma * Lj1 + Math.Pow(tay, 2) * f(i * h, j * tay);
                    alf[i + 1] = B / (C - A * alf[i]);
                    bet[i + 1] = (F + A * bet[i]) / (C - A * alf[i]);
                }
                for (int i = N; i > 1; i--)
                {
                    y[i - 1, j + 1] = y[i, j + 1] * alf[i] + bet[i];
                }

            }
        }


        static void Main()
        {
            Console.Write("sigma = ");
            double sigma = double.Parse(Console.ReadLine());
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("M = ");
            int M = int.Parse(Console.ReadLine());

            double[,] y = new double[N + 2, M + 2];
            double[,] ur = new double[N + 1, M + 1];
            double h = 1.0 / N, tay = 1.0 / M;
            Filling(ref y, h, tay, N, M);
            zapu(ref ur, h, tay, N, M);
            Console.WriteLine();
            Progon(ref y, N, M, h, tay, sigma);
            Console.WriteLine("z = {0:0.############}", maxz(y, ur, N, M));



            Console.ReadKey();
        }
    }
}
