using System.Net;
using HTML_Parser.Abstract;

namespace HTML_Parser.Core;

public class Client
{
    private readonly HttpClient _client;
    private readonly string _url;

    public Client(IPageSettings settings)
    {
        _client = new HttpClient();
        _url = settings.Url; 
    }
    
    public async Task<string> LoadHtml()
    {
        var response = await _client.GetAsync(_url);
        string source = null;
        if (source == null) throw new ArgumentNullException(nameof(source));

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