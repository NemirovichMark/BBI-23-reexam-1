using System;

namespace Variant_3
{
    public class Task1
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
                double deltaX = Math.Abs(this.b.X - this.a.X);
                double deltaY = Math.Abs(this.b.Y - this.a.Y);
                double deltaZ = Math.Abs(this.b.Z - this.a.Z);

                return Math.Round(Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ), 2);
            }

            
            public override string ToString()
            {
                return $"{A.ToString()}\n{B.ToString()}\nLength = {Length()}";
            }
        }

        
        private Vector[] list;

        
        public Vector[] Vectors { get { return list; } }

        
        public Task1(Vector[] list)
        {
            this.list = list;
        }

        
        public void Sorting()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list.Length - 1; j++)
                {
                    if (list[j].Length() > list[j + 1].Length())
                    {
                        
                        Vector temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    }
}