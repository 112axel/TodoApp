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
}