using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task2
    {
        public abstract class Shape
        {
            protected Task1.Dot center;
            protected Task1.Vector pointer;

            public Task1.Dot Center { get { return center; } }
            public Task1.Vector Pointer {  get { return pointer; } }

            public Shape(Task1.Dot c)
            {
                center = c;
            }

            public void CreateVector(Task1.Dot d)
            {
                pointer = new Task1.Vector(d, center);
            }

            public abstract double Volume();

            public override string ToString()
            {
                Console.WriteLine("a with V = b");
                return "Done";
            }
        }
        
        public class Sphere : Shape
        {
            public Sphere(Task1.Dot c) : base(c) { }

            public override double Volume()
            {
                return Math.PI * Math.Pow(pointer.Length(), 3) * 4 / 3;
            }

            public override string ToString()
            {
                Console.WriteLine($"Sphere with V = {Volume()}");
                return "Done";
            }
        }

        public class Cube : Shape
        {
            public Cube(Task1.Dot c) : base(c) { }

            public override double Volume()
            {
                return Math.Pow(pointer.Length() * 2, 3);
            }

            public override string ToString()
            {
                Console.WriteLine($"Cube with V = {Volume()}");
                return "Done";
            }
        }

        private Shape[] shapes;
        public Shape[] Shapes { get { return shapes; } }

        public Task2(Shape[] s)
        {
            shapes = s;
        }

        public override string ToString()
        {
            foreach (Shape s in shapes)
            {
                s.ToString();
            }
            return "Done";
        }

        public void Sorting()
        {
            QuickSort(0, shapes.Length - 1);
        }

        private void QuickSort(int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            double pivot = shapes[0].Volume();
            while (i <= j)
            {
                while (shapes[i].Volume() < pivot)
                {
                    i++;
                }

                while (shapes[i].Volume() > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    Shape temp = shapes[i];
                    shapes[i] = shapes[j];
                    shapes[j] = temp;
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