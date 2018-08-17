using System;

namespace CHM1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int k = 0;
			float  a = 1, s = 1, q;
			Console.Write ("Введите х = ");
			float x = Convert.ToSingle(Console.ReadLine());
            float e = 0.0001f;

            while ((Math.Abs(a / s) > e))
            {
                q = x / (2 * k + 2);
                a = a * q;
                s = s + a;
                k = k + 1;
            }
            Console.WriteLine("S = {0}; k = {1}", s, k);			
            Console.ReadKey();
		}
	}
}
