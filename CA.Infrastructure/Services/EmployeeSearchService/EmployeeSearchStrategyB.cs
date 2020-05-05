using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using System.Linq;

namespace CA.Infrastructure.Services.EmployeeSearchService
{
    public class EmployeeSearchStrategyB : IEmployeeSearchStrategy
    {
        public IQueryable<Employee> Run(IQueryable<Employee> employees)
        {
            return employees.Where(x => x.Name.ToUpper().StartsWith("A"));
        }
    }
}
