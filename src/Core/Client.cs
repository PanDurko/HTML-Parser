using System.Net;
using HTML_Parser.Abstract;

namespace HTML_Parser;

public class Client
{
    private HttpClient _client;
    private string _url;

    public Client(IPageSettings settings)
    {
        _client = new HttpClient();
        _url = settings.Url; 
    }
    
    public async Task<string> LoadHtml()
    {
        var response = await _client.GetAsync(_url);
        string source = null;

        bool CanConnectToPage()
        {
            return response.StatusCode == HttpStatusCode.OK;
        }

        if (CanConnectToPage())
        {
            source = await response.Content.ReadAsStringAsync();
        }

        return source;
    }
}