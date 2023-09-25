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

            /*Stack z = new Stack(3);
            Console.WriteLine(z.IsEmpty());
            z.Push('a');
            z.Push('b');
            z.Push('c');
            z.Push('d');
            z.Pop();
            Console.WriteLine(z.Peek());
            Console.WriteLine(z.IsEmpty());
            z.PrintStack();*/
            
            // úloha 5

            Console.WriteLine(BracketValidator("[{((]]"));
        }
        
        public  static int BracketValidator(string text)
        {
            Stack s = new Stack(text.Length/2);
            string brackets = "()[]{}";

            for (int i = 0; i < text.Length; i++)
            {
                int index = brackets.IndexOf(text[i]);
                if (index%2 == 0)
                {
                    try
                    {
                        s.Push(text[i]);
                    }
                    catch(InvalidOperationException)
                    {
                        return i;
                    }
                }
                else if (index%2==1)
                {
                    char popped = s.Pop();

                    if (popped != brackets[index-1])
                    {
                        return i;
                    }
                }
            }

            if (!s.IsEmpty())
            {
                return text.Length;
            }

            return -1;
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
        public char Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Zásobník je prázdný");
            }
            else
            {
                char a = array[index];
                index--;
                return a;
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
            if (index==-1)
            {
                return true;
            }
            else
            {
                return false;
            }
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
