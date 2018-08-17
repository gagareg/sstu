using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_6
{
    class Class
    {
        static int[,] Input(out int n, out int m)
        {
            Random rnd = new Random();
            Console.WriteLine("введите размерность массива");
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(0, 7);
                }
            //a[0, 0] = 20;
            //a[0, 1] = 20;
            return a;
        }
        static void Print(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write("{0,5} ", a[i, j]);
                Console.WriteLine();
            }
        }
        static void Delete(int[,] a, int n, ref int m, int k)
        {
            for (int i = 0; i < n; i++)
                for (int j = k; j < m - 1; j++)
                    a[i, j] = a[i, j + 1];
            --m;
        }
        static void Main()
        {
            int n, m;
            int[,] a = Input(out n, out m);
            Console.WriteLine("Исходный массив:");
            Print(a, n, m);
            for (int i = 0; i < n; i++)
            {
                if (a[0, 0] > a[n - 1, m - 1])
                {
                    Delete(a, n, ref m, 0);
                }

            }
            Console.WriteLine("Измененный массив:");
            Print(a, n, m);
            Console.ReadKey();
        }
    }
}
