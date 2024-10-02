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
            public double x;
            public double y;

            public double X
            {
                get { return x; }
            }

            public double Y
            {
                get { return y; }
            }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"x = {x}, y = {y}";
            }

            public double Length(Point other)
            {
                double distance = Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2));
                return Math.Round(distance, 2);
            }

            public static string GetInfo(Point point1, Point point2)
            {
                string info = $"Точка 1: {point1}nТочка 2: {point2}nРасстояние между точками: {point1.Length(point2)}";
                return info;
            }
        }

        abstract public class Fourangle
        {
            protected Point[] points;

            public Fourangle(Point[] points)
            {
                if (points.Length != 4)
                {
                    this.points = new Point[4];
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
                return $"{GetType().Name} with P = {Length():F2}, S = {Area():F2}";
            }
        }

        public Task2(Point[] points)
        {
         
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
                double width = points[0].Length(points[1]); // Ширина прямоугольника
                double height = points[1].Length(points[2]); // Высота прямоугольника
                return 2 * (width + height);
            }

            public override double Area()
            {
                double width = points[0].Length(points[1]);
                double height = points[1].Length(points[2]);
                return width * height;
            }
        }

        private Fourangle[] fourangles;

        public Fourangle[] Fourangles
        {
            get { return fourangles; }
        }

        public Task2(Fourangle[] fourangles)
        {
            this.fourangles = fourangles;
        }

        public void Sorting()
        {
            Array.Sort(fourangles, (f1, f2) => f2.Area().CompareTo(f1.Area())); // Сортировка по убыванию площади
        }

        public override string ToString()
        {
            string output = "";
            foreach (Fourangle fourangle in fourangles)
            {
                output += fourangle.ToString() + "n";
            }
            return output;
        }
    }
}