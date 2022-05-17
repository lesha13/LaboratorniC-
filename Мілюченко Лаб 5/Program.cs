using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public class TCircle
        {
            protected double r;
            public double R { get { return r; } set { r = (value >= 0.1 ? value : 0.1); } }

            public TCircle()
            {
                r = 1;
            }
            public TCircle(double r)
            { 
                this.r = r; 
            }
            public TCircle(TCircle circle)
            {
                this.r = circle.r;
            }

            public double S()
            {
                return Math.PI * r * r;
            }
            public double S(double angle)
            {
                return Math.PI * r * r * (angle/360);
            }

            public double L()
            {
                return Math.PI * r * 2;
            }

            public bool Compare(TCircle circle)
            {
                return this.r == circle.r;
            }
            public static TCircle operator +(TCircle circle1, TCircle circle2)
            {
                return new TCircle(circle1.r + circle1.r);
            }
            public static TCircle operator -(TCircle circle1, TCircle circle2)
            {
                return new TCircle(circle1.r - circle1.r);
            }
            public static TCircle operator *(TCircle circle1, double num)
            {
                return new TCircle(circle1.r * num);
            }
            public static TCircle operator *(double num, TCircle circle1)
            {
                return new TCircle(circle1.r * num);
            }

            public override string ToString()
            {
                return $"Circle with radius: {r}";
            }
            ~TCircle()
            {
                // Console.WriteLine("Circle lifespan ended");
            }
        }

        public class TCone : TCircle
        {
            protected double h;
            public double H { get { return h; } set { h = (value >= 0.1 ? value : 0.1); } }

            public TCone(): base()
            {
                h = 1;
            }
            public TCone(double r, double h) : base(r)
            {
                this.h = h;
            }
            public TCone(TCone cone) : base(cone.r)
            {
                this.h = cone.h;
            }

            public double V()
            {
                return base.S() * h * (1 / 3);
            }

            public new bool Compare(TCone cone)
            {
                return base.Compare(cone) && this.h == cone.h;
            }

            public static TCone operator *(TCone cone, double num)
            {
                return new TCone(cone.r * num, cone.h * num);
            }
            public static TCone operator *(double num, TCone cone)
            {
                return new TCone(cone.r * num, cone.h * num);
            }

            public override string ToString()
            {
                return $"Cone with radius: {r}, heigth: {h}";
            }
            ~TCone()
            {
                // Console.WriteLine("Cone lifespan ended");
            }
        }
        static void Main(string[] args)
        {
            TCircle circle1 = new TCircle(2);
            TCircle circle2 = new TCircle();
            TCircle circle3 = new TCircle(circle2);

            Console.WriteLine(circle1);
            Console.WriteLine(circle2);
            Console.WriteLine(circle3);

            Console.WriteLine(circle1.R);
            Console.WriteLine(circle1.S());
            Console.WriteLine(circle1.S(90));
            Console.WriteLine(circle1.L());
            Console.WriteLine(circle1.Compare(circle1));
            Console.WriteLine(circle1 + circle2);
            Console.WriteLine(circle1 - circle2);
            Console.WriteLine(circle1 * 2);
            Console.WriteLine(2 * circle1);

            TCone cone1 = new TCone(2, 2);
            TCone cone2 = new TCone();
            TCone cone3 = new TCone(cone2);

            Console.WriteLine(cone1);
            Console.WriteLine(cone2);
            Console.WriteLine(cone3);

            Console.WriteLine(cone1.R);
            Console.WriteLine(cone1.H);
            Console.WriteLine(cone1.V());
            Console.WriteLine(cone1.Compare(cone1));
            Console.WriteLine(cone1 * 2);
            Console.WriteLine(2 * cone1);
        }   
    }
}
