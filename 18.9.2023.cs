using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // úloha 3

            /*DateTime amerika = new DateTime(1492,10,12);
            DateTime hus = new DateTime(1415,7,6);

            TimeSpan ts = amerika - hus;

            double days =  ts.Days/365.25;

            Console.WriteLine("rozdíl je " + days + " let");
            Console.WriteLine("Amerika: " + amerika.DayOfWeek);
            Console.WriteLine("Hus: " + hus.DayOfWeek);*/

            // úloha 4

            Stack z = new Stack(3);
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
        private char[] array;
        private int index;

        public Stack(int size)
        {
            array = new char[size];
            index = -1;
        }
        public void Push(char c)
        {
            if (index+1 >= array.Length)
            {
                throw new InvalidOperationException("Zásobník je plný");
            }
            else
            {
                index++;
                array[index] = c;
            }
        }
        public void Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Zásobník je prázdný");
            }
            else
            {
                char a = array[index];
                Console.WriteLine(a);
                index--;
            }
        }
        public char Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Zásobník je prázdný");
            }
            else
            {
                return array[index];
            }
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
