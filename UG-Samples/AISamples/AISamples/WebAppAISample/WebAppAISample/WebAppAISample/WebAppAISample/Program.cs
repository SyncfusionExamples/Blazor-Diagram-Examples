using WebAppAISample.Components;
using Syncfusion.Blazor;
using AIService;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

// Register AzureAIService for server-side DI so components can inject it
// NOTE: Move secrets to configuration or user-secrets for production
string apiKey = "c71665b4639d46a5917c4a15f33e57a4";
string deploymentName = "gpt-4o-mini";
string endpoint = "https://openaijegan.openai.azure.com";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(endpoint),
     new ApiKeyCredential(apiKey)
);

IChatClient AIChatClient = azureOpenAIClient.GetChatClient(deploymentName).AsIChatClient();
builder.Services.AddScoped<AzureAIService>(sp => new AzureAIService(AIChatClient));

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

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebAppAISample.Client._Imports).Assembly);

app.Run();
