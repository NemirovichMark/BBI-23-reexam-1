public class Task1
{
    public struct Dot
    {
        private double x, y, z;
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Z { get { return z; } set { z = value; } }
        public Dot(double[] coordinates)
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
        private Dot start, end;
        public Dot Start { get { return start; } set { start = value; } }
        public Dot End { get { return end; } set { end = value; } }

        public Vector(Dot start, Dot end)
        {
            this.start = start;
            this.end = end;
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.Z - start.Z, 2));
        }

        public override string ToString()
        {
            return $"{start}\n{end}\nlength = {GetLength()}";
        }
    }

    private Vector[] vectors;

    public Vector[] Vectors { get { return vectors; } }

    public Task1(Vector[] vectors)
    {
        this.vectors = vectors;
    }

    public void Sort()
    {
        int i = 1;
        int j = 2;

        while (i < vectors.Length)
        {
            if (vectors[i - 1].GetLength() <= vectors[i].GetLength())
            {
                i = j;
                j++;
            }
            else
            {
                var temp = vectors[i - 1];
                vectors[i - 1] = vectors[i];
                vectors[i] = temp;
                i--;
                if (i == 0)
                {
                    i = j;
                    j++;
                }
            }
        }
    }
}