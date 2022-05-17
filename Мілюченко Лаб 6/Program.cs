using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мілюченко_Лаб_6
{
    internal class Program
    {
        public abstract class TQuadrangle
        {
            protected double a;
            public double A { get { return a; } set { a = (value > 0 ? value : 0.1 ); } }

            protected double b;
            public double B { get { return b; } set { b = (value > 0 ? value : 0.1); } }

            protected double c;
            public double C { get { return c; } set { c = (value > 0 ? value : 0.1); } }

            protected double d;
            public double D { get { return d; } set { d = (value > 0 ? value : 0.1); } }


            public TQuadrangle(double a, double b, double c, double d)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.d = d;
            }

            public abstract double S();

            public abstract double P();
        }

        public class Rectangle : TQuadrangle
        {
            public Rectangle(double a, double b) : base(a,b,a,b) 
            { 
            }

            public override double S()
            {
                return a * b;
            }
            public override double P()
            {
                return 2 * a + 2 * b;
            }

            public override string ToString()
            {
                return $"Rectangle with a = {a}, b = {b}";
            }
        }

        public class Square : TQuadrangle
        {
            public Square(double a) : base(a, a, a, a)
            {
            }

            public override double S()
            {
                return a * a;
            }
            public override double P()
            {
                return 4 * a;
            }

            public override string ToString()
            {
                return $"Square with a = {a}";
            }
        }

        public class Parallelogram : TQuadrangle
        {
            protected double angle;
            public double Angle { get { return angle; } set { angle = (value > 0 && value < 180 ? value : 30); } }

            public Parallelogram(double a, double b, double angle) : base(a, b, a, b)
            {
                this.angle = angle;
            }

            public override double S()
            {
                return a * b * Math.Sin(angle * Math.PI / 180);
            }
            public override double P()
            {
                return 2 * a + 2 * b;
            }

            public override string ToString()
            {
                return $"Parallelogram with a = {a}, b = {b} and angle = {angle}";
            }
        }


        static void Main(string[] args)
        {
            /*
            Rectangle rectangle = new Rectangle(2,4);
            Console.WriteLine(rectangle);
            Console.WriteLine(rectangle.A);
            Console.WriteLine(rectangle.B);
            Console.WriteLine(rectangle.C);
            Console.WriteLine(rectangle.D);
            Console.WriteLine(rectangle.S());
            Console.WriteLine(rectangle.P());

            Console.WriteLine("----------");

            Square square = new Square(2);
            Console.WriteLine(square);
            Console.WriteLine(square.A);
            Console.WriteLine(square.B);
            Console.WriteLine(square.C);
            Console.WriteLine(square.D);
            Console.WriteLine(square.S());
            Console.WriteLine(square.P());

            Console.WriteLine("----------");

            Parallelogram parallelogram = new Parallelogram(2, 30);
            Console.WriteLine(parallelogram);
            Console.WriteLine(parallelogram.A);
            Console.WriteLine(parallelogram.B);
            Console.WriteLine(parallelogram.C);
            Console.WriteLine(parallelogram.D);
            Console.WriteLine(parallelogram.S());
            Console.WriteLine(parallelogram.P());
            Console.WriteLine(parallelogram.Angle);
            */

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            List<TQuadrangle> parts = new List<TQuadrangle>();

            Random rnd = new Random();

            for (int i = 0; i < n / 3; i++)
            {
                parts.Add(new Rectangle(rnd.Next(1, 11), rnd.Next(1, 11) ) );
                parts.Add(new Square(rnd.Next(1, 11) ) );
                parts.Add(new Parallelogram(rnd.Next(1, 11), rnd.Next(1, 11), rnd.Next(30, 61) ) );
            }

            double sumArea = 0;
            double sumPerimetr = 0;
            
            foreach (TQuadrangle quadrangle in parts)
            {
                Console.WriteLine(quadrangle);
                if (quadrangle is Parallelogram)
                {
                    sumPerimetr += quadrangle.P();
                }
                else
                {
                    sumArea += quadrangle.S();
                }
            }

            Console.WriteLine("----------");
            Console.WriteLine($"Sum pf squares and rectangles areas = {sumArea}");
            Console.WriteLine($"Sum of paralelograms perimetrs = {sumPerimetr}");
        }
    }
}
