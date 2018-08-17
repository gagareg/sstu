using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//На основе данных входного файла составить инвентарную ведомость игрушек, включив
//следующие данные: название игрушки, ее стоимость(в руб.), а также возрастные границы
//детей, для которых предназначена игрушка.Вывести в новый файл информацию о тех
//игрушках, которые предназначены для детей от N до M лет, отсортировав записи по
//стоимости
namespace Задание_2
{
    struct Toy:IComparable
    {
        private string name;
        public int Price { get; }
        public int Up { get; }
        public int Down { get; }

       
       
        public Toy(string name, int price, int down, int up)
        {
            this.name = name;
            Price = price;
            Up = up;
            Down = down;
        }
        public int CompareTo(object o)
        {
            if (Price > ((Toy)o).Price)
                return 1;
            if (Price < ((Toy)o).Price)
                return -1;
            return 0;
        }
        public void Show()
        {
            Console.WriteLine("Имя:{0} Цена:{1} от {2} до {3} лет/годов", name, Price, Down, Up);
        }
        public override string ToString()
        {
            return string.Format("Имя:{0} Цена:{1} от {2} до {3} лет/годов", name, Price, Down, Up);
        }
    }

    class Program
    {
        static public Toy[] Input()
        {
            string[] allLines = File.ReadAllLines("input.txt");
            Toy[] array = new Toy[allLines.Length];
            for (int index = 0; index < allLines.Length; index++)
            {
                string line = allLines[index];
                string[] fields = line.Split(';');
                Toy student = new Toy(fields[0], Convert.ToInt32(fields[1]), Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]));
                array[index] = student;
            }
            return array;
        }
        static void ToFile(string fileName, List<Toy> toyList) 
        {
            using (StreamWriter sr = new StreamWriter(fileName))
            {
                foreach (var item in toyList)
                {
                    sr.WriteLine(item);
                }    
            }
        }
        static void Sort(Toy[] a) //Сортировка пузырьком
        {
            Toy temp;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = a.Length - 1; j > i; j--)
                {
                    if (a[j].Price < a[j - 1].Price) 
                    {
                        temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                    }
                }
            }
        }

        static void Main()
        {
            Toy[] array = Input();
            Console.WriteLine("от ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("до ");
            int m = int.Parse(Console.ReadLine());
            //Sort(array);
            Array.Sort(array);
            List<Toy> linesToSave = new List<Toy>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Down >= n && array[i].Up <= m)
                {
                    linesToSave.Add(array[i]);
                }
            }
            ToFile("output.txt", linesToSave);
            Console.ReadKey();
        }
    }
}


