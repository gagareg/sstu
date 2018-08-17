using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    class StepArray
    {
        public int lines = 0;
        public int columns = 0;
        private double[,] doubleArray;

        public StepArray(int lines, int columns)
        {
            doubleArray = new double[lines, columns];
        }
        public void Add()
        {
            for (int i = 0; i < doubleArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleArray.GetLength(1); j++)
                {
                    doubleArray[i,j] = double.Parse(Console.ReadLine());
                }
            }
        }


    }
}
