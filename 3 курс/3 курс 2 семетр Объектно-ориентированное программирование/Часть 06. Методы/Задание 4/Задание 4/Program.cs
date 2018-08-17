using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Combination(1, 10));
            Console.ReadKey();
        }
        public static int Combination(int m, int n)
        {
            int c = 0;

            if (n == 0)
                return 0;

            if ((m == 0 || m == n))
                return 1;

            if ((n > m) && (m > 0))
            {
                c = Factorial(n) / (Factorial(m) * Factorial(n - m));
            }

            return c;
        }

        public static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}
