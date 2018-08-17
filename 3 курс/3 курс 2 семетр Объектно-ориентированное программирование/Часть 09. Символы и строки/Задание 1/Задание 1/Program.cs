using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    class Program
    {
        static string FindAlphabet(string text)
        {
            for (int i = 1; i < text.Length; i++)
            {
                text = text.Replace("  ", string.Empty);
                text = text.Trim().Replace(" ", string.Empty);
            }
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i - 1] >= text[i]) 
                {
                    return "Нет";
                }
            }
            return "Да";
        }

        static void Main()
        {
            string s = Console.ReadLine();
            Console.WriteLine("{0} по алфавиту? {1}", s.ToLower(), FindAlphabet(s));
            Console.ReadKey();
        }
    }
}
