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
            WriteLine("Коллекция целых чисел");
            List<int> listInt = new List<int>();
            Random rand = new Random();
          
            for (int i = 0; i < 10; i++)
            {
                listInt.Add(rand.Next(100));
                Write($"{listInt[i]} ");
            }
            WriteLine();
            WriteLine("Коллекция строк: ");
            List<string> listString = new List<string>();
            listString.Add("Hello");
            listString.Add("wpu221");
            listString.Add("developers!");
            foreach (string str in listString)
            {
                Console.WriteLine(str);
            }
        }
    }
}
