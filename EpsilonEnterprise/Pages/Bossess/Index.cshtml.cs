using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;
using EpsilonEnterprise.Models.EnterpriseViewModels;

namespace EpsilonEnterprise.Pages.Bosss
{
    public class IndexModel : PageModel
    {
        private readonly EpsilonEnterprise.Data.BusinessContext _context;

        public IndexModel(EpsilonEnterprise.Data.BusinessContext context)
        {
            _context = context;
        }
        public BossIndexData Boss { get; set; }
        public int BossID { get; set; }
        public int AssignmentID { get; set; }

        public async Task OnGetAsync(int? id, int? assignmentID)
        {
            Boss = new BossIndexData();
            Boss.Boss = await _context.Boss
                .Include(i => i.OfficeAssignment)
                .Include(i => i.AssignmentAssignments)
                    .ThenInclude(i => i.Assignment)
                        .ThenInclude(i => i.Department)
                .Include(i => i.AssignmentAssignments)
                    .ThenInclude(i => i.Assignment)
                        .ThenInclude(i => i.Enrollments)
                            .ThenInclude(i => i.Employee)
                .AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if (id != null)
            {
                BossID = id.Value;
                Boss boss = Boss.Boss
                    .Where(i => i.ID == id.Value).Single();
                Boss.Assignments = boss.AssignmentAssignments.Select(s => s.Assignment);
            }

            if (assignmentID != null)
            {
                AssignmentID = assignmentID.Value;
                var selectedCourse = Boss.Assignments
                    .Where(x => x.AssignmentID == assignmentID).Single();
                await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Employee).LoadAsync();
                }
                Boss.Enrollments = selectedCourse.Enrollments;
            }
        }
    }
}
