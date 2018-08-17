using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = Console.ReadLine();
            StringBuilder s = new StringBuilder("Пример  строки и я два");
            //Char delimiter = ' ';
            //String[] substrings = s.Split(delimiter);
            //for (int i = 0; i < substrings.Length; i++)
            //{
            //    if (substrings[i].Length == 1)
            //    {
            //        substrings[i] = "";
            //    }
            //}
            //foreach (var substring in substrings)
            //    Console.Write("{0} ", substring);
            F(s);
            Console.WriteLine(s);
            Console.ReadLine();
        }
        static void F(StringBuilder s)
        { int i = 0;
            while (i < s.Length && s[i] == ' ')
                s.Remove(i, 1);

            for (i = 0; i < s.Length - 1; i++)
            {
                if (i == 0)
                {
                    if (s[i + 1] == ' ')
                    {
                        s.Remove(i, 2);
                        i--;
                    }
                }
                else
                    if (s[i - 1] == ' ' && s[i + 1] == ' ')
                {
                    s.Remove(i, 2);
                    i--;
                }
            }
            if (s.Length == 1) s.Remove(0, 1);
            else
            if(s[s.Length - 2] == ' ') s.Remove(s.Length-2, 2);



        }

    }
}
