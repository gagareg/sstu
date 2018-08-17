using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Да, тут были числа 1231231321 но теперь их нету!";
            //string s = Console.ReadLine();
            Console.WriteLine(DeleteAllNumbers(s));
            Console.ReadKey();
        }
        static string DeleteAllNumbers(string s)
        {
            string str = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                {
                    str += s[i];
                }
            }
            return str;
        }
    }
}
