using static Task1;

public class Task2
{
    private Shape[] shapes;

    public Shape[] Shapes => shapes;


    public Task2(Shape[] shapesArray)
    {
        shapes = shapesArray;
    }

    public override string ToString()
    {
        string result = "";
        foreach (var shape in shapes)
        {
            result += shape.ToString() + "\n";
        }
        return result.TrimEnd();
    }

    public void Sorting()
    {
        QuickSort(shapes, 0, shapes.Length - 1);
    }

    private void QuickSort(Shape[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    private int Partition(Shape[] array, int left, int right)
    {
        Shape pivot = array[right];
        double pivotVolume = pivot.Volume();
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (array[j].Volume() < pivotVolume)
            {
                i++;
                Swap(ref array[i], ref array[j]);
            }
        }
        Swap(ref array[i + 1], ref array[right]);
        return i + 1;
    }

    private void Swap(ref Shape a, ref Shape b)
    {
        Shape temp = a;
        a = b;
        b = temp;
    }
    public struct Dot
    {
        private double x;
        private double y;
        private double z;

        public double X => x;
        public double Y => y;
        public double Z => z;

        public Dot(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }

    public class Vector
    {
        private double x;
        private double y;
        private double z;

        public double X => x;
        public double Y => y;
        public double Z => z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public override string ToString()
        {
            return $"Vector({x}, {y}, {z})";
        }
    }

    public abstract class Shape
    {
        private Dot center;
        private Vector pointer;

        public Dot Center => center;
        public Vector Pointer => pointer;

        public Shape(Dot center)
        {
            this.center = center;
        }

        public void CreateVector(Dot point)
        {
            pointer = new Vector(point.X - center.X, point.Y - center.Y, point.Z - center.Z);
        }

        public abstract double Volume();

        public override string ToString()
        {
            return $"{this.GetType().Name} with V = {Volume():0.00}";
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
            double side = Pointer.Length();
            return Math.Pow(side, 3);
        }
    }

}