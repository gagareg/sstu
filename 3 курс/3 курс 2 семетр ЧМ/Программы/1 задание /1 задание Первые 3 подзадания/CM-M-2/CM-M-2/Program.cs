using System;

namespace CMM2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int k = 1;
			float  a = 0.5f, s = 0.5f, q;
			Console.Write ("Введите х = ");
			float x = Convert.ToSingle(Console.ReadLine());
            float e = 0.0001f;


            while ((Math.Abs(a / s) > e))
            {
                q = (k + 1) * x / (2 * k * Factorial(k) * Factorial((k + 1)));
                a = a * q;
                s = s + a;
                k = k + 1;
            }
            Console.WriteLine("S = {0}; k = {1}", s, k);
            Console.ReadKey();

		}
		public static int Factorial(int facno)
		{
			int temno = 1;

			for (int i = 1; i <= facno; i++)
			{
				temno = temno * i;
			}

			return temno;
		}
	}
}
