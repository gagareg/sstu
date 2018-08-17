using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    class Program
    {
        static int[,] Input(out int n)
        {
            Random rnd = new Random();
            n = rnd.Next(2, 5);
            Console.WriteLine("Размерность массива {0}x{1}", n, n);
            int[,] a = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                {
                    a[i, j] = rnd.Next(10);
                }
            return a;
        }

        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write("{0,5} ", a[i, j]);
        }

        static void Rezalt(int[,] a,int row1,int row2)
        {
            //int row1;
            //int row2;
            //if (a.GetLength(0) % 2 == 0)
            //{
            //    row1 = a.GetLength(0) / 2;
            //    row2 = row1 - 1;
            //}
            //else
            //{
            //    row1 = a.GetLength(0) / 2;
            //    row2 = 0;
            //}
            for (int i = 0; i < a.GetLength(1); i++)
            {
                int tmp = a[row1, i];
                a[row1, i] = a[row2, i];
                a[row2, i] = tmp;
            }
        }

        static void Main(string[] args)
        {
            int n;
            int[,] myArray = Input(out n);
            Console.WriteLine("Исходный массив:");
            Print(myArray);
            Console.WriteLine("Полученный массив:");
            if(myArray.GetLength(0)%2==0)
                Rezalt(myArray, myArray.GetLength(0) / 2-1, myArray.GetLength(0) / 2 );
            else
            Rezalt(myArray,0, myArray.GetLength(0)/2);
            Print(myArray);
            Console.ReadKey();
        }
    }
}

//static void Input(out int[,] a)
//{
//    Random rnd = new Random();
//    int n = rnd.Next(2, 5);
//    //int m = rnd.Next(2, 5);
//    Console.WriteLine("Размерность массива {0}x{1}", n, n);
//    a = new int[n, n];
//    for (int i = 0; i < a.GetLength(0); i++)
//    {
//        for (int j = 0; j < a.GetLength(1); j++)
//        {
//            a[i, j] = rnd.Next(10);
//        }
//    }
//}