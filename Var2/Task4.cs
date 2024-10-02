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
#endregion
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Variant_2.Task3;

namespace Variant_2
{
    public class Task4
    {
        public interface ICreator
        {
            void CreateFolder(string path, string folderName);

            void CreateFolders(string path, string[] folderNames);

            void CreateFile(string path, string fileName);

            void CreateFiles(string path, string[] fileNames);
        }

        public interface IDataSerializer
        {
            void Write<T>(string path, T obj);

            T Read<T>(string path);
        }

        public class DataSerializer : ICreator, IDataSerializer
        {
            public void CreateFolder(string path, string folderName)
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (var folderName in folderNames)
                {
                    CreateFolder(path, folderName);
                }
            }

            public void CreateFile(string path, string fileName)
            {
                using (File.Create(Path.Combine(path, fileName))) { }
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (var fileName in fileNames)
                {
                    CreateFile(path, fileName);
                }
            }

            public void Write<T>(string path, T obj)
            {
                var json = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, json);
            }

            public T Read<T>(string path)
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json);
            }

            public void CreateFolder(string path, string[] strings)
            {
                throw new NotImplementedException();
            }

            public void CreateFile(string path, string[] strings)
            {
                throw new NotImplementedException();
            }

            public void Write(Grep greper, string path)
            {
                throw new NotImplementedException();
            }
        }

        private Grep greper;

        public Grep Greper => greper;

        public Task4(Grep grep)
        {
            greper = grep;
        }
    }
}