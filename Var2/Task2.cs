using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Variant_2.Task2;

namespace Variant_2
{
    public class Task2
    {
        private Fourangle[]? fourangles;

        public Fourangle[] Fourangles
        {
            get { return fourangles; }
        }




        public struct Point
        {
            private double x;
            private double y;

            public double X
            {
                get { return x; }
            }

            public double Y
            {
                get { return y; }
            }

            public Point(double[] points)
            {
                if (points.Length != 2)
                {
                    points[0] = 0;
                    points[1] = 0;
                }
                if (points == null)
                {
                    points[0] = 0;
                    points[1] = 0;
                }
                else
                {
                    this.x = points[0];
                    this.y = points[1];
                }
            }

            public static implicit operator Point(double v)
            {
                throw new NotImplementedException();
            }

            public double Length(Point point)
            {
                double DeltaX = point.X - this.X;
                double DeltaY = point.Y - this.Y;
                var temp = Math.Sqrt(Math.Pow(DeltaX, 2) + Math.Pow(DeltaY, 2));

                return Math.Round(temp, 2);
            }

            public static string ToCompare(Point FirstPoint, Point SecondPoint)
            {
                return $"Кординаты первой точки: x = {FirstPoint.X}, y = {FirstPoint.Y} '\r\n' Координаты второй точки: x = {SecondPoint.X}, y = {SecondPoint.Y} '\r\n' Расстояние между ними: {FirstPoint.Length(SecondPoint)}";
            }

            public override string ToString()
            {
                return $"x = {this.X}, y = {this.Y}";
            }

            public double DistanceFromZeroes()
            {
                return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
            }
        }
        abstract public class Fourangle
        {
            protected Point[] points;

            public Fourangle(Point[] points)
            {
                if (points.Length != 4)
                {
                    points = new Point[4] { 0, 0, 0, 0 };
                }
                if (points == null)
                {
                    points = new Point[4] { 0, 0, 0, 0 };
                }
                else
                {
                    this.points = points;
                }
            }

            public abstract double Length();
            public abstract double Area();


            public override string ToString()
            {
                return $"{this.GetType()} with P = {this.Length}, S = {this.Area}";
            }
        }

        public Task2(Point[] points)
        {
            
        }

        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points)
            {

            }

            public override double Length()
            {
                double side = Distance(points[0], points[1]);
                return 4 * side;
            }
            public override double Area()
            {
                double side = Distance(points[0], points[1]);
                return side * side;
            }

            private double Distance(Point p1, Point p2)
            {
                return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            }


        }

        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points)
            {
            }

            public override double Length()
            {
                double length = Distance(points[0], points[1]);
                double width = Distance(points[1], points[2]);
                return 2 * (length + width);
            }
            public override double Area()
            {
                double length = Distance(points[0], points[1]);
                double width = Distance(points[1], points[2]);
                return length * width;
            }

            private double Distance(Point p1, Point p2)
            {
                return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            }
        }
        

    }
}