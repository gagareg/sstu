using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
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
                Console.WriteLine("Введите d");
                var d = float.Parse(Console.ReadLine());
                Console.WriteLine("Введите e");
                var e = float.Parse(Console.ReadLine());

                if ((a > b) && (a > c) && (a > d) && (a > e))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(a);
                }
                if ((b > a) && (b > c) && (b > d) && (b > e))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(b);
                }
                if ((c > a) && (c > b) && (c > d) && (c > e))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(c);
                }
                if ((d > a) && (d > b) && (d > c) && (d > e))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(d);
                }
                if ((e > a) && (e > b) && (e > c) && (e > d))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(e);
                }
                if ((c > a) && (c > b) && (c > d) && (c > e))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(c);
                }
                if ((a == b) && (a == c) && (a == d) && (a == e))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(a);
                }
                Console.ReadKey();
            }
        }
    }

