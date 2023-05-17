using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
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

    [BindProperty(SupportsGet = true)] public string? SearchString { get; set; }

    public async Task OnGetAsync()
    {
        var allocations = _context.Allocations.Where(x => User.Identity != null && x.CreatedBy == User.Identity.Name);
        if (!string.IsNullOrEmpty(SearchString))
            allocations = allocations.Where(x =>
                x.Product.Code.Contains(SearchString) || x.Bin.Name.Contains(SearchString));
        Allocations = await allocations.Include(x => x.Bin).Include(x => x.Product).ToListAsync();
    }
}