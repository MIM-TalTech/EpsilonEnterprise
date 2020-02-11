using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise.Data
{
    public class EpsilonEnterpriseContext : DbContext
    {
        public EpsilonEnterpriseContext (DbContextOptions<EpsilonEnterpriseContext> options)
            : base(options)
        {
        }

        public DbSet<EpsilonEnterprise.Models.Assignment> Assignment { get; set; }
    }
}
