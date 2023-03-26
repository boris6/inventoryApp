using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventoryApp.ContextFactory;
using InventoryApp.Model.Models;

namespace InventoryApp.Pages.Allocation
{
    public class CreateModel : PageModel
    {
        private readonly InventoryApp.ContextFactory.RepositoryContext _context;

        public CreateModel(InventoryApp.ContextFactory.RepositoryContext context)
        {
            _context = context;
           
        }

        public IActionResult OnGet()
        {
            Bins = _context.Bins.Where(x => x.CreatedBy == User.Identity.Name).ToList();
            Products = _context.Products.Where(x => x.CreatedBy == User.Identity.Name).ToList();
            return Page();
        }

        [BindProperty]
        public Model.Models.Allocation Allocation { get; set; } = default!;
        public IList<Model.Models.Product> Products { get; set; } 
        public IList<Model.Models.Bin> Bins { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.ClearValidationState(nameof(Allocation));
            Allocation.CreatedBy = User.Identity.Name;
            if (!TryValidateModel(Allocation, nameof(Allocation ))) return Page();

            if (!ModelState.IsValid || _context.Allocations == null || Allocation == null) return Page();

            _context.Allocations.Add(Allocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
