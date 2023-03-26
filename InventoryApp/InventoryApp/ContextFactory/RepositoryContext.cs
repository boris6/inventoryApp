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

    public DbSet<Bin> Bins { get; set; }

    public DbSet<Allocation> Allocations { get; set; }

    public DbSet<Allocation> Allocation { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source = Application.db; Cache = Shared");
    }
}