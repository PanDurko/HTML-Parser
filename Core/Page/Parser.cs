using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using HTML_Parser.Abstract;

namespace HTML_Parser;

public class Parser : IParser<string[]>
{
    public string[] Parse(IHtmlDocument document)
    {
        List<string> films = new List<string>();
        var elements = document.GetElementById("main").QuerySelectorAll("li");

        foreach (var element in elements)
        {
            films.Add(element.TextContent.Trim());
        }

        return films.ToArray();
    }
}