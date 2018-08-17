using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Эйлера
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Метод Эйлера");
            Console.WriteLine("При h = 0.1 Ответ: {0}", FF(1,10));
            Console.WriteLine("При h = 0.01 Ответ: {0}", FF(1,100));
            Console.WriteLine();
            Console.WriteLine("Метод Рунге-Кутта 2-го порядка");
            Console.WriteLine("При h = 0.1 Ответ: {0}", FF1(1, 10, 1, 0.5));
            Console.WriteLine("При h = 0.1 Ответ: {0}", FF1(1, 10, 0.5, 1));
            Console.WriteLine("При h = 0.01 Ответ: {0}", FF1(1, 100, 1, 0.5));
            Console.WriteLine("При h = 0.01 Ответ: {0}", FF1(1, 100, 0.5, 1));
            Console.WriteLine();
            Console.WriteLine("Метод Рунге-Кутта 4-го порядка");
            Console.WriteLine("При h = 0.01 Ответ: {0}", FF2(1, 100));
            Console.WriteLine("При h = 0.01 Ответ: {0:0.000000000000000000000000000000000}", FF2(1, 100));
            Console.WriteLine("При h = 0.1 Ответ: {0}", FF2(1, 10));
            Console.WriteLine("При h = 0.1 Ответ: {0:0.000000000000000000000000000000000}", FF2(1, 10));

            Console.ReadKey();
        }
        public static double F(double x) //Точное решение U(x)
        {
            return (Math.Log(x, Math.E) + 1.7) * (x * x);
            //return x * x;
        }
        public static double DF(double x, double u) //Дифференциальное уравнение U'= f(x,u)
        {
            return (x * x + 2 * u) / x;
            //return (x * x + u) / x;/////
        }
        public static double FF(double h, double n) //Для Эйлера
        {
            double[] y = new double[10000];
            double[] z = new double[10000];
            double max = 0, t, t0 = 1;
            h = 1 / n;
            t = t0;
            y[0] = 1.7; // Начальное условие
            for (int i = 0; i <= n; i++) 
            {
                t = t0 + i * h;
                y[i + 1] = y[i] + h * DF(t, y[i]); //32 нижняя   38 для второго 
                z[i + 1] = Math.Abs(y[i] - F(t0 + h * i)); //Погрешность решения разностной схемы
                max = z[i + 1];
            }
            return (max);
        }
        public static double FF1(double h, double n, double sigma, double alpha) // Рунге-Кутта
        {
            double[] y = new double[10000];
            double[] z = new double[10000];
            double max = 0, t, t0 = 1;
            h = 1 / n;
            t = t0;
            y[0] = 1.7; // Начальное условие
            for (int i = 0; i <= n; i++)
            {
                t = t0 + i * h;
                y[i + 1] = y[i] + h * ((1 - sigma) * DF(t, y[i]) + sigma * DF(t + alpha * h, y[i] + alpha * h * DF(t, y[i])));
                z[i + 1] = Math.Abs(y[i] - F(t0 + h * i)); //Погрешность решения разностной схемы
                max = z[i + 1];
            }
            return (max);
        }

        public static double FF2(double h, double n) // Рунге-Кутта
        {
            double[] y = new double[10000];
            double[] z = new double[10000];
            double max = 0, t, t0 = 1;
            h = 1 / n;
            t = t0;
            y[0] = 1.7; // Начальное условие
            for (int i = 0; i <= n - 1; i++)
            {
                t = t0 + i * h;
                double k1 = DF(t, y[i]), k2 = DF(t + h / 2, y[i] + h * k1 / 2), k3 = DF(t + h / 2, y[i] + h * k2 / 2), k4 = DF(t + h, y[i] + h * k3);
                y[i + 1] = y[i] + h * ((1 * (k1 + 2 * k2 + 2 * k3 + k4) / 6));
                z[i + 1] = Math.Abs(y[i] - F(t0 + h * i)); //Погрешность решения разностной схемы
                max = z[i + 1];
            }
            return (max);
        }
        /*public static double FN(double h)
        {
            double n, t0 = 1, T = 2;
            n = (T - t0) / h;
            return n;
        } */
    }
}