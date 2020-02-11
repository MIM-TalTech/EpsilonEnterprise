using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpsilonEnterprise.Models
{
    public class AssignmentAssignment
    {
        public int BossID { get; set; }
        public int AssignmentID { get; set; }
        public Bosses Boss { get; set; }
        public Assignment Assignment { get; set; }

        internal IEnumerable<Assignment> Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public static implicit operator AssignmentAssignment(List<AssignmentAssignment> v)
        {
            throw new NotImplementedException();
        }

        internal void Add(AssignmentAssignment assignmentAssignment)
        {
            throw new NotImplementedException();
        }

        internal AssignmentAssignment SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
