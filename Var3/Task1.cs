using System;

public class Task1
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
            return $"{A}\n{B}\nLength = {Length():F2}";
        }
    }
    private Vector[] vectors;
    public Vector[] Vectors
    {
        get { return vectors; }
    }
    public Task1(Vector[] vectors)
    {
        this.vectors = vectors;
    }
    public override string ToString()
    {
        string result = "";
        foreach (var vector in vectors)
        {
            result += vector.ToString() + "\n\n";
        }
        return result;
    }
    public void Sorting()
    {
        for (int i = 0; i < vectors.Length - 1; i++)
        {
            for (int j = 0; j < vectors.Length - 1 - i; j++)
            {
                if (vectors[j].Length() > vectors[j + 1].Length())
                {
                    Vector temp = vectors[j];
                    vectors[j] = vectors[j + 1];
                    vectors[j + 1] = temp;
                }
            }
        }
    }
    //public static void Main(string[] args)
    //{
    //    Task1.Dot dot1 = new Task1.Dot(new int[] { 1, 2, 3 });
    //    Task1.Dot dot2 = new Task1.Dot(new int[] { 4, 5, 6 });
    //    Task1.Dot dot3 = new Task1.Dot(new int[] { 7, 8, 9 });
    //    Task1.Vector vector1 = new Task1.Vector(dot1, dot2);
    //    Task1.Vector vector2 = new Task1.Vector(dot2, dot3);
    //    Task1.Vector vector3 = new Task1.Vector(dot1, dot3);
    //    Task1 task = new Task1(new Task1.Vector[] { vector1, vector2, vector3 });
    //    Console.WriteLine("Before sorting:");
    //    Console.WriteLine(task.ToString());
    //    task.Sorting();
    //    Console.WriteLine("After sorting:");
    //    Console.WriteLine(task.ToString());
    //}
}