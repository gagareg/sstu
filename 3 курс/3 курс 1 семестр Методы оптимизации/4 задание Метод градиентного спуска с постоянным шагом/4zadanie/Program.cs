using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4zadanie
{
    class Program
    {
        public static double F(double x,double y, double z)
        {
            double q = ((y - x * x) * (y - x * x) + (1 - x) * (1 - x) + (z - 2) * (z - 2));
            //double q = ((y - x * x) * (y - x * x) + (1 - x) * (1 - x));
            return (q);
        }

        static void Main(string[] args)
        {
            double gr1, gr2, gr3, e1=0.001f,e2=0.001f,m=1000,grad=1,h=0.0001f,a,b;
            int k = 0;
            Console.Write("Введите x = ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите y = ");
            double y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите z = ");
            double z = Convert.ToDouble(Console.ReadLine());
            while ((grad>e1)&&(k<m))
            {
                //Console.WriteLine("K={0}", k);
                gr1 = (F(x + h, y, z) - F(x, y, z)) / h;
                gr2 = (F(x, y + h, z) - F(x, y, z)) / h;
                gr3 = (F(x, y, z + h) - F(x, y, z)) / h;
                grad = Math.Sqrt(gr1 * gr1 + gr2 * gr2 + gr3 * gr3);
                //Console.WriteLine("grad={0}", grad);
                //метод деления пополам
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
                    if (F(x - yk * gr1, y - yk * gr2, z - yk * gr3) < F(x - xs * gr1, y - xs * gr2, z - xs * gr3))
                    {
                        b = xs;
                    };

                    if (F(x - yk * gr1, y - yk * gr2, z - yk * gr3) >= F(x - xs * gr1, y - xs * gr2, z - xs * gr3))
                    {
                        if (F(x - zk * gr1, y - zk * gr2, z - zk * gr3) < F(x - xs * gr1, y - xs * gr2, z - xs * gr3))//6a 
                        {
                            a = xs;
                        }
                        if (F(x - zk * gr1, y - zk * gr2, z - zk * gr3) >= F(x - xs * gr1, y - xs * gr2, z - xs * gr3))
                        {
                            a = yk;
                            b = zk;
                        };
                    };
                    K++;
                };
                t = (a + b) / 2;
                //Console.WriteLine("t={0}", t);

                ////////// 

                xv = x;
                yv = y;
                zv = z;
                x = xv - t * gr1;
                y = yv - t * gr2;
                z = zv - t * gr3;

                if ((((Math.Sqrt((xv - x) * (xv - x) + (yv - y) * (yv - y) + (zv - z) * (zv - z))) < e2) && (Math.Abs(F(xv, yv, zv) - F(x, y, z))) < e2) && (grad < e1))
                {
                    goto step2;
                };

                k++;
            };
        step2:
            Console.WriteLine();
            Console.Write("Координаты точки минимума:");
            Console.WriteLine("\nx = {0}, \ny = {1}, \nz = {2}", x,y,z);
            Console.WriteLine("\nЗначение функции f(x,y,z) = {0:0.0000}", F(x,y,z));
            Console.WriteLine("k = {0}", k);
      
            Console.ReadKey();



           
        }
    }
        }
  
