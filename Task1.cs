using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task1
    {
        private Vector[] vectors;

        public Vector[] Vectors { get { return vectors; } }

        public struct Dot
        {
            private int x;
            private int y;
            private int z;

            public int X { get { return x; } }
            public int Y { get { return y; } }
            public int Z { get { return z; } }

            public Dot(int[] coords)
            {
                if (coords.Length != 3)
                {
                    x = 0; y = 0; z = 0;
                }
                else
                {
                    x = coords[0]; y = coords[1]; z = coords[2];
                }
            }

            public override string ToString()
            {
                Console.WriteLine($"x = {x}, y = {y}, z = {z}");
                return "Done";
            }
        }

        public struct Vector
        {
            private Dot a;
            private Dot b;

            public Dot A { get { return a;} }
            public Dot B { get { return b;} }

            public Vector(Dot start, Dot end)
            {
                a = start; b = end;
            }

            public double Length()
            {
                return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
            }

            public override string ToString()
            {
                Console.Write("A: ");
                a.ToString();
                Console.Write("B: ");
                b.ToString();
                Console.WriteLine($"Length: {Length()}");
                return "Done";
            }
        }

        public Task1(Vector[] vectorsArray)
        {
            vectors = vectorsArray;
        }

        public override string ToString()
        {
            foreach(Vector v in vectors)
            {
                v.ToString();
            }
            return "Done";
        }

        public void Sorting()
        {
            QuickSort(0, vectors.Length - 1);
        }

        private void QuickSort(int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            double pivot = vectors[0].Length();
            while (i <= j)
            {
                while (vectors[i].Length() < pivot)
                {
                    i++;
                }

                while (vectors[i].Length() > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    Vector temp = vectors[i];
                    vectors[i] = vectors[j];
                    vectors[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(leftIndex, j);
            if (i < rightIndex)
                QuickSort(i, rightIndex);
        }
    }
}