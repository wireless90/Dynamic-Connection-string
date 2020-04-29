using CA.Application.Common.Interfaces;
using CA.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CA.Persistence
{
    public class CompanyDbContext : DbContext, ICompanyDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DatabaseFacade DatabaseFacade { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            DatabaseFacade = Database;
            
        }

    }
}
