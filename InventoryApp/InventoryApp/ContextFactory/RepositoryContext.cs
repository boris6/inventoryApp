using InventoryApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.ContextFactory;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source = Application.db; Cache = Shared");
    }
}