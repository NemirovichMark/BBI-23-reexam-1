using static Task1;
using System;

public class Task2
{
    public abstract class Shape
    {
        private Dot center;
        private Vector pointer;
        public Dot Center { get { return center; } }
        public Vector Pointer { get { return pointer; } }

        public Shape(Dot center)
        {
            this.center = center;
        }

        public void CreateVector(Dot point)
        {
            pointer = new Vector(Center, point);
        }

        public abstract double Volume();

        public override string ToString()
        {
            return $"{GetType().Name} with V = {Volume():F2}";
        }
    }

    public class Sphere : Shape
    {
        public Sphere(Dot center) : base(center) { }

        public override double Volume()
        {
            double radius = Pointer.GetLength();
            return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }
    }

    public class Cube : Shape
    {
        public Cube(Dot center) : base(center) { }

        public override double Volume()
        {
            double edge = Pointer.GetLength();
            return Math.Pow(edge, 3);
        }
    }

    private Shape[] _shapes;

    public Shape[] Shapes => _shapes;

    public Task2(Shape[] shapes)
    {
        _shapes = shapes;
    }

    public void Sorting()
    {
        for (int i = 1; i < _shapes.Length; i++)
        {
            var key = _shapes[i];
            int j = i - 1;

            while (j >= 0 && _shapes[j].Volume() > key.Volume())
            {
                _shapes[j + 1] = _shapes[j];
                j = j - 1;
            }
            _shapes[j + 1] = key;
        }
    }

    public override string ToString()
    {
        string result = "";
        foreach (var shape in _shapes)
        {
            result += shape + "\n";
        }
        return result;
    }
}