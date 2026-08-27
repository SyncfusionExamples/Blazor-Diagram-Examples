using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using AIService;
using System.ClientModel;
namespace MauiAppAISample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSyncfusionBlazor();
            string azureOpenAIKey = "AZURE_OPENAI_KEY";
            string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
            string azureOpenAIModel = "AZURE_OPENAI_MODEL";

            AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
                 new Uri(azureOpenAIEndpoint),
                 new ApiKeyCredential(azureOpenAIKey)
            );

            IChatClient AIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
            builder.Services.AddScoped<AzureAIService>(sp =>
            {
                return new AzureAIService(AIChatClient);
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
