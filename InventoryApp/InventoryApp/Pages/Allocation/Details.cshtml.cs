using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Allocation;

public class DetailsModel : PageModel
{
    private readonly RepositoryContext _context;

    public DetailsModel(RepositoryContext context)
    {
        _context = context;
    }

    public Model.Models.Allocation Allocation { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Allocations == null) return NotFound();

        var allocation = await _context.Allocations.FirstOrDefaultAsync(m => m.AllocationID == id);
        if (allocation == null)
            return NotFound();
        Allocation = allocation;
        return Page();
    }
}