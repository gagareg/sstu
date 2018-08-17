using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Струна
{
    class Program
    {
        static void Main(string[] args)
        {
            dif_yravnenie_2();
        }
        static double U(double x, double t)//u
        {
            return 10 * x * x * x * t * t * t + x * t + 10 * x + 1;
        }
        static double U1(double x)
        {
            return x;
        }
        static double f(double x, double t)
        {
            return 60 * x * x * x * t - 60 * t * t * t * x;
        }
        static double fi1(double x, double t)
        {
            return f(x, t);
        }
        static double fi2(double x, double t, double h)
        {
            return f(x, t) + h * h * d2f(x, t) / 12;
        }
        static double d2f(double x, double t)//d2f/dx2
        {
            return 360 * x * t;
        }
        static double m1(double t)//u(0,t)
        {
            return 1;
        }
        static double m2(double t)//u(1,t)
        {
            return 10 * t * t * t + t + 11;
        }
        static double U0(double x)//u(x,0)
        {
            return 10 * x + 1;
        }
        static public void dif_yravnenie_2()
        {
            Console.Write("Размерность сетки: \nN = ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("M = ");
            int M = int.Parse(Console.ReadLine());
            Console.Write("sigma = ");
            double sig = double.Parse(Console.ReadLine());
            Console.WriteLine();
            double[,] u = new double[N + 1, M + 1];
            double h = 1.0 / N;
            double t = 1.0 / M;
            filling(N, M, h, t, ref u);
            Struna(sig, N, M, h, t, ref u);           
            Console.ReadKey();
        }
        static public void Struna(double sig, int N, int M, double h, double t, ref double[,] a) //для любой sigma
        {

            double gam = t / h;
            double max = 0;
            for (int j = 1; j < M; j++)
            {
                double[] alf = new double[N + 1];
                double[] bet = new double[N + 1];
                bet[1] = a[0, j + 1];
                alf[1] = 0;
                for (int i = 1; i < N; i++)
                {
                    double A = sig * gam * gam; //47
                    double C = 1 + 2.0 * gam * gam * sig;
                    double B = sig * gam * gam;
                    double F = 2 * a[i, j] - a[i, j - 1] + (1 - 2 * sig) * gam * gam * (a[i + 1, j] - 2 * a[i, j] + a[i - 1, j]) + sig * gam * gam * (a[i + 1, j - 1] - 2 * a[i, j - 1] + a[i - 1, j - 1]) + t * t * fi1(i * h, j * t);
                    alf[i + 1] = B / (C - A * alf[i]);
                    bet[i + 1] = (F + A * bet[i]) / (C - A * alf[i]);
                }
                for (int i = N; i > 1; i--)
                {
                    a[i - 1, j + 1] = a[i, j + 1] * alf[i] + bet[i];
                    if (max <= Math.Abs(U((i - 1) * h, (j + 1) * t) - a[i - 1, j + 1]) / a[i - 1, j + 1])
                    {
                        max = Math.Abs(U((i - 1) * h, (j + 1) * t) - a[i - 1, j + 1]) / a[i - 1, j + 1];
                    }
                    
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
                    if (j == 1 && i > 0 && i < N) a[i, j] = a[i, j - 1] + t * (U1(i * h) + 0.5 * t * f(i * h, 0));
                    //if (j == 1 && i > 0 && i < N) a[i, j] = U(i*h,j*t);
                }
        }
    }
}
