using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        public static double FF(double x1, double x2, double x3)
        {
            double y;
            y = x1 * x1 + (x2 - 2) * (x2 - 2);
            return (y);
        }
        public static double G1(double x1, double x2, double x3)
        {
            double y;

            y = x1 * x1 + 2 * x2 * x2 - 8;
            return (y);
        }
        public static double G2(double x1, double x2, double x3)
        {
            double y;

            y = 0;
            return (y);
        }
        public static double G3(double x1, double x2, double x3)
        {
            double y;

            y = 0;
            return (y);
        }
        public static double H1(double x1, double x2, double x3)
        {
            double y;

            y = x1 * x1 + 2 * (x2 - 2) * (x2 - 2) - 8;
            return (y);
        }
        public static double H2(double x1, double x2, double x3)
        {
            double y;

            y = 0;
            return (y);
        }
        public static double H3(double x1, double x2, double x3)
        {
            double y;

            y = 0;
            return (y);
        }
        public static double G(double x1, double x2, double x3)
        {
            double y;

            y = G1(x1, x2, x3) + G2(x1, x2, x3) + G3(x1, x2, x3);
            return (y);
        }
        public static double H(double x1, double x2, double x3)
        {
            double y;

            y = H1(x1, x2, x3) + H2(x1, x2, x3) + H3(x1, x2, x3);
            return (y);
        }
        public static double Gl1(double x1, double x2, double x3, double l)
        {
            double y;

            y = G1(x1, x2, x3) * l;
            return (y);
        }
        public static double Gl2(double x1, double x2, double x3, double l)
        {
            double y;

            y = G2(x1, x2, x3) * l;
            return (y);
        }
        public static double Gl3(double x1, double x2, double x3, double l)
        {
            double y;

            y = G3(x1, x2, x3) * l;
            return (y);
        }
        public static double Gl(double x1, double x2, double x3, double l1, double l2, double l3)
        {
            double y;

            y = Gl1(x1, x2, x3, l1) + Gl2(x1, x2, x3, l2) + Gl3(x1, x2, x3, l3);
            return (y);
        }
        public static double Hn1(double max, double nn)
        {
            double y;

            y = max * max - nn * nn;
            return (y);
        }
        public static double Hn2(double max, double nn)
        {
            double y;

            y = max * max - nn * nn;
            return (y);
        }
        public static double Hn3(double max, double nn)
        {
            double y;

            y = max * max - nn * nn;
            return (y);
        }
        public static double Hn(double max, double n1, double n2, double n3)
        {
            double y;

            y = Hn1(max, n1) + Hn2(max, n2) + Hn3(max, n3);
            return (y);
        }
        public static double Max1(double x1, double x2, double x3, double nn, double r)
        {
            double y;
            y = 0;
            if ((nn + r * H1(x1, x2, x3) > 0))
            {
                y = nn + r * H1(x1, x2, x3);
            }

            return (y);
        }
        public static double Max2(double x1, double x2, double x3, double nn, double r)
        {
            double y;
            y = 0;
            if ((nn + r * H2(x1, x2, x3) > 0))
            {
                y = nn + r * H2(x1, x2, x3);
            }

            return (y);
        }
        public static double Max3(double x1, double x2, double x3, double nn, double r)
        {
            double y;
            y = 0;
            if ((nn + r * H3(x1, x2, x3) > 0))
            {
                y = nn + r * H3(x1, x2, x3);
            }

            return (y);
        }
        public static double Max(double x1, double x2, double x3, double n1, double n2, double n3, double r)
        {
            double y;

            y = Max1(x1, x2, x3, n1, r) + Max2(x1, x2, x3, n2, r) + Max3(x1, x2, x3, n3, r);
            return (y);
        }

        static void Main(string[] args)
        {
            double dz11, max=1, max10, max20, max30, l1=0, l2=0, l3=0, n1=0, n2=0, n3=0, e1=0.0001, e2=0.0001, e3= 0.01, h=0.0001, z10, z20, z30, z11, z22, z33, dz1, dz2, dz3, ndf=1, f0, fy, fz, a, b, y, z, l, L,  x, ndz, z01, z02, z03, mf, r=1, c, p;

            int k = 0,M = 1000,n=0;

                Console.Write("Введите x = ");
                double z1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите y = ");
                double z2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите z = ");
                double z3 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
           
            do
            {
                k = 0;
                n++;
                while ((ndf > e1) && (k < M))
                {

                    k = k + 1;


                    z10 = z1 + h;
                    z20 = z2 + h;
                    z30 = z3 + h;

                    max = Max(z1, z2, z3, n1, n2, n3, r);

                    max10 = Max(z10, z2, z3, n1, n2, n3, r);
                    max20 = Max(z1, z20, z3, n1, n2, n3, r);
                    max30 = Max(z1, z2, z30, n1, n2, n3, r);

                    dz1 = ((FF(z10, z2, z3) + Gl(z10, z2, z3, l1, l2, l3) + (r * G(z10, z2, z3) * G(z10, z2, z3) / 2) + Hn(max10, n1, n2, n3) / (2 * r)) - (dz11 = FF(z1, z2, z3) + Gl(z1, z2, z3, l1, l2, l3) + (r * G(z1, z2, z3) * G(z1, z2, z3) / 2) + Hn(max, n1, n2, n3) / (2 * r))) / h;
                    dz2 = ((FF(z1, z20, z3) + Gl(z1, z20, z3, l1, l2, l3) + (r * G(z1, z20, z3) * G(z1, z20, z3) / 2) + Hn(max20, n1, n2, n3) / (2 * r)) - (dz11 = FF(z1, z2, z3) + Gl(z1, z2, z3, l1, l2, l3) + (r * G(z1, z2, z3) * G(z1, z2, z3) / 2) + Hn(max, n1, n2, n3) / (2 * r))) / h;
                    dz3 = ((FF(z1, z2, z30) + Gl(z1, z2, z30, l1, l2, l3) + (r * G(z1, z2, z30) * G(z1, z2, z30) / 2) + Hn(max30, n1, n2, n3) / (2 * r)) - (dz11 = FF(z1, z2, z3) + Gl(z1, z2, z3, l1, l2, l3) + (r * G(z1, z2, z3) * G(z1, z2, z3) / 2) + Hn(max, n1, n2, n3) / (2 * r))) / h;


                    ndf = Math.Sqrt(dz1 * dz1 + dz2 * dz2 + dz3 * dz3);

                   
                    l = 0.001;
                    a = 0;
                    b = 3;
                    x = (a + b) / 2;
                    L = b - a;
                    while (L > l)
                        {

                            f0 = FF(z1 - x * dz1, z2 - x * dz2, z3 - x * dz3);
                            y = a + L / 4;
                            z = b - L / 4;
                            fy = FF(z1 - y * dz1, z2 - y * dz2, z3 - y * dz3);
                            fz = FF(z1 - z * dz1, z2 - z * dz2, z3 - z * dz3);

                                if (fy < f0)
                                    {
                                        b = x;
                                        x = y;
                                    }
                                else if (fz < f0)
                                    {
                                        a = x;
                                        x = z;
                                    }
                                else
                                    {
                                        a = y;
                                        b = z;
                                    }

                            L = b - a;
                        }

                    z11 = z1 - x * dz1;
                    z22 = z2 - x * dz2;
                    z33 = z3 - x * dz3;

                    mf = Math.Abs(FF(z11, z22, z33) - FF(z1, z2, z3));

                    z01 = z11 - z1;
                    z02 = z22 - z2;
                    z03 = z33 - z3;

                    z1 = z11;
                    z2 = z22;
                    z3 = z33;

                    ndz = Math.Sqrt(z01 * z01 + z02 * z02 + z03 * z03);

                    if ((ndz < e2) && (mf < e2))
                        {
                            goto step2;
                        }
                }
                step2:

                    p = (r * G(z1, z2, z3) * G(z1, z2, z3) / 2) + Hn(max, n1, n2, n3) / (2 * r);

                Console.WriteLine("\nhn = {0}", Hn(max, n1, n2, n3));
                Console.WriteLine("\nG^2 = {0}", G(z1, z2, z3) * G(z1, z2, z3));
                
                    l1 = l1 + r * G1(z1, z2, z3);
                    l2 = l2 + r * G2(z1, z2, z3);
                    l3 = l3 + r * G3(z1, z2, z3);
                    n1 = Max1(z1, z2, z3, n1, r);
                    n2 = Max2(z1, z2, z3, n2, r);
                    n3 = Max3(z1, z2, z3, n3, r);
                    c = 4;
                    r = r * c;
                
                Console.WriteLine("\np = {0}", p);

            } while ((p > e3) && (n < 100));

                Console.WriteLine();
                Console.WriteLine("n = {0}", n);
              
                Console.WriteLine("\nL=({1},{3},{5}) \n\nn=({0},{2},{4})", n1, l1, n2, l2, n3, l3);
                Console.WriteLine("\nКолличество шагов = {0}", k);
                Console.WriteLine("\nКоординаты точки минимума:");
                Console.WriteLine("\nx = {0},\ny = {1},\nz = {2}", z1, z2, z3);
                Console.WriteLine("\nЗначение функции f(x,y,z) = {0}", FF(z1, z2, z3));
                Console.ReadKey();        
            
        }
    }
}

