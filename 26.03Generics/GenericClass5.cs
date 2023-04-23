using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// . Ограничения параметров типов
namespace _26._03Generics
{
    /// <summary>
    /// Обобщенный класс точки
    /// </summary>
    /// <typeparam name="T">
    /// координаты точки могут быть любого типа
    /// </typeparam>

    public class Point2D<T> where T: struct // Ограничение
    {
        // параметр типа используется для задания типа свойства
        public T X { get; set; }
        public T Y { get; set; }
        //параметр типа используется для задания типов
        //параметров метода
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public Point2D()
        {
            X = default(T);
            Y = default(T);
        }

    }

    internal class Program
    {

        static void Main(string[] args)
        {
            // тестирование обобщенного класса - 
            // точки в 2D
            Point2D<int> p1 = new Point2D<int>();
            WriteLine($"Точка Х: {p1.X}\tТочка Y: {p1.Y}");
            WriteLine(typeof(Point2D<int>));
            Console.WriteLine();
            Point2D<double> p2 = new Point2D<double> { X = 4.4, Y = 6.6 };
            WriteLine($"Точка Х: {p2.X}\tТочка Y: {p2.Y}");
            WriteLine(typeof(Point2D<double>));
            Console.WriteLine();
            // Ссылочный тип уже не можем указать, возникает ошибка на этапе компиляции
            Point2D<string> p3 = new Point2D<string>("Vulf", "Neo");
            WriteLine($"Точка Х: {p3.X}\tТочка Y: {p3.Y}");
            WriteLine(typeof(Point2D<double>));
            Console.WriteLine();
        }
    }
}
