using System;

public class Task1
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

    private Point[] _points;

    public Point[] Points { get { return _points; } }

    public Task1(Point[] points)
    {
        if (points.Length == 2)
        {
            _points = points;
        }
        else
        {
            _points = new Point[] { new Point(new int[] { 0, 0 }), new Point(new int[] { 0, 0 }) };
        }
    }

    public override string ToString()
    {
        string result = string.Empty;
        foreach (var point in _points)
        {
            result += point + "\n";
        }
        return result;
    }

    public void Sorting()
    {
        for (int i = 1; i < _points.Length; i++)
        {
            var key = _points[i];
            int j = i - 1;

            double keyLength = key.Length(new Point(new int[] { 0, 0 }));

            while (j >= 0 && _points[j].Length(new Point(new int[] { 0, 0 })) > keyLength)
            {
                _points[j + 1] = _points[j];
                j = j - 1;
            }
            _points[j + 1] = key;
        }
    }
}
//    public static void Main(string[] args)
//    {
//        Point point1 = new Point(new int[] { 1, 2 });
//        Point point2 = new Point(new int[] { 0, 1 });

//        Point[] points = new Point[] { point2, point1 };

//        Task1 task = new Task1(points);
//        Console.WriteLine(task);
//        task.Sorting();

//        Console.WriteLine("After sorting:");
//        Console.WriteLine(task);

//        Console.WriteLine(Point.GetDistanceInfo(point1, point2));

//    }
//}