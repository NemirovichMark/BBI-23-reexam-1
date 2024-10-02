using static Task1;
public class Task2
{
    public abstract class Shape
    {
        public Dot Center { get; }
        public Vector Pointer { get; private set; }

        protected Shape(Dot center)
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
            return $"{GetType().Name} with V = {Volume():F2}";
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

    private Shape[] shapes; 

    public Shape[] Shapes => shapes; 

    public Task2(Shape[] inputShapes)
    {
        shapes = new Shape[inputShapes.Length];
        for (int i = 0; i < inputShapes.Length; i++)
        {
            shapes[i] = inputShapes[i];
        }
    }

    public void Sorting()
    {
        for (int i = 0; i < shapes.Length - 1; i++)
        {
            for (int j = 0; j < shapes.Length - 1 - i; j++)
            {
                if (shapes[j].Volume() > shapes[j + 1].Volume())
                {
                    Shape temp = shapes[j];
                    shapes[j] = shapes[j + 1];
                    shapes[j + 1] = temp;
                }
            }
        }
    }

    public override string ToString()
    {
        string result = "";
        foreach (var shape in shapes)
        {
            result += shape.ToString() + "\n";
        }
        return result;
    }
}
