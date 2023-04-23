using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// Пример наследования обычного от обобщенного класса
namespace _26._03Generics
{
    public class GenericClass<T>
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
    class InheritClass : GenericClass<int> //необходимо явно указывать тип
    {
        public override void M2(int data)
        {
            WriteLine($"Inherit: {data}");
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            GenericClass<double> obj1 = new GenericClass<double>();
            obj1.M1(5.6);
            obj1.M2(6.4);
            InheritClass inH = new InheritClass();
            inH.M1(5);
            inH.M2(50);
           
        }
    }
}

 