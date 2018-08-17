using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1___2
{
    class Program
    {
        static void Print(int[] a) //выводит на экран массив a
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }

        static void FindAverage(int[] a) // выводит среднее арифметическое отрицательный чисел 
        {
            double average = 0, counter = 0;
            for (int i = 0; i < a.Length; i++)
            {

                if (a[i] < 0)
                {
                    average = average + (a[i]);
                    counter++;
                }
            }
            double totals = average / counter;
            Console.WriteLine("Среднее Арифметическое Отрицательный чисел = {0}", totals);
        }
        static void FindMinElement(int[] a)
        {
            int min = a[0];
            int lastNumber = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                    lastNumber = i;
                }
            }
            Console.WriteLine("Минимальный элемент = {0}, а его индекс = {1}", min, lastNumber);
        }
        static void Main()
        {
            Console.Write("Исходный массив: ");
            Random rnd = new Random();
            int[] myArray;
            int n = rnd.Next(5, 10); //генерируем случайное число из диапазона[5..10)
            myArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                myArray[i] = rnd.Next(-10, 10); //заполняем массив случайными числами
            }
            //int[] myArray = { 0, -1, -22, 3, 4, 5, -6, -7, -22};
            Print(myArray);
            FindAverage(myArray);
            FindMinElement(myArray);
            Console.ReadKey();
        }
    }
}
