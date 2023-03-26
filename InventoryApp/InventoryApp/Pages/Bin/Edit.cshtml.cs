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

namespace InventoryApp.Pages.Bin
{
    public class EditModel : PageModel
    {
        private readonly InventoryApp.ContextFactory.RepositoryContext _context;

        public EditModel(InventoryApp.ContextFactory.RepositoryContext context)
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

            var bin =  await _context.Bins.FirstOrDefaultAsync(m => m.BinID == id);
            if (bin == null)
            {
                return NotFound();
            }
            Bin = bin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bin).State = EntityState.Modified;
            _context.Entry(Bin).Property(e => e.CreatedDate).IsModified = false;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinExists(Bin.BinID))
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

        private bool BinExists(Guid id)
        {
          return (_context.Bins?.Any(e => e.BinID == id)).GetValueOrDefault();
        }
    }
}
