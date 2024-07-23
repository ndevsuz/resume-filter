using System.Text;
using Newtonsoft.Json.Linq;

namespace Resume_Filter.Application.Helpers;

public static class GPTHelper
{
    
    private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";
    private static string apiKey = "";
    
    public async static Task<string> SendRequest(string request)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authori       zation", $"Bearer {apiKey}");

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = request }
                }
            };

            var content = new StringContent(JObject.FromObject(requestBody).ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
        
    }
}