using HTML_Parser;

public class Program
{
    public static async Task Main(string[] args)
    {
        PageContext<string[]> context = new PageContext<string[]>(new Page("main", "li"), new PageSettings("https://www.imdb.com/calendar/"));

        await context.StartParsing();
    }
}
