using BlazorServerStyle.Models;
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
        return await _http.GetFromJsonAsync<List<LayoutNode>>("api/layout");
    }
}