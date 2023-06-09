﻿using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Product;

public class EditModel : PageModel
{
    private readonly RepositoryContext _context;

    public EditModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Products == null) return NotFound();

        var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);
        if (product == null) return NotFound();
        Product = product;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        Product.CreatedBy = User.Identity.Name;
        ModelState.ClearValidationState(nameof(Product));
        if (!TryValidateModel(Product, nameof(Product))) return Page();

        _context.Attach(Product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(Product.ProductID))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ProductExists(Guid id)
    {
        return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
    }
}