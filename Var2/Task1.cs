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
            private int x;
            private int y;

            public int X { get => x; }
            public int Y { get => y; }

            public Point(int[] coordinates)
            {
                if (coordinates.Length == 2)
                {
                    x = coordinates[0];
                    y = coordinates[1];
                }
                else
                {
                    x = 0;
                    y = 0;
                }
            }

            public override string ToString()
            {
                return "x = " + x + " y = " + y;
            }

            public double Length(Point point)
            {
                return Math.Round(Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2)), 2);
            }

            public static string Distance(Point point_1, Point point_2)
            {
                return point_1 + "\n" + point_2 + "\n" + "Distance = " + point_1.Length(point_2);
            }
        }

        private Point[] points;

        public Point[] Points { get => points; }

        public Task1(Point[] points)
        {
            if (points.Length == 2)
            {
                this.points = points;
            }
            else
            {
                this.points = new Point[] { new Point(new int[] { 0, 0 }), new Point(new int[] { 0, 0 }) };
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (var point in points)
            {
                result += point + "\n";
            }
            return result;
        }

        public void Sorting()
        {
            int i = 0;
            while (i < points.Length)
            {
                if (i == 0 || points[i].Length(new Point(new int[] { 0, 0 })) >= points[i - 1].Length(new Point(new int[] { 0, 0 })))
                {
                    i++;
                }
                else
                {
                    Point temp = points[i];
                    points[i] = points[i - 1];
                    points[i - 1] = temp;
                    i--;
                }
            }
        }
    }
}