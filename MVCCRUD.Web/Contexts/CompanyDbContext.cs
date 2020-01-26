using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCRUD.Data.Contexts
{
    public class CompanyDbContext: DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> dbContextOptions): base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}
