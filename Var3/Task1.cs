using System;

public class Task1
{
    public struct Dot
    {
        private int x;
        private int y;
        private int z;

        public int X => x;
        public int Y => y;
        public int Z => z;

        public Dot(double[] coordinates)
        {
            if (coordinates.Length == 3)
            {
                x = (int)coordinates[0];
                y = (int)coordinates[1];
                z = (int)coordinates[2];
            }
            else
            {
                x = 0;
                y = 0;
                z = 0;
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

        public Dot A => a;
        public Dot B => b;

        public Vector(Dot start, Dot end)
        {
            a = start;
            b = end;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));
        }

        public override string ToString()
        {
            return $"{a}\n{b}\nLength = {Length():F2}";
        }
    }

    private Vector[] vectors;

    public Vector[] Vectors => vectors;

    public Task1(Vector[] vectors)
    {
        this.vectors = vectors;
    }

    public override string ToString()
    {
        string result = string.Empty;
        foreach (var vector in vectors)
        {
            result += vector.ToString() + "\n";
        }
        return result;
    }

    public void Sorting()
    {
        int index = 0;
        while (index < vectors.Length)
        {
            if (index == 0 || vectors[index].Length() >= vectors[index - 1].Length())
            {
                index++;
            }
            else
            {
                var temp = vectors[index];
                vectors[index] = vectors[index - 1];
                vectors[index - 1] = temp;
                index--;
            }
        }
    }
}