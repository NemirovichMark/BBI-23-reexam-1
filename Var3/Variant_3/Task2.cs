using static Task1;

public class Task2
{
    private Shape[] _shapes;

    public Shape[] Shapes
    {
        get { return _shapes; }
    }

    public Task2(Shape[] shapes)
    {
        _shapes = shapes;
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

    public void Sorting()
    {
        QuickSort(_shapes, 0, _shapes.Length - 1);
    }

    private void QuickSort(Shape[] shapes, int left, int right)
    {
        int i = left;
        int j = right;
        double pivot = shapes[(left + right) / 2].Volume();

        while (i <= j)
        {
            while (shapes[i].Volume() < pivot)
                i++;

            while (shapes[j].Volume() > pivot)
                j--;

            if (i <= j)
            {
                Shape temp = shapes[i];
                shapes[i] = shapes[j];
                shapes[j] = temp;
                i++;
                j--;
            }
        }

        if (left < j)
            QuickSort(shapes, left, j);

        if (i < right)
            QuickSort(shapes, i, right);
    }

    public abstract class Shape
    {
        public Dot Center { get; private set; }
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
            return $"{GetType().Name} with V = {Volume()}";
        }
    }

    public class Sphere : Shape
    {
        public Sphere(Dot center) : base(center) { }

        public override double Volume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Pointer.Length(), 3);

        }
    }

    public class Cube : Shape
    {
        public Cube(Dot center) : base(center) { }

        public override double Volume()
        {
            return Math.Sqrt(Math.Pow(Pointer.Length(), 2)) ;
        }
    }

}
