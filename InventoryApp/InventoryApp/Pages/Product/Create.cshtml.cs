// This method is called when the user submits the form. The user can only submit the form if the model is valid, which is determined by ModelState.IsValid. The method adds the product to the database and saves the changes. Then it redirects the user to the Index page.

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