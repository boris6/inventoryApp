using InventoryApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlite(configuration.GetConnectionString("sqlConnection")));
    }
}