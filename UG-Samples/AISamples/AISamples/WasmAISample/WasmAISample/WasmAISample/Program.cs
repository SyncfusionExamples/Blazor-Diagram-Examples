using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.AI;
using WasmAISample;
using Syncfusion.Blazor;
using System.ClientModel;
using AIService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();
string azureOpenAIKey = "c71665b4639d46a5917c4a15f33e57a4";
string azureOpenAIEndpoint = "https://openaijegan.openai.azure.com";
string azureOpenAIModel = "gpt-4o-mini";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAIEndpoint),
     new ApiKeyCredential(azureOpenAIKey)
);

IChatClient AIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddScoped<AzureAIService>(sp =>
{
    return new AzureAIService(AIChatClient);
});
await builder.Build().RunAsync();
