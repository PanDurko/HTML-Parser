using System.Text.Json.Serialization;
using AngleSharp.Parser.Html;
using AngleSharp.Html.Parser;
using HTML_Parser.Abstract;
using HtmlParser = AngleSharp.Parser.Html.HtmlParser;

namespace HTML_Parser;

public class ParserWorker<T> where T : class
{
    private IParser<T> _parser;
    private IParserSettings _parserSettings;

    private JsonConverter<T> _converter;
    private HtmlLoader _loader;

    public IParser<T> Parser
    {
        get
        {
            return _parser;
        }
        set
        {
            _parser = value;
        }
    }
    
    public IParserSettings Settings
    {
        get
        {
            return _parserSettings;
        }
        set
        {
            _parserSettings = value;
            _loader = new HtmlLoader(value);
        }
    }

    public ParserWorker(IParser<T> parser)
    {
        _parser = parser;
        _converter = new JsonConverter<T>();
    }
    
    
    public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
    {
        _parserSettings = parserSettings;
    }

    public async Task StartParsing()
    {
        var source = await _loader.LoadHtml();
        var domParser = new HtmlParser();

        var document = await domParser.ParseAsync(source);
        
        _converter.WriteDataToJsonFile(_parser.Parse(document));
    }
}