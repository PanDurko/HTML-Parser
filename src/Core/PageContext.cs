using AngleSharp.Dom.Html;
using HTML_Parser.Abstract;
using HtmlParser = AngleSharp.Parser.Html.HtmlParser;

namespace HTML_Parser.Core;

public class PageContext<T> where T : class
{
    private readonly IPage<T> _page;

    private readonly JsonFile<T> _file;
    private readonly Client _client;

    private PageContext(IPage<T> page)
    {
        _page = page;
        _file = new JsonFile<T>();
    }
    
    
    public PageContext(IPage<T> page, IPageSettings pageSettings) : this(page)
    {
        _client = new Client(pageSettings); 
    }

    private async Task<IHtmlDocument> GetHtmlDocument()
    {
        var source = await _client.LoadHtml();
        var domParser = new HtmlParser();

        var document = await domParser.ParseAsync(source);
        return document;
    }
    
    public async Task StartParsing()
    {
        var document = await GetHtmlDocument();
        var parsedData = _page.Parse(document); 
        
        _file.CreateJsonFile(parsedData);
    }
}