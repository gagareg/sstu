using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Повторяющиеся_числа
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите число: ");
            int a = int.Parse(Console.ReadLine());
			a = 0;
            bool p = false;
            
                while (a > 0)
                {
                    int mod = a % 10;
                    a /= 10;
                    int y = a;
                    while (y > 0)
                    {
                        if (mod == (y % 10))
                        {
                            p = true;
                            Console.WriteLine("Да");
                            a = 0;
                            break;
                        }
                        y /= 10;
                    }

                }
                if (!p)
                {
                    Console.WriteLine("Нет");
                }
            
            
            
            
            Console.ReadKey();
        }
    }
}
