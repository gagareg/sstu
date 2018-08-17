using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите а");
            var a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите b");
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите c");
            var c = int.Parse(Console.ReadLine());

            Console.WriteLine("Сумма равно");
            Console.WriteLine(a+b+c);
            Console.WriteLine("Произведение равно");
            Console.WriteLine(a*b*c);
            Console.ReadKey();
        }
    }
}
