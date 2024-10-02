#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
// using System.Text.Json;
// using System.Text.Json.Serialization;
#endregion

using Variant_3;

public class Program
{
    public static void Main()
    {
        Task1.Dot dot1 = new Task1.Dot(new int[5]);
        int[] a = { 0, 0, 1 };
        int[] b = { 0, 1, 1 };
        int[] c = { 1, 1, 1 };
        Task1.Dot dot2 = new Task1.Dot(a);
        Task1.Dot dot3 = new Task1.Dot(b);
        Task2.Sphere s = new Task2.Sphere(dot1);
        Task2.Sphere h = new Task2.Sphere(dot1);
        s.CreateVector(dot2);
        h.CreateVector(dot3);
        Task2.Shape[] shapes = {h, s};
        Task2 tsk = new Task2(shapes);
        tsk.ToString();
        tsk.Sorting();
        tsk.ToString();
        string gh = "aa asa rrr errtt assa ddss qweewq 1weew1";
        Task3 tsk3 = new Task3(gh);
        Console.WriteLine(tsk3.ToString());
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Task3.Searcher searcher = new Task3.Searcher("aa asa rrr errtt assa ddss qweewq 1weew1");
        Task4.SerializerInJson serializer = new Task4.SerializerInJson();
        serializer.Write(tsk3.PalindromeSearcher, Path.Combine(path, "answer.json"));
        Task3.Searcher sr = serializer.Read<Task3.Searcher>(Path.Combine(path, "answer.json"));
        sr.ToString();

    }
}