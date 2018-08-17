using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Маленький_Гаус_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] c = new double[5, 5];
            double[] x = new double[5];
            double[] y = new double[5];
            double[] b = new double[5];

            double e = 0.001, k = 0, n = 3;
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

            x[1] = 0; x[2] = 0; x[3] = 0;
            //x[1] = 17.8; x[2] = 11; x[3] = 5.8;

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

            Console.WriteLine();

            double w = 0.9;

            for (int l = 1; l <= 10; l++)
            {
                w = w + 0.1;k = 0;
                x[1] = 17.8; x[2] = 11; x[3] = 5.8;
                y[1] = 0;y[2] = 0;y[3] = 0;
                
                do
                {
                    for (i = 1; i <= n; i++)
                    {
                        double Sl = 0, Sr = 0;
                        //правая часть
                        for (int j = i; j <= n; j++)
                        {
                            Sr = Sr + (c[i, j] * x[j]);
                        }
                        //левая часть
                        for (int j = 1; j <= i - 1; j++)
                        {
                            Sl = Sl + (c[i, j] * y[j]);
                        }
                        y[i] = x[i] + ((w / c[i, i]) * (b[i] - Sl - Sr));
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
                Console.WriteLine("При w = {0}", w);
                Console.Write("Ответ: ");
                for (i = 1; i <= n; i++)
                {
                    Console.Write("{0}  ", x[i]);
                }
                Console.WriteLine("\nСчётчик = {0}", counter);

                i = 1; 
            }            
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
