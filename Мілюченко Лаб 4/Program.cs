using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        class TCircle
        {
            private double r;
            public double R { get { return r; } set { r = value; } }

            public TCircle()
            {
                r = 1;
            }
            public TCircle(double radius)
            {
                r = radius;
            }
            public TCircle(TCircle circle)
            {
                r = circle.R;
            }

            public double S()
            {
                return Math.PI * r * r;
            }

            public double L()
            {
                return Math.PI * r * 2;
            }

            public string Compare(TCircle circle)
            {
                if      (this.r > circle.r) { return "Bigger"; }
                else if (this.r < circle.r) { return "Smaller"; }
                else { return "Equal"; }
            }

            public static TCircle operator +(TCircle circle1, TCircle circle2)
            {
                return new TCircle(circle1.r + circle2.r);
            }
            public static TCircle operator -(TCircle circle1, TCircle circle2)
            {
                return new TCircle(circle1.r - circle2.r);
            }
            public static TCircle operator *(TCircle circle1, double num)
            {
                return new TCircle(circle1.r * num);
            }

            public override string ToString()
            {
                return $"Circle with radius {r}";
            }

            ~TCircle()
            {
                //Console.WriteLine("Circle lifespan ended");
            }
        }
        static void Main(string[] args)
        {
            TCircle circle1 = new TCircle(2);
            TCircle circle2 = new TCircle();
            TCircle circle3 = new TCircle(circle1);

            Console.WriteLine(circle1);
            Console.WriteLine(circle1.R);
            Console.WriteLine(circle1.S());
            Console.WriteLine(circle1.L());
            Console.WriteLine(circle1.Compare(circle2));
            Console.WriteLine(circle1 + circle2);
            Console.WriteLine(circle1 - circle2);
            Console.WriteLine(circle1 * 2);
        }
    }
}
