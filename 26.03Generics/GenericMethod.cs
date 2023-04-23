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
        static T MaxElem<T>(T[]arr)where T:IComparable
        {
            T max = arr[0];
            foreach(T i in arr)
            {
                if (i.CompareTo(max) > 0)
                    max = i;
            }
            return max;
        }

        static void Main(string[] args)
        {
            int[] arrInt = { 19, 2, 37, 4, 5, 6, 17, 8 };
            // реальный тип для параметра типа 
            // указывается явно
            WriteLine($"Максимальный элемент: {MaxElem<int>(arrInt)}");

            double[] arrDouble = { 3.4, 76.656, 33.77, 5.55, 8.6 };
            // реальный тип определяется 
            // по типу переданного массива
            WriteLine($"Максимальный элемент: {MaxElem(arrDouble)}");

          
        }
    }
}
