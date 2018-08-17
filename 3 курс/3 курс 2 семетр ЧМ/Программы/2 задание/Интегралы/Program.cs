using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интегралы
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("n = ");
            double n = Convert.ToDouble(Console.ReadLine());

            double In = Math.Abs(IntegrableFunction(a) - IntegrableFunction(b)); //Значение интеграла
            Console.WriteLine("Значение интеграла = {0}", In);
            Console.WriteLine();
            double e = 0.0001;// точность до которой надо считать 
            double n1 = n; //  переопределяем количество отрезков, чтобы не обнулять переменную каждый раз перед расчётом погрешности другого метода

            double R=0, R1, S1, S2, k = 0; 
            do
            {
                S1 = FindLeft(a, b, n1); // интеграл с обычным шагом 
                n1 = 2 * n1; // увеличение шага в 2 раза 
                S2 = FindLeft(a, b, n1); // интеграл с двойным шагом 
                R = Math.Abs((S1 - S2) / S1);
                k++; // счётчик
            } while (R > e);
            Console.WriteLine("Левых прямоугольников = {0}: k = {1}, n = {2}", S2, k,n1);
            R1 = Math.Abs((In - S2) / S2);
            Console.WriteLine("Погрешность = {0}", R1);
            Console.WriteLine();

            n1 = n;k = 0; // Обнулям эти переменные, чтобы подсчитать другие погрешность в других методах.
            do
            {
                S1 = FindMiddle(a, b, n1);
                n1 = 2 * n1;
                S2 = FindMiddle(a, b, n1);
                R = Math.Abs((S1 - S2) / S1);
                k++;
            } while (R > e);
            Console.WriteLine("Средних прямоугольников = {0}: k = {1}, n = {2}", S2, k, n1);
            R1 = Math.Abs((In - S2) / S2);
            Console.WriteLine("Погрешность = {0}", R1);
            Console.WriteLine();

            n1 = n; k = 0;
            do
            {
                S1 = FindRight(a, b, n1);
                n1 = 2 * n1;
                S2 = FindRight(a, b, n1);
                R = Math.Abs((S1 - S2) / S1);
                k++;
            } while (R > e);
            Console.WriteLine("Правых прямоугольников = {0}: k = {1}, n = {2}", S2, k, n1);
            R1 = Math.Abs((In - S2) / S2);
            Console.WriteLine("Погрешность = {0}", R1);
            Console.WriteLine();

            n1 = n; k = 0;
            do
            {
                S1 = FindTrapeze(a, b, n1);
                n1 = 2 * n1;
                S2 = FindTrapeze(a, b, n1);
                R = Math.Abs((S1 - S2) / S1);
                k++;
            } while (R > e);
            Console.WriteLine("Трапеций = {0}: k = {1}, n = {2}", S2, k, n1);
            R1 = Math.Abs((In - S2) / S2);
            Console.WriteLine("Погрешность = {0}", R1);
            Console.WriteLine();

            n1 = n; k = 0;
            do
            {
                S1 = Find2nStepsSimpsons(a, b, n1);
                n1 = 2 * n1;
                S2 = Find2nStepsSimpsons(a, b, n1);
                R = Math.Abs((S1 - S2) / S1);
                k++;
            } while (R > e);
            Console.WriteLine("Симпсона = {0}: k = {1}, n = {2}", S2, k, n1);
            R1 = Math.Abs((In - S2) / S2);
            Console.WriteLine("Погрешность = {0}", R1);
            Console.WriteLine();


            Console.ReadKey();
        }
        public static double IntegrableFunction(double x) //Проинтегрированная функция
        {
            //return (x * x * x) / 3;
            return x + (x * x * x) / 6 + (x * x * x * x) / 32;
        }
        public static double F(double x) // Функция из задания с 3-мя многочленнами
        {
            //return x * x;
            return 1 + (x * x) / 2 + (x * x * x) / 8;
        }
        public static double FindLeft(double a, double b,double n)
        {
            double h = (b - a) / n; // длина между узлами сетки
            double S = 0; // Сумма
            double x0 = a; // Левая часть прямоугольника
            for (int i = 0; i < n - 1; i++) // Равномерая сетка
            {
                 //Составная формула для левых прямоугольников https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_%D0%BF%D1%80%D1%8F%D0%BC%D0%BE%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA%D0%BE%D0%B2
                S = S + F(x0) * h;
                x0 = x0 + h; // Следующая точка(узел)
            }
            return S;
        }
        public static double FindRight(double a, double b, double n)
        {
            double h = (b - a) / n; // длина между узлами сетки
            double S = 0; // Сумма
            double x0 = a + h; // Правая часть прямоугольника
            for (int i = 1; i <= n; i++) // Равномерая сетка
            {
                //Составная формула для правых прямоугольников https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_%D0%BF%D1%80%D1%8F%D0%BC%D0%BE%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA%D0%BE%D0%B2
                S = S + F(x0) * h;
                x0 = x0 + h; // Следующая точка(узел)
            }
            return S;
        }
        public static double FindMiddle(double a, double b, double n)
        {
            double h = (b - a) / n; // длина между узлами сетки
            double S = 0; // Сумма
            double x0 = a + h/2; // Середина прямоугольника
            for (int i = 1; i <= n; i++) // Равномерая сетка
            {
                //Составная формула для средних прямоугольников https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_%D0%BF%D1%80%D1%8F%D0%BC%D0%BE%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA%D0%BE%D0%B2
                S = S + F(x0) * h;
                x0 = x0 + h; // Следующая точка(узел)
            }
            return S;
        }
        public static double Find2nStepsSimpsons(double a, double b, double n) // Состовная формула
        {
            double h = (b - a) / (2 * n); //длина между узлами сетки
            double x0 = a + h; //Точка с обычным шагом
            double x02 = a + 2 * h; // Точка с двойным шагом
            double S = 0; // Копилка для общей суммы
            double formula = 0; // https://ru.wikipedia.org/wiki/%D0%A4%D0%BE%D1%80%D0%BC%D1%83%D0%BB%D0%B0_%D0%A1%D0%B8%D0%BC%D0%BF%D1%81%D0%BE%D0%BD%D0%B0
            for (int i = 0; i <= n - 1; i++) // Равномерая сетка
            {
                S = (S + (2 * F(x02) + 4 * F(x0)));
                formula = (h / 3) * (F(a) + S - F(b));
                x0 = x0 + 2 * h; // След. точки
                x02 = x02 + 2 * h; // След. точки
            }
            return formula;
        }
        public static double FindTrapeze(double a, double b, double n)
        {
            double h = (b - a) / n; // длина между узлами сетки
            double S = 0; // Сумма
            double x0 = a; // Начальная точка
            double x1 = a + h; // След. точка
            for (int i = 1; i <= n; i++) // Равномерая сетка
            {
                S = S + (F(x1) + F(x0)) * (h / 2);
                x0 = x0 + h;
                x1 = x1 + h;
            }
            return S;
        }
    }
}

