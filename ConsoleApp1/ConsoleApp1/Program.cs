using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public abstract class Teleso
    {
        public abstract double Povrch();
        public abstract double Objem();
        public double PomerPovrchKObjemu()
        {
            return Povrch()/Objem();
        }
    }
    public abstract class Valec : Teleso 
    {
        private double polomer;
        public double Polomer
        {
            get { return polomer; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    polomer = value;
                }
            } 
        }
        private double vyska;
        public double Vyska
        {
            get { return polomer; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    vyska = value;
                }
            }
        }
        public override double Povrch()
        {
            return 2*Math.PI*Polomer*(Polomer+Vyska);
        }
        public override double Objem()
        {
            return Math.PI * Math.Pow(Polomer, 2) * Vyska;
        }
    }
    public abstract class Koule : Teleso
    {
        private double polomer;
        public double Polomer
        {
            get { return polomer; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    polomer = value;
                }
            }
        }
        public override double Povrch()
        {
            return 4 * Math.PI * Math.Pow(Polomer,2);
        }
        public override double Objem()
        {
            return (4 / 3) * Math.PI * Math.Pow(Polomer, 3);
        }
    }
    public abstract class Krychle : Teleso
    {
        private double strana;
        public double Strana
        {
            get { return strana; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    strana = value;
                }
            }
        }
        public override double Povrch()
        {
            return 6 * Math.Pow(Strana, 2);
        }
        public override double Objem()
        {
            return Math.Pow(Strana, 3);
        }
    }
    public abstract class Kuzel : Teleso
    {
        private double polomer;
        public double Polomer
        {
            get { return polomer; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    polomer = value;
                }
            }
        }
        private double vyska;
        public double Vyska
        {
            get { return polomer; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    vyska = value;
                }
            }
        }
        public override double Povrch()
        {
            return Math.PI * Polomer * (Polomer + Math.Sqrt(Math.Pow(Vyska,2)+Math.Pow(Polomer,2)));
        }
        public override double Objem()
        {
            return (1/3) * Math.PI * Math.Pow(Polomer, 2) * Vyska;
        }
    }
}