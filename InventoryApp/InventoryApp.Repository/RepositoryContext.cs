using InventoryApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Product>? Products { get; set; }
}