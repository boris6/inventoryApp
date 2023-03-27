using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryApp.Pages.Allocation;

public class CreateModel : PageModel
{
    private readonly RepositoryContext _context;

    public CreateModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Allocation Allocation { get; set; } = default!;

    public IList<Model.Models.Product> Products { get; set; }
    public IList<Model.Models.Bin> Bins { get; set; }

    public IActionResult OnGet()
    {
        Bins = _context.Bins.Where(x => x.CreatedBy == User.Identity.Name).ToList();
        Products = _context.Products.Where(x => x.CreatedBy == User.Identity.Name).ToList();
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.ClearValidationState(nameof(Allocation));
        Allocation.CreatedBy = User.Identity.Name;
        if (!TryValidateModel(Allocation, nameof(Allocation))) return Page();

        if (!ModelState.IsValid || _context.Allocations == null || Allocation == null) return Page();

        _context.Allocations.Add(Allocation);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}