using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;
    private readonly TodoService todoService;

    public TodoController(ILogger<TodoController> logger,TodoService todoService )
    {
        this.logger = logger;
        this.todoService = todoService;
    }
    [HttpGet("getItems")]
    [EnableCors]
    public List<TodoItem> GetTodoItems()
    {
        return todoService.GetTodoItems();
    }

    [HttpPost("newItem")]
    public void AddNewTodo(TodoItem item)
    {
        todoService.CreateNewTodo(item);
    }

    [HttpDelete("removeItem")]
    public void DeleteTodo([FromBody] string name)
    {
        todoService.RemoveTodo(name);
    }

}
