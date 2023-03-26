using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Bin;

public class EditModel : PageModel
{
    private readonly RepositoryContext _context;

    public EditModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Bin Bin { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Bins == null) return NotFound();

        var bin = await _context.Bins.FirstOrDefaultAsync(m => m.BinID == id);
        if (bin == null) return NotFound();
        Bin = bin;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        Bin.CreatedBy = User.Identity.Name;

        ModelState.ClearValidationState(nameof(Bin));
        if (!TryValidateModel(Bin, nameof(Bin))) return Page();

        _context.Attach(Bin).State = EntityState.Modified;
        _context.Entry(Bin).Property(e => e.CreatedDate).IsModified = false;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BinExists(Bin.BinID))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool BinExists(Guid id)
    {
        return (_context.Bins?.Any(e => e.BinID == id)).GetValueOrDefault();
    }
}