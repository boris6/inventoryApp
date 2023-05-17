using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Allocation;

public class DeleteModel : PageModel
{
    private readonly RepositoryContext _context;

    public DeleteModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Allocation Allocation { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Allocations == null) return NotFound();

        var allocation = await _context.Allocations.FirstOrDefaultAsync(m => m.AllocationID == id);

        if (allocation == null)
            return NotFound();
        Allocation = allocation;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null || _context.Allocations == null) return NotFound();
        var allocation = await _context.Allocations.FindAsync(id);

        if (allocation != null)
        {
            Allocation = allocation;
            _context.Allocations.Remove(Allocation);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}