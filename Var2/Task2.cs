using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Variant_2.Task2;

namespace Variant_2
{
	public class Task2
	{
		public struct Point
		{
			public double[] Coordinates; // Изменяем на массив

			public Point(double x, double y)
			{
				Coordinates = new double[] { x, y }; // Инициализируем массив
			}
		}

		abstract public class Fourangle
		{
			protected Point[] points;

			public Fourangle(Point[] points)
			{
				if (points.Length != 4)
				{
					this.points = new Point[4];
				}
				else
				{
					this.points = points;
				}
			}

			public abstract double CalculatePerimeter();
			public abstract double CalculateArea();

			public override string ToString()
			{
				return $"{GetType().Name} = {CalculatePerimeter():F2}, = {CalculateArea():F2}";
			}
		}

		public class Square : Fourangle
		{
			public Square(Point[] points) : base(points) { }

			public override double CalculatePerimeter()
			{
				double side = Math.Sqrt(Math.Pow(points[0].Coordinates[0] - points[1].Coordinates[0], 2) + Math.Pow(points[0].Coordinates[1] - points[1].Coordinates[1], 2));
				return 4 * side;
			}

			public override double CalculateArea()
			{
				double side = Math.Sqrt(Math.Pow(points[0].Coordinates[0] - points[1].Coordinates[0], 2) + Math.Pow(points[0].Coordinates[1] - points[1].Coordinates[1], 2));
				return side * side;
			}
		}

		public class Rectangle : Fourangle
		{
			public Rectangle(Point[] points) : base(points) { }

			public override double CalculatePerimeter()
			{
				double perimeter = 0;
				for (int i = 0; i < 3; i++)
				{
					perimeter += Math.Sqrt(Math.Pow(points[i].Coordinates[0] - points[i + 1].Coordinates[0], 2) + Math.Pow(points[i].Coordinates[1] - points[i + 1].Coordinates[1], 2));
				}
				perimeter += Math.Sqrt(Math.Pow(points[3].Coordinates[0] - points[0].Coordinates[0], 2) + Math.Pow(points[3].Coordinates[1] - points[0].Coordinates[1], 2));
				return perimeter;
			}

			public override double CalculateArea()
			{
				double length = Math.Abs(points[0].Coordinates[0] - points[1].Coordinates[0]);
				double width = Math.Abs(points[0].Coordinates[1] - points[2].Coordinates[1]);
				return length * width;
			}
		}

		private Fourangle[] fourangles;

		public Task2(Fourangle[] fourangles)
		{
			this.fourangles = fourangles;
		}

		public void PrintFigures()
		{
			foreach (var figure in fourangles)
			{
				Console.WriteLine(figure);
			}
		}
		static void Main(string[] args)
		{
			// Создание фигур
			Fourangle[] figures = {
				new Rectangle(new Point[] { new Point(0, 0), new Point(4, 0), new Point(4, 3), new Point(0, 3) }),
				new Square(new Point[] { new Point(1, 1), new Point(5, 1), new Point(5, 5), new Point(1, 5) }),
				new Rectangle(new Point[] { new Point(2, 2), new Point(6, 2), new Point(6, 7), new Point(2, 7) })
			};

			// Создание объекта Task2
			Task2 manager = new Task2(figures);

			// Вывод фигур на консоль
			manager.PrintFigures();

			Console.ReadLine();
		}
	}

}