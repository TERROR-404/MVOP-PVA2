using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            string[] input = File.ReadAllLines("rahul.txt");
            for (int i = 0; i < input.Length; i++)
            {
                string[] a = input[i].Split(" ");
                foreach (var item in a)
                {
                    if (d.ContainsKey(item))
                    {
                        d[item]++;
                    }
                    else
                    {
                        d.Add(item,1);
                    }

                }
            }
            double totalValue = 0;
            foreach (var item in d)
            {
                totalValue += item.Value;
            }

            foreach (var item in d)
            {
                Console.WriteLine($"{item.Key}, {item.Value}, {item.Value/totalValue}%");
            }
        }
    }
}
