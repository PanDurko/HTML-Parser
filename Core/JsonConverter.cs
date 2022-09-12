using Newtonsoft.Json;

namespace HTML_Parser;

public class JsonConverter<T> where T : class
{
    private readonly string _path = @"C:/Users/ASUS/Desktop/FilmsData.json";
    
    public void WriteDataToJsonFile(T data)
    {
        using (StreamWriter file = File.CreateText(_path))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, data);
        }
        
        Console.WriteLine($"Data saved to JSON! Path: {_path}");
    }
}