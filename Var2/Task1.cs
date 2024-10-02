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
        private Point[] points;

        public Point[] Points
        {
            get { return points; }
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

        public Task1(Point[] points)
        {
            this.points = points;
        }

        public void Sorting()
        {
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length - 1 - i; j++)
                {
                    if (points[j].DistanceFromZeroes() > points[j + 1].DistanceFromZeroes())
                    {
                        Point temp = points[j];
                        points[j] = points[j + 1];
                        points[j + 1] = temp;
                    }
                }
            }
        }
    }
}