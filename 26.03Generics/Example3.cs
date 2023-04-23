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
           ArrayList arrayList = new ArrayList();
            // при записи элемента в коллекцию тип int 
            // приводится в object - УПАКОВКА
            arrayList.Add(10);
            arrayList.Add(12);
            // при извлечении выполняем приведение типа - 
            // РАСПАКОВКА
            int a = (int)arrayList[0];
            // вывод значения - int приводится к string -  УПАКОВКА
            WriteLine($"Первый элемент коллекции: {a}");
            WriteLine("\nВсе элементы коллекции:");
            foreach(int i in arrayList)
                Console.WriteLine(i);// Упаковка
            WriteLine();
            WriteLine();
            List <int> list = new List<int> { 3,5,7};
            list.Add(1);
           // list.Add(2.3);// Нельзя привести из double в int
            foreach(int i in list)
                Console.WriteLine(i);
        }
    }
}
