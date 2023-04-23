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
            arrayList.Add(1);
            try
            {
                short a =(short) arrayList[0];
            }
            catch (InvalidCastException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
