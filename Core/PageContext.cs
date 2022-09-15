using AngleSharp.Dom.Html;
using HTML_Parser.Abstract;
using HtmlParser = AngleSharp.Parser.Html.HtmlParser;

namespace HTML_Parser;

public class PageContext<T> where T : class
{
    private IPage<T> _page;
    private IPageSettings _pageSettings;

    private JsonFile<T> _file;
    private Client _client;

    public PageContext(IPage<T> page)
    {
        _page = page;
        _file = new JsonFile<T>();
    }
    
    
    public PageContext(IPage<T> page, IPageSettings pageSettings) : this(page)
    {
        _pageSettings = pageSettings;

        _client = new Client(_pageSettings); 
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