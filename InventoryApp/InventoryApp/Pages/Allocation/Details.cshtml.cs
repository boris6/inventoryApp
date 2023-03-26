﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly InventoryApp.ContextFactory.RepositoryContext _context;

        public DetailsModel(InventoryApp.ContextFactory.RepositoryContext context)
        {
            _context = context;
        }

      public Model.Models.Allocation Allocation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Allocations == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocations.FirstOrDefaultAsync(m => m.AllocationID == id);
            if (allocation == null)
            {
                return NotFound();
            }
            else 
            {
                Allocation = allocation;
            }
            return Page();
        }
    }
}