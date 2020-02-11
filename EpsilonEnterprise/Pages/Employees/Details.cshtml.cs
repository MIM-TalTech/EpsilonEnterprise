using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;
using EpsilonEnterprise;

namespace EpsilonEnterprise.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public DetailsModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Assignment)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
