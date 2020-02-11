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
using EpsilonEnterprise;

namespace EpsilonEnterprise.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public EditModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var employeeToUpdate = await _context.Employee.FindAsync(id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "employee",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
