using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoDotnet.Models;

namespace DemoDotnet.Data
{
    public class DemoDotnetContext : DbContext
    {
        public DemoDotnetContext(DbContextOptions<DemoDotnetContext> options)
            : base(options)
        {
            Database.Migrate(); // Run migrations when the application starts
        }

        public DbSet<DemoDotnet.Models.Country> Country { get; set; } = default!;
    }
}
