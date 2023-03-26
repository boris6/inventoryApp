using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Product;

public class IndexModel : PageModel
{
    private readonly RepositoryContext _context;

    public IndexModel(RepositoryContext context)
    {
        _context = context;
    }

    public IList<Model.Models.Product> Product { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Products != null)
            Product = await _context.Products.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
    }
}