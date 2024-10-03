using System;

namespace Variant_2
{
    public class Task2
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

        public abstract class Fourangle
        {
            protected Point[] points;

            public Fourangle(Point[] points)
            {
                if (points.Length != 4)
                {
                    this.points = new Point[4]; // Создаем пустой четырехугольник
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
                return $"{GetType().Name} with P = {Length()}, S = {Area()}";
            }
        }

        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }

            public override double Length()
            {
                double side = points[0].DistanceTo(points[1]);
                return side * 4;
            }

            public override double Area()
            {
                double side = points[0].DistanceTo(points[1]);
                return side * side;
            }
        }

        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }

            public override double Length()
            {
                double side1 = points[0].DistanceTo(points[1]);
                double side2 = points[1].DistanceTo(points[2]);
                return 2 * (side1 + side2);
            }

            public override double Area()
            {
                double side1 = points[0].DistanceTo(points[1]);
                double side2 = points[1].DistanceTo(points[2]);
                return side1 * side2;
            }
        }

        private Fourangle[] fourangles;

        public Task2(Fourangle[] fourangles)
        {
            this.fourangles = fourangles;
        }

        public Fourangle[] Fourangles
        {
            get { return fourangles; }
        }

        public void Sorting()
        {
            QuickSort(0, fourangles.Length - 1);
        }

        private void QuickSort(int left, int right)
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
            double pivotArea = fourangles[right].Area();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (fourangles[j].Area() >= pivotArea)
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
            Fourangle temp = fourangles[i];
            fourangles[i] = fourangles[j];
            fourangles[j] = temp;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Fourangle fourangle in fourangles)
            {
                result += fourangle.ToString() + "\n";
            }
            return result;
        }
    }
}