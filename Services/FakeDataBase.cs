using Domain;
using Domain.Entities;
namespace Services
{
    public class FakeDataBase
    {
        public List<TodoItem> TodoItems { get; set; } = new() { new TodoItem("make food","make meatballs")  };

    }
}
