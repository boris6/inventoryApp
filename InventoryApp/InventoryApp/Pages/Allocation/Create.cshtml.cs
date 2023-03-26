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
            return Page();
        }

        [BindProperty]
        public Model.Models.Allocation Allocation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Allocations == null || Allocation == null)
            {
                return Page();
            }

            _context.Allocations.Add(Allocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
