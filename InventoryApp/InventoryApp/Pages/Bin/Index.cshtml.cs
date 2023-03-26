using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Bin;

public class IndexModel : PageModel
{
    private readonly RepositoryContext _context;

    public IndexModel(RepositoryContext context)
    {
        _context = context;
    }

    public IList<Model.Models.Bin> Bin { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Bins != null)
            Bin = await _context.Bins.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
    }
}