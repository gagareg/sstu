using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _88
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            int a = int.Parse(Console.ReadLine());
            int x = a;
            int s = 0;
            if (a > 0)
            {
                while (x != 0)
                {
                    s = s + (x % 10);
                    x = x / 10;
                }
                Console.WriteLine("Сумма цифр числа " + a + " = " + s);
                if (s == 10)
                {
                    Console.WriteLine("Да");
                }
                else
                {
                    Console.WriteLine("Нет");
                }
            }
            else
            {
                Console.WriteLine("Нужно положительное число");
            }
          
            Console.ReadKey();
        }
    }
}
