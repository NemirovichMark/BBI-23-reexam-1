public class Task2
{
   
    public struct Dot
    {
        private double x;
        private double y;
        private double z;

       
        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Z { get { return z; } }

        
        public Dot(double[] vec)
        {
            if (vec.Length == 3)
            {
                this.x = vec[0];
                this.y = vec[1];
                this.z = vec[2];
            }
            else
            {
                this.x = this.y = this.z = 0;
            }
        }

        public override string ToString()
        {
            return $"x = {x}, y = {y}, z = {z}";
        }
    }

   
    public struct Vector
    {
        private Dot a;
        private Dot b;

        
        public Dot A { get { return a; } }
        public Dot B { get { return b; } }

        
        public Vector(Dot x, Dot y)
        {
            this.a = x;
            this.b = y;
        }

       
        public double Length()
        {
            double deltaX = Math.Abs(b.X - a.X);
            double deltaY = Math.Abs(b.Y - a.Y);
            double deltaZ = Math.Abs(b.Z - a.Z);

            return Math.Round(Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ), 2);
        }

       
        public override string ToString()
        {
            return $"{A.ToString()}\n{B.ToString()}\nLength = {Length()}";
        }
    }

    
    public abstract class Shape
    {
        protected Dot center;
        protected Vector pointer;

       
        public Dot Center { get { return center; } }
        public Vector Pointer { get { return pointer; } }

        
        public Shape(Dot center)
        {
            this.center = center;
        }

        
        public void CreateVector(Dot a)
        {
            this.pointer = new Vector(this.center, a);
        }

        
        public abstract double Volume();

        
        public override string ToString()
        {
            return $"Shape with V = {Volume()}";
        }
    }

    
    public class Sphere : Shape
    {
        
        public Sphere(Dot center) : base(center) { }

       
        public override double Volume()
        {
            double r = this.pointer.Length();
            return Math.Round((4.0 / 3.0) * Math.PI * Math.Pow(r, 3), 2);
        }

       
        public override string ToString()
        {
            return $"Sphere with V = {Volume()}";
        }
    }

   
    public class Cube : Shape
    {
        
        public Cube(Dot center) : base(center) { }

        
        public override double Volume()
        {
            double diagonalLength = this.pointer.Length();
            double sideLength = diagonalLength / Math.Sqrt(3);
            return Math.Round(Math.Pow(sideLength, 3), 2);
        }

       
        public override string ToString()
        {
            return $"Cube with V = {Volume()}";
        }
    }

    
    private Shape[] list;
    public Shape[] Shapes { get { return list; } }

    
    public Task2(Shape[] list)
    {
        this.list = list;
    }

    
    public override string ToString()
    {
        string result = "";
        foreach (Shape shape in list)
        {
            result += shape.ToString() + "\n";
        }
        return result;
    }

   
    public void Sorting()
    {
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = i + 1; j < list.Length; j++)
            {
                if (list[i].Volume() > list[j].Volume())
                {
                    Shape temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }
}
