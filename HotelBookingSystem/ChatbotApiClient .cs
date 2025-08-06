using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    
    public class ChatbotApiClient
    {
        private readonly HttpClient _httpClient;

        public ChatbotApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ChatbotApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7034/")
            };
        }
        public class ChatbotResponse
        {
            public string Status { get; set; }
            public string ChatResponse { get; set; }
        }

        public async Task<string> AskAsync(string userQuestion)
        {
            var response = await _httpClient.PostAsJsonAsync("api/chatbot/ask", userQuestion);
            if (!response.IsSuccessStatusCode)
            {
                return "Error: Failed to get response from chatbot.";
            }

            var result = await response.Content.ReadFromJsonAsync<ChatbotResponse>();
            return result?.ChatResponse ?? "Error: No reply from chatbot. Try another query.";
        }
    }
}
