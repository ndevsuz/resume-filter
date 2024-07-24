using System.Text;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Completions;

namespace Resume_Filter.Application.Helpers;

public static class GPTHelper
{
    private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";
        private static string apiKey = "sk-proj-WUs93ruktNWCh48HLVvjT3BlbkFJjkYsd8RuvauTSsBGSBLX";
    
    public async static Task<string> SendRequest(string request)
    {
        var openai = new OpenAIAPI(apiKey);

        var completionRequest = new CompletionRequest
        {
            Model = "gpt-3.5-turbo",
            Prompt = request,
            MaxTokens = 50
        };

        var completionResult = await openai.Completions.CreateCompletionAsync(completionRequest);
        return completionResult.Completions[0].Text;    
    }
}