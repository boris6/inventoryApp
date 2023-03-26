using InventoryApp.ContextFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryApp.Pages.Bin;

public class CreateModel : PageModel
{
    private readonly RepositoryContext _context;

    public CreateModel(RepositoryContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Models.Bin Bin { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        Bin.CreatedDate = DateTime.Now;
        if (!ModelState.IsValid || _context.Bins == null || Bin == null) return Page();

        _context.Bins.Add(Bin);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}