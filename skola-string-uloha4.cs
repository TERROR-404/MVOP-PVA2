using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "rahul.txt";
            string text = File.ReadAllText(file);
            Dictionary<string, List<int>> d = new Dictionary<string, List<int>>();
            string[] t = text.Split(' ', '\n'); // \r odebere problémy s přidáváním \n za slova, když jsou na konci řádku, ale začne to přidávat nějaký mezer od nuly do 26
            foreach (var i in t)
            {
                if (d.ContainsKey(i))
                {
                    int a = text.IndexOf(i, d[i][d[i].Count - 1] + 1, text.Length - (d[i][d[i].Count - 1]) - 1);
                    d[i].Add(a);
                }
                else
                {
                    List<int> l = new List<int>();
                    int a = text.IndexOf(i);
                    l.Add(a);
                    d.Add(i, l);
                }
            }
            string s = "\n\n";
            foreach (var i in d)
            {
                s+= i.Key;
                foreach (var j in i.Value)
                {
                    s +=$" {j},";
                }
                s+="\n";
            }
            File.AppendAllText(file, s);
        }
    }
}
