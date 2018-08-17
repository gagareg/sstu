using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Потоки
{
    class Program
    {
        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("text.txt", Encoding.GetEncoding(1251)))
            {
                using (StreamWriter fileOut = new StreamWriter("newText.txt", false))
                {
                    string text = fileIn.ReadToEnd();
                    char find = char.Parse(Console.ReadLine());
                    string[] textArr = text.Split(new char[] { '\r', '\n' });
                    for (int i = 0; i < textArr.Length; i++)
                    {
                        string temp = textArr[i];
                        if (String.IsNullOrWhiteSpace(temp) == !true)
                        {
                            if (temp[0] == find)

                                fileOut.WriteLine(textArr[i]);
                        }
                    }
                }
            }
        }
    }
}


//FileStream fileIn = new FileStream("C:/Users/Microalab/source/repos/Потоки/text.txt", FileMode.Open, FileAccess.Read);
//FileStream fileOut = new FileStream("C:/Users/Microalab/source/repos/Потоки/newText.txt", FileMode.Create, FileAccess.Write);

