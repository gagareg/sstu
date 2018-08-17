
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_M_3
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] y = new float[6];
            float[] s = new float[6];
            float x, a = 0.1f, h = 0.1f;

            for (int i = 0; i < 6; i++)
            {
                x = a + i * h;
                y[i] = a + i * h;
                s[i] = F(y[i]);
                Console.WriteLine("f({0}) = {1}", y[i], s[i]);
            }

            Console.ReadKey();
        }
        
         static public float F(float x)
        {
            float[] y = new float[6];
            float[] s = new float[6];
            float q, e = 0.0001f, m = 1, a = 1;
            int k = 0;

            while ((Math.Abs(a / m)) > e) 
            {
                q = x / (2 * k + 2);
                a = a * q;
                m = m + a;
                k = k + 1;
            }

            return m;
        }

         static public int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
