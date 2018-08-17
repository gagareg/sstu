using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48_4
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
                

                if ((a > b) && (a > c))
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(a);
                }
                if ((b > a) && (b > c) )
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(b);
                }
                if ((c > a) && (c > b) )
                {
                    Console.WriteLine("Наибольшее число");
                    Console.WriteLine(c);
                }
                
                Console.ReadKey();
            }
        }
    }
   
