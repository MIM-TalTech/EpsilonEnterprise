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
    public class DetailsModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public DetailsModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

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
    }
}
