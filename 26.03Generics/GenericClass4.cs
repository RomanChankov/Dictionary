using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// Пример наследования  обобщенного от обычного класса
namespace _26._03Generics
{
    class A<T>
    {
        public class Inner
        {

        }
    }
    class B<T>
    {
        public class Inner<T>
        {

        }
    }

    internal class Program
    {
       
        static void Main(string[] args)
        {
           A<int>.Inner a = new A<int>.Inner();
            WriteLine(a);
            B<int>.Inner<string> inner = new B<int>.Inner<string>();
            WriteLine(inner);
        }
    }
}

