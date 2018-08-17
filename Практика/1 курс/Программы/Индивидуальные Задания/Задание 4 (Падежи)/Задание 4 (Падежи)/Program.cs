using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4__Падежи_
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите падеж: ");
            string x = Console.ReadLine();
            bool ok = true;
            string res = "";
            switch (x)
            {
                case "именительный": res = "Кто? Что?"; break;
                case "родительный": res = "Кого? Чего?"; break;
                case "дательный": res = "Кому ? Чему?"; break;
                case "винительный": res = "Кого? Что?"; break;
                case "творительный": res = "Кем? Чем?"; break;
                case "предложный": res = "О ком? О чём? "; break;
                default: ok = false; break;
            }
            if (ok)
            {
                Console.WriteLine("Отвечает на вопрос {0}", res);
            }
            else Console.WriteLine("Ошибка!");
            Console.ReadKey();
        }
    }
}
