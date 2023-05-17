using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Product;

public class DetailsModel : PageModel
{
    private readonly RepositoryContext _context;

    public DetailsModel(RepositoryContext context)
    {
        _context = context;
    }

    public Model.Models.Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Products == null) return NotFound();

        var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);
        if (product == null)
            return NotFound();
        Product = product;
        return Page();
    }
}