using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4
{

    class Program
    {
        public static double FindMax(double k)
        {
            double max = -999999;
            if (k > max)
            {
                max = k;
            }
            return k;
        }
        static void Main(string[] args)
        {
            double[,] c = new double[5, 5];
            double[] x = new double[5];
            double[] y = new double[5];
            double[] b = new double[5];

            double e = 0.001, n = 3, k = 0, det = 1;
            int counter = 0, i = 1, z = 1;
            

            c[1, 1] = 3;
            c[1, 2] = 0.3;
            c[1, 3] = 0.2;
            b[1] = 9.8;
            c[2, 1] = 0.3;
            c[2, 2] = 2;
            c[2, 3] = 0.1;
            b[2] = 5;
            c[3, 1] = 0.2;
            c[3, 2] = 0.1;
            c[3, 3] = 1;
            b[3] = 1.8;

            x[1] = 9.8; x[2] = 5; x[3] = 1.8;
            Console.WriteLine("Исходная матрица");
            for ( i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write("{0}\t", c[i, j]);
                }
                Console.WriteLine();
            }

            for ( i = 1; i <= n; i++)//считаем определитель 
            {
                for (int j = 1; j <= (n); j++)
                {
                    //det = c[1, 1];


                    if ((i == j) && (i > 1))
                    {

                        det *= Math.Pow((c[i, j]), z);
                        z++;


                    }
                }
            }
            det = det * c[1, 1];
            Console.WriteLine();
            Console.Write("Det={0}", det);
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Правая часть= начальный вектор");
            for ( i = 1; i <= n; i++)
            {
                Console.Write("{0}\n", b[i]);
            }


            double w = 0.99;

            for (int l = 1; l <= 100; l++)
            {
                w = w + 0.01; k = 0;
                x[1] = 17.8; x[2] = 11; x[3] = 5.8;
                y[1] = 0; y[2] = 0; y[3] = 0;
                counter = 0;

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
                Console.Write("Корни: ");
                for (i = 1; i <= n; i++)
                {
                    Console.Write("\nx({0})={1}  ", i,x[i]);
                }
                Console.WriteLine("\nСчётчик = {0}", counter);

                i = 1;
            }
            Console.ReadKey();
        }
    }
    
}
