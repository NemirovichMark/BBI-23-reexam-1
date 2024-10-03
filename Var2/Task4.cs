using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Variant_2.Task3;
#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
//using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
#endregion
namespace Variant_2
{
    public class Task4
    {
        private Grep _Greper;
        
        public Grep Greper
        {
            get { return Greper; }
        }

        public interface ICreator
        {
            void Write<T>(string path, T data);
            T Read<T>(string path);
        }
        public interface IDataSerializer
        {
            void CreateFolder(string path, string folderName);
            void CreateFile(string path, string fileName);
            void CreateFolders(string path, string[] folderNames);
            void CreateFiles(string path, string[] fileNames);
        }
        public class DataSerializer : IDataSerializer, ICreator
        {
            public void CreateFile(string path, string fileName)
            {
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath).Dispose();
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (var fileName in fileNames)
                {
                    CreateFile(path, fileName);
                }
            }

            public void CreateFolder(string path, string folderName)
            {
                string fullPath = Path.Combine(path, folderName);
                Directory.CreateDirectory(fullPath);
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (var folderName in folderNames)
                {
                    CreateFolder(path, folderName);
                }
            }

            public void Write<T>(string path, T data)
            {
                var json = JsonSerializer.Serialize(data);
                File.WriteAllText(path, json);
            }
            public T Read<T>(string path)
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json);
            }


        }

        public Task4(Grep greper)
        {
            _Greper = greper;
        }
    }
}