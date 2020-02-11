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

namespace EpsilonEnterprise.Pages.Assignmentss
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public EditModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignments
                .Include(a => a.Department).FirstOrDefaultAsync(m => m.AssignmentID == id);

            if (Assignment == null)
            {
                return NotFound();
            }
            // Select current DepartmentID.
            PopulateDepartmentsDropDownList(_context, Assignment.DepartmentID);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignmentToUpdate = await _context.Assignments.FindAsync(id);

            if (assignmentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Assignment>(
                 assignmentToUpdate,
                 "course",   // Prefix for form value.
                   c => c.Credits, c => c.DepartmentID, c => c.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, assignmentToUpdate.DepartmentID);
            return Page();
           
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentID == id);
        }
    }
}
