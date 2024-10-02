using System.Reflection;
using static Task1;
using static Task2;

public class Task2
{
    public abstract class Shape
    {
        private Dot _center;
        private Vector _pointer;

        public Shape(Dot center)
        {
            _center = center;
        }

        public Dot Center => _center;
        public Vector Pointer => _pointer;

        
        public void CreateVector(Dot point)
        {
            _pointer = new Vector(_center, point);
        }

        
        public abstract double Volume();

        public override string ToString()
        {
            return $"{GetType().Name} with V = {Volume():F2}";
        }
    }


    private Shape[] _shapes;

   
    public Shape[] Shapes => _shapes;

    
    public Task2(Shape[] shapes)
    {
        _shapes = shapes;
    }

    public void Sorting()
    {

        int i = 1;
        while (i < _shapes.Length)
        {
            if (i == 0 || _shapes[i - 1].Volume() <= _shapes[i].Volume())
            {
                i++;
            }
            else
            {

                Shape temp = _shapes[i];
                _shapes[i] = _shapes[i - 1];
                _shapes[i - 1] = temp;
                i--;
            }
        }
    }
}
public class Sphere : Shape
{
        public Sphere(Dot center) : base(center) { }

        
        public override double Volume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Pointer.Length(), 3);
        }
}

public class Cube : Shape
{
    
    public Cube(Dot center) : base(center) { }

        
    public override double Volume()
    {
    return Math.Pow(Pointer.Length() * 2, 3);
    }
}





//2.В классe Task2 заполните абстрактный класс Shape, представляющую геометрическую фигуру с полем для центра фигуры Dot и полем для описания радиус-вектора фигуры Vector,
//    свойствами для их чтения: Center и Pointer соответственно. В конструктор класса Shape нужно передавать центральную точку Dot. Создать в классе Shape метод CreateVector,
//    который принимает в себя точку Dot и заполняет поле вектора объектом Vector, соединяющий эту точку с центром фигуры. Создайте абстрактный метод Volume().
//    Переопределите метод ToString() для вывода фигуры на консоль в формате “a with V = b”, где a - тип фигуры, b - объем фигуры.
//    Создайте связь родитель-наследник от класса Shape для классов Sphere, Cube. Переопределите метод для вычисления объёма каждой из этих фигур, используя длину вектора. 
//    В классе Task2 создайте массив из фигур и свойство Shapes для его чтения. Напишите метод Sorting() для сортировки фигур по увеличению объема.
//    Переопределите метод ToString() для вывода фигур на консоль построчно.
