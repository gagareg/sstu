using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _95_2
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                Console.WriteLine("Введите текущий год");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите текущий месяц");
                int m = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите текущий число");
                int d = int.Parse(Console.ReadLine());
                try
                {
                    DateTime date = new DateTime(y, m, d);
                    DateTime newYear = new DateTime(y, 12, 31);
                    int n = (newYear - date).Days;
                    Console.WriteLine("До Нового года осталось дней: " + n);
                }
                catch
                {
                    Console.WriteLine("Неверно введен номер месяца или число!");
                }
                Console.ReadKey();
            }
        }
    }
}
