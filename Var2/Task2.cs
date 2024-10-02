using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Variant_2.Task2;

namespace Variant_2
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

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public abstract class Fourangle
    {
        public abstract double Area { get; }
        public abstract double Perimeter { get; }

        public abstract void DisplayInfo();
    }

    public class Square : Fourangle
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }

        public override double Area => Side * Side;

        public override double Perimeter => 4 * Side;

        public override void DisplayInfo()
        {
            Console.WriteLine($"Square: Side = {Side}, Area = {Area}, Perimeter = {Perimeter}");
        }
    }

    public class Rectangle : Fourangle
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area => Width * Height;

        public override double Perimeter => 2 * (Width + Height);

        public override void DisplayInfo()
        {
            Console.WriteLine($"Rectangle: Width = {Width}, Height = {Height}, Area = {Area}, Perimeter = {Perimeter}");
        }
    }

    public class Task2
    {
        public Point[] Points { get; }
        public Fourangle[] Fourangles { get; }

        public Task2(Point[] points)
        {
            Points = points;
        }

        public Task2(Fourangle[] fourangles)
        {
            Fourangles = fourangles;
        }

        public void DisplayFiguresInfo()
        {
            if (Fourangles != null)
            {
                foreach (var fourangle in Fourangles)
                {
                    fourangle.DisplayInfo();
                }
            }
        }
    }
}