using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryApp.ContextFactory;
using InventoryApp.Model.Models;

namespace InventoryApp.Pages.Allocation
{
    public class EditModel : PageModel
    {
        private readonly InventoryApp.ContextFactory.RepositoryContext _context;

        public EditModel(InventoryApp.ContextFactory.RepositoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Models.Allocation Allocation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Allocations == null)
            {
                return NotFound();
            }

            var allocation =  await _context.Allocations.FirstOrDefaultAsync(m => m.AllocationID == id);
            if (allocation == null)
            {
                return NotFound();
            }
            Allocation = allocation;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Allocation.CreatedBy = User.Identity.Name;
            ModelState.ClearValidationState(nameof(Allocation));

            if (!TryValidateModel(Allocation, nameof(Allocation)))
            {
                return Page();
            }

            _context.Attach(Allocation).State = EntityState.Modified;
            _context.Entry(Allocation).Property(e => e.BinID).IsModified = false;
            _context.Entry(Allocation).Property(e => e.ProductID).IsModified = false;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocationExists(Allocation.AllocationID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AllocationExists(Guid id)
        {
          return (_context.Allocations?.Any(e => e.AllocationID == id)).GetValueOrDefault();
        }
    }
}
