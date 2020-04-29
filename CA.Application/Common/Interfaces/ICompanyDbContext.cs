using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Common.Interfaces
{
    public interface ICompanyDbContext
    {
        DbSet<Employee> Employees { get; set; }

        void SetConnectionString(string connectionString);
    }
}
