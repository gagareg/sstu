using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    class DoubleArray
    {
        private double[,] doubleArray;

        public DoubleArray(int lines, int columns)
        {
            doubleArray = new double[lines, columns];
        }

        public void AddArray()
        {
            for (int i = 0; i < doubleArray.GetLength(0); i++) 
            {
                for (int j = 0; j < doubleArray.GetLength(1); j++)
                {
                    Console.Write("a[{0}, {1}] = ", i, j);
                    doubleArray[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < doubleArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleArray.GetLength(1); j++)
                    Console.Write("{0,5} ", doubleArray[i, j]);
                Console.WriteLine();
            }
        }

        public void SortArray()
        {
            double[] temp = new double[doubleArray.GetLength(1)];
            for (int i = 0; i < doubleArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleArray.GetLength(1); j++) 
                {
                    temp[j] = doubleArray[i, j];
                }
                Sort(temp);
                for (int j = 0; j < doubleArray.GetLength(1); j++)
                {
                    doubleArray[i, j] = temp[j];
                }
            }
        }

        private void Sort(double[] a)
        {
            double max;
            int index;
            int i, j;
            for (i = 0; i < a.Length - 1; i++)
            {
                index = i;
                max = a[i];
                for (j = i + 1; j < a.Length; j++)
                {
                    if (a[j] > max)
                    {
                        max = a[j];
                        index = j;
                    }
                }
                a[index] = a[i];
                a[i] = max;
            }
        }

        public int AmountOfElementsArray
        {
            get
            {
                return doubleArray.Length;
            }
        }

        public int ScalarArray
        {
            
            set
            {
                for (int i = 0; i < doubleArray.GetLength(0); i++)
                {
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                    {
                        doubleArray[i, j] = doubleArray[i, j] * value;
                    }
                }
            }
        }

        public double this[int line, int column]
        {
            get
            {
                if (line >= doubleArray.GetLength(0) || column >= doubleArray.GetLength(1))
                {
                    Console.WriteLine("Неправильные индексы!");
                }
                return doubleArray[line,column];
            }
            set
            {
                doubleArray[line, column] = value;
            }
        }

        private double LengthLine
        {
            get
            {
                return doubleArray.GetLength(0);
            }
        }

        private double LengthColumn
        {
            get
            {
                return doubleArray.GetLength(1);
            }
        }

        public static DoubleArray operator ++(DoubleArray array)
        {
            for (int i = 0; i < array.LengthLine; i++)
            {
                for (int j = 0; j < array.LengthColumn; j++)
                {
                    array[i, j] = array[i, j] + 1;
                }
            }
            return array;
        }

        public static DoubleArray operator --(DoubleArray array)
        {
            for (int i = 0; i < array.LengthLine; i++)
            {
                for (int j = 0; j < array.LengthColumn; j++)
                {
                    array[i, j] = array[i, j] - 1;
                }
            }
            return array;
        }

        //Метод проверят является ли следующий эл-нт массива больше предыдущего
        private static bool TestIncrement(double [] mas)
        {
            bool result=false;
            for (int i = 0; i < mas.Length - 1; i++) 
            {
                if (mas[i + 1] > mas[i])  
                {
                    result = true;
                }
            }
            if (result)
            {
                return true;
            }
            return false;
        }

        public static bool operator true(DoubleArray array)
        {
            double[] mas = new double[(int)array.LengthLine];
            bool result = false;
            for (int i = 0; i < array.LengthLine; i++)
            {
                for (int j = 0; j < array.LengthColumn; j++)
                {
                    mas[j] = array[i, j];
                }
                result = TestIncrement(mas);
                if (!result)
                {
                    return false;
                }
            }
            
            return true;
            
        }

        //Спросить насчёт этого оператора
        public static bool operator false(DoubleArray array)
        {
            return false;
        }

        //неявное преобразование типа double[,] в DoubleArray
        public static implicit operator DoubleArray(double[,] a)
        {
            return new DoubleArray(a.GetLength(0), a.GetLength(1));
        }

        //неявное преобразование типа DoubleArray в double [,]
        public static implicit operator double[,] (DoubleArray a)
        {
            double[,] temp = new double[(int)a.LengthLine, (int)a.LengthColumn];
            for (int i = 0; i < a.LengthLine; i++)
            {
                for (int j = 0; j < a.LengthColumn; j++)
                {
                    temp[i, j] = a[i, j];
                }
            }
            return temp;
        }
    }
}
