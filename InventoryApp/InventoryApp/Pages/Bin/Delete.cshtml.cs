using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryApp.ContextFactory;
using InventoryApp.Model.Models;

namespace InventoryApp.Pages.Bin
{
    public class DeleteModel : PageModel
    {
        private readonly InventoryApp.ContextFactory.RepositoryContext _context;

        public DeleteModel(InventoryApp.ContextFactory.RepositoryContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Model.Models.Bin Bin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Bins == null)
            {
                return NotFound();
            }

            var bin = await _context.Bins.FirstOrDefaultAsync(m => m.BinID == id);

            if (bin == null)
            {
                return NotFound();
            }
            else 
            {
                Bin = bin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Bins == null)
            {
                return NotFound();
            }
            var bin = await _context.Bins.FindAsync(id);

            if (bin != null)
            {
                Bin = bin;
                _context.Bins.Remove(Bin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
