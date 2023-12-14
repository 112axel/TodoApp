using Domain.Entities;
using Services;
namespace Tests;

public class TodoServiceTesting
{
    [Fact]
    public void RequestFromNewDBShouldBeOneSeededValue()
    {
        //Arange
        var db = new FakeDataBase();

        //act

        var result = db.TodoItems;

        //assert
        Assert.NotNull(result);

        Assert.Single(result);

        Assert.Equal("make food",result[0].Title );
        Assert.Equal("make meatballs",result[0].Description );
    }

    [Fact]
    public void CreateNewTodoReturnsSameValue()
    {
        //arrange
        var db = new FakeDataBase();
        var todoService = new TodoService(db);

        //act
        var result = todoService.CreateNewTodo(new TodoItem("dishwasher", "empty dishwasher"));

        //assert
        Assert.Equal("dishwasher", result.Title);
        Assert.Equal("empty dishwasher", result.Description);

    }

    [Fact]
    public void CreateNewTodoListIsLongerAfterCreate()
    {
        //arrange
        var db = new FakeDataBase();
        var todoService = new TodoService(db);

        //act
        var result = todoService.CreateNewTodo(new TodoItem("dishwasher", "empty dishwasher"));

        Assert.Equal(2, db.TodoItems.Count);
    }
}