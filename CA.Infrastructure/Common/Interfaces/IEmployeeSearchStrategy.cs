using CA.Domain;
using System.Linq;

namespace CA.Infrastructure.Common.Interfaces
{
    public interface IEmployeeSearchStrategy
    {
        IQueryable<Employee> Run(IQueryable<Employee> employees);
    }
}
