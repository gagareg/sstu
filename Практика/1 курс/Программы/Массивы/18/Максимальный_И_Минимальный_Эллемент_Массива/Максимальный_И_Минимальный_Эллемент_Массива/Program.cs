using System;

namespace Максимальный_И_Минимальный_Эллемент_Массива
{
	class MainClass
	{
		static void Main(string[] args)
		{
			int min_ind = 0, max_ind = 0;
			int[] mas = new int[5];

			Random r = new Random();

			for (int i = 0; i < mas.Length; i++) 
			{
				mas [i] = r.Next (-10, 10);
			}
			for (int i = 0; i < mas.Length; i++) 
			{
				Console.Write (mas [i] + " ");
			}
			int min, max;
			min = max = mas[0];

			for (int i = 0; i < mas.Length; i++)
			{
				if (min > mas[i])
				{
					min = mas[i];
					min_ind = i;
				}
				if (max < mas[i])
				{
					max = mas[i];
					max_ind = i;
				}
			}

			Console.WriteLine("\nMax value: " + max + "\nMin value: " + min + "\nMax index: " + max_ind + "\nMin index: " + min_ind);
			Console.ReadKey();
		}
	}
}
