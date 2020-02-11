using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise.Pages.Assignmentss
{
    public class DetailsModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public DetailsModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        public Assignment Assignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignments.AsNoTracking()
                .Include(a => a.Department).FirstOrDefaultAsync(m => m.AssignmentID == id);

            if (Assignment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
