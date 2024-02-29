using System;
using System.IO;
namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string file = "30x10.csv";
            string[] lines = File.ReadAllLines(file);
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] c = lines[i].Split(',');
                for (int j = 0; j < c.Length; j++)
                {
                    int num;
                    bool ex = int.TryParse(c[j], out num);
                    if (ex)
                    {
                        sum += num;
                    }
                    else
                    {
                        sum += 0;
                    }
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(Sum(1,1,3,2));
            
            // method

        }
        public static int Sum(int y1,int x1,int y2,int x2)
        {
            if (y1>y2&&x1>x2)
            {
                int y = y1;
                int x = x1;
                y1 = y2;
                x1 = x2;
                y2 = y;
                x2 = x;
            }
            string file = "30x10.csv";
            string[] lines = File.ReadAllLines(file);
            int sum = 0;
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i<y1)
                    {
                        continue;
                    }
                    else if (i>y2)
                    {
                        break;
                    }
                    string[] c = lines[i].Split(',');
                    for (int j = 0; j < c.Length; j++)
                    {
                        if (j<x1)
                        {
                            continue;
                        }
                        else if (j>x2)
                        {
                            break;
                        }
                        int num;
                        bool ex = int.TryParse(c[j], out num);
                        if (ex)
                        {
                            sum += num;
                        }
                        else
                        {
                            sum += 0;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return sum;
        }
    }
}
