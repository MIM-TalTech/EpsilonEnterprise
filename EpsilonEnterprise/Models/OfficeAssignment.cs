using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EpsilonEnterprise.Models
{
    public class OfficeAssignment
    {

        [Key]
        public int BossID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Boss Boss { get; set; }
    }
}
