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

        public async Task NewTodo(TodoItem item)
        {
            var content = new StringContent(JsonSerializer.Serialize(item),System.Text.Encoding.UTF8,"application/json");
            var result = httpClient.PostAsync("todo/newItem",content);

        }
        
        public async Task RemoveTodo(string name)
        {
            var content = new StringContent(JsonSerializer.Serialize(name),System.Text.Encoding.UTF8,"application/json");
            HttpRequestMessage httpRequest = new()
            {
                Method = HttpMethod.Delete,
                Content = content,
                RequestUri = new Uri("https://localhost:7249/api/todo/removeItem")
            };
            var result = httpClient.SendAsync(httpRequest);
        }
    }
}
