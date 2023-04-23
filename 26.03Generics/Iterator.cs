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
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"Фамилия: {LastName}, Имя: {FirstName}, Родился: { BirthDate.ToLongDateString()} ";
        }
    }
    class Auditory //:IEnumerable
    {
        List<Student> _auditory = new List<Student>
        {
            new Student
            {
                FirstName ="John",
                LastName ="Miller",
                BirthDate =new DateTime(1997,3,12)
            },
            new Student
            {
                FirstName ="Candice",
                LastName ="Leman",
                BirthDate =new DateTime(1998,7,22)
            },
            new Student
            {
                FirstName ="Joey",
                LastName ="Finch",
                BirthDate =new DateTime(1996,11,30)
            },
            new Student
            {
                FirstName ="Nicole",
                LastName ="Taylor",
                BirthDate =new DateTime(1996,5,10)
            }
        };
        //Для вывода студентов через foreach  в необобщенных классах нужно было реализовывать интерфейс IEnumerable
        //нтерфейс IEnumerable позволяет, при помощи перечислителя, осуществить перебор всех элементов не обобщенной коллекции.
        // И в классе необходимо было реализовывать метод GetEnumerator(), который возвращает интерфейс IEnumerator.

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return _auditory.GetEnumerator();
        //}

        // Но в обобщенной коллекции можем создать метод-итератор который определяет каким образом будут передаваться элементы в конструкцию foreach
        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = 0; i < _auditory.Count ; i++)
            {
                yield return _auditory[i]; 
            }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
          Auditory auditory = new Auditory();
            WriteLine("+++++ список студентов +++++\n");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
        }
    }
}
