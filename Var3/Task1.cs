//В классе Task1 заполните структуру Dot, представляющую собой точку в трехмерном пространстве (x, y, z) со свойствами для чтения её координат X, Y, Z.
    //В конструктор точки нужно передавать массив целых чисел и проверять его на корректную длину. Если длина массива не равна 3, заполнять структуру нулями.
    //Переопределите метод ToString() для вывода информации о точке в формате:  “x = 1, y = 2, z = 3”, , где 1, 2, 3 - значения полей x, y и z. В классе Task1
    //заполните структуру Vector, представляющую собой вектор, составленный из двух точек Dot и свойствами для их чтения A и B. В конструктор передавать 2 точки:
    //начальную и конечную. Напишите метод Length() для вычисления длины вектора. Переопределите метод ToString() для вывода информации о векторе построчно: координаты
    //первой точки, координаты второй точки и длина вектора (“Length = дробное число“). В классе Task1 создайте приватное поле для массива векторов и свойство Vectors для
    //чтения этого массива. Переопределите метод ToString() для вывода всех элементов массива Vectors на консоль построчно. Напишите метод Sorting() для сортировки векторов
    //в массиве Vectors по возрастанию их длины (чем выше скорость сортировки, тем больше баллов за выполнение).
public class Task1
{
    private Vector[] _vectors;

    public Vector[] Vectors
    {
        get { return _vectors; }
    }

    public Task1(Vector[] vectors)
    {
        _vectors = vectors;
    }

    public override string ToString()
    {
        string result = string.Empty;
        foreach (var vector in _vectors)
        {
            result += vector.ToString() + "\n";
        }
        return result;
    }

    public void Sorting()
    {
        int n = _vectors.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (_vectors[j].Length() > _vectors[j + 1].Length())
                {
                    Vector temp = _vectors[j];
                    _vectors[j] = _vectors[j + 1];
                    _vectors[j + 1] = temp;
                }
            }
        }
    }
    public struct Dot
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Dot(double[] coordinates)
        {
            if (coordinates.Length != 3)
            {
                X = 0;
                Y = 0;
                Z = 0;
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
        public Dot A { get; private set; }
        public Dot B { get; private set; }

        public Vector(Dot a, Dot b)
        {
            A = a;
            B = b;
        }

        public double Length()
        {
            double dx = B.X - A.X;
            double dy = B.Y - A.Y;
            double dz = B.Z - A.Z;
            return Math.Round(Math.Sqrt(dx * dx + dy * dy + dz * dz),2);
        }

        public override string ToString()
        {
            return $"{A.ToString()}\n{B.ToString()}\nLength = {(Length())}\n";
   

        }
    }


}
