using CA.Application.Common.Interfaces;
using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Persistence
{
    public class CompanyDbContext : DbContext, ICompanyDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public void SetConnectionString(string connectionString)
        {
            Database.GetDbConnection().ConnectionString = connectionString;
        }
    }
}
