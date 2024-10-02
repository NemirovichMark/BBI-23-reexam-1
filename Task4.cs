using System.IO;
using Newtonsoft.Json;

public interface IDataSerializer
{
    void Write<T>(string path, T obj);
    T Read<T>(string path);
}

public interface ICreator
{
    void CreateFolder(string path, string folderName);
    void CreateFile(string path, string fileName);
    void CreateFolders(string path, string[] folderNames);
    void CreateFiles(string path, string[] fileNames);
}

public class DataSerializer : IDataSerializer, ICreator
{
    private Grep _grepInstance;

    public Grep GrepInstance
    {
        get => _grepInstance;
        private set => _grepInstance = value;
    }

    public void Write<T>(string path, T obj)
    {
        var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public T Read<T>(string path)
    {
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json);
    }

    public void CreateFolder(string path, string folderName)
    {
        Directory.CreateDirectory(Path.Combine(path, folderName));
    }

    public void CreateFile(string path, string fileName)
    {
        File.Create(Path.Combine(path, fileName)).Dispose();
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

public class Grep
{
    public string Pattern { get; set; }
    public string[] Files { get; set; }
  
}
