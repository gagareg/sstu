using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    class Program
    {
        static double Method3(double x)
        {
            double y = 0;

            if (x < 0)
            {
                y = -4;
            }

            else if (0 <= x && x < 1)
            {
                for (double i = 0; i <= 1; i++)
                {
                    y = x * x + 3 * x + 4;
                }
            }

            else if (x >= 1)
            {
                y = 2;
            }
            return y;


        }
        static void Main()
        {
            Console.WriteLine(Method3(0.5));
            Console.ReadKey();
        }
    }
}
