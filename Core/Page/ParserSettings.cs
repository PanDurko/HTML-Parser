using HTML_Parser.Abstract;

namespace HTML_Parser;

public class ParserSettings : IParserSettings
{
    public string Url { get; set; } = "https://www.imdb.com/calendar/";
}