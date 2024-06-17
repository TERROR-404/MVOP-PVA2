using System.Collections.Generic;
using System.Security;

namespace skola_posledni_hodina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarMeet carMeet = new CarMeet(80, 90, 200);
            carMeet.Start();
            SteelRope steelRope = new SteelRope();
            Console.WriteLine(steelRope.Start(1,22,1300));
        }
    }
    public class SteelRope // nemám páru co dělám
    {
        public double d;
        public double Q;
        public double A;
        public double maxPower;
        public double time;
        public double force;

        public double Start(double d, double q, double strength)
        {
            this.d = d;
            this.Q = q;
            A = (Math.PI*Math.Pow(d,2))/4;
            this.maxPower = A * strength;
            while (true)
            {
                Move();
                if (force > maxPower)
                {
                    return time;
                    
                }
            }
        }
        public void Move(double sec = 1)
        {
            force += (Q * sec) * 9.8;
            this.time += sec;
        }
    }
    public class CarMeet
    {
        public int VA { get; set; }
        public int VB { get; set; }
        public int distance;
        public double distA;
        public double distB;
        public double time;

        public CarMeet(int vA, int vB, int distance)
        {
            VA = vA;
            VB = vB;
            this.distance = distance;
            this.distA = 0;
            this.distB=0;
            this.time = 0;
        }
        public void Start()
        {
            while (distA < distance && distB < distance)
            {
                Move(0.1);
                if (distance - (distB + distA) <= 0)
                {
                    break;
                }
            }
            Console.WriteLine(distA);
            Console.WriteLine(distB);
            Console.WriteLine(time);
        }
        public void Move(double minutes = 1)
        {
            distA += VA * (minutes / 60);
            distB += VB * (minutes / 60);
            time += minutes;
        }
    }
}