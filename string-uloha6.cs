using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "30x10.csv";
            int x = 0;
            int y = 0;
            int numbers = 0;
            string[] fileLines = File.ReadAllLines(fileName);
            foreach (var item in fileLines)
            {
                string[] a = item.Split(',', ' ');
                x = 0;
                foreach (var j in a)
                {
                    try
                    {
                        numbers += int.Parse(j);
                    }
                    catch (Exception)
                    {
                        int[] ex = { x, y };
                        Console.WriteLine($"{ex[0]}, {ex[1]}, {j}");
                        numbers += 0;
                    }
                    x++;
                    if (x == a.Length - 1)
                    {
                        break;
                    }
                }
                y++;
            }
            Console.WriteLine(numbers);
            Table table = new Table();
            Console.WriteLine(table.Sum(1,1,3,2));
        }
    }
    public class Table
    {
        private int x = 0;
        private int y = 0;
        List<int> numbers = new List<int>();

        public int Sum(int y1, int x1, int y2, int x2)
        {
            string fileName = "30x10.csv";
            string[] fileLines = File.ReadAllLines(fileName);
            bool breaking = false;
            y = y1;
            int sum = 0;
            try
            {
                foreach (var item in fileLines)
                {
                    string[] a = item.Split(',', ' ');
                    x = x1;
                    int xIndex = 0;
                    foreach (var j in a)
                    {
                        if (xIndex < x)
                        {
                            xIndex++;
                            continue;
                        }
                        int number = 0;
                        if (breaking)
                        {
                            break;
                        }
                        try
                        {
                            number = int.Parse(j);
                        }
                        catch (Exception)
                        {
                        }
                        Console.WriteLine(number);
                        sum +=number;
                        if (y == y2 && x == x2)
                        {
                            breaking = true;
                            break;
                        }
                        else if (x == x2)
                        {
                            break;
                        }
                        x++;
                        if (x == a.Length - 1)
                        {
                            break;
                        }
                    }
                    y++;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            return sum;
        }
    }
}
