using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise.Pages.Bossess

{
    public class DeleteModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public DeleteModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bosses Bosses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bosses = await _context.Boss.FirstOrDefaultAsync(m => m.ID == id);

            if (Bosses == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bosses = await _context.Boss.FindAsync(id);
            Bosses instructor = await _context.Boss
                .Include(i => i.AssignmentAssignments)
                .SingleAsync(i => i.ID == id);

            if (instructor == null)
            {
                return RedirectToPage("./Index");
            }

            var departments = await _context.Departments
                .Where(d => d.BossID == id)
                .ToListAsync();
            departments.ForEach(d => d.BossID = null);

            _context.Boss.Remove(instructor);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
