using Domain.Entities;
using System.Text.Json;

namespace Blazor.Helpers
{
    public class ApiCalls
    {
        private HttpClient httpClient { get; set; }
        public ApiCalls()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7249/api/");
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Get,
            };
            var result = await httpClient.GetAsync("todo/getItems");
            var json = await result.Content.ReadAsStringAsync();
            List<TodoItem> todoItems = JsonSerializer.Deserialize<List<TodoItem>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ;
            return todoItems;
        }

    }
}
