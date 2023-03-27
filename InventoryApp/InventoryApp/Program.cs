using InventoryApp.Areas.Identity.Data;
using InventoryApp.ContextFactory;
using InventoryApp.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("InventoryAppContextConnection") ??
                               throw new InvalidOperationException(
                                   "Connection string 'InventoryAppContextConnection' not found.");

        builder.Services.AddDbContext<InventoryAppContext>(options => options.UseSqlite(connectionString));

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