using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _83
{
    class Program
    {
        static void Main(string[] args)
        {
            double b = 2, c = 3, z = 1, d = 3;
            double s = 0, a = 1;
            while (Math.Abs(a) > 0.001)
            {
                s += a;
                a = z * b / (c * d);
                z = -z;
                b = b + 2;
                c = c + 2;
                d = d * 3;
            }
            Console.WriteLine("{0:0.000}", s);
            Console.Read();
        }
    }
}
