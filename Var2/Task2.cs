using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Variant_2.Task2;

namespace Variant_2
{
    public class Task2
    {
        private Fourangle[] fourangles;

        public Fourangle[] Fourangles => fourangles;

        public Task2(Fourangle[] figures)
        {
            this.fourangles = figures;
        }

        public void Sorting()
        {
            QuickSort(fourangles, 0, fourangles.Length - 1);
        }

        private void QuickSort(Fourangle[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        private int Partition(Fourangle[] array, int low, int high)
        {
            double pivotValue = array[high].Area();
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j].Area() > pivotValue)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[high]);
            return i + 1;
        }

        private void Swap(ref Fourangle a, ref Fourangle b)
        {
            Fourangle temp = a;
            a = b;
            b = temp;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var figure in fourangles)
            {
                result += figure.ToString() + "\n";
            }
            return result.TrimEnd();
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

        public double DistanceFromOrigin()
        {
            return Length(new Point(0, 0));
        }
    }

    public abstract class Fourangle
    {
        protected Point[] points;

        public Fourangle(Point[] points)
        {
            if (points.Length == 4)
            {
                this.points = points;
            }
            else
            {
                this.points = new Point[] {
                    new Point(0, 0),
                    new Point(0, 0),
                    new Point(0, 0),
                    new Point(0, 0)
                };
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
            return points[0].Length(points[1]) * 4;
        }

        public override double Area()
        {
            double side = points[0].Length(points[1]);
            return Math.Pow(side, 2);
        }
    }

    public class Rectangle : Fourangle
    {
        public Rectangle(Point[] points) : base(points) { }

        public override double Length()
        {
            double side1 = points[0].Length(points[1]);
            double side2 = points[1].Length(points[2]);
            return 2 * (side1 + side2);
        }

        public override double Area()
        {
            double side1 = points[0].Length(points[1]);
            double side2 = points[1].Length(points[2]);
            return side1 * side2;
        }
    }
}