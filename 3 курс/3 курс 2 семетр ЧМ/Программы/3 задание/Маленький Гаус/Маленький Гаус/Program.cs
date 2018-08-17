using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Маленький_Гаус
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] c = new double[5, 5];
            double[] y = new double[5];
            double[] x = new double[5];
            int n = 3, m = 3;

            c[1, 1] = 4;
            c[1, 2] = 0.4;
            c[1, 3] = 0.3;
            c[1, 4] = 17.8;
            c[2, 1] = 0.4;
            c[2, 2] = 3;
            c[2, 3] = 0.2;
            c[2, 4] = 11;
            c[3, 1] = 0.3;
            c[3, 2] = 0.2;
            c[3, 3] = 2;
            c[3, 4] = 5.8;

            Console.WriteLine("Исходная матрица:");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= (m + 1); j++)
                {
                    Console.Write("{0}\t", c[i, j]);
                }
                Console.WriteLine();
            }

            for (int k = 1; k <= n; k++)
            {
                for (int i = k; i <= n; i++)
                {
                    for (int j = (m + 1); j >= k; j--) 
                    {
                        c[i, j] = c[i, j] / c[i, k];
                    }
                }

                for (int i = k; i <= (n - 1); i++) 
                {
                    for (int j = k; j <= (m + 1); j++) 
                    {
                        c[(i+1), j] = c[(i+1), j] - c[k, j];
                    }
                }
            }
            Console.WriteLine();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= (m + 1); j++)
                {
                    //Console.Write("{0}\t", c[i, j]); показывает треугольный вид матрицы
                }
                Console.WriteLine();
            }

            for (int i = 1; i <= n; i++)
            {
                y[i] = c[i, (n + 1)];
            }

            for (int i = n; i >= 1; i--)
            {
                x[i] = 0;
            }

            for (int i = n; i >= 1; i--)
            {
                double l = 0;
                for (int j = n; j >= 1; j--)
                {
                    l = l - x[j] * c[i, j];
                }
                x[i] = y[i] + l;
            }
            Console.WriteLine("Ответ:");
            for (int i = 1; i <= n; i++) 
            {
                Console.Write("{0} \t", x[i]);
            }
            Console.ReadKey();
        }
    }
}
