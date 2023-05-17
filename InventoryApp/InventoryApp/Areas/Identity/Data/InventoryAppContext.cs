using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Areas.Identity.Data;

public class InventoryAppContext : IdentityDbContext<InventoryAppUser>
{
    public InventoryAppContext(DbContextOptions<InventoryAppContext> options)
        : base(options)
    {
    }
}