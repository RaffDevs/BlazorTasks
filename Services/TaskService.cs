using System.Net.Http.Json;
using Task = TarefasBlazor.Models.Task;

namespace TarefasBlazor.Services;

public class TaskService
{
    private readonly HttpClient _httpClient;

    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Task>> GetTasks()
    {
        var request = 
            await _httpClient.GetAsync("https://raw.githubusercontent.com/RaffDevs/MyMocks/main/tasks.json");

        if (!request.IsSuccessStatusCode) throw new HttpRequestException();
        
        var response = await request.Content.ReadFromJsonAsync<IEnumerable<Task>>();
        return response;

    }
}