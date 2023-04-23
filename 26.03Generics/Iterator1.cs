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
    class NamedIterator
    {
        const int LIM = 30;
        int _limit;
        public NamedIterator(int limit)
        {
            _limit = limit;
        }
        public IEnumerator<int>GetEnumerator()
        {
            for (int i = 0; i < _limit; i++)
            {
                if (i == _limit)
                {
                    yield break; //Прерывание итератора по условию
                }
            yield return i;
            }
        }
        public IEnumerable<int>GetRange(int start)
        {
            for (int i= start = 0; start <=_limit; i++)
            {
                if (i == LIM)
                {
                    yield break;
                }
                yield return i;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите начальное значение: ");
            int start = int.Parse(ReadLine());

            Write("\nВведите конечное значение: ");
            int end = int.Parse(ReadLine());

            NamedIterator iterator = new NamedIterator(end);
            Write("\nВсе значения: ");
            foreach (int item in iterator)
            {
                Write($"{item} ");
            }
            Write("\n\nЗначения в заданном диапазоне: ");
            foreach (int item in iterator.GetRange(start))
            {
                Write($"{item} ");
            }

        }
    }
}
