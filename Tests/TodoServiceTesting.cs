using Domain.Entities;
using Services;
using System.Security.Cryptography.X509Certificates;
namespace Tests;

public class TodoServiceTesting
{
    private FakeDataBase fakeDataBase { get; set; }
    private TodoService todoService { get; set; }
    public TodoServiceTesting()
    {
        fakeDataBase = new FakeDataBase();
        todoService = new TodoService(fakeDataBase);
    }


    [Fact]
    public void RequestFromNewDBShouldBeOneSeededValue()
    {
        //act

        var result = todoService.GetTodoItems();

        //assert
        Assert.NotNull(result);

        Assert.Single(result);

        Assert.Equal("make food",result[0].Title );
        Assert.Equal("make meatballs",result[0].Description );
    }

    [Fact]
    public void CreateNewTodoReturnsSameValue()
    {
        //act
        var result = todoService.CreateNewTodo(new TodoItem("dishwasher", "empty dishwasher"));

        //assert
        Assert.Equal("dishwasher", result.Title);
        Assert.Equal("empty dishwasher", result.Description);

    }

    [Fact]
    public void CreateNewTodoListIsLongerAfterCreate()
    {
        //act
        var result = todoService.CreateNewTodo(new TodoItem("dishwasher", "empty dishwasher"));

        Assert.Equal(2, fakeDataBase.TodoItems.Count);
    }
}