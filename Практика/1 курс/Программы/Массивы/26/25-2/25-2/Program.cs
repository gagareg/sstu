using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 12;
            Random r = new Random();
            int[] arr = new int[n];
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(-100, 10);
                Console.Write("\t" + arr[i]);

            }
            int k = 4;
            for (int i = 0; i < k; ++i)
            {
                int aLast = arr[n - 1];
                for (int j = n - 1; j > 0; j--)
                    arr[j] = arr[j - 1];
                arr[0] = aLast;
            }

            Console.WriteLine();
            for (int i = 0; i < n; ++i)
                Console.Write("\t" + arr[i]);

            Console.ReadKey();
        }
    }
}

