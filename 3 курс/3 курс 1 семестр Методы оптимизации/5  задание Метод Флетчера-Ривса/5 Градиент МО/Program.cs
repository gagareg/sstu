using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Градиент_МО
{
    class Program
    {
        public static double F(double x, double y, double z)
        {
            double q;
            q = ((y - x * x) * (y - x * x) + (1 - x) * (1 - x) + (z - 2) * (z - 2));
            //q = ((y - x * x) * (y - x * x) + (1 - x) * (1 - x));

            return (q);
        }
        static void Main(string[] args)
        {

            double gr1, gr2, gr3, gr11 = 1, gr22 = 1, gr33 = 1, e1 = 0.001f, e2 = 0.001f, M = 1000, grad, h = 0.0001f, a, b, bk = 0, bk1 = 0, ost, dk1 = 0, dk2 = 0, dk3 = 0, bdx, bdy, bdz, dkx, dky, dkz;

            int k = 0;
            Console.Write("Введите x = ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите y = ");
            double y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите z = ");
            double z = Convert.ToDouble(Console.ReadLine());
            grad = 1;

            while ((grad > e1) && (k < M))
            {
                ost = k % 3;
                gr1 = (F(x + h, y, z) - F(x, y, z)) / h;
                gr2 = (F(x, y + h, z) - F(x, y, z)) / h;
                gr3 = (F(x, y, z + h) - F(x, y, z)) / h;
                grad = Math.Sqrt(gr1 * gr1 + gr2 * gr2 + gr3 * gr3);

                if (ost == 0)
                {
                    bdx = 0;
                    bdy = 0;
                    bdz = 0;
                }
                else
                {
                    bdx = bk1 * dk1;
                    bdy = bk1 * dk2;
                    bdz = bk1 * dk3;
                };


                bk = (gr1 * gr1 + gr2 * gr2 + gr3 * gr3) / (gr11 * gr11 + gr22 * gr22 + gr33 * gr33);
                bk1 = bk;
                dkx = -gr1 + bdx;
                dk1 = dkx;
                dky = -gr2 + bdy;
                dk2 = dky;
                dkz = -gr3 + bdz;
                dk3 = dkz;


                /////алгоритм нахождения минимума (деление пополам)
                double Lk = 1, e = 0.0001, xs, yk, zk, t, xv, yv, zv;
                int K;

                a = 0;
                b = 3.901;
                Lk = b - a;
                K = 0;
                while (Lk > e)
                {
                    xs = (a + b) / 2;
                    Lk = b - a;
                    yk = a + Lk / 4;
                    zk = b - Lk / 4;
                    if (F(x + yk * dkx, y + yk * dky, z + yk * dkz) < F(x + xs * dkx, y + xs * dky, z + xs * dkz))
                    {
                        b = xs;
                    };

                    if (F(x + yk * dkx, y + yk * dky, z + yk * dkz) >= F(x + xs * dkx, y + xs * dky, z + xs * dkz))
                    {
                        if (F(x + zk * dkx, y + zk * dky, z + zk * dkz) < F(x + xs * dkx, y + xs * dky, z + xs * dkz))//6a
                        {
                            a = xs;
                        }
                        if (F(x + zk * dkx, y + zk * dky, z + zk * dkz) >= F(x + xs * dkx, y + xs * dky, z + xs * dkz))
                        {
                            a = yk;
                            b = zk;
                        };
                    };
                    K++;
                };
                t = (a + b) / 2;


                //////////
                gr11 = gr1;
                gr22 = gr2;
                gr33 = gr3;
                xv = x;
                yv = y;
                zv = z;
                x = xv + t * dkx;
                y = yv + t * dky;
                z = zv + t * dkz;

                if ((((Math.Sqrt((xv - x) * (xv - x) + (yv - y) * (yv - y) + (zv - z) * (zv - z))) < e2) && (Math.Abs(F(xv, yv, zv) - F(x, y, z))) < e2) && (grad < e1))
                {
                    goto step2;
                };

                k++;
            };
            step2:
            Console.WriteLine();
            Console.Write("Координаты точки минимума:");
            Console.WriteLine("\nx = {0},\ny = {1},\nz = {2}", x, y, z);
            Console.WriteLine("\nЗначение функции f(x,y,z) = {0:0.0000}", F(x, y, z));
            Console.WriteLine("k = {0}", k);

            Console.ReadKey();






        }



    }
} 
