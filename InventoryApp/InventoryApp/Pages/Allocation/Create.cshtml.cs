using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        if (!IsBinCapacityOk())
        {
            Bins = await _context.Bins.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
            Products = await _context.Products.Where(x => x.CreatedBy == User.Identity.Name).ToListAsync();
            ModelState.AddModelError("ExceedCapacity", "Bin exceed it's capacity!");
            return Page();
        }

        _context.Allocations.Add(Allocation);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private bool IsBinCapacityOk()
    {
        var bin = _context.Bins.First(x => x.BinID == Allocation.BinID);
        var product = _context.Products.First(x => x.ProductID == Allocation.ProductID);
        var sumOfAllocations = _context.Allocations.Where(x => x.BinID == Allocation.BinID)
            .Sum(x => (double)(x.Quantity * x.Product.Weight));
        var sumOfAllocationsIncludingThis = sumOfAllocations + (double)(Allocation.Quantity * product.Weight);

        if (bin.MaximumCapacity < (decimal)sumOfAllocationsIncludingThis)
            return false;

        return true;
    }
}