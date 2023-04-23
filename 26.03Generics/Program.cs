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
    /// <summary>
    /// Вспомогательный класс для профилирования участка кода
    /// выполняет измерения времени выполнения
    /// и подсчет количества сборок мусора
    /// </summary>
    internal sealed class OperationTimer:IDisposable
    {
        long _startTime;
        string _text;
        int _collectionCount;

        public OperationTimer( string text)
        {
            PrepareForOperation();
            // сохраняется начальное время
            _startTime = Stopwatch.GetTimestamp();
            _text = text;
            // сохраняется количество сборок мусора, 
            // выполненных на текущий момент
            _collectionCount = GC.CollectionCount(0);
        }
        /// создания объекта до момента его удаления
        /// количество выполненных сборок мусора, 
        /// выполненных за это время
        /// </summary>
        public void Dispose()
        {
            WriteLine($"{_text}\t{(Stopwatch.GetTimestamp()-_startTime)/(double)Stopwatch.Frequency:0.00} секунды (сборок мусора{GC.CollectionCount(0) - _collectionCount})");
        }
        /// <summary>
        /// Метод удаляются все неиспользуемые объекты
        /// Это надо для "чистоты эксперимента",
        /// т.е. чтобы сборка мусора происходила только
        /// для объектов, которые будут создаваться 
        /// в профилируемом блоке кода
        ///</summary>
        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

        }
    }
    internal class Program
    {
        /// <summary>
        /// метод для тестирования производительности 
        /// обобщенного и необобщенного списка
        /// </summary>
        private static  void ValueTypesPerfTest()
        {
            const int COUNT = 100000000;
            // объект OperationTimer создается
            // перед началом использования коллекции
            // после завершения ее использования 
            // выводит время, затраченное на работу 
            // с коллекцией 
            using (new OperationTimer("List"))
            {
                //использование обобщенного списка
                List<int> list = new List<int>(COUNT);
                for (int i = 0; i < COUNT; i++)
                {
                    list.Add(i);
                    int x = list[i];
                }
                list = null;  // для гарантированного 
                              // выполнения сборки мусора
            }
            using (new OperationTimer("arrayList"))
            {
                // использование необобщенного списка
                ArrayList array = new ArrayList(COUNT);
                for (int i = 0; i < COUNT; i++)
                {
                    array.Add(i);  // выполняется упаковка
                    int x = (int)array[i]; // выполняется распаковка
                }
                    array = null;  // для гарантированного 
                                   // выполнения сборки мусора
            }
        }
        static void Main(string[] args)
        {
           ValueTypesPerfTest();
        }
    }
}
