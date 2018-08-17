using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace петрович
{
    class Program
    {
        static void Main(string[] args)
        {

            
            double exs, a=0, b=0, delta=0, xp, k = 0, y, i;
            double e = 0.001, Lk;
            
            int p = 0;
            //Console.Write("Введите а = ");//cout
            //double a = Convert.ToDouble(Console.ReadLine());//cin

            Console.WriteLine("Введите х");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите t=");
            double t = Convert.ToDouble(Console.ReadLine());


            if ((F(x - t) <= F(x)) && (F(x + t) <= F(x)))
            {
                //p = 1;
                Console.WriteLine("Функция не являтся унимодальной, введите другую");
                Console.ReadKey();
            };

            if ((F(x - t) >= F(x)) && (F(x + t) >= F(x)))
            {
                a = x - t;
                b = x + t;
                p = 1;
            };


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

            while ((p != 1))
            {

                if ((F(x) < F(xp)) && (delta * t > 0))
                    a = xp;
                if ((F(x) < F(xp)) && (delta * t < 0))
                    b = xp;
                if ((F(x) > F(xp)) && (delta * t > 0))
                {
                    b = x;
                    p = 1;
                };

                if ((F(x) > F(xp)) && (delta * t < 0))
                {
                    a = x;
                    p = 1;
                };

                k++;
                xp = x;
                x = xp + Math.Pow(2.0, k) * delta;
                if (k > 1000)
                {
                    Console.WriteLine("Количество шагов превышает допустимое значение");
                    Console.ReadKey();
                };

            }
            Console.WriteLine("Интервал: [ a={0}; b={1}]", a, b);
            Console.WriteLine("колличесво шагов по алгоритму свена: k={0}", k);


            double z, yp, zp;

            delta = b - a;
            Lk = b - a;
            k = 0;
            y = a + ((3 - Math.Sqrt(5)) / 2) * Lk;
            //y = a + 0.38196601*Lk;
            z = a + b - y;
            while (delta > e)
            {

                if (F(y) <= F(z))
                {
                    b = z;
                    yp = y;
                    y = a + b - yp;
                    z = yp;
                }
                else
                {
                    a = y;
                    y = z;
                    zp = z;
                    z = a + b - zp;
                };
                //Lk = b - a;
                delta = b - a;
                k++;
                if (k > 1000)
                {
                    Console.WriteLine("Количество шагов превышает допустимое значение");
                    Console.ReadKey();
                };

            };
            exs = (a + b) / 2;
            i = k - 1;
            Console.WriteLine("Точка минимума: exs={0:0.##}; Значение функции в точке минимума F(exs)={1:0.##} ", exs, F(exs));
            Console.WriteLine("Колличество шагов золотого сечения: i={0}", i);
            Console.ReadKey();

        }

        public static double F(double x)

        {


            //y = x;
            //y = 100*pow((100-x*x),2)+pow((10-x),2);
            double y = Math.Pow((x * x * (x + 3)), 0.333333333);
            //double y = x*x + 2 * x - 5;
            //y = (x - 5)*(x - 5);
            //y = x*x;
            //y = 2 * x*x - 12 * x;
            //y = 2 * x*x + 16 / x;
            return (y);

        }
    }
}
    

