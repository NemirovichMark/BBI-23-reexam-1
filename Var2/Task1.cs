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

        public Point[] Points => points;

        public Task1(Point[] pointsArray)
        {
            if (pointsArray.Length != 2)
                throw new ArgumentException("Массив должен содержать ровно 2 точки.");
            this.points = pointsArray;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var point in points)
            {
                result += point.ToString() + "\n";
            }
            return result.TrimEnd();
        }

        public void Sorting()
        {
            ShellSort(points);
        }

        private void ShellSort(Point[] array)
        {
            int n = array.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    Point temp = array[i];
                    double tempDistance = temp.DistanceFromOrigin();
                    int j;
                    for (j = i; j >= gap && array[j - gap].DistanceFromOrigin() > tempDistance; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
                gap /= 2;
            }
        }

    }
    public struct Point
    {
        private double x;
        private double y;

        public double X => x;
        public double Y => y;

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
            double distance = Math.Sqrt(Math.Pow(other.X - this.X, 2) + Math.Pow(other.Y - this.Y, 2));
            return Math.Round(distance, 2);
        }

        public static string ComparePoints(Point p1, Point p2)
        {
            double distance = p1.Length(p2);
            return $"{p1}\n{p2}\nDistance: {distance}";
        }

        public double DistanceFromOrigin()
        {
            return Length(new Point(0, 0));
        }
    }
}
