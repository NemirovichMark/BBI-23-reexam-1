using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Variant_2.Task2;

//namespace Variant_2
//{
//    public class Task2
//    {
//        public struct Point
//        {

//        }
//        abstract public class Fourangle
//        {

//        }

//        public Task2(Point[] points)
//        {

//        }

//        public class Square
//        {

//        }

//        public class Rectangle
//        {

//        }
//        public Task2(Fourangle[] fourangles)
//        {

//        }

//    }
//}

namespace Variant_2
{
    public class Task2
    {
        public struct Point
        {
            private double x;
            private double y;
            private double[] doubles;

            public double X => x;
            public double Y => y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public Point(double[] doubles) : this()
            {
                this.doubles = doubles;
            }

            public override string ToString()
            {
                return $"x = {x}, y = {y}";
            }

            public double Length(Point other)
            {
                return Math.Round(Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2)), 2);
            }
        }

        abstract public class Fourangle
        {
            protected Point[] points;

            public Fourangle(Point[] points)
            {
                if (points.Length == 4)
                {
                    this.points = points;
                }
                else
                {
                    this.points = new Point[4];
                }
            }

            public abstract double Length();
            public abstract double Area();

            public override string ToString()
            {
                return $"Type: {this.GetType().Name}, P = {Length()}, S = {Area()}";
            }
        }

        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }

            public override double Length()
            {
                return 4 * points[0].Length(points[1]);
            }

            public override double Area()
            {
                return Math.Pow(points[0].Length(points[1]), 2);
            }
        }

        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }

            public override double Length()
            {
                return 2 * (points[0].Length(points[1]) + points[1].Length(points[2]));
            }

            public override double Area()
            {
                return points[0].Length(points[1]) * points[1].Length(points[2]);
            }
        }

        private Fourangle[] fourangles;

        public Fourangle[] Fourangles => fourangles;

        public Task2(Point[] points)
        {

        }

        public Task2(Fourangle[] fourangles)
        {
            this.fourangles = fourangles;
        }

        public void Sorting()
        {
            Array.Sort(fourangles, (f1, f2) => f2.Area().CompareTo(f1.Area()));
        }

        public override string ToString()
        {
            return string.Join("\n", fourangles.Select(f => f.ToString()));
        }
    }
}