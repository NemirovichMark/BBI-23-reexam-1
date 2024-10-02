using System;
using System.IO;
using System.Text.Json;

namespace Variant_3
{
    
    public class Task4
    {
        interface ICreator
        {
            public void CreateFolder(string path, string name);
            public void CreateFile(string path, string name);
            public void CreateFolder(string[] paths, string[] names);
            public void CreateFile(string[] paths, string[] names);
        }

        public abstract class SerializerInFormate 
        {
            public abstract void Write<T>(T obj, string filePath);
            public abstract T Read<T>(string filePath);
        }

        public class SerializerInJson : SerializerInFormate, ICreator
        {
            private Task3.Searcher searcher = new Task3.Searcher("");
            public override void Write<T>(T obj, string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, obj);
                }
            }
            public override T Read<T>(string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    return JsonSerializer.Deserialize<T>(fs);
                }
            }

            public void CreateFolder(string path, string name)
            {
                string finalPath = Path.Combine(path, name);
                if (!Directory.Exists(finalPath)) Directory.CreateDirectory(finalPath);
            }
            public void CreateFolder(string[] paths, string[] names)
            {
                SerializerInJson serializer = new SerializerInJson();
                for (int i = 0; i < Math.Min(paths.Length, names.Length); i++)
                {
                    string finalPath = Path.Combine(paths[1], names[1]);
                    if (!Directory.Exists(finalPath)) Directory.CreateDirectory(finalPath);
                }
            }

            public void CreateFile(string path, string name)
            {
                Write(searcher, Path.Combine(path, name));
            }

            public void CreateFile(string[] paths, string[] names)
            {
                for (int i = 0; i < Math.Min(paths.Length, names.Length); i++)
                {
                    string finalPath = Path.Combine(paths[1], names[1]);
                    Write(searcher, finalPath);
                }
            }
        }

        private Task3.Searcher palindromeSearcher;
        private SerializerInJson serializer;

        public SerializerInJson Serializer {  get { return serializer; } }
        public Task3.Searcher PalindromeSearcher {  get {  return palindromeSearcher; } }
        public Task4(Task3.Searcher searcher)
        {
            palindromeSearcher = searcher;
        }
    }
}