using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Bin;

public class DeleteModel : PageModel
{
    private readonly RepositoryContext _context;

    public DeleteModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Bin Bin { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Bins == null) return NotFound();

        var bin = await _context.Bins.FirstOrDefaultAsync(m => m.BinID == id);

        if (bin == null)
            return NotFound();
        Bin = bin;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null || _context.Bins == null) return NotFound();
        var bin = await _context.Bins.FindAsync(id);

        if (bin != null)
        {
            Bin = bin;
            _context.Bins.Remove(Bin);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}