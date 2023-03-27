using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryApp.Pages.Product;

public class CreateModel : PageModel
{
    private readonly RepositoryContext _context;

    public CreateModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Product Product { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        Product.CreatedBy = User.Identity.Name;
        ModelState.ClearValidationState(nameof(Product));
        if (!TryValidateModel(Product, nameof(Product))) return Page();
        if (!ModelState.IsValid || _context.Products == null || Product == null) return Page();

        _context.Products.Add(Product);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}