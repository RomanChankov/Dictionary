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
   class BasicClass
    {
        protected int _age;
        public void Meth()
        {
            WriteLine(" BasicClass");
        }
    }
    class GenericClass<T>:BasicClass
    {
        public void M1(T obj)
        {
            _age = 57;
            WriteLine($"Basic: {_age}\tGeneric: {obj}");
        }
    }
  
    internal class Program
    {

        static void Main(string[] args)
        {
            BasicClass bas=new BasicClass();
            bas.Meth();
           
            GenericClass<int> Gen= new GenericClass<int>();
            Gen.Meth();
            Gen.M1(100);
        }
    }
}

