using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models.EnterpriseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EpsilonEnterprise.Pages
{
    public class AboutModel : PageModel
    {
        private readonly BusinessContext _context;

        public AboutModel(BusinessContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Employees { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Employees
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    EmployeeCount = dateGroup.Count()
                };

            Employees = await data.AsNoTracking().ToListAsync();
        }
    }
}
