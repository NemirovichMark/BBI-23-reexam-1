using System;

public class Task2
{
    public struct Point
    {
        private int x;
        private int y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

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
            return $"x = {x}, y = {y}";
        }

        public double Length(Point other)
        {
            return Math.Round(Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2)), 2);
        }

        public static string GetDistanceInfo(Point p1, Point p2)
        {
            return $"{p1}\n{p2}\nDistance = {p1.Length(p2):F2}";
        }
    }

    public abstract class Fourangle
    {
        private Point[] points;
        public Point[] Points { get { return points; } }

        protected Fourangle(Point[] points)
        {
            if (points.Length == 4)
            {
                this.points = points;
            }
            else
            {
                this.points = new Point[4];
            }
        }

        public abstract double Length();
        public abstract double Area();

        public override string ToString()
        {
            return $"{GetType().Name} with P = {Length():F2}, S = {Area():F2}";
        }

        protected double Distance(Point p1, Point p2)
        {
            return p1.Length(p2);
        }
    }

    public class Square : Fourangle
    {
        public Square(Point[] points) : base(points) { }

        public override double Length()
        {
            double side = Distance(Points[0], Points[1]);
            return side * 4;
        }

        public override double Area()
        {
            double side = Distance(Points[0], Points[1]);
            return Math.Pow(side, 2);
        }
    }

    public class Rectangle : Fourangle
    {
        public Rectangle(Point[] points) : base(points) { }

        public override double Length()
        {
            double length = Distance(Points[0], Points[1]);
            double width = Distance(Points[1], Points[2]);
            return 2 * (length + width);
        }

        public override double Area()
        {
            double length = Distance(Points[0], Points[1]);
            double width = Distance(Points[1], Points[2]);
            return length * width;
        }
    }

    private Fourangle[] _fourangles;

    public Fourangle[] Fourangles { get { return _fourangles; } }

    public Task2(Fourangle[] fourangles)
    {
        _fourangles = fourangles;
    }

    public void Sorting()
    {
        for (int i = 1; i < _fourangles.Length; i++)
        {
            var key = _fourangles[i];
            int j = i - 1;

            while (j >= 0 && _fourangles[j].Area() < key.Area())
            {
                _fourangles[j + 1] = _fourangles[j];
                j = j - 1;
            }
            _fourangles[j + 1] = key;
        }
    }

    public override string ToString()
    {
        string result = string.Empty;
        foreach (var fourangle in _fourangles)
        {
            result += fourangle + "\n";
        }
        return result;
    }
}