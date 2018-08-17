using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Теплопроводность_версия_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Sigma = ");
            double sig = double.Parse(Console.ReadLine());
            if (sig == 0)
            {
                int N = 10;
                int M = 200;
                double[,] u = new double[N + 1, M + 1];
                double h = 1.0 / N;
                double t = 1.0 / M;
                filling(N, M, h, t, ref u);
                krank(sig, N, M, h, t, ref u);
            }
            else if (sig == 0.5)
            {
                int N = 10;
                int M = 10;
                double[,] u = new double[N + 1, M + 1];
                double h = 1.0 / N;
                double t = 1.0 / M;
                filling(N, M, h, t, ref u);
                krank(sig, N, M, h, t, ref u);
            }
            else if (sig == 1)
            {
                int N = 10;
                int M = 100;
                double[,] u = new double[N + 1, M + 1];
                double h = 1.0 / N;
                double t = 1.0 / M;
                filling(N, M, h, t, ref u);
                krank(sig, N, M, h, t, ref u);
            }
            else
                Console.Write("Error");
            Console.ReadKey();
        }
        static double U(double x, double t)
        {
            return 7 * Math.Pow(x, 2) * Math.Pow(t, 2) + x * t + 7 * x + 1;
        }
        static double f(double x, double t)
        {
            return 14 * Math.Pow(x, 2) * t - 14 * Math.Pow(t, 2) + x;
        }
        static double m1(double t)
        {
            return U(0, t);
        }
        static double m2(double t)
        {
            return U(1, t);
        }
        static double U0(double x)
        {
            return U(x, 0);
        }
        static public void krank(double sig, int N, int M, double h, double t, ref double[,] a)
        {
            double max = 0;
            for (int j = 0; j < M; j++)
            {
                double[] alf = new double[N + 1];
                double[] bet = new double[N + 1];
                bet[1] = a[0, j + 1];
                alf[1] = 0;
                for (int i = 1; i < N; i++)
                {
                    double A = t * sig / (h * h);
                    double C = 1 + 2.0 * t * sig / (h * h);
                    double B = t * sig / (h * h);
                    double F = a[i, j] + t * (1 - sig) * (a[i - 1, j] - 2 * a[i, j] + a[i + 1, j]) / (h * h) + t * f(h * i, t * (j + 0.5));
                    alf[i + 1] = B / (C - A * alf[i]);
                    bet[i + 1] = (F + A * bet[i]) / (C - A * alf[i]);
                }
                for (int i = N; i > 1; i--)
                {
                    a[i - 1, j + 1] = a[i, j + 1] * alf[i] + bet[i];
                    if (max <= Math.Abs(U((i - 1) * h, (j + 1) * t) - a[i - 1, j + 1]))
                        max = Math.Abs(U((i - 1) * h, (j + 1) * t) - a[i - 1, j + 1]);
                }
            }
            Console.WriteLine("z = {0}", max);
        }
        static void filling(int N, int M, double h, double t, ref double[,] a)
        {
            for (int i = 0; i <= N; i++)
                for (int j = 0; j <= M; j++)
                {
                    if (i == 0) a[i, j] = m1(j * t);
                    if (i == N) a[i, j] = m2(j * t);
                    if (j == 0) a[i, j] = U0(i * h);
                }
        }
        static public void print(int N, int M, double[,] a)
        {
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                    Console.Write("{0:0.00} ", a[i, j]);
                Console.WriteLine("\n");
            }
        }
    }
}
