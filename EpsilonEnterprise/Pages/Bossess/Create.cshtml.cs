using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise.Pages.Bosss

{
    public class CreateModel : BossAssignmentsPageModel
    {
        private readonly BusinessContext _context;

        public CreateModel(BusinessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var instructor = new Boss();
            instructor.AssignmentAssignments = new List<AssignmentAssignment>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedCourseData(_context, instructor);
            return Page();
        }

        [BindProperty]
        public Boss Boss { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newInstructor = new Boss();
            if (selectedCourses != null)
            {
                newInstructor.AssignmentAssignments = new List<AssignmentAssignment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new AssignmentAssignment
                    {
                        AssignmentID = int.Parse(course)
                    };
                    newInstructor.AssignmentAssignments.Add(courseToAdd);
                }
            }

            if (await TryUpdateModelAsync<Boss>(
                newInstructor,
                "Boss",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                _context.Boss.Add(newInstructor);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCourseData(_context, newInstructor);
            return Page();
        }
    }
}
