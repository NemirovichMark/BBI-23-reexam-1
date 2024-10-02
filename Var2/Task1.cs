using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
	public class Task1
	{
		public struct Point
		{
			// Изменяем на массив
			public double[] Coordinates;

			public Point(double x, double y)
			{
				// Инициализируем массив
				Coordinates = new double[] { x, y };
			}

			public override string ToString()
			{
				return $"x = {Coordinates[0]}, y = {Coordinates[1]}";
			}

			public double DistanceTo(Point other)
			{
				return Math.Round(Math.Sqrt(Math.Pow(Coordinates[0] - other.Coordinates[0], 2) + Math.Pow(Coordinates[1] - other.Coordinates[1], 2)), 2);
			}
		}

		private Point[] points;

		public Task1(Point[] points)
		{
			if (points.Length != 2)
			{
				throw new ArgumentException("Массив должен содержать 2 точки.");
			}
			this.points = points;
		}

		public override string ToString()
		{
			string result = "";
			foreach (Point point in points)
			{
				result += point.ToString() + " ";
			}
			return result;
		}

		public static string GetPointInfo(Point[] points)
		{
			string result = "";
			result += points[0].ToString() + " ";
			result += points[1].ToString() + " ";
			result += $"Расстояние между точками: {points[0].DistanceTo(points[1])}";
			return result;
		}
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			Task1.Point[] points = new Task1.Point[] { new Task1.Point(1, 2), new Task1.Point(3, 4) };
			Task1 collection = new Task1(points);
			Console.WriteLine(collection);

			Console.WriteLine(Task1.GetPointInfo(points));
			Console.ReadKey();
		}
	}
}