using Newtonsoft.Json;

namespace HTML_Parser;

public class JsonFile<T> where T : class
{
    private readonly string _path = @"C:/Users/ASUS/Desktop/FilmsData.json";
    
    public void CreateJsonFile(T data)
    {
        using (StreamWriter file = File.CreateText(_path))
        {
            SerializeData(data, file);
        }
        
        Console.WriteLine($"Data saved to JSON! Path: {_path}");
    }

    private static void SerializeData(T data, StreamWriter file)
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, data);
    }
}