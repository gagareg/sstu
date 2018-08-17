using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _69
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число b");
            int b = int.Parse(Console.ReadLine());
            while (a <= b)
            {
                Console.WriteLine(a);
                Console.WriteLine((a * a));
                Console.WriteLine((a * a * a));
                a++;
            }
          
            Console.ReadKey();
        }
    }
}

