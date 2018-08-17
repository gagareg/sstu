using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //int[,] a = Init(4, 4, rnd);
            //Print(a);
            int[][] b = InitStep(4, rnd);
            PrintStep(b);
            Print(FindMinOfColumnOfStep(b));



            Console.ReadKey();
        }
        static void Print(int[] a)
        {
            Console.WriteLine("Сумма отрицательных элеметов столбцов");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0,4}", a[i]);
            }
        }
        static int[,] Init(int n, int m, Random rnd)
        {
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(-5, 10);
                }
            }
            return a;
        }
        static void Print(int[,] a)
        {
            Console.WriteLine("Квадратный Массив");
            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                {
                }
            }
            Console.WriteLine();
        }
        static int[][] InitStep(int n, Random rnd)
        {
            int[][] a = new int[n][];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new int[a.Length];
                for (int j = 0; j < a.Length; j++)
                {

                    a[i][j] = rnd.Next(-10, 3);
                }
            }
            return a;
        }
        static void PrintStep(int[][] a)
        {
            Console.WriteLine("Ступенчатый Массив");
            for (int i = 0; i < a.Length; ++i, Console.WriteLine())
            {
                for (int j = 0; j < a.Length; ++j)
                {
                    Console.Write("{0,4}", a[i][j]);
                }
            }
        }
        static int[] FindMinOfColumnOfStep(int[][] a)
        {
            int temp = 0;
            int[] tempArray = new int[a.GetLength(0)];
            for (int i = 0; i < a.Length; i++)
            {
                temp = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j][i] < 0)
                    {
                        temp += (a[j][i]);
                    }
                    tempArray[i] = temp;
                }
            }
            return tempArray;
        }
    }
}
