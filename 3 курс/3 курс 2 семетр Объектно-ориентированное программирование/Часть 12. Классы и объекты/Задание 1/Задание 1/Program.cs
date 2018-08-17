using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Создать класс для работы со ступенчатым массивом вещественных чисел. Разработать
следующие функциональные члены класса:
1. Поля:
    • double [][] doubelArray;
2. Конструктор, позволяющий создать ступенчатый массив.
3. Методы, позволяющие:
    • ввести элементы массива с клавиатуры;
    • вывести элементы массива на экран;
    • отсортировать элементы каждой строки массива в порядке убывания.
4. Свойства:
    • возвращающее общее количество элементов в массиве (доступное только для чтения);
    • позволяющее увеличить значение всех элементов массива на скаляр (доступное только
для записи).
5. Двумерный индексатор, позволяющий обращаться к соответствующему элементу
массива.
6. Перегруженные операции и константы, позволяющие:
    • увеличить, или уменьшить значение всех элементов массива на 1 (++ и --);
    • проверить, является ли каждая строка массива упорядоченной по возрастанию (true и false);
    • преобразовать экземпляр класса в ступенчатый массив (и наоборот).

*/

namespace Задание_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleArray a = new DoubleArray(2,2);
            a.AddArray();
            Console.WriteLine("Вывод массива");
            a.PrintArray();
            //a.SortArray();
            //Console.WriteLine("Вывод сортированного массива");
            //a.PrintArray();
            //Console.WriteLine("Количество эл-ов в массиве = {0}", a.AmountOfElementsArray);
            //Console.Write("На какое число увеличим все эл-ты массива? ");
            //a.ScalarArray = int.Parse(Console.ReadLine());
            //Console.WriteLine("Увеличенный массив");
            //a.PrintArray();

            //Остановились тут!

            Console.WriteLine("Индексатор");
            Double index = a[0, 0];
            Console.WriteLine(index);
            Console.WriteLine("Перегрузка ++");
            a++;
            a.PrintArray();
            Console.WriteLine("Перегрузка --");
            a--;
            a.PrintArray();

            if (a) 
            {
                Console.WriteLine("Упорядочены");
            }
            else
            {
                Console.WriteLine("Неупорядочены");
            }

            Console.ReadKey();

            //Преобразование
            double[,] mas = a;
            double[,] mas2 = (double[,])a;
            DoubleArray b1 = mas;
            DoubleArray b2 = (DoubleArray)mas2;
        }
    }
}
