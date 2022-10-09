using AngleSharp.Dom.Html;

namespace HTML_Parser.Abstract;

public interface IPage<T> where T : class
{
    T Parse(IHtmlDocument document); 
}