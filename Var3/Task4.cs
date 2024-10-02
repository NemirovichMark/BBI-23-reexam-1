using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Task3;
#region Выберите библиотеку(и) для сериализации
using System.Text.Json;
#endregion
namespace Variant_3
{
    public class Task4
    {
        public interface ICreator
        {
            void CreateFolder(string path, string folderName);
            void CreateFile(string path, string fileName);
            void CreateFolders(string basePath, string[] folderNames);
            void CreateFiles(string basePath, string[] fileNames);
        }

        public abstract class SerializerInFormate
        {
            public abstract void Write<T>(T obj, string path);
            public abstract T Read<T>(string path);
        }

        public class SerializerInJson : SerializerInFormate, ICreator
        {
            public override void Write<T>(T obj, string path)
            {
                var jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, jsonString);
            }

            public override T Read<T>(string path)
            {
                var jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(jsonString);
            }

            public void CreateFolder(string path, string folderName)
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }

            public void CreateFile(string path, string fileName)
            {
                File.Create(Path.Combine(path, fileName)).Dispose(); 
            }

            public void CreateFolders(string basePath, string[] folderNames)
            {
                foreach (var folderName in folderNames)
                {
                    CreateFolder(basePath, folderName);
                }
            }

            public void CreateFiles(string basePath, string[] fileNames)
            {
                foreach (var fileName in fileNames)
                {
                    CreateFile(basePath, fileName);
                }
            }
        }

        private SerializerInJson serializer; 
        private Searcher searcher; 

        public Task4(Searcher searcher)
        {
            this.searcher = searcher;
            this.serializer = new SerializerInJson();
        }

        public void SaveToFile(string path)
        {
            serializer.Write(searcher, path);
        }

        public Searcher LoadFromFile(string path)
        {
            return serializer.Read<Searcher>(path);
        }
    }
}
