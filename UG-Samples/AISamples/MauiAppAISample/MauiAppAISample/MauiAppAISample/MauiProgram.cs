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

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
