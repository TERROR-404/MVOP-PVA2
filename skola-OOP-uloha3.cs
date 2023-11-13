using System;
namespace ConsoleApp1
{
    public enum OS {Linux, Windows, MacOS, IOS, Android}
    class Program
    {
        static void Main(string[] args)
        {
            Notebook n1 = new Notebook("Intel", 16, OS.Linux, 4000);
            Notebook n2 = new Notebook("M1", 32, OS.MacOS, 6000);
            Tablet t1 = new Tablet("AMD", 8, OS.Linux, 2000, false);
            Tablet t2 = new Tablet("Intel", 8, OS.IOS, 10000, true);
            Computer[] computers = new Computer[4] { n1,n2,t1,t2};
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine((OS)i+":");
                foreach (var item in computers)
                {
                    if (item.Os == (OS)i)
                    {
                        Console.WriteLine(item);
                    }
                }
                Console.WriteLine();
            }
        }
    }
    public class Computer
    {
        public string Processor{get ;set ;}
        public int RAM { get; set; }
        public OS Os { get; set; }
        public Computer(string processor, int ram, OS os)
        {
            this.Processor = processor;
            this.RAM = ram;
            this.Os = os;
        }
        public override string ToString()
        {
            return string.Format("{0} má procesor {1}, {2}GB RAM, operační systém {3}",
            this.GetType().Name,Processor,RAM,Os);
        }
    }
    public class Notebook : Computer
    {
        public int BatteryCapacity { get; set; }
        public Notebook(string processor, int ram, OS os,
         int batteryCapacity) : base(processor,ram,os)
        {
            this.BatteryCapacity = batteryCapacity;
        }
        public override string ToString()
        {
            return string.Format(base.ToString() +
             " a kapacitu baterie {0} Wh.",
             BatteryCapacity);
        }
    }    public class Tablet : Computer
    {
        public int BatteryCapacity { get; set; }
        public bool Stylus { get; set; }
        public Tablet(string processor, int ram, OS os,
         int batteryCapacity, bool stylus) : base(processor, ram, os)
        {
            this.BatteryCapacity = batteryCapacity;
            this.Stylus = stylus;
        }
        public override string ToString()
        {
            string s = Stylus ? "používá" : "nepoužívá";
            return string.Format(base.ToString() +
             ", kapacitu baterie {0} Wh a Stylus {1}.",
             BatteryCapacity,s);
        }
    }

}
