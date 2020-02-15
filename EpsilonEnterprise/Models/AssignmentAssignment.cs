using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpsilonEnterprise.Models
{
    public class AssignmentAssignment
    {
        public int BossID { get; set; }
        public int AssignmentID { get; set; }
        public Boss Boss { get; set; }
        public Assignment Assignment { get; set; }


    }
}
