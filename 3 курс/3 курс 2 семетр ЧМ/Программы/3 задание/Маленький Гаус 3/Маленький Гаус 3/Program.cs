using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Маленький_Гаус_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] c = new double[5, 5];
            double[] x = new double[5];
            double[] y = new double[5];
            double[] b = new double[5];

            double e = 0.001, n = 3;
            int counter = 0, i = 1;

            c[1, 1] = 4;
            c[1, 2] = 0.4;
            c[1, 3] = 0.3;
            b[1] = 17.8;
            c[2, 1] = 0.4;
            c[2, 2] = 3;
            c[2, 3] = 0.2;
            b[2] = 11;
            c[3, 1] = 0.3;
            c[3, 2] = 0.2;
            c[3, 3] = 2;
            b[3] = 5.8;

            x[1] = 17.8; x[2] = 11; x[3] = 5.8;
            //x[1] = 0; x[2] = 0; x[3] = 0;

            Console.WriteLine("Матрица А");
            for (i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write("{0}\t", c[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Матрица B");
            for (i = 1; i <= n; i++)
            {
                Console.Write("{0}\n", b[i]);
            }

            double k = 0;

            do
            {
                for (i = 1; i <= n; i++)
                {
                    double Sl = 0, Sr = 0;

                    //формула 20
                    for (int j = 2; j <= n; j++)
                    {
                        Sl = Sl + (c[1, j] * x[j]);
                    }
                    y[1] = (1 / c[1, 1]) * (b[1] - Sl - Sr);

                    Sl = 0;
                    //формула 21
                    for (int j = i + 1; j <= n; j++) // прававое слагаемое
                    {
                        Sr = Sr + (c[i, j] * x[j]);
                    }

                    for (int j = 1; j <= i - 1; j++)// левое слагаемое
                    {
                        Sl = Sl + (c[i, j] * y[j]);
                    }
                    y[i] = (1 / c[i, i]) * (b[i] - Sl - Sr); // коэффициент 
                }

                //проверка условий для окончания
                for (i = 1; i <= n; i++)
                {
                    k = Math.Abs(y[i] - x[i]);
                    FindMax(k);//поиск максимума
                }

                for (i = 1; i <= n; i++)
                {
                    x[i] = y[i];
                }
                counter++;
            } while (k > e);
           
            Console.WriteLine();
            Console.Write("Ответ: ");
            for (i = 1; i <= n; i++) 
            {
                Console.Write("{0} ", x[i]);
            }

            Console.WriteLine("\nСчётчик = {0}", counter);
            Console.ReadKey();
        }

        public static double FindMax(double k)
        {
            double max = -999999;
            if (k > max)
            {
                max = k;
            }
            return k;
        }
    }
}
