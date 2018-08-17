using System;


namespace Задание_3
{
    class Program
    {
        static void Main()
        {
            int n = 44;
            for (int i = 1; i <= n; i = 2 * i)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            
        }
    }
}
