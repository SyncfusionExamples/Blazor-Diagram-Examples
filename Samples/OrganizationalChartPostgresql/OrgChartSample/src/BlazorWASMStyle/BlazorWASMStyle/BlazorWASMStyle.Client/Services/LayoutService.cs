using BlazorWASMStyle.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Services;   // change namespace for WASM project

public class LayoutService
{
    private readonly HttpClient _http;

    public LayoutService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<LayoutNode>?> GetOrgChartAsync()
    {
        // Use a relative path so HttpClient's BaseAddress (set in Program.cs)
        // determines the origin. Retry once to hide transient connection-refused
        // errors that can occur if the server isn't fully ready when the client
        // first attempts the fetch.
        const string relativeApi = "api/layout";
        for (int attempt = 0; attempt < 2; attempt++)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<LayoutNode>>(relativeApi);
            }
            catch (HttpRequestException)
            {
                if (attempt == 1)
                    throw;
                await Task.Delay(500);
            }
        }

        return null;
    }
}