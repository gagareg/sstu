using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization_methods_test2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0, b = 0, delta = 0, xp, k = 0, y, e = 0.0001d;
            double xs, yk, zk, lk;
            double exs;
            int p = 0;
            
            Console.Write("x = ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("t = ");
            double t = Convert.ToDouble(Console.ReadLine());
            
            //part 1
            if ((F(x - t) <= F(x)) && (F(x + t) <= F(x))) 
            {
                Console.WriteLine("unimodal function");
            }

            if ((F(x - t) >= F(x) && (F(x + t) >= F(x)))) 
            {
                a = x - t;
                b = x + t;
                p = 1;
            }

            xp = x;

            if ((F(x - t) >= F(x)) && (F(x) >= F(x + t))) 
            {
                delta = t;
                a = x;
                x = x + t;
            }
            if ((F(x - t) <= F(x)) && (F(x) <= F(x + t)))
            {
                delta = -t;
                b = x;
                x = x - t;
            }

            while (p != 1) 
            {
                if ((F(x) < F(xp)) && (delta * t > 0)) 
                {
                    a = xp;
                }
                if ((F(x) < F(xp)) && (delta * t < 0))
                {
                    b = xp;
                }
                if ((F(x) > F(xp)) && (delta * t > 0)) 
                {
                    b = x;
                    p = 1;
                }
                if ((F(x) > F(xp)) && (delta * t < 0))
                {
                    a = x;
                    p = 1;
                }

                k++;
                xp = x;
                x = xp + Math.Pow(2, k) * delta;
                if (k>1000)
                {
                    Console.WriteLine("invalid number of steps");
                    Console.ReadKey();
                    break;
                }
            }
            Console.WriteLine("[{0},{1}]; k = {2}", a, b, k);
            // part 2 
            lk = b - a;
            k = 0;
            while (lk > e) 
            {
                xs = (a + b) / 2;
                lk = b - a;
                yk = a + (lk / 4);
                zk = b - (lk / 4);

                if (F(yk) < F(xs)) 
                {
                    b = xs;
                }
                if (F(yk) >= F(xs)) 
                {
                    if (F(zk) < F(xs)) 
                    {
                        a = xs;
                    }
                    if (F(zk) >= F(xs))
                    {
                        a = yk;
                        b = zk;
                    }
                }
                k++;
            }

            exs = (a + b) / 2;
            Console.WriteLine("ext = {0}; f(ext) = {1}; k = {2}", exs, F(exs), k);
            Console.ReadKey();

        }

        public static double F( double x)
        {
            double y;
            y = Math.Pow((x - 5), 2);
            //y = 2 * Math.Pow(x, 2) - 12 * x;
            //y = Math.Pow((Math.Pow(x, 2) * (x + 3)), (1.0 / 3));
            //y = Math.Pow((Math.Pow(x, 3) + 3 * Math.Pow(x, 2)), 1.0 / 3);
            return y;
        }
    }
}
