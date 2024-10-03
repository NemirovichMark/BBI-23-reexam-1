
using static Task1;
using static Task2;
using static Task3;

public class Task1
{
    public struct Dot
    {
        private double _x;
        private double _y;
        private double _z;



        public Dot(double[] coordinates)
        {
            if (coordinates.Length != 3)
            {
                _x = 0;
                _y = 0;
                _z = 0;
            }
            else
            {
                _x = coordinates[0];
                _y = coordinates[1];
                _z = coordinates[2];
            }
        }
        public double X => _x;
        public double Y => _y;
        public double Z => _z;
        public override string ToString()
        {
            return $"x = {X}, y = {Y}, z = {Z}";
        }
    }


    public struct Vector
    {
        private Dot _a;
        private Dot _b;

       
        public Vector(Dot a, Dot b)
        {
            _a = a;
            _b = b;
        }

       
        public Dot A => _a;
        public Dot B => _b;

        
        public double Length()
        {
            return Math.Sqrt(Math.Pow(_b.X - _a.X, 2) + Math.Pow(_b.Y - _a.Y, 2) + Math.Pow(_b.Z - _a.Z, 2));
        }
        public override string ToString()
        {
            return $"A: {_a}nB: {_b}nLength = {Length()}";
        }
    }

    private Vector[] _vectors;
    
    public Vector[] Vectors => _vectors;
    public Task1(Vector[] vectors)
    {
        _vectors = vectors;
    }


    public override string ToString()
    {
        string output = "";
        foreach (var vector in _vectors)
        {
            output += $"{vector}n";
        }
        return output;
    }
    public void Sorting()
    {
        int i = 1;
        while (i < _vectors.Length)
        {
            if (i == 0 || _vectors[i - 1].Length() <= _vectors[i].Length())
            {
                i++;
            }
            else
            {
                Vector temp = _vectors[i];
                _vectors[i] = _vectors[i - 1];
                _vectors[i - 1] = temp;
                i--;
            }
        }
    }
}
//1.В классе Task1 заполните структуру Dot, представляющую собой точку в трехмерном пространстве (x, y, z) со свойствами для чтения её координат X, Y, Z. 
//    В конструктор точки нужно передавать массив целых чисел и проверять его на корректную длину.
//    Если длина массива не равна 3, заполнять структуру нулями. Переопределите метод ToString() для вывода информации о точке в формате:  “x = 1, y = 2, z = 3”, , где 1, 2, 3 - значения полей x, y и z.
//    В классе Task1 заполните структуру Vector, представляющую собой вектор, составленный из двух точек Dot и свойствами для их чтения A и B.
//    В конструктор передавать 2 точки: начальную и конечную. Напишите метод Length() для вычисления длины вектора.
//    Переопределите метод ToString() для вывода информации о векторе построчно: координаты первой точки, координаты второй точки и длина вектора (“Length = дробное число“).
//    В классе Task1 создайте приватное поле для массива векторов и свойство Vectors для чтения этого массива. Переопределите метод ToString() для вывода всех элементов массива Vectors на консоль построчно.
//    Напишите метод Sorting() для сортировки векторов в массиве Vectors по возрастанию их длины (чем выше скорость сортировки, тем больше баллов за выполнение).

