using SequenceDiagramSample.Components;
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

string apiKey = "AZURE_OPENAI_KEY";
string deploymentName = "AZURE_OPENAI_MODEL";
string endpoint = "AZURE_OPENAI_ENDPOINT";

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
    .AddAdditionalAssemblies(typeof(SequenceDiagramSample.Client._Imports).Assembly);

app.Run();
