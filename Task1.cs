public class Task1
{
    private Vector[] _vectors;

    public struct Dot
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Dot(double[] coordinates)
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

    public Vector[] Vectors
    {
        get { return _vectors; }
    }

    public Task1(Vector[] vectors)
    {
        _vectors = vectors;
    }

    public void Sorting()
    {
        MergeSort(_vectors, 0, _vectors.Length - 1);
    }

    private void MergeSort(Vector[] vectors, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            
            MergeSort(vectors, left, middle);
            MergeSort(vectors, middle + 1, right);

            
            Merge(vectors, left, middle, right);
        }
    }

    private void Merge(Vector[] vectors, int left, int middle, int right)
    {
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        Vector[] leftArray = new Vector[leftSize];
        Vector[] rightArray = new Vector[rightSize];

        Array.Copy(vectors, left, leftArray, 0, leftSize);
        Array.Copy(vectors, middle + 1, rightArray, 0, rightSize);

        int i = 0, j = 0, k = left;

        while (i < leftSize && j < rightSize)
        {
            if (leftArray[i].Length() <= rightArray[j].Length())
            {
                vectors[k] = leftArray[i];
                i++;
            }
            else
            {
                vectors[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftSize)
        {
            vectors[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightSize)
        {
            vectors[k] = rightArray[j];
            j++;
            k++;
        }
    }

    public override string ToString()
    {
        string result = "";
        foreach (var vector in _vectors)
        {
            result += vector.ToString() + "\n";
        }
        return result;
    }
}


