using System;

namespace Variant_2
{
    public class Task1
    {
        public struct Point
        {
            public double[] Coordinates;

            public Point(double x, double y)
            {
                Coordinates = new double[] { x, y };
            }

            public override string ToString()
            {
                return $"x = {Coordinates[0]}, y = {Coordinates[1]}";
            }

            public double DistanceTo(Point other)
            {
                return Math.Round(Math.Sqrt(Math.Pow(Coordinates[0] - other.Coordinates[0], 2) + Math.Pow(Coordinates[1] - other.Coordinates[1], 2)), 2);
            }
        }

        private Point[] points;

        public Task1(Point[] points)
        {
            if (points.Length != 2)
            {
                throw new ArgumentException("Массив должен содержать 2 точки.");
            }
            this.points = points;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Point point in points)
            {
                result += point.ToString() + " ";
            }
            return result;
        }

        public static string GetPointInfo(Point[] points)
        {
            string result = "";
            result += points[0].ToString() + " ";
            result += points[1].ToString() + " ";
            result += $"Расстояние между точками: {points[0].DistanceTo(points[1])}";
            return result;
        }

        public void QuickSort(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(left, right);
                QuickSort(left, pivotIndex - 1);
                QuickSort(pivotIndex + 1, right);
            }
        }

        private int Partition(int left, int right)
        {
            double pivotDistance = CalculateDistance(points[right]);
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (CalculateDistance(points[j]) <= pivotDistance)
                {
                    i++;
                    Swap(i, j);
                }
            }
            Swap(i + 1, right);
            return i + 1;
        }

        private void Swap(int i, int j)
        {
            Point temp = points[i];
            points[i] = points[j];
            points[j] = temp;
        }

        private double CalculateDistance(Point point)
        {
            return Math.Sqrt(Math.Pow(point.Coordinates[0], 2) + Math.Pow(point.Coordinates[1], 2));
        }
    }
}