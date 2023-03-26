using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryApp.ContextFactory;
using InventoryApp.Model.Models;

namespace InventoryApp.Pages.Allocation
{
    public class IndexModel : PageModel
    {
        private readonly InventoryApp.ContextFactory.RepositoryContext _context;

        public IndexModel(InventoryApp.ContextFactory.RepositoryContext context)
        {
            _context = context;
        }

        public IList<Model.Models.Allocation> Allocation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Allocations != null)
            {
                Allocation = await _context.Allocations.ToListAsync();
            }
        }
    }
}
