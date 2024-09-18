using System.IO;
using DiagramWithRemoteData.Components;
using DiagramWithRemoteData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
string _contentRootPath = "";
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
var env = builder.Environment;
builder.Configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
_contentRootPath = env.ContentRootPath;
ServerPath.MapPath = _contentRootPath;
string connection = builder.Configuration.GetConnectionString("DataBase");
if (connection.Contains("|DataDirectory|"))
{
    connection = connection.Replace("|DataDirectory|", _contentRootPath);
}
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connection));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options =>
{
    options.DetailedErrors = true;
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    await dbContext.Database.EnsureCreatedAsync();
    await dbContext.SeedDataAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public class ServerPath
{
    public static string MapPath = "";
}