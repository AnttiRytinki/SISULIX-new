namespace SISULIX
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    class ChatGPTClient
    {
        private static readonly HttpClient client = new HttpClient();
        private const string apiKey = "";

        public async Task<string> AskChatGPT(string input)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
            new { role = "user", content = input }
        }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            try
            {
                using var doc = JsonDocument.Parse(responseString);

                if (doc.RootElement.TryGetProperty("choices", out JsonElement choices))
                {
                    var message = choices[0].GetProperty("message").GetProperty("content");
                    return message.GetString()!.Trim();
                }
                else if (doc.RootElement.TryGetProperty("error", out JsonElement error))
                {
                    //string errorMessage = error.GetProperty("message").GetString();
                    string errorMessage = error.GetProperty("message").GetString() ?? "Default error message";

                    return "[API Error] " + errorMessage;
                }
                else
                {
                    return "[Okänt svar från API]";
                }
            }
            catch (Exception ex)
            {
                return "[JSON Fel] " + ex.Message + "\nSvar:\n" + responseString;
            }
        }

    }
}
