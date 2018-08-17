using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Массивы_начало_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива");
            int n = int.Parse(Console.ReadLine());
            double[] Data = new double[n];
            int i;
            double min = 999;
            for ( i = 0; i < n; i++)
            {
                Console.WriteLine("Введите элемент массива");
                Data[i] = double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            for ( i = 0; i < n; i++)
            {
                
                if (min > Data[i])
                {
                    min = Data[i];
                }
                
            }
            Console.WriteLine(min);
            Console.ReadKey();
        }
    }
}