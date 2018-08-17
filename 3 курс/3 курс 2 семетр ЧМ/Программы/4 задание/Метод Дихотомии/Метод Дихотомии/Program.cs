using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Метод_Дихотомии
{
    class Program
    {
        static void Main(string[] args)
        {
            // Точность.
            Console.Write("Точность = ");
            double accuracy = Convert.ToDouble(Console.ReadLine());

            // Интервал поиска.
            double min = 0;
            double max = 10;
            // Длина интервала.
            var length = max - min;
            // Начальная ошибка.
            var err = length;
            // Начальная точка.

            //Console.Write("Начальная точка = ");
            //double x = Convert.ToDouble(Console.ReadLine());
            double x = 0;
            //double x = 1;
            while (err > accuracy && F(x) != 0)
            {
                // Вычисляем середину интервала.
                x = (min + max) / 2;
                // Найдём новый интервал, в котором функция меняет знак.
                if (F(min) * F(x) < 0)
                {
                    max = x;
                }
                else if (F(x) * F(max) < 0)
                {
                    min = x;
                }
                // Вычисляем новую ошибку.
                err = (max - min) / length;
            }

            Console.WriteLine("Ответ = {0}", x);
            Console.WriteLine("Невязка = {0}",F(x));
            Console.ReadKey();
        }
        // Функция.
        public static double F(double x)
        {
            return x - Math.Atan(Math.Sqrt(x)) - 0.4;
        }
    }

}
