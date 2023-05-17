using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Product;

public class DeleteModel : PageModel
{
    private readonly RepositoryContext _context;

    public DeleteModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Products == null) return NotFound();

        var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);

        if (product == null)
            return NotFound();
        Product = product;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null || _context.Products == null) return NotFound();
        var product = await _context.Products.FindAsync(id);

        if (product != null)
        {
            Product = product;
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}