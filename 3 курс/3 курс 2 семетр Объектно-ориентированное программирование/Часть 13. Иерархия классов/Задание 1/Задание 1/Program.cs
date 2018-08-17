using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

/*Задание 1
1)        Создать абстрактный класс Figure с методами вычисления площади и периметра, а также методом, выводящим информацию о фигуре на экран.
2)        Создать производные классы: Rectangle (прямоугольник), Circle (круг), Triangle (треугольник) со своими методами вычисления площади и периметра.
3)        Создать массив n фигур и вывести полную информацию о фигурах на экран. */

namespace MyNamespac
{
    public abstract class Figure
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public abstract void show();
        public abstract double square();
        public abstract double perimetr();
    }

    public class Rectangle : Figure
    {
        private double weidth;
        private double height;

        public Rectangle(string name, double height, double weidth)
        {
            Name = name;
            this.weidth = weidth;
            this.height = height;
        }
        private Rectangle() { }
        public override double square()
        {
            return weidth * height;
        }
        public override double perimetr()
        {
            return 2 * (weidth + height);
        }
        public override void show()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Ширина: {0}", weidth);
            Console.WriteLine("Высота: {0}", height);
            Console.WriteLine("Площадь: {0}", square());
            Console.WriteLine("Периметр: {0}", perimetr());

        }
        
    }
    public class Triangle : Figure
    {
        private double basis;
        private double height;

        public Triangle(string name, double height, double basis)
        {
            Name = name;
            this.basis = basis;
            this.height = height;
        }
        private Triangle() { }
        public override double square()
        {
            return 0.5 * (basis * height);
        }
        public override double perimetr()
        {
            return Math.Sqrt(Math.Pow(0.5 * basis, 2) + Math.Pow(height, 2)) * 2 + height;
        }
        public override void show()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Основание: {0}", basis);
            Console.WriteLine("Высота: {0}", height);
            Console.WriteLine("Площадь: {0}", square());
            Console.WriteLine("Периметр: {0}", perimetr());

        }
        
    }
    public class Circle : Figure
    {
        private double r;

        public Circle(string name, double r)
        {
            Name = name;
            this.r = r;
        }
        private Circle() { }
        public override double square()
        {
            return Math.PI * r * r;
        }
        public override double perimetr()
        {
            return 2 * Math.PI * r;
        }
        public override void show()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Радиус: {0}", r);
            Console.WriteLine("Площадь: {0}", square());
            Console.WriteLine("Длина окружности: {0}", perimetr());
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figure = new List<Figure>();
            if (!File.Exists("file.txt"))
            {
                Console.WriteLine("Не найден файл - file.txt");
                Console.ReadLine();
                return;
            }
            string str = null;
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                str = sr.ReadToEnd();
            }
            string[] par = str.Split('\n');
            int i = 0;
            while (i < par.Length)
            {
                switch (par[i][0])
                {
                    case 'r':
                        {
                            figure.Add(new Rectangle(par[i], Convert.ToDouble(par[++i]), Convert.ToDouble(par[++i])));
                            i++;
                            break;
                        }
                    case 'c':
                        {
                            figure.Add(new Circle(par[i], Convert.ToDouble(par[++i])));
                            i++;
                            break;
                        }
                    case 't':
                        {
                            figure.Add(new Triangle(par[i], Convert.ToDouble(par[++i]), Convert.ToDouble(par[++i])));
                            i++;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("defaulte");
                            i++;
                            break;
                        }
                }

            }
            foreach (Figure f in figure)
                f.show();
            Console.ReadKey();
        }
    }
}