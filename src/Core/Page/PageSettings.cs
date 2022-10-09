using HTML_Parser.Abstract;

namespace HTML_Parser;

public class PageSettings : IPageSettings
{
    public string Url { get; set; }

    public PageSettings(string url)
    {
        Url = url; 
    }
}