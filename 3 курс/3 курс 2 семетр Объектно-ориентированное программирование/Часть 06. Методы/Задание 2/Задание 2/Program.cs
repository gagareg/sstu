using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MethodTwo(10));
            Console.WriteLine();

            MethodTwoOne(1, 10);
            Console.WriteLine();

            Console.WriteLine(MethodTwoThree(1, 10));
            Console.WriteLine();

            Console.WriteLine(MethodTwoFour(1, 1, 10));

            Console.ReadKey();
        }

        public static int MethodTwo(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    sum++;
                }
            }
            return sum;
        }
        public static void MethodTwoOne(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine("У {0} количетво делителей равно {1}", i, MethodTwo(i));
            }
            
        }
        public static int MethodTwoThree(int a, int b)
        {
            int max = 0;
            int MaxOfDevider = 0;
            for (int i = a; i <= b; i++)
            {
                if (MethodTwo(i) >= MethodTwo(max)) 
                {
                    max = MethodTwo(i);
                }
            }
            for (int i = a; i <= b; i++)
            {
                if (max == MethodTwo(i)) 
                {
                    MaxOfDevider++;
                }
            }
            return MaxOfDevider;
        }
        public static int MethodTwoFour(int A, int a, int b)
        {
            int number = 0;
            for (int i = a; i <= b; i++)
            {
                if (MethodTwo(A) == MethodTwo(i) && A != i && A < i)  
                {
                    number = i;
                    break;
                }
            }
            return number;
        }
    }

}
