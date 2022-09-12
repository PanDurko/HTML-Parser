using HTML_Parser;

public class Program
{
    public static async Task Main(string[] args)
    {
        ParserWorker<string[]> worker = new ParserWorker<string[]>(new Parser());
        worker.Settings = new ParserSettings(); 
        
        await worker.StartParsing();
    }
}
