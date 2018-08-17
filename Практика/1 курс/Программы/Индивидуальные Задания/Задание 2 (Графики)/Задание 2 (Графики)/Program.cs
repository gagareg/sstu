using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2__Графики_
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите координату х: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите координату y: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Введите радиус r: ");
            double r = double.Parse(Console.ReadLine());
            //y>x and y>-x and y<sqrt(r^2-x^2) Верх
            //y<x and y<-x and y>-sqrt(r^2-x^2) Низ
            if (((y > x) && (y > -x) && (y < Math.Sqrt(r * r - x * x))) || ((y < x) && (y < -x) && (y > -Math.Sqrt(r * r - x * x))))
            {
                Console.WriteLine("Точка находится внутри");
            }
            if (((y < x) && (y < -x) && (y > Math.Sqrt(r * r - x * x))) && ((y > x) && (y > -x) && (y < -Math.Sqrt(r * r - x * x))))
            {
                Console.WriteLine("Точка находится не внутри");
            }
            if (((y == x) || (y == -x) || (y == Math.Sqrt(r * r - x * x))) || ((y == x) || (y == -x) || (y == Math.Sqrt(r * r - x * x))))
            {
                Console.WriteLine("Точка находится на границе");
            }

            Console.ReadKey();
        }
    }
}

