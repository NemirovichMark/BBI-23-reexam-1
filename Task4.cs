using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Task3;
#region Выберите библиотеку(и) для сериализации
using Newtonsoft;
using System.Text.Json;
using System.Text.Json.Serialization;
#endregion
namespace Variant_3
{
    public class Task4
    {
        public interface ICreator
        {
            void CreateFolder(string path, string folderName);

            void CreateFile(string path, string fileName);

            void CreateFolders(string path, string[] folderNames);

            void CreateFiles(string path, string[] fileNames);
        }
        public abstract class SerializerInFormate
        {
            public abstract void Write<T>(string path, T obj);

            public abstract T Read<T>(string path);
        }

        public class SerializerInJson : SerializerInFormate, ICreator
        {
            private Searcher _palindromeSearcher;

            public Searcher PalindromeSearcher => _palindromeSearcher;

            public SerializerInJson(Searcher searcher)
            {
                _palindromeSearcher = searcher;
            }

            public override void Write<T>(string path, T obj)
            {
                string json = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, json);
            }

            public override T Read<T>(string path)
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json);
            }

            public void CreateFolder(string path, string folderName)
            {
                string fullPath = Path.Combine(path, folderName);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
            }

            public void CreateFile(string path, string fileName)
            {
                string fullPath = Path.Combine(path, fileName);
                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath).Dispose();
                }
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (var folderName in folderNames)
                {
                    CreateFolder(path, folderName);
                }
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (var fileName in fileNames)
                {
                    CreateFile(path, fileName);
                }
            }
        }

        public class DataSerializer
        {
            private readonly SerializerInFormate _serializer;

            public DataSerializer(SerializerInFormate serializer)
            {
                _serializer = serializer;
            }

            public DataSerializer()
            {
            }

            public void SerializeSearcher(string path, Searcher searcher)
            {
                _serializer.Write(path, searcher);
            }

            public Searcher DeserializeSearcher(string path)
            {
                return _serializer.Read<Searcher>(path);
            }

            public void SerializeObject<T>(string path, T obj)
            {
                _serializer.Write(path, obj);
            }

            public T DeserializeObject<T>(string path)
            {
                return _serializer.Read<T>(path);
            }

            public void CreateFolder(string v1, string v2)
            {
                throw new NotImplementedException();
            }

            public void CreateFile(string path, string v)
            {
                throw new NotImplementedException();
            }

            public void CreateFile(string path, string[] strings)
            {
                throw new NotImplementedException();
            }

            public object Read<T>(string path)
            {
                throw new NotImplementedException();
            }

            public void Write(Searcher searcherer, string path)
            {
                throw new NotImplementedException();
            }

            public void CreateFolder(string path, string[] strings)
            {
                throw new NotImplementedException();
            }
        }
    }
}

