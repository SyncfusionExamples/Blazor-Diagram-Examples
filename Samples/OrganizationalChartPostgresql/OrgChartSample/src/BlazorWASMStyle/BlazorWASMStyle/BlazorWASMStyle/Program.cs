using BlazorWASMStyle.Client.Pages;
using BlazorWASMStyle.Components;
using Services;
using Syncfusion.Blazor;
using Microsoft.EntityFrameworkCore;
using BlazorWASMStyle.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();
// Add controllers and DbContext
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register a server-side HttpClient-backed LayoutService so components can be
// prerendered on the server. The client project also registers LayoutService
// for the WebAssembly runtime.
builder.Services.AddHttpClient<LayoutService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5252");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseAuthorization();

app.MapControllers();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWASMStyle.Client._Imports).Assembly);

app.Run();
