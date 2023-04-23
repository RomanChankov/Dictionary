//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Console;

//namespace _26._03Generics
//{
//    class DateComparer :IComparer<Student>
//    {
//        public int Compare(Student x,Student y)
//        {
//            return DateTime.Compare(x.BirthDate, y.BirthDate);
//        }
//    }
//    class Student: IComparable<Student>
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime BirthDate { get; set; }
//        public override string ToString()
//        {
//            return $"Фамилия: {LastName}, Имя: {FirstName}, Родился: {BirthDate.ToLongDateString()}";
//        }
//        public int CompareTo(Student other)
//        {
//            return LastName.CompareTo(other.LastName);
//        }
//    }
//    internal class Program
//    {
       
//        static void Main(string[] args)
//        {
//           List <Student> auditory = new List<Student>
//           { 
//               new Student
//               {
//                   FirstName="John",
//                   LastName="Miller",
//                   BirthDate=new DateTime(1997,3,12) 
//               },
//               new Student
//               {
//                   FirstName="Candice",
//                   LastName="Leman",
//                   BirthDate=new DateTime(1994,3,18)
//               }
//           };
//            WriteLine("******Список студентов*******\n");
//            foreach (Student student in auditory)
//            {
//                WriteLine(student);
//            }
//            auditory.Sort();
//            WriteLine();
//            foreach (Student student in auditory)
//            {
//                WriteLine(student);
//            }
//            auditory.Sort(new DateComparer());
//            WriteLine();
//            foreach (Student student in auditory)
//            {
//                WriteLine(student);
//            }
//        }
//    }
//}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson2603
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Number}\t{Series}";
        }
    }
    class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }

        //public int CompareTo(object obj)
        //{
        //    if (obj is Student)
        //    {
        //        return LastName.CompareTo((obj as Student).LastName);
        //    }
        //    throw new NotImplementedException();
        //}
        public int CompareTo(Student obj)
        {
            return LastName.CompareTo(obj.LastName);
        }

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{BirthDate.ToShortDateString()}\t{StudentCard}";
        }
    }
    class Auditory : IEnumerable
    {
        Student[] students =
        {
            new Student
            {
                FirstName = "John",
                LastName = "Miller",
                BirthDate = new DateTime (1997, 3, 12),
                StudentCard = new StudentCard { Number = 189356, Series = "AB" }
            },
            new Student
            {
                FirstName = "Candice",
                LastName = "Leman",
                BirthDate = new DateTime (1998, 7, 22),
                StudentCard = new StudentCard { Number = 345185, Series = "XA" }
            },
            new Student
            {
                FirstName = "Joey",
                LastName = "Finch",
                BirthDate = new DateTime (1996, 11, 30),
                StudentCard = new StudentCard { Number = 258322, Series = "AA" }
            },
            new Student
            {
                FirstName = "Nicole",
                LastName = "Taylor",
                BirthDate = new DateTime (1996, 5, 10),
                StudentCard = new StudentCard { Number = 513484, Series = "AA" }
            }
        };

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }
    }
    class DateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDate, (y as Student).BirthDate);
            }
            throw new NotImplementedException();
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Auditory auditory = new Auditory();
            WriteLine("---Список студентов:----");
            foreach (Student student in auditory)
                WriteLine(student);
            WriteLine();
            auditory.Sort();
            WriteLine("--Сортировка по фамилии:---");
            foreach (Student student in auditory)
                WriteLine(student);
            WriteLine();
            WriteLine("--Сортировка по дате рождения:---");
            auditory.Sort(new DateComparer());
            foreach (Student student in auditory)
                WriteLine(student);
            WriteLine();
        }

    }
}



