using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    class Program
    {
        public static double F(double x, double y, double z)
        {
            double q = x * x + (y - 2) * (y - 2);
            return (q);
        }
        public static double G1(double x, double y, double z)
        {
            double q = x * x + 2 * y * y - 8;
            return (q);
        }
        public static double G2(double x, double y, double z)
        {
            double q = 0;
            return (q);
        }
        public static double G3(double x, double y, double z)
        {
            double q = 0;
            return (q);
        }
        public static double H1(double x, double y, double z)
        {
            double q = 0;
            return (q);
        }
        public static double H2(double x, double y, double z)
        {
            double q = x * x + 2 * (y - 2) * (y - 2) - 8;
            return (q);
        }
        public static double H3(double x, double y, double z)
        {
            double q = 0;
            return (q);
        }
        public static double G(double x, double y, double z)
        {
            double q = G1(x, y, z) + G2(x, y, z) + G3(x, y, z);
            return (q);
        }
        public static double H(double x, double y, double z)
        {
            double q = H1(x, y, z) + H2(x, y, z) + H3(x, y, z);
            return (q);
        }
        static void Main(string[] args)
        {
            double  grad = 1, gr1, gr2, gr3, a = 0, b = 3.901, Lk = 1, yk, zk, xv, yv, zv, xs, t;
            double h = 0.0001;
            double e = 0.001, e1 = 0.01, e2 = 0.0001;
            double k = 0, M = 1000, n = 0, N = 0, r = 1, p;
           

            Console.Write("Введите x = ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите y = ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите z = ");
            double z = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            do
            {
                k = 0;
                n++;
                while ((grad > e2) && (k < M))
                {

                    gr1 = ((F(x + h, y, z) + G(x + h, y, z) * G(x + h, y, z) / (2 * r) - r / H(x + h, y, z)) - (F(x, y, z) + G(x, y, z) * G(x, y, z) / (2 * r) - r / H(x, y, z))) / h;
                    gr2 = ((F(x, y + h, z) + G(x, y + h, z) * G(x, y + h, z) / (2 * r) - r / H(x, y + h, z)) - (F(x, y, z) + G(x, y, z) * G(x, y, z) / (2 * r) - r / H(x, y, z))) / h;
                    gr3 = ((F(x, y, z + h) + G(x, y, z + h) * G(x, y, z + h) / (2 * r) - r / H(x, y, z + h)) - (F(x, y, z) + G(x, y, z) * G(x, y, z) / (2 * r) - r / H(x, y, z))) / h;
                    grad = Math.Sqrt(gr1 * gr1 + gr2 * gr2 + gr3 * gr3);

                    a = 0;
                    b = 3;
                    xs = (a + b) / 2;

                    do
                    {
                        yk = a + Lk / 4;
                        zk = b - Lk / 4;
                        if (F(x - yk * gr1, y - yk * gr2, z - yk * gr3) < F(x - xs * gr1, y - xs * gr2, z - xs * gr3))
                        {
                            b = xs;
                            xs = yk;
                        };

                        if (F(x - yk * gr1, y - yk * gr2, z - yk * gr3) >= F(x - xs * gr1, y - xs * gr2, z - xs * gr3))
                        {
                            if (F(x - zk * gr1, y - zk * gr2, z - zk * gr3) < F(x - xs * gr1, y - xs * gr2, z - xs * gr3))
                            {
                                a = xs;
                                xs = zk;
                            }
                            if (F(x - zk * gr1, y - zk * gr2, z - zk * gr3) >= F(x - xs * gr1, y - xs * gr2, z - xs * gr3))
                            {
                                a = yk;
                                b = zk;
                            }
                            Lk = b - a;
                        };

                    } while (Lk > e);

                    xv = x;
                    yv = y;
                    zv = z;
                    x = x - xs * gr1;
                    y = y - xs * gr2;
                    z = z - xs * gr3;


                    if (((Math.Sqrt((xv - x) * (xv - x) + (yv - y) * (yv - y) + (zv - z) * (zv - z))) < e2) && ((Math.Abs(F(xv, yv, zv) -F(x, y, z))) < e2))
                    {
                        goto end;
                    };

                    k = k + 1;
                };
                end:
                r = r / 4;
                p = G(x, y, z) * G(x, y, z) / (2 * r) - r / H(x, y, z);
                Console.WriteLine("p = {0}", p);

            }  while ((p > e1) && (n< 100));

            Console.WriteLine();
            Console.WriteLine("n = {0}", n);
            //Console.WriteLine();
            Console.WriteLine("\nКоординаты точки минимума:");
            Console.WriteLine("\nx = {0},\ny = {1},\nz = {2}", x, y, z);
            Console.WriteLine("\nЗначение функции f(x,y,z) = {0}", F(x, y, z));
            Console.ReadKey();
        }
    }
}
