using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Variant_2.Task2;

namespace Variant_2
{
    public class Task2
    {
        
        public struct Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double Length(Point other)
            {
                return Math.Round(Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2)), 2);
            }

            public override string ToString()
            {
                return $"x = {X}, y = {Y}";
            }
        }

      
        public abstract class Fourangle
        {
            protected Point[] points;

            public Point[] Points => points;

           
            public Fourangle(Point[] points)
            {
                if (points.Length == 4)
                {
                    this.points = points;
                }
                else
                {
                   
                    this.points = new Point[4]
                    {
                        new Point(0, 0),
                        new Point(0, 0),
                        new Point(0, 0),
                        new Point(0, 0)
                    };
                }
            }

            public abstract double Length();
            public abstract double Area();

            
            public override string ToString()
            {
                return $"{this.GetType().Name} with P = {Length()}, S = {Area()}";
            }
        }

        
        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }

            public override double Length()
            {
                double side = points[0].Length(points[1]);
                return side * 4;
            }

            public override double Area()
            {
                double side = points[0].Length(points[1]);
                return side * side;
            }
        }

       
        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }

            public override double Length()
            {
                double length = points[0].Length(points[1]);
                double width = points[1].Length(points[2]);
                return 2 * (length + width);
            }

            public override double Area()
            {
                double length = points[0].Length(points[1]);
                double width = points[1].Length(points[2]);
                return length * width;
            }
        }

        
        private Fourangle[] fourangles;

        
        public Fourangle[] Fourangles => fourangles;

      
        public Task2(Fourangle[] fourangles)
        {
            this.fourangles = fourangles;
        }

        
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var fourangle in fourangles)
            {
                result += fourangle.ToString() + "\n";
            }
            return result;
        }

       
        public void Sorting()
        {
            Array.Sort(fourangles, (f1, f2) => f2.Area().CompareTo(f1.Area()));
        }
    }
}