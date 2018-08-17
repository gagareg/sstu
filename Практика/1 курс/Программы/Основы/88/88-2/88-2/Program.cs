using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _88_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int b, c = 0, c0 = 0, c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0, a0 = 10, a1 = 10, a2 = 10, a3 = 10, a4 = 10, a5 = 10, a6 = 10, a7 = 10, a8 = 10, a9 = 10;
            Console.WriteLine("Введите число ");
            int a = int.Parse(Console.ReadLine());
            while (a >= 1)
            {
                b = a % 10;
                a /= 10;
                if ((b == a0) || (b == a1) || (b == a2) || (b == a3) || (b == a4) || (b == a5) || (b == a6) || (b == a7) || (b == a8) || (b == a9)) c += 1;
                if (b == a0) c0++;
                if (b == a1) c1++;
                if (b == a2) c2++;
                if (b == a3) c3++;
                if (b == a4) c4++;
                if (b == a5) c5++;
                if (b == a6) c6++;
                if (b == a7) c7++;
                if (b == a8) c8++;
                if (b == a9) c9++;
                if (b == 0) a0 = 0;
                if (b == 1) a1 = 1;
                if (b == 2) a2 = 2;
                if (b == 3) a3 = 3;
                if (b == 4) a4 = 4;
                if (b == 5) a5 = 5;
                if (b == 6) a6 = 6;
                if (b == 7) a7 = 7;
                if (b == 8) a8 = 8;
                if (b == 9) a9 = 9;
            }

            if (c0 >= 1) 
            Console.WriteLine("0");
            if (c1 >= 1) 
            Console.WriteLine("1");
            if (c2 >= 1) 
            Console.WriteLine("2");
            if (c3 >= 1) 
            Console.WriteLine("3");
            if (c4 >= 1) 
            Console.WriteLine("4");
            if (c5 >= 1) 
            Console.WriteLine("5");
            if (c6 >= 1) 
            Console.WriteLine("6");
            if (c7 >= 1) 
            Console.WriteLine("7");
            if (c8 >= 1) 
            Console.WriteLine("8");
            if (c9 >= 1) 
            Console.WriteLine("9");
            if (c == 0) 
            Console.WriteLine("Нет повторений");
            Console.ReadKey();
        }
    }
}
