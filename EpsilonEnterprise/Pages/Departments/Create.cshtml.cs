using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise
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
        ViewData["BossID"] = new SelectList(_context.Boss, "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
