using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _83_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double e = 0.001;
            double t = -1;
            double s = 1;
            double n = 0;
            double f1 = 1;
            double f2 = 1;
            double f = 1;
            while (Math.Abs(t+2*n/f)>e)
            {
                f = f1 + f2;
                n = n + 1;
                t = -t / 3;
                s = s + t * 2 * n / f;
                f1 = f2;
                f2 = f;
            }
            Console.WriteLine("{0:0.000}", s);
            Console.Read();
        }
    }
}
