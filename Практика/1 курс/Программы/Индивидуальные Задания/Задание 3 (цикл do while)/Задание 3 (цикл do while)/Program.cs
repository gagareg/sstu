using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3__цикл_do_while_
{
    class Program
    {
        static void Main()
        {
            double y = 0;
            Console.Write("Введите значение x1: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите значение x2: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите шаг h: ");
            double h = double.Parse(Console.ReadLine());
            double x = 0;
            do
            {
                if (x < 0)
                {
                    Console.Write("x = " + x);
                    Console.WriteLine(" y = " + y);
                }

                if ((x >= 0) && (x != 1))
                {
                    y = x * x + 3 * x + 1;
                    Console.Write("x = " + x);
                    Console.WriteLine(" y = " + y);
                }

                if (x == 1)
                {
                    y = 1;
                    Console.Write("x = " + x);
                    Console.WriteLine(" y = " + y);
                }
                x = x + h;
            } while (x <= b);

            Console.ReadKey();
        }
    }
}

