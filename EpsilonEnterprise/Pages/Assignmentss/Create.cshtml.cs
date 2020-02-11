using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise.Pages.Assignmentss
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly BusinessContext _context;

        public CreateModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
       
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCourse = new Assignment();

            if (await TryUpdateModelAsync<Assignment>(
                 emptyCourse,
                 "course",   // Prefix for form value.
                 s => s.AssignmentID, s => s.DepartmentID, s => s.Title, s => s.Credits))
            {
                _context.Assignments.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
    }
}
