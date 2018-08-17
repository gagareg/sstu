using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Потоки_2
{
    class Program
    {
        static void Main()
        {
            using (StreamWriter fileOut = new StreamWriter("newText.txt", false))
            {
                using (StreamReader fileIn = new StreamReader("text.txt", Encoding.GetEncoding(1251)))
            {
                
                    string line = fileIn.ReadLine();
                    string[] lineArr = line.Split(' ');
                    int[] intArr = new int[lineArr.Length];
                    for (int i = 0; i < lineArr.Length; i++)
                    {
                        intArr[i] = int.Parse(lineArr[i]);
                    }

                    for (int i = 0; i < intArr.Length; i++)
                    {
                        if (intArr[i] > 0)
                        {
                            //Console.WriteLine(intArr[i]);
                            fileOut.Write("{0} ", intArr[i]);
                            
                        }
                    }
                }
            
            using (StreamReader fileIn = new StreamReader("text2.txt", Encoding.GetEncoding(1251)))
            {
                
                    string line = fileIn.ReadLine();
                    string[] lineArr = line.Split(' ');
                    int[] intArr = new int[lineArr.Length];
                    for (int i = 0; i < lineArr.Length; i++)
                    {
                        intArr[i] = int.Parse(lineArr[i]);
                    }
                    fileOut.WriteLine();
                    for (int i = 0; i < intArr.Length; i++)
                    {
                        if (intArr[i] < 0)
                        {
                            //Console.WriteLine(intArr[i]);
                            fileOut.Write("{0} ", intArr[i]);
                        }
                    }
                }
            }
        }
        
    }
}
