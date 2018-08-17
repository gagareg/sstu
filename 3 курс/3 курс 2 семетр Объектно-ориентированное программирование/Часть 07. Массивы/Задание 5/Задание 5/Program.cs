using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    class Program
    {
        static int[] Input(out int n)
        {
            Random rnd = new Random();
            Console.Write("Введите размерность массива ");
            n = int.Parse(Console.ReadLine());
            //выделяем памяти больше чем требуется
            int[] a = new int[2 * n];
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(-5, 0);
            }
            return a;
        }
        static void Print(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,4} ", a[i]);
            }
            Console.WriteLine();
        }
        static void Add(int[] a, ref int n)
        {
            int maxIndex = -1;
            for (int i = n; i>=0; i--)
            {
                if (a[i] > 0)
                {
                    maxIndex = i;
                    break;
                }
            }
          
            if (maxIndex>=0)
            {
                ++n;
                for (int i = n - 1; i > maxIndex; i--)
                {
                    a[i + 1] = a[i];

                }
                Console.Write("Введите значение нового элемента ");
                a[maxIndex + 1] = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Положительных элементов нету");
            }
            
        }
        static void Main()
        {
            int n;
            int[] a = Input(out n);
            Console.WriteLine("Исходный массив:");
            Print(a, n);
            Add(a, ref n);
            Console.WriteLine("Измененный массив:");
            Print(a, n);
            Console.ReadKey();
        }
    }
}
