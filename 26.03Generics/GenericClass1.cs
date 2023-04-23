using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;




namespace _26._03Generics
{
    // Список ограничений параметра типа

    //1:   where T: struct---
    //Параметр типа должен наследоваться от System.ValueType, т.е. быть структурным типом

    //2:   Where T: class---
    //Параметр типа не должен наследоваться от System.ValueType, т.е. быть ссылочным типом

    //3:   where T: new()--- Класс должен иметь конструктор по 
    //умолчанию (указывается последним)

    //4:   where T: BaseClass---
    //Параметр типа должен быть производным классом от указанного базового класса
    //Вместо BaseClass- указывается имя класса!

    //5:   where T: Interface ---Параметр типа должен реализовать указанный интерфейс
    //Вместо Interface- указывается конкретный интерфейс!
    //Пример
    class GenericClass1<T> where T : class, IComparable, new() { } //Тип должен ссылочным, реализовать интерфейс IComparable, иметь конструктор по умолчанию
    
    //Generic-класс с ограничением параметра типа на использование только значимых типов
    public class Point2D<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }
        // параметр типа используется для задания типа свойства
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public Point2D()
        {
            //X=default(T);
            //Y=default(T);
            X = x;
            Y = y;
        }

    }
    internal class Program
    {
        //public class Point2D<T> //Таким образом показываем ,что класс будет обобщенным, т.е Generic ом.
        //{
        //    public T X { get; set; }
        //    public T Y { get; set; }

        //    public Point2D(T x, T y)
        //    {
        //        X = x;
        //        Y = y;
        //    }
        //    //И конструктор по умолчанию, Какие значения записывать мы не знаем,поэтому записываем default.
        //    public Point2D()
        //    {
        //        X = default(T);
        //        Y = default(T);
        //    }
        //}
        //***********************************************
        //Пример наследования от обобщенного класса
        class GenericClass<T>
        {
            public void M1(T obj)
            {
                WriteLine($"Параметр: {obj}");
            }
            public virtual void M2(T data)
            {
                WriteLine($"Generic: {data}");
            }

        }
        // При наследовании обычного класса от Generic а, наследник обязан явно указать тип данных класса-родителя
        class InheritClass : GenericClass<int>
        {
            public override void M2(int data)
            {
                WriteLine($"Inherit: {data}");
            }
        }
        //***********************************************
        //Пример наследования Generica от обычного класса
        //class BasicClass
        //{
        //    protected int age=86;
        //}
        //class GenericClassic<T>:BasicClass
        //{
        //    public void M1(T obj)
        //    {
        //        WriteLine($"Basic: {age}\tGeneric: {obj}");
        //    }
        //}
        static void Main(string[] args)
        {
            // При создании объекта generic-класса необходимо явно указать тип данных вместо параметра. При этом также создается класс с явным типом данных, который называется сконструированным
            Point2D<int> d = new Point2D<int>();
            WriteLine($"x={d.X}\ty={d.Y}");
            //Имя сконструированного класса состоит из : 1-пространства имен,2-имя generic -класса,3-количество параметров типа, 4(тип данных) сконструированного класса
            WriteLine(typeof(Point2D<int>));

            //Point2D<string> str = new Point2D<string>("Vulf", "Neo");
            //WriteLine($"x={str.X}\ty={str.Y}");
            //WriteLine(typeof(Point2D<string>));

            Point2D<double> p3 = new Point2D<double>(20.3, 9.7);
            WriteLine($"x={p3.X}\ty={p3.Y}");
            WriteLine(typeof(Point2D<double>));
            WriteLine();

            //InheritClass obj = new InheritClass();
            //obj.M1(45);
            //obj.M2(55);

            //GenericClassic<int> gen= new GenericClassic<int>();
            //gen.M1(50);
        }
    }
}
