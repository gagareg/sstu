using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Метод_Простой_Итерации
{
    class Program
    {
        static void Main(string[] args)
        {
            const double eps = 0.0001;
            double x0 = 1, x_next = 0;
            int iter = 0;
            bool error = false;

            do
            {
                x_next = Func(x0);
                iter++;
                if (Math.Abs(x_next - x0) >= eps && iter == 1000)
                {
                    error = true;
                    break;
                }
                x0 = x_next;
            } while (Math.Abs(x0 - Func(x0)) > eps);

            if (error)
            {
                Console.WriteLine("Не найдено");
            }
            else
            {
                Console.WriteLine("Ответ: X = {0} ", x_next);
                Console.WriteLine("Итераций пройдено: {0}", iter);
                //Console.WriteLine("Невязка = {0:0.00000000}", F(x_next));
                Console.WriteLine("Невязка = {0}", F(x_next));
            }

            Console.ReadKey();
        }

        static double Func(double x)
        {
            return Math.Atan(Math.Sqrt(x)) + 0.4;
        }
        static double F(double x)
        {
            return x - Math.Atan(Math.Sqrt(x)) - 0.4;
        }
    }

}
