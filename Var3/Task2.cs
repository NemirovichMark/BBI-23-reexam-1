using static Task1;

public class Task2
{
    public struct Dot
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Dot(int[] coordinates)
        {
            if (coordinates.Length == 3)
            {
                X = coordinates[0];
                Y = coordinates[1];
                Z = coordinates[2];
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
            }
        }

        public override string ToString()
        {
            return $"x = {X}, y = {Y}, z = {Z}";
        }
    }
    public struct Vector
    {
        public Dot A { get; }
        public Dot B { get; }

        public Vector(Dot a, Dot b)
        {
            A = a;
            B = b;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.Z - A.Z, 2));
        }

        public override string ToString()
        {
            return $"Length = {Length():F2}";
        }
    }
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
            double r = Pointer.Length();
            return (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);
        }
    }
    public class Cube : Shape
    {
        public Cube(Dot center) : base(center) { }
        public override double Volume()
        {
            double r = Pointer.Length();
            return Math.Pow(r, 3);
        }
    }
    private Shape[] shapes;
    public Shape[] Shapes
    {
        get { return shapes; }
    }
    public Task2(Shape[] shapes)
    {
        this.shapes = shapes;
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
    //public static void Main(string[] args)
    //{
    //    Task2.Dot center1 = new Task2.Dot(new int[] { 0, 0, 0 });
    //    Task2.Dot point1 = new Task2.Dot(new int[] { 3, 4, 0 });
    //    Task2.Dot center2 = new Task2.Dot(new int[] { 1, 1, 1 });
    //    Task2.Dot point2 = new Task2.Dot(new int[] { 4, 5, 1 });


    //    Sphere sphere = new Sphere(center1);
    //    sphere.CreateVector(point1);

    //    Cube cube = new Cube(center2);
    //    cube.CreateVector(point2);

    //    Task2 task = new Task2(new Shape[] { sphere, cube });

    //    Console.WriteLine("Before sorting:");
    //    Console.WriteLine(task.ToString());

    //    task.Sorting();

    //    Console.WriteLine("After sorting:");
    //    Console.WriteLine(task.ToString());
    //}
}