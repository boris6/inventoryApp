using System.Security.Claims;
using InventoryApp.ContextFactory;
using InventoryApp.Pages.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Test;

public class IndexPageTest
{
    [Fact]
    public async Task OnPost_IfInvalidModel_ReturnBadRequest()
    {
        //arrange

        var contextBuilder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source=:memory:;");
        var context = new RepositoryContext(contextBuilder.Options);

        var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new(ClaimTypes.NameIdentifier, "SomeValueHere"),
            new Claim(ClaimTypes.Name, "gunnar@somecompany.com")
            // other required and custom claims
        }, "TestAuthentication"));

        var pageModel = new CreateModel(context);
        pageModel.User.AddIdentity(new ClaimsIdentity(new[]
        {
            new(ClaimTypes.NameIdentifier, "SomeValueHere"),
            new Claim(ClaimTypes.Name, "gunnar@somecompany.com")
            // other required and custom claims
        }));

        //
        var result = await pageModel.OnPostAsync();

        //assert
        Assert.IsType<PageResult>(result);
    }
}