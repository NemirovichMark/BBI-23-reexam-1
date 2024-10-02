using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using static Task3;
#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
// using System.Text.Json;
// using System.Text.Json.Serialization;
#endregion
namespace Variant_3
{
    public class Task4
    {
        public abstract class SerializerInFormat
        {
            public abstract void Write(string path, object obj);
            public abstract object Read(string path);
        }

        public class SerializerInJson : SerializerInFormat, ICreator
        {
            private Searcher _palindomeSearcher;
            public Searcher PalindomeSearcher { get; }

            public SerializerInJson(Searcher palindomeSearcher)
            {
                _palindomeSearcher = palindomeSearcher;
                PalindomeSearcher = palindomeSearcher;
            }

            public override void Write(string path, object obj)
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, jsonString);
            }

            public override object Read(string path)
            {
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<Searcher>(jsonString);
            }

            public void CreateFolder(string path, string folderName)
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }

            public void CreateFile(string path, string fileName)
            {
                File.Create(Path.Combine(path, fileName)).Close();
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (string folderName in folderNames)
                {
                    CreateFolder(path, folderName);
                }
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (string fileName in fileNames)
                {
                    CreateFile(path, fileName);
                }
            }
        }

        public interface ICreator
        {
            void CreateFolder(string path, string folderName);
            void CreateFile(string path, string fileName);
            void CreateFolders(string path, string[] folderNames);
            void CreateFiles(string path, string[] fileNames);
        }

        public class Searcher
        {
        }
        //public static void Main(string[] args)
        //{
        //    string text = "Anna went to see civic duties with her level radar";
        //    Searcher searcher = new Searcher(text);
        //    SerializerInJson jsonSerializer = new SerializerInJson(searcher);
        //    jsonSerializer.Write("path/to/file.json", searcher);
        //    Searcher loadedSearcher = (Searcher)jsonSerializer.Read("path/to/file.json");
        //    jsonSerializer.CreateFolder("path/to/folder", "new_folder");
        //    jsonSerializer.CreateFile("path/to/folder", "new_file.txt");
        //    jsonSerializer.CreateFolders("path/to/folder", new string[] { "folder1", "folder2" });
        //    jsonSerializer.CreateFiles("path/to/folder", new string[] { "file1.txt", "file2.txt" });
        //}
    }
}
