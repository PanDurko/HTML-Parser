using AngleSharp.Dom.Html;
using HTML_Parser.Abstract;

namespace HTML_Parser.Core.Page;

public class Page : IPage<string[]>
{
    private readonly string _elementId;
    private readonly string _selectors;

    public Page(string elementId, string selectors)
    {
        _elementId = elementId;
        _selectors = selectors; 
    }
    
    public string[] Parse(IHtmlDocument document)
    {
        var elements = document.GetElementById(_elementId).QuerySelectorAll(_selectors);

        return elements.Select(element => element.TextContent.Trim()).ToArray();
    }
}