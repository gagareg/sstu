using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _95
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца:");
            int m = int.Parse(Console.ReadLine());
            switch (m)
            {
                case 1:
                    Console.WriteLine("В этом месяце 31 дней.");
                    break;
                case 2:
                    Console.WriteLine("В этом месяце 29 дней.");
                    break;
                case 3:
                    Console.WriteLine("В этом месяце 31 дней.");
                    break;
                case 4:
                    Console.WriteLine("В этом месяце 30 дней.");
                    break;
                case 5:
                    Console.WriteLine("В этом месяце 31 дней.");
                    break;
                case 6:
                    Console.WriteLine("В этом месяце 30 дней.");
                    break;
                case 7:
                    Console.WriteLine("В этом месяце 31 дней.");
                    break;
                case 8:
                    Console.WriteLine("В этом месяце 31 дней.");
                    break;
                case 9:
                    Console.WriteLine("В этом месяце 30 дней.");
                    break;
                case 10:
                    Console.WriteLine("В этом месяце 30 дней.");
                    break;
                case 11:
                    Console.WriteLine("В этом месяце 30 дней.");
                    break;
                case 12:
                    Console.WriteLine("В этом месяце 31 дней.");
                    break;
                default:
                    Console.WriteLine("Вы ошиблись!");
                    break;
            }
            
            Console.ReadKey();
        }
    }
}
