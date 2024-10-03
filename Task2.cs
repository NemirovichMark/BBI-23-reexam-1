using static Task1;

public class Task2
{
    private Shape[] _shapes;
    public abstract class Shape
    {
        public Dot Center { get; }
        public Vector Pointer { get; private set; }

        public Shape(Dot center)
        {
            Center = center;
        }

        public void CreateVector(Dot point)
        {
            Pointer = new Vector(Center, point);
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
            double side = Pointer.Length() * Math.Sqrt(3);
            return Math.Pow(side, 3);
        }
    }

    public Shape[] Shapes
    {
        get { return _shapes; }
    }

    public Task2(Shape[] shapes)
    {
        _shapes = shapes;
    }

    public void Sorting()
    {
        QuickSort(_shapes, 0, _shapes.Length - 1);
    }

    private void QuickSort(Shape[] shapes, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(shapes, left, right);
            QuickSort(shapes, left, pivotIndex - 1);
            QuickSort(shapes, pivotIndex + 1, right);
        }
    }

    private int Partition(Shape[] shapes, int left, int right)
    {
        Shape pivot = shapes[right];
        double pivotVolume = pivot.Volume();
        int i = left;

        for (int j = left; j < right; j++)
        {
            if (shapes[j].Volume() < pivotVolume)
            {
                Swap(shapes, i, j);
                i++;
            }
        }
        Swap(shapes, i, right);
        return i;
    }

    private void Swap(Shape[] shapes, int i, int j)
    {
        Shape temp = shapes[i];
        shapes[i] = shapes[j];
        shapes[j] = temp;
    }

    public override string ToString()
    {
        string result = "";
        foreach (var shape in _shapes)
        {
            result += shape.ToString() + "\n";
        }
        return result;
    }

}
