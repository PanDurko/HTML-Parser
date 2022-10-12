using HTML_Parser.Abstract;

namespace HTML_Parser.Core.Page;

public class PageSettings : IPageSettings
{
    public string Url { get; set; }

    public PageSettings(string url)
    {
        Url = url; 
    }
}