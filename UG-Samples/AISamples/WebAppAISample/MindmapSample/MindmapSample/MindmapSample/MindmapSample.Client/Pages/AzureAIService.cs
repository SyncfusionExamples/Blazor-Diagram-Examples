using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using System;


namespace AIService
{
    public class AzureAIService
    {
        private IChatClient _chatClient;

        public AzureAIService(IChatClient client)
        {
            this._chatClient = client ?? throw new ArgumentNullException(nameof(client));
        }


        /// <summary>
        /// Gets a text completion from the Azure OpenAI service.
        /// </summary>
        /// <param name="prompt">The user prompt to send to the AI service.</param>
        /// <param name="returnAsJson">Indicates whether the response should be returned in JSON format. Defaults to <c>true</c></param>
        /// <param name="systemRole">Specifies the systemRole that is sent to AI Clients. Defaults to <c>null</c></param>
        /// <returns>The AI-generated completion as a string.</returns>
        public async Task<string> GetCompletionAsync(string prompt, bool returnAsJson = true,  string systemRole = null, int outputTokens = 2000)
        {
            string systemMessage = returnAsJson ? "You are a helpful assistant that only returns and replies with valid, iterable RFC8259 compliant JSON in your responses unless I ask for any other format. Do not provide introductory words such as 'Here is your result' or '```json', etc. in the response" : !string.IsNullOrEmpty(systemRole) ? systemRole : "You are a helpful assistant";
            try
            {
                ChatParameters chatParameters = new ChatParameters();
                chatParameters.Messages = new List<ChatMessage>(2) {
                    new ChatMessage (ChatRole.System, systemMessage),
                    new ChatMessage(ChatRole.User,prompt),
                };
                string completion = await GetChatResponseAsync(chatParameters);
                return completion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception has occurred: {ex.Message}");
                return "";
            }
        }

        public async Task<string> GetChatResponseAsync(ChatParameters options)
        {
            ChatOptions completionRequest = new ChatOptions
            {
                Temperature = options.Temperature ?? 0.5f,
                TopP = options.TopP ?? 1.0f,
                MaxOutputTokens = options.MaxTokens ?? 2000,
                FrequencyPenalty = options.FrequencyPenalty ?? 0.0f,
                PresencePenalty = options.PresencePenalty ?? 0.0f,
                StopSequences = options.StopSequences
            };
            try
            {
                ChatResponse completion = await _chatClient.GetResponseAsync(options.Messages, completionRequest);
                return completion.Text.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
