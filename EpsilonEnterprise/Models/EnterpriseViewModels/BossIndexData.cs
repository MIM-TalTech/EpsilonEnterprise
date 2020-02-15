using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpsilonEnterprise.Models.EnterpriseViewModels
{
    public class BossIndexData
    {
        public IEnumerable<Boss> Boss { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
       
    }
}
