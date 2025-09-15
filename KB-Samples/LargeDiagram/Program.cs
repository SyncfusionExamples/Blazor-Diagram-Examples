using LargeDiagram;
using LargeDiagram.Components;
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.JSInterop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddControllers();
builder.Services.AddServerSideBlazor().AddHubOptions(o =>
{
    o.MaximumReceiveMessageSize = 102400000; // Increased limit to handle large JSON data
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();
app.Run();
