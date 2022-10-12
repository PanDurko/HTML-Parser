using AngleSharp.Dom.Html;

namespace HTML_Parser.Abstract;

public interface IPage<out T> where T : class
{
    T Parse(IHtmlDocument document); 
}