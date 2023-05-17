using InventoryApp.Areas.Identity.Data;
using InventoryApp.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Get Connection String from appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("InventoryAppContextConnection") ??
                               throw new InvalidOperationException(
                                   "Connection string 'InventoryAppContextConnection' not found.");

        // Add DbContext to DI
        builder.Services.AddDbContext<InventoryAppContext>(options => options.UseSqlite(connectionString));

        // Add Identity User to DI
        builder.Services.AddDefaultIdentity<InventoryAppUser>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        }).AddEntityFrameworkStores<InventoryAppContext>();

        // Add services to the container.
        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.AuthorizeFolder("/");
            options.Conventions.AllowAnonymousToPage("/Privacy");
        });
        builder.Services.ConfigureSqlContext(builder.Configuration);

        var app = builder.Build();

        // Ensure Database is created
        app.EnsureDbCreated();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error");
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}