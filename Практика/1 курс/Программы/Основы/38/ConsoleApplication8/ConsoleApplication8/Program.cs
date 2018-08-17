using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите а");
            var a = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите b");
            var b = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите c");
            var c = float.Parse(Console.ReadLine());

            Console.WriteLine("Сумма равно");
            Console.WriteLine(a + b + c);
            Console.WriteLine("Произведение равно");
            Console.WriteLine(a * b * c);
            Console.WriteLine("Среднее Арифметическое равно");
            Console.WriteLine((a + b + c) / 3);
            Console.ReadKey();
        }
    }
}
