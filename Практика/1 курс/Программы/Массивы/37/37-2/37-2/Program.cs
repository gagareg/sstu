using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int buf;
            const int n = 10;
            Random r = new Random();
            int[] arr = new int[n];
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(0, 100);
                Console.Write("\t" + arr[i]);
         
            }
            for (int i = 0; i < 5; ++i)
            {
                for (int j = i + 1 ; j < 6 - 1; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        buf = arr[i];
                        arr[i] = arr[j];
                        arr[j] = buf;
                    }   
                }
             }
            for (int i = 5; i < 9; ++i)
            {
                for (int j = i + 1; j < 9 - 1; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        buf = arr[i];
                        arr[i] = arr[j];
                        arr[j] = buf;
                    }
                }
            }


            Console.WriteLine();
            for (int i = 0; i < n; ++i)
                Console.Write("\t" + arr[i]);

            Console.ReadKey();
        }
    }
}

