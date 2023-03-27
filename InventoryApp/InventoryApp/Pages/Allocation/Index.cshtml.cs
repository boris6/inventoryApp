using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Allocation;

public class IndexModel : PageModel
{
    private readonly RepositoryContext _context;

    public IndexModel(RepositoryContext context)
    {
        _context = context;
    }

    public IList<Model.Models.Allocation> Allocations { get; set; } = default!;
    public IList<Model.Models.Product> Products { get; set; } = default!;
    public IList<Model.Models.Bin> Bins { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Allocations != null)
        {
            Allocations = await _context.Allocations.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
            Bins = await _context.Bins.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
            Products = await _context.Products.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
        }
    }
}