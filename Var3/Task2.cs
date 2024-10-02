using System;
using System.Numerics;
using static Task1;

public class Task2
{
    public abstract class Shape
    {
        private Dot center;
        private Task1.Vector pointer;

        public Dot Center => center;
        public Task1.Vector Pointer => pointer;

        protected Shape(Dot center)
        {
            this.center = center;
        }

        public void CreateVector(Dot point)
        {
            pointer = new Task1.Vector(center, point);
        }

        public abstract double Volume();

        public override string ToString()
        {
            return $"{this.GetType().Name} with V = {Volume():F2}";
        }
    }

    public class Sphere : Shape
    {
        public Sphere(Dot center) : base(center) { }

        public override double Volume()
        {
            double radius = Pointer.Length();
            return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }
    }

    public class Cube : Shape
    {
        public Cube(Dot center) : base(center) { }

        public override double Volume()
        {
            double sideLength = Pointer.Length();
            return Math.Pow(sideLength, 3);
        }
    }

    private Shape[] shapes;

    public Shape[] Shapes => shapes;

    public Task2(Shape[] shapes)
    {
        this.shapes = shapes;
    }

    public override string ToString()
    {
        string result = string.Empty;
        foreach (var shape in shapes)
        {
            result += shape.ToString() + "\n";
        }
        return result;
    }

    public void Sorting()
    {
        int index = 0;
        while (index < shapes.Length)
        {
            if (index == 0 || shapes[index - 1].Volume() <= shapes[index].Volume())
            {
                index++;
            }
            else
            {
                var temp = shapes[index];
                shapes[index] = shapes[index - 1];
                shapes[index - 1] = temp;
                index--;
            }
        }
    }
}