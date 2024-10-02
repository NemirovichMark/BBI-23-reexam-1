using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task1
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

       
        private Point[] points;

        
        public Point[] Points => points;

        
        public Task1(Point[] points)
        {
            if (points.Length == 2)
            {
                this.points = points;
            }
            else
            {
                throw new ArgumentException("Должно быть передано ровно 2 точки.");
            }
        }

      
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var point in points)
            {
                result += point.ToString() + "\n";
            }
            return result;
        }

        
        public void Sorting()
        {
            Array.Sort(points, (p1, p2) => p1.Length(new Point(0, 0)).CompareTo(p2.Length(new Point(0, 0))));
        }

        
        public static string DistanceBetweenPoints(Point p1, Point p2)
        {
            double distance = p1.Length(p2);
            return $"{p1}\n{p2}\nРасстояние: {distance}";
        }
    }
}