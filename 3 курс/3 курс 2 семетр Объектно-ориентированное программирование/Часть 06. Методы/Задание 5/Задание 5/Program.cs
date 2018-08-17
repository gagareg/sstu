using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    class Program
    {
        public static string MethodFive(int i)
        {
            if (i <= 0)
                return "";
            string result = i + " " + MethodFive(i - 1);
            Console.WriteLine(result);
            return result;
        }

        static void Main()
        {
            MethodFive(5);
            Console.ReadKey();
        }
    }
}
