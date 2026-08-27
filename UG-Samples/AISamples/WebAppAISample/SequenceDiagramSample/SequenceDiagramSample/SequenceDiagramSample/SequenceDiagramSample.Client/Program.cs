using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using AIService;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using System.ClientModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

string apiKey = "AZURE_OPENAI_KEY";
string deploymentName = "AZURE_OPENAI_MODEL";
string endpoint = "AZURE_OPENAI_ENDPOINT";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(endpoint),
     new ApiKeyCredential(apiKey)
);

IChatClient AIChatClient = azureOpenAIClient.GetChatClient(deploymentName).AsIChatClient();
builder.Services.AddScoped<AzureAIService>(sp =>
{
    return new AzureAIService(AIChatClient);
});

await builder.Build().RunAsync();
