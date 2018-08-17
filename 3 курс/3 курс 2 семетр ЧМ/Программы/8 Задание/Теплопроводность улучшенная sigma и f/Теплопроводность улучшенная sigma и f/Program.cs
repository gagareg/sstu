using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Теплопроводность_улучшенная_sigma_и_f
{
    class Program
    {
        static void Main(string[] args)
        {
            dif_yravnenie_2();
        }
        static double U(double x, double t)//u
        {
            return 10 * x * x * t * t + x * t + 10 * x + 1;
        }
        static double f(double x, double t)//v
        {
            return 20 * x * x * t + x - 20 * t * t;
        }
        static double fP(double x, double t)//v
        {
            return 40 * t;
        }
        static double fi1(double x, double t, double h)//v
        {
            return (f(x, t) + h * h * fP(x, t) / 12);
        }
        static double m1(double t)//v
        {
            return U(0, t);
        }
        static double m2(double t)//v
        {
            return U(1, t);
        }
        static double U0(double x)//v
        {
            return U(x, 0);
        }
        static public void dif_yravnenie_2()
        {
            Console.Write("Размерность сетки: \nN = ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("M = ");
            int M = int.Parse(Console.ReadLine());
            Console.WriteLine();
            double[,] u = new double[N + 1, M + 1];
            double h = 1.0 / N;
            double t = 1.0 / M;
            filling(N, M, h, t, ref u);
            Krank_Nicols3(N, M, h, t, ref u); // улучшенно sigma и f
            Console.WriteLine();
            Console.ReadKey();
        }
        static public void Krank_Nicols3(int N, int M, double h, double t, ref double[,] a) // улучшенно sigma и f
        {
            double sig = 0.5 - (h * h) / (12 * t);
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
                    double F = a[i, j] + t * (1 - sig) * (a[i - 1, j] - 2 * a[i, j] + a[i + 1, j]) / (h * h) + t * fi1(h * i, t * (j + 0.5), h);
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
    }
}
