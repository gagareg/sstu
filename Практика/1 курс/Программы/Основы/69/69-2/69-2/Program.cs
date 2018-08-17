using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _69_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            while (a < 12)
            {
                Console.WriteLine(a);
                Console.WriteLine((a * a));
                Console.WriteLine((a * a * a));
                a += 2;
            }

            Console.ReadKey();
        }
    }
}
