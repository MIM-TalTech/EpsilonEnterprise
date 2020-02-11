using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise.Pages.Bossess
{
    public class EditModel : BossAssignmentsPageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public EditModel(EpsilonEnterprise.Data.BusinessContext context)
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

            Bosses = await _context.Boss
                .Include(i => i.OfficeAssignment)
                .Include(i => i.AssignmentAssignments).ThenInclude(i => i.Assignment)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Bosses == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(_context, Bosses);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedAssignments)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bossToUpdate = await _context.Boss
                .Include(i => i.OfficeAssignment)
                .Include(i => i.AssignmentAssignments)
                    .ThenInclude(i => i.Assignment)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (bossToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Bosses>(
                bossToUpdate,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                if (String.IsNullOrWhiteSpace(
                    bossToUpdate.OfficeAssignment?.Location))
                {
                    bossToUpdate.OfficeAssignment = null;
                }
                UpdateBossAssignments(_context, selectedAssignments, bossToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateBossAssignments(_context, selectedAssignments, bossToUpdate);
            PopulateAssignedCourseData(_context, bossToUpdate);
            return Page();
        }
    }
}
