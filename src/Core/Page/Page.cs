using AngleSharp.Dom.Html;
using HTML_Parser.Abstract;

namespace HTML_Parser;

public class Page : IPage<string[]>
{
    private string _elementId;
    private string _selectors;

    public Page(string elementId, string selectors)
    {
        _elementId = elementId;
        _selectors = selectors; 
    }
    
    public string[] Parse(IHtmlDocument document)
    {
        List<string> films = new List<string>();
        var elements = document.GetElementById(_elementId).QuerySelectorAll(_selectors);

        foreach (var element in elements)
        {
            films.Add(element.TextContent.Trim());
        }
        
        return films.ToArray();
    }
}