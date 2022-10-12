using Newtonsoft.Json;

namespace HTML_Parser.Core;

public class JsonFile<T> where T : class
{
    private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    
    public void CreateJsonFile(T data)
    {
        using (var file = File.CreateText(_path))
        {
            SerializeData(data, file);
        }
        
        Console.WriteLine($"Data saved to JSON! Path: {_path}");
    }

    private static void SerializeData(T data, TextWriter file)
    {
        var serializer = new JsonSerializer();
        serializer.Serialize(file, data);
    }
}