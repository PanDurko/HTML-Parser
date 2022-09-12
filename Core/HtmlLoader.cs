using System.Net;
using HTML_Parser.Abstract;

namespace HTML_Parser;

public class HtmlLoader
{
    private HttpClient _client;
    private string _url;

    public HtmlLoader(IParserSettings settings)
    {
        _client = new HttpClient();
        _url = settings.Url; 
    }
    
    public async Task<string> LoadHtml()
    {
        var response = await _client.GetAsync(_url);
        string source = null;

        if (response != null && response.StatusCode == HttpStatusCode.OK)
        {
            source = await response.Content.ReadAsStringAsync();
        }

        return source;
    }
}