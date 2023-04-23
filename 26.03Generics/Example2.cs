using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _26._03Generics
{


    internal class Program
    {

        static void Main(string[] args)
        {
            object obj = 45;  //Упаковка
            WriteLine($"Упаковка: {obj}");

            int number=(int)obj;// Распаковка
            WriteLine($"Распаковка: {number}");
        }
    }
}
