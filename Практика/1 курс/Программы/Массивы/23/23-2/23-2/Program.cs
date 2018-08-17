using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_2
{
    class Program
    {
        
            static void Main(string[] args)
            {
                int buf;
                int[] arr = new int[12];

                Random r = new Random();

                for (int i = 0; i < 12; i++)
                {
                    arr[i] = r.Next(-9, 9);
                    Console.Write("{0,3}", arr[i]);

                }
                for (int i = 0; i < 2; i++)
                {
                    buf = arr[3 - i];
                    arr[3 - i] = arr[i];
                    arr[i] = buf;
                }

                for (int i = 4; i < 6; i++)
                {
                    buf = arr[11 - i];
                    arr[11 - i] = arr[i];
                    arr[i] = buf;
                }
                for (int i = 8; i < 10; i++)
                {
                    buf = arr[19 - i];
                    arr[19 - i] = arr[i];
                    arr[i] = buf;
                }
                Console.WriteLine("  Исходный");
                for (int i = 0; i < 12; i++)
                {
                    Console.Write("{0,3}", arr[i]);
                }
                Console.WriteLine("  Результат");
                Console.ReadKey();
            }
     }
}

