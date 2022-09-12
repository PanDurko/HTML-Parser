using AngleSharp.Dom.Html;

namespace HTML_Parser.Abstract;

public interface IParser<T> where T : class
{
    T Parse(IHtmlDocument document); 
}