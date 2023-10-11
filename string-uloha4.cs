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
        		Dictionary<string,List<int>> d = new Dictionary<string,List<int>>();
        		string[] t = text.Split('\n',' ');
        		foreach(var i in t)
        		{
        			if(d.ContainsKey(i))
        			{
        				int a = text.IndexOf(i,d[i][d[i].Count-1]+1 , text.Length-(d[i][d[i].Count-1])-1);
        				d[i].Add(a);
        			}
        			else
        			{
        				List<int> l = new List<int>();
        				int a = text.IndexOf(i);
        				l.Add(a);
        				d.Add(i,l);
        			}
        		}
          using(StreamWriter sw = new StreamWriter(file))
          {
            foreach(var i in d)
        		{
        			sw.Write(i.Key);
        			foreach(var j in i.Value)
        			{
        				sw.Write(" {0},",j);
        			}
        			sw.WriteLine();
        		}
          }
        }
    }
}
