using Microsoft.AspNetCore.Components;
using TarefasBlazor.Services;
using TaskModel = TarefasBlazor.Models.Task;

namespace TarefasBlazor.Pages;

public class HomeBase : ComponentBase
{
    [Inject]
    private TaskService _taskService { get; set; }
    protected List<TaskModel> _tasks = [];
    protected bool _loading = true;
    protected bool _hasErrors = false;
    protected string? _description = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var data = await _taskService.GetTasks();
        _tasks = data.ToList();
        _loading = false;
    }

    protected void AddTask()
    {
        if (String.IsNullOrEmpty(_description))
        {
            _hasErrors = true;
            return;
        }

        var task = new TaskModel
        {
            Id = Guid.NewGuid(),
            Description = _description,
            CreatedAt = DateTime.Now,
            Done = false
        };

        _tasks.Add(task);
        _description = string.Empty;
        _hasErrors = false;
    }
    
    protected void DeletaTarefa(TaskModel task)
    {
        _tasks.Remove(task);
    }
}