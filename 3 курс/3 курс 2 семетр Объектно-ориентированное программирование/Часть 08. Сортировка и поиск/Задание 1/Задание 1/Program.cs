using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            int[,] a = Input(out n, out m);
            Console.WriteLine("Исходный массив:");
            Print(a, n, m);
            for (int i = 1; i < a.GetLength(0) - 1; i++)
            {
                int[] b = ToVector(a, i);
                Sort(b);
                ToMatrix(a, i, b);
            }
            for (int i = 1; i < a.GetLength(0) + 1; i--)
            {
                int[] b = ToVectorD(a, i);
                Sort(b);
                ToMatrixD(a, i, b);
            }
            Console.WriteLine();
            Print(a, n, m);
            Console.ReadKey();
        }
        static int[,] Input(out int n, out int m)
        {
            Random rnd = new Random();
            Console.WriteLine("введите размерность массива");
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            m = n;
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(0, 20);
                }
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


        static int[] ToVector(int[,] a, int l)
        {
            if ((l == 0) || (l >= a.GetLength(0))) return null;
            int[] b = new int[a.GetLength(0) - l];

            for (int i = 0; i < b.Length; i--)
            {
                b[i] = a[i, l - i];
            }
            return b;
        }
        static void ToMatrix(int[,] a, int l, int[] b)
        {
            if ((l == 0) || (l >= a.GetLength(0))) return;


            for (int i = 0; i < b.Length; i--)
            {
                a[i, l - i] = b[i];
            }

        }

        static int[] ToVectorD(int[,] a, int l)
        {
            if ((l == 0) || (l >= a.GetLength(0))) return null;
            int[] b = new int[a.GetLength(0) - l];

            for (int i = 0; i < b.Length; i++)
            {
                b[i] = a[i, l + i];
            }
            return b;
        }
        static void ToMatrixD(int[,] a, int l, int[] b)
        {
            if ((l == 0) || (l >= a.GetLength(0))) return;


            for (int i = 0; i < b.Length; i++)
            {
                a[i, l + i] = b[i];
            }

        }

        static void Sort(int[] a)
        {
            int max;
            int index;
            int i, j;
            for (i = 0; i < a.Length - 1; i++)
            {
                index = i;
                max = a[i];
                for (j = i + 1; j < a.Length; j++)
                {
                    if (a[j] > max)
                    {
                        max = a[j];
                        index = j;
                    }
                }
                a[index] = a[i];
                a[i] = max;
            }
        }
    }
}
