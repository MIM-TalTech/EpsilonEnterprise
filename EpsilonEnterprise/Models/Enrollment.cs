using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpsilonEnterprise.Models
{
 
        public enum Pay
        {
            A, B, C, D, F
        }

        public class Enrollment
        {
            public int EnrollmentID { get; set; }
            public int AssignmentID { get; set; }
            public int EmployeeID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
            public Pay? Pay { get; set; }
            
            public Assignment Assignment { get; set; }

            public Employee Employee { get; set; }
        }
    
}
