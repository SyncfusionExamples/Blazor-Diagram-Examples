using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using AIService;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using System.ClientModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();
string apiKey = "c71665b4639d46a5917c4a15f33e57a4";
string deploymentName = "gpt-4o-mini";
string endpoint = "https://openaijegan.openai.azure.com";

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
