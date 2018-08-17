using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Метод_Ньютона
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Точность = ");
            double eps = Convert.ToDouble(Console.ReadLine());

            Console.Write("Начальная точка = ");
            double x = Convert.ToDouble(Console.ReadLine());
            int n = 0;
            double x0;
            do
            {

                x0 = x - equat(x) / equatDiverative(x);//Формула 29
                x = x0;
                n++;

            } while (Math.Abs(equat(x)) >= eps);

            Console.WriteLine("Ответ = {0}", x);
            Console.WriteLine("Количество итераций = {0}", n);
            Console.WriteLine("Невязка = {0}",equat(x));
            Console.WriteLine("Невязка = {0:0.00000000000000}", equat(x));
            Console.ReadKey();
        }
        // Вычисляемое уравнение
        static double equat(double x)
        {
            return x - Math.Atan(Math.Sqrt(x)) - 0.4;
        }

        // Его производная
        static double equatDiverative(double x)
        {
            return 1 - 1 / (2 * Math.Sqrt(x) * (x + 1));
        }


    }

}
