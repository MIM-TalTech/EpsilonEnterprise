using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;
using EpsilonEnterprise;

namespace EpsilonEnterprise.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public CreateModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyEmployee = new Employee();

            if (await TryUpdateModelAsync<Employee>(
                emptyEmployee,
                "employee",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Employee.Add(emptyEmployee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
