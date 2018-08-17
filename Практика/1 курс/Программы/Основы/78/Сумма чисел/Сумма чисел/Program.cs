
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сумма_чисел
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите число: ");
            int a = int.Parse(Console.ReadLine());
            int s = 0;
            while (a > 0)
            {
                s = s + a % 10;
                a = a / 10;
            }
            Console.WriteLine("Сумма чисел равно " + s);
            Console.ReadKey();
        }
    }
}
