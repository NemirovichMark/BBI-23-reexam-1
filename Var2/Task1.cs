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
            QuickSort(points, 0, points.Length - 1);
        }

        private void QuickSort(Point[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private int Partition(Point[] array, int left, int right)
        {
            Point pivot = array[right];
            double pivotDistance = pivot.DistanceFromOrigin();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j].DistanceFromOrigin() < pivotDistance)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i + 1], ref array[right]);
            return i + 1;
        }

        private void Swap(ref Point a, ref Point b)
        {
            Point temp = a;
            a = b;
            b = temp;
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