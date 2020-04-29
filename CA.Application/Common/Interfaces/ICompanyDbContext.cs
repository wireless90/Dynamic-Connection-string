using CA.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CA.Application.Common.Interfaces
{
    public interface ICompanyDbContext
    {
        DbSet<Employee> Employees { get; set; }

        DatabaseFacade   DatabaseFacade { get; set; }
    }
}
