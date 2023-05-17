using InventoryApp.Areas.Identity.Data;
using InventoryApp.ContextFactory;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Extensions;

public static class DbExtensions
{
    public static void EnsureDbCreated(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var repositoryContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        repositoryContext.Database.Migrate();
        var inventoryAppContext = scope.ServiceProvider.GetRequiredService<InventoryAppContext>();
        inventoryAppContext.Database.Migrate();
    }
}