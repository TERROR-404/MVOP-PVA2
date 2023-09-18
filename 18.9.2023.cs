using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DateTime amerika = new DateTime(1492,10,12);
            DateTime hus = new DateTime(1415,7,6);

            TimeSpan ts = amerika - hus;

            double days =  ts.Days/365.25;

            Console.WriteLine("rozdíl je " + days + " let");
            Console.WriteLine("Amerika: " + amerika.DayOfWeek);
            Console.WriteLine("Hus: " + hus.DayOfWeek);*/

            Stack z = new Stack(10);
            Console.WriteLine(z.IsEmpty());
            z.Push('a');
            z.Push('b');
            z.Push('c');
            z.Push('d');
            z.Pop();
            Console.WriteLine(z.Peek());
            Console.WriteLine(z.IsEmpty());
            z.PrintStack();
        }
    }
    class Stack
    {
        public char[] array;
        public int index;

        public Stack(int size)
        {
            array = new char[size];
            index = 0;
        }
        public void Push(char c)
        {
            index++;
            array[index] = c;
        }
        public void Pop()
        {
            char a = array[index];
            Console.WriteLine(a);
            index--;
        }
        public char Peek()
        {
            return array[index];
        }
        public bool IsEmpty()
        {
            bool b = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    b =  false;
                    break;
                }
            }
            return b;
        }
        public void PrintStack()
        {
            for (int i = 0; i < index+1; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
