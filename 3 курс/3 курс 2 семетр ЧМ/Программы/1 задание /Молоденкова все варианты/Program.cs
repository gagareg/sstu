using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Молоденкова_все_варианты
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int r, i = 0;
            double[] s = new double[10];
            double[] P = new double[10];
            double[] t = new double[10];
            double[] y = new double[10];
            double[] fo = new double[10];
            double[] l = new double[10];
            double[] v = new double[10];
            double[] z = new double[10];
            double[] fm = new double[10];
            double[] fp = new double[10];
            double x, b, a = 0.1, h = 0.01, z_;

            Console.WriteLine("Задание 2");
            for (i = 1; i < 5; i++)
            {
                x = a + i * h;
                y[i] = a + i * h;
                s[i] = F_(y[i]);
                Console.WriteLine("f'({0}) = {1:0.0000}", y[i], s[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Задание 3");
            for ( i = 0; i < 6; i++)
            {
                x = a + i * h;
                y[i] = a + i * h;
                s[i] = F(y[i]);
                Console.WriteLine("f({0}) = {1:0.0000}", y[i], s[i]);
            }

            b = 0.15;//Коэффициент для х
            Console.WriteLine();
            Console.WriteLine("Задание 4 - 5");
            for ( i = 0; i < 5; i++)
            {
                x = b + i * h;
                r = i + 1;
                P[i] = s[i] - (s[r] - s[i]) * y[i] / (y[r] - y[i]) + (s[r] - s[i]) * x / (y[r] - y[i]);//Линейная интерполяция
                l[i] = b + i * h;
                t[i] = F(l[i]);
                x = a + i * h;
                z[i] = Math.Abs(t[i] - P[i]);
                Console.WriteLine("|[f = {1:0.####}] --- [P = {3:0.####}]| === [Z = {5:0.####}]", l[i], t[i], x, P[i], x, z[i]);
                //Console.WriteLine("|[f({0}) = {1:0.####}] --- [P({2}) = {3:0.####}]| === [Z({4}) = {5:0.####}]", l[i], t[i], x, P[i], x, z[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Задание 6");
            for ( i = 1; i < 5; i++)
            {
                r = i + 1;
                n = i - 1;
                fm[i] = (s[i] - s[n]) / h;
                fo[i] = (s[r] - s[n]) / (2 * h);
                fp[i] = (s[r] - s[i]) / h;
                Console.WriteLine("x = {0}; f- = {1}; f0 = {2}; f+ = {3}", y[i], fm[i], fo[i], fp[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Задание 7");
            for ( i = 0; i < 6; i++)
            {
                l[i] = a + i * h;
                v[i] = F_(l[i]);
            }
            for ( i = 1; i < 5; i++)
            {
                z_ = Math.Abs(fm[i] - v[i]);
                Console.WriteLine("|f'({0:0.0000}) - f-({1:0.0000})| = Z_({2:0.0000})", v[i], fm[i], z_);
            }
            Console.WriteLine();
            for (i = 1; i < 5; i++)
            {
                z_ = Math.Abs(fo[i] - v[i]);
                Console.WriteLine("|f'({0:0.0000}) - f0({1:0.0000})| = Z_({2:0.0000})", v[i], fo[i], z_);
            }
            Console.WriteLine();
            for (i = 1; i < 5; i++)
            {
                z_ = Math.Abs(fp[i] - v[i]);
                Console.WriteLine("|f'({0:0.0000}) - f+({1:0.0000})| = Z_({2:0.0000})", v[i], fp[i], z_);
            }




            Console.ReadKey();
        }

        public static double F(double x)
        {
            int k = 0;
            double a = 1, q, e = 0.0001, m = 1;
            while (Math.Abs(a / m) > e) 
            {
                q = x / (2 * k + 2);
                a = a * q;
                m = m + a;
                k = k + 1;
            }

            return m;
        }

        public static double F_(double x)
        {
            int k = 1;
            double a, q, e = 0.0001, m;
            a = 0.5; m = 0.5;
            while (Math.Abs(a / m) > e)
            {
                q = (k + 1) * x / (2 * k * Factorial(k) * Factorial((k + 1)));
                a = a * q;
                m = m + a;
                k = k + 1;
            }

            return m;
        }

        public static int Factorial(int facno)
        {
            int temno = 1;

            for (int i = 1; i <= facno; i++)
            {
                temno = temno * i;
            }

            return temno;
        }
    }
}
