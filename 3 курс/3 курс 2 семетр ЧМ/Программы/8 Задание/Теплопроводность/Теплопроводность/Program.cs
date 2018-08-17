using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Теплопроводность
{
    class Program
    {
        static double u(double x, double t)
        {
            return 7 * Math.Pow(x, 2) * Math.Pow(t, 2) + x * t + 7 * x + 1;
        }
        static double f(double x, double t)
        {
            return 14 * Math.Pow(x, 2) * t - 14 * Math.Pow(t, 2) + x;
        }
        static double u0(double x)
        {
            return 7 * x + 1;
        }
        static double m1()
        {
            return 1;
        }
        static double m2(double x, double t)
        {
            //return 7 * Math.Pow(t, 2) + t + 7 + 1;
            return u(x, t); 
        }
        static void Filling(ref double[,] y, double x, double t, int N, int M) // Заполнение шаблона(сетки)
        {
            for (int i = 0; i <= N; i++)
            {
                y[i, 0] = u0(i * x);
            }
            for (int j = 0; j <= M; j++)
            {
                y[0, j] = m1(); //3.4
                y[N, j] = m2(x * (N), j * t);
            }
        }

        static void counting(ref double[,] y, double h, double tay, int N, int M)
        {
            for (int j = 0; j <= M - 1; j++)
            {
                for (int i = 1; i <= N - 1; i++)
                {
                    y[i, j + 1] = tay * (y[i - 1, j] - 2 * y[i, j] + y[i + 1, j]) / Math.Pow(h, 2) + y[i, j] + tay * f(i * h, tay * (j + 0.5));
                    //  Раздел 3 формула 1, то есть формула 6 в тетрадке при 1 
                }
            }
        }
        static void zapu(ref double[,] y, double h, double tay, int N, int M) //Заполнение U
        {
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    y[i, j] = u(h * i, j * tay);
                }
            }
        }
        static double maxz(double[,] y, double[,] u, int N, int M) // Раздел 5 формула 1
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

        static public void progon1(ref double[,] y, int N, int M, double h, double tay)
        {
            for (int j = 0; j < M; j++)
            {
                double[] alf = new double[N + 1];
                double[] bet = new double[N + 1];
                bet[1] = y[0, j + 1];
                alf[1] = 0;
                for (int i = 1; i < N; i++)
                {
                    double A = tay / (h * h); //31 страница
                    double B = 1 + 2.0 * tay / (h * h);
                    double C = tay / (h * h);
                    double F = y[i, j] + tay * f(i * h, tay * (j + 0.5));
                    alf[i + 1] = B / (C - A * alf[i]); //49 первая методичка
                    bet[i + 1] = (F + A * bet[i]) / (C - A * alf[i]); //50 первая методичка
                }
                for (int i = N; i > 1; i--)
                {
                    y[i - 1, j + 1] = y[i, j + 1] * alf[i] + bet[i];
                }
            }
        }
        static public void progon05(ref double[,] y, int N, int M, double h, double tay)
        {

            for (int j = 0; j < M; j++)
            {
                double[] alf = new double[N + 1];
                double[] bet = new double[N + 1];
                bet[1] = y[0, j + 1];
                alf[1] = 0;
                for (int i = 1; i < N; i++)
                {
                    double A = tay * 0.5 / (h * h); 
                    double C = 1 + tay / (h * h);
                    double B = tay * 0.5 / (h * h);
                    double F = y[i, j] + tay * 0.5 * (y[i - 1, j] - 2 * y[i, j] + y[i + 1, j]) / (h * h) + tay * f(i * h, tay * (j + 0.5));
                    alf[i + 1] = B / (C - A * alf[i]);
                    bet[i + 1] = (F + A * bet[i]) / (C - A * alf[i]);
                }
                for (int i = N; i > 1; i--)
                {
                    y[i - 1, j + 1] = y[i, j + 1] * alf[i] + bet[i];
                }
            }
        }

        static public void Krank_Nicols1(double sig, int N, int M, double h, double t, ref double[,] a) //для любой sigma
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
                    double F = a[i, j] + t * (1 - sig) * (a[i - 1, j] - 2 * a[i, j] + a[i + 1, j]) / (h * h) + t * f(i * h, t * (j + 0.5));
                    alf[i + 1] = B / (C - A * alf[i]);
                    bet[i + 1] = (F + A * bet[i]) / (C - A * alf[i]);
                }
                //for (int i = N; i > 1; i--)
                //{
                //    a[i - 1, j + 1] = a[i, j + 1] * alf[i] + bet[i];
                //}
                for (int i = N; i > 1; i--)
                {
                    a[i - 1, j + 1] = a[i, j + 1] * alf[i] + bet[i];
                    if (max <= Math.Abs(u((i - 1) * h, (j + 1) * t) - a[i - 1, j + 1])) max = Math.Abs(u((i - 1) * h, (j + 1) * t) - a[i - 1, j + 1]);
                }
            }
            Console.WriteLine("z = {0}", max);
        }

        static void Main()
        {
            Console.Write("sigma = ");
            double sigma = double.Parse(Console.ReadLine());

            if (sigma == 1)
            {
                int N = 10, M = 100;
                double[,] y = new double[N + 1, M + 1];
                double[,] ur = new double[N + 1, M + 1];
                double h = 1.0 / N, tay = 1.0 / M;
                Filling(ref y, h, tay, N, M);
                progon1(ref y, N, M, h, tay);
                counting(ref y, h, tay, N, M);
                zapu(ref ur, h, tay, N, M);
                Console.WriteLine("z = {0}", maxz(y, ur, N, M));
            }
            else if (sigma == 0.5)
            {
                int N = 10, M = 10;
                double[,] y = new double[N + 1, M + 1];
                double[,] ur = new double[N + 1, M + 1];
                double h = 1.0 / N, tay = 1.0 / M;
                Filling(ref y, h, tay, N, M);
                zapu(ref ur, h, tay, N, M);
                progon05(ref y, N, M, h, tay);
                Console.WriteLine("z = {0}", maxz(y, ur, N, M));
            }
            else if (sigma == 0)
            {
                int M = 200;
                int N = 100;
                double h = 1.0 / N, tay = (h * h) / 2;
                double[,] y = new double[N + 1, M + 1];
                double[,] ur = new double[N + 1, M + 1];
                Filling(ref y, h, tay, N, M);
                counting(ref y, h, tay, N, M);
                zapu(ref ur, h, tay, N, M);
                Console.WriteLine("z = {0}", maxz(y, ur, N, M));
            }
            else if (sigma == 123)
            {
                int N = 10, M = 100, sig = 1;
                Console.WriteLine();
                double[,] y = new double[N + 1, M + 1];
                double h = 1.0 / N;
                double tay = 1.0 / M;
                Filling(ref y, h, tay, N, M);
                Krank_Nicols1(sig, N, M, h, tay, ref y);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
