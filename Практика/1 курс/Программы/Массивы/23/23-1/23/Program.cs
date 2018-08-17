using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23
{
    class Program
    {
        static void Main(string[] args)
        {
            int buf;
            int[] arr = new int[10];

            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                arr[i] = r.Next(-9, 9);
                Console.Write("{0,3}",arr[i]);
                
            }
            for (int i = 0; i <= 2; i++)
            {
                buf = arr[4 - i];
                arr[4 - i] = arr[i];
                arr[i] = buf;
            }
            
            for (int i = 5; i <= 7; i++)
            {
                buf = arr[14 - i];
                arr[14 - i] = arr[i];
                arr[i] = buf;
            }
            Console.WriteLine("  Исходный");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0,3}", arr[i]);
            }
            Console.WriteLine("  Результат");
            Console.ReadKey();
        }
    }
}
