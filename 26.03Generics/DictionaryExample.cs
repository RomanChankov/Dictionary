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
            Dictionary<string, int> groups = new Dictionary<string, int>();

            // добавление значений в список

            groups["GR1"] = 12;
            groups["GR1"] = 22;// Ошибки не будет На такой же ключ записывается новое значение.
            groups["GR2"] = 32;
            groups["GR3"] = 45;
            groups["GR4"] = 10;
            groups["GR5"] = 15;
            groups.Add("eee", 100);

            WriteLine("Содержимое словаря: ");
            foreach (var i in groups)
            {
                Console.WriteLine(i);
            }
            WriteLine();
            // изменение значения
            groups["GR1"] = 14;
            // WriteLine(groups.ContainsValue(45));
            WriteLine("Еще один способ вывода словаря:");
            foreach (KeyValuePair<string, int> i in groups)
            {
                //Console.WriteLine(i);
                Console.WriteLine($"Ключ: {i.Key}\tЗначение: {i.Value}");
            }
            try
            {
                groups.Add("GR4", 50);
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
            foreach (KeyValuePair<string, int> i in groups)
            {
                //Console.WriteLine(i);
                Console.WriteLine($"Ключ: {i.Key}\tЗначение: {i.Value}");
            }
            WriteLine();
            // попытка обращения к несуществующему ключу
            try
            {
                WriteLine(groups["GR7"]);
            }
            catch (KeyNotFoundException e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            // проверка существования ключа и получение 
            // значения
            int key;
            if (groups.TryGetValue("GR7", out key))
            {
                WriteLine(key);
            }
            else
            {
                WriteLine("Ключ не существует");
            }
            //Способ инициализации=>
            Dictionary<string, int> gr = new Dictionary<string, int>
            {
                ["GR1"] = 199,  //Можно заполнить значениями сразу
                ["GR1"] = 299,
                ["GR2"] = 399,
                ["GR3"] = 499,
                ["GR4"] = 199,
                ["GR5"] = 199
            };
            foreach (var i in gr)
            {
                Console.WriteLine(i);
            }



        }
    }
}
