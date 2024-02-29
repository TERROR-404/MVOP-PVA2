using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle k1 = new Circle(0, 0, 5);
            Circle k2 = new Circle(0, 0, 3);
            Circle k3 = new Circle(1, 1, 1);
            List<object> l = new List<object>();
            l.Add(k1);
            l.Add(k2);
            l.Add(k3);
            Console.WriteLine(k1.Area());
            Console.WriteLine(k1.Perimeter());
            Console.WriteLine(k1.Cross(k2));
        }
        public static void Parameters(double x, double y, double r)
        {

        }
    }
    public class GeometricObject
    {
        private double x;
        public double X { get; set; }
        private double y;

        public GeometricObject(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Y { get; set; }
    }
    public class Circle : GeometricObject
    {
        private double r;
        public double R { get; set; }

        public Circle(double x, double y, int r):base(x,y)
        {
            R = r;
        }
        public double Area()
        {
            return Math.PI * 2 * R;
        }
        public double Perimeter()
        {
            return Math.PI*Math.Pow(R,2);
        }
        public bool Cross(Circle o)
        {
            double distance = Math.Sqrt(Math.Pow(o.X-X,2)+Math.Pow(o.Y-Y,2));
            if (distance > (R+o.R)|| ())
            {
                return false;
            }
            return true;
        }
        public class Square : GeometricObject
        {
            public Square(double x, double y) : base(x, y)
            {
            }

            public double Area()
            {
                return X*Y;
            }
            public double Perimeter()
            {
                return 2*X+2*Y;
            }
        }
    }
}
