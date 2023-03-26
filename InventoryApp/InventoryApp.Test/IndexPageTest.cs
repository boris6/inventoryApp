using System.Security.Claims;
using InventoryApp.ContextFactory;
using InventoryApp.Pages.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using IndexModel = InventoryApp.Pages.IndexModel;

namespace InventoryApp.Test;

public class IndexPageTest
{
    [Fact]
    public async Task OnPost_IfInvalidModel_ReturnBadRequest()
    {
        //arrange

        var contextBuilder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source=:memory:;");
        var context = new RepositoryContext(contextBuilder.Options);

        var pageModel = new CreateModel(context);


        //
        var result = await pageModel.OnPostAsync();

        //assert
        Assert.IsType<PageResult>(result);
    }
}