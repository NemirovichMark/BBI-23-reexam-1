public class Task1
{
    public struct Dot
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Dot(int[] coordinates)
        {
            if (coordinates.Length != 3)
            {
                X = Y = Z = 0;
            }
            else
            {
                X = coordinates[0];
                Y = coordinates[1];
                Z = coordinates[2];
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

        public Vector(Dot start, Dot end)
        {
            A = start;
            B = end;
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

    public Vector[] Vectors => vectors;

    public Task1(Vector[] inputVectors)
    {
        vectors = new Vector[inputVectors.Length];
        for (int i = 0; i < inputVectors.Length; i++)
        {
            vectors[i] = inputVectors[i];
        }
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

    public override string ToString()
    {
        string result = "";
        foreach (var vector in vectors)
        {
            result += vector.ToString() + "\n";
        }
        return result;
    }
}

