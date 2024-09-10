using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valec");
            Valec valec = new Valec();
            valec.Polomer = 5;
            valec.Vyska = 5;
            Console.WriteLine(valec.Povrch());
            Console.WriteLine(valec.Objem());
            Console.WriteLine(valec.PomerPovrchKObjemu());
            Console.WriteLine();

            Console.WriteLine("Koule");
            Koule koule = new Koule();
            koule.Polomer = 5;
            Console.WriteLine(koule.Povrch());
            Console.WriteLine(koule.Objem());
            Console.WriteLine(koule.PomerPovrchKObjemu());
            Console.WriteLine();

            Console.WriteLine("Krychle");
            Krychle krychle = new Krychle();
            krychle.Strana = 5;
            Console.WriteLine(krychle.Povrch());
            Console.WriteLine(krychle.Objem());
            Console.WriteLine(krychle.PomerPovrchKObjemu());
            Console.WriteLine();

            Console.WriteLine("Kuzel");
            Kuzel kuzel= new Kuzel();
            kuzel.Polomer = 5;
            kuzel.Vyska = 5;
            Console.WriteLine(kuzel.Povrch());
            Console.WriteLine(kuzel.Objem());
            Console.WriteLine(kuzel.PomerPovrchKObjemu());
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
    public class Valec : Teleso 
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
    public class Koule : Teleso
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
            return (4.0 / 3) * Math.PI * Math.Pow(Polomer, 3);
        }
    }
    public class Krychle : Teleso
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
    public class Kuzel : Teleso
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
            return (1.0/3) * Math.PI * Math.Pow(Polomer, 2) * Vyska;
        }
    }
}