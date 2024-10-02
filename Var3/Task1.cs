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

        public Dot(int[] coordinates)
        {
            if (coordinates.Length == 3)
            {
                x = coordinates[0];
                y = coordinates[1];
                z = coordinates[2];
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
            this.a = start;
            this.b = end;
        }

        public double Length()
        {
            return Math.Round(
                Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2)), 2);
        }

        public override string ToString()
        {
            return $"{a}\n{b}\nLength = {Length()}";
        }
    }

    private Vector[] vectors;

    public Vector[] Vectors => vectors;

    public Task1(Vector[] vectors)
    {
        this.vectors = vectors;
    }

    public void Sorting()
    {
        ShellSort(vectors);
    }

    private void ShellSort(Vector[] array)
    {
        int n = array.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                Vector temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap].Length() > temp.Length(); j -= gap)
                {
                    array[j] = array[j - gap];
                }
                array[j] = temp;
            }
        }
    }

    public override string ToString()
    {
        string result = "";
        foreach (var vector in vectors)
        {
            result += vector.ToString() + "\n";
        }
        return result.TrimEnd();
    }
}
