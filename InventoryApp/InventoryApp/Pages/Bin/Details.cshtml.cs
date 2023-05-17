using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Bin;

public class DetailsModel : PageModel
{
    private readonly RepositoryContext _context;

    public decimal CurrentAllocation;

    public DetailsModel(RepositoryContext context)
    {
        _context = context;
    }

    public Model.Models.Bin Bin { get; set; } = default!;
    public IList<Model.Models.Allocation> Allocations { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Bins == null) return NotFound();

        var bin = await _context.Bins.FirstOrDefaultAsync(m => m.BinID == id);
        if (bin == null)
            return NotFound();
        var allocations = await _context.Allocations.Where(x => x.BinID == bin.BinID).Include(x => x.Product)
            .ToListAsync();
        Bin = bin;
        Allocations = allocations;
        CurrentAllocation = Allocations.Sum(x => x.Quantity * x.Product.Weight);
        return Page();
    }
}