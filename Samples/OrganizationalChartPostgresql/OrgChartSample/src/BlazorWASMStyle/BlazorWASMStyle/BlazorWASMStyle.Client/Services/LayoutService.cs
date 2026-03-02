using Shared.Models;
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
        // build an absolute URI using the registered BaseAddress if present,
        // otherwise fall back to an explicit API url
        var apiBase = _http.BaseAddress?.ToString() ?? "http://localhost:5176/";
        var uri = new Uri(new Uri(apiBase), "api/layout");
        return await _http.GetFromJsonAsync<List<LayoutNode>>(uri);
    }
}