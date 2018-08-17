using System;

namespace Среднее_арифметическое_массива
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int n;
			int i;
			Console.WriteLine ("Введите число элементов массива");
			n = Convert.ToInt16 (Console.ReadLine ());
			double[] Data = new double[n];
			double middle = 0;
			for ( i = 0; i < n; i++) 
			{
				Console.WriteLine ("Введите элемент массива");
				Data [i] = double.Parse (Console.ReadLine ());
				Console.WriteLine ();
			}
			foreach(int value in Data)
			{
				middle += value;
			}
			middle /= n;
			Console.WriteLine ("Среднее арифметическое массива равно " + middle);
			Console.ReadKey ();
		}
	}
}
