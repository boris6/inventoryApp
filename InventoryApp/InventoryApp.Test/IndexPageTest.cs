using InventoryApp.ContextFactory;
using InventoryApp.Pages.Product;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Test;

public class IndexPageTest
{
    [Fact]
    public async Task OnPost_ThrowsException_WhenNoUser()
    {
        //arrange

        var contextBuilder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source=:memory:;");
        var context = new RepositoryContext(contextBuilder.Options);

        var pageModel = new CreateModel(context);


        //act and assert
        await Assert.ThrowsAsync<NullReferenceException>(async () => await pageModel.OnPostAsync());
    }
}