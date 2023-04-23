using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//    В данном случае объявлен общедоступный делегат
// по имени IntDelegate, позволяющий хранить ссылки
// на методы, принимающие в качестве параметра вещественное и возвращающие   целочисленное значение
//  public delegate int MaDelegate(double d);

namespace _26._03Generics
{
    public delegate double CalcDelegate(double x, double y);
    public class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public static double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mult(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if (y != 0)
            {
                return x / y;
            }
            throw new DivideByZeroException();

        }

    }
    internal class Program
    {


        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            WriteLine("Введите выражение");
            string expression = ReadLine();
            char sign = ' ';
            foreach (char item in expression)
            {
                if (item == '+' || item == '-' || item == '*' || item == '/')
                {
                    sign = item;
                    break;
                }
            }
            string[] numbers = expression.Split(sign);
            CalcDelegate del = null;
            switch (sign)
            {
                case '+':
                    del = new CalcDelegate(calc.Add);
                    break;
                case '-':
                    del = new CalcDelegate(Calculator.Sub);
                    break;
                case '*':
                    del = calc.Mult;
                    break;
                case '/':
                    del = calc.Div;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            WriteLine($"Result: {del(double.Parse(numbers[0]), double.Parse(numbers[1]))}");
        }
    }
}
