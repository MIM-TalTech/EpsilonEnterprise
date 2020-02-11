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
    public class IndexModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public IndexModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignments { get;set; }

        public async Task OnGetAsync()
        {
            Assignments = await _context.Assignments
                .Include(a => a.Department).AsNoTracking().ToListAsync();
        }
    }
}
