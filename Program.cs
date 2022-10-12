using HTML_Parser.Core;
using HTML_Parser.Core.Page;

namespace HTML_Parser;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var context = new PageContext<string[]>(new Page("main", "li"), new PageSettings("https://www.imdb.com/calendar/"));

        await context.StartParsing();
    }
}